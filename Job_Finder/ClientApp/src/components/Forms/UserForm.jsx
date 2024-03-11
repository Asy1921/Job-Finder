import React, { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import "./userForm.css  ";

const initialValues = {
  userId: "",
  isRecruiter: "",
  name: "",
  highestQualification: "",
  domain: "",
  yearsOfExperience: "",
  currentLocation: "",
  email: "",
  mobile: "",
};

// Replace with your API endpoint or logic to fetch domain and location options
const fetchDomainOptions = async () => {
  const response = await fetch("/api/domains"); // Replace with your API endpoint
  const data = await response.json();
  return data.map((option) => ({ value: option, label: option }));
};

const fetchLocationOptions = async () => {
  const response = await fetch("/api/locations"); // Replace with your API endpoint
  const data = await response.json();
  return data.map((option) => ({ value: option, label: option }));
};

const UserForm = () => {
  const [domainOptions, setDomainOptions] = useState([]);
  const [locationOptions, setLocationOptions] = useState([]);
  const [newDomainOption, setNewDomainOption] = useState("");
  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
  } = useForm({ defaultValues: initialValues });

  const handleDomainSubmit = (e) => {
    e.preventDefault();
    if (newDomainOption) {
      setDomainOptions([
        ...domainOptions,
        { value: newDomainOption, label: newDomainOption },
      ]);
      setNewDomainOption("");
    }
  };

  const onSubmit = (data) => {
    console.log(data);
    // Perform form submission logic here (e.g., send data to server)
  };

  const filteredDomainOptions = watch("domain", domainOptions); // Filter based on search term
  const filteredLocationOptions = watch("currentLocation", locationOptions); // Filter based on search term

  useEffect(() => {
    const fetchData = async () => {
      const domainData = await fetchDomainOptions();
      const locationData = await fetchLocationOptions();
      setDomainOptions(domainData);
      setLocationOptions(locationData);
    };
    fetchData();
  }, []);

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      {/* User ID */}
      <div>
        <label htmlFor="userId">User ID (Required, min. 6 chars):</label>
        <input
          {...register("userId", {
            required: "User ID is required.",
            minLength: {
              value: 6,
              message: "User ID must be at least 6 characters long.",
            },
          })}
          id="userId"
          type="text"
          placeholder="Enter User ID"
        />
        {errors.userId && (
          <span className="error">{errors.userId.message}</span>
        )}
      </div>

      {/* Is Recruiter */}
      <div>
        <label>Is Recruiter (Required):</label>
        <div>
          <input
            {...register("isRecruiter", {
              required: "Is Recruiter is required.",
            })}
            id="isRecruiterYes"
            type="radio"
            value="Yes"
          />
          <label htmlFor="isRecruiterYes">Yes</label>
          <input
            {...register("isRecruiter", {
              required: "Is Recruiter is required.",
            })}
            id="isRecruiterNo"
            type="radio"
            value="No"
          />
          <label htmlFor="isRecruiterNo">No</label>
        </div>
        {errors.isRecruiter && (
          <span className="error">{errors.isRecruiter.message}</span>
        )}
      </div>

      {/* Name */}
      <div>
        <label htmlFor="name">Name (Required):</label>
        <input
          {...register("name", { required: "Name is required." })}
          id="name"
          type="text"
          placeholder="Enter Name"
        />
        {errors.name && <span className="error">{errors.name.message}</span>}
      </div>

      {/* Highest Qualification */}
      <div>
        <label htmlFor="highestQualification">
          Highest Qualification (Optional):
        </label>
        <input
          {...register("highestQualification")}
          id="highestQualification"
          type="text"
          placeholder="Enter Highest Qualification"
        />
      </div>

      {/* Domain */}
      <div>
        <label htmlFor="domain">Domain (Required):</label>
        <select {...register("domain", { required: "Domain is required." })}>
          {/* {filteredDomainOptions.map((option) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))} */}
          <option value="">Add New...</option>
        </select>
        {errors.domain && (
          <span className="error">{errors.domain.message}</span>
        )}

        {/* Add new domain option */}
        <div>
          <input
            type="text"
            value={newDomainOption}
            onChange={(e) => setNewDomainOption(e.target.value)}
            placeholder="Enter New Domain"
          />
          <button type="button" onClick={handleDomainSubmit}>
            Add
          </button>
        </div>
      </div>

      <div>
        <label htmlFor="yearsOfExperience">
          Years of Experience (Required, Positive only):
        </label>
        <input
          {...register("yearsOfExperience", {
            required: "Years of Experience is required.",
            pattern: {
              value: /^[0-9]+<span class="math-inline">/,
              message: "Please enter a positive integer value.",
            },
          })}
          id="yearsOfExperience"
          type="number"
          min="0"
          placeholder="Enter Years of Experience"
        />
        {errors.yearsOfExperience && (
          <span className="error">{errors.yearsOfExperience.message}</span>
        )}
      </div>

      {/* Current Location */}
      <div>
        <label htmlFor="currentLocation">Current Location (Required):</label>
        <select
          {...register("currentLocation", {
            required: "Current Location is required.",
          })}
        >
          {/* {filteredLocationOptions.map((option) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))} */}
        </select>
        {errors.currentLocation && (
          <span className="error">{errors.currentLocation.message}</span>
        )}
      </div>

      {/* Email (unchanged) */}

      {/* ... (rest of the form fields) */}

      <button type="submit">Submit</button>
    </form>
  );
};

export default UserForm;
