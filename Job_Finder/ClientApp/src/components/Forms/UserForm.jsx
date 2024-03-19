import React, { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { Select, message } from "antd";
import "./userForm.css";
import axios from "axios";

const initialValues = {
  User_ID: "",
  IsHiring: "",
  Name: "",
  HighestQualification: "",
  Domain: "",
  YearsOfExperience: "",
  CurrentLocation: "",
  Email: "",
  Mobile: "",
};

// Replace with your API endpoint or logic to fetch domain and location options

const UserForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
  } = useForm({ defaultValues: initialValues });

  const [cities, setCities] = useState([]);

  // useEffect(() => {
  //   var headers = new Headers();
  //   headers.append("X-CSCAPI-KEY", "API_KEY");

  //   var requestOptions = {
  //     method: "GET",
  //     headers: headers,
  //     redirect: "follow",
  //   };
  //   fetch(
  //     "https://api.countrystatecity.in/v1/countries/IN/cities",
  //     requestOptions
  //   )
  //     .then((response) => response.json())
  //     .then((data) => {
  //       setCities(data.results.map((city) => city.city));
  //     });
  // }, []);

  const onSubmit = async (data) => {
    console.log(data);
    data.IsHiring = data.IsHiring === "true" ? true : false;
    await axios
      .post("/Home/AddUpdateUser", data)
      .then((item) => {
        message.success(item.data);
      })
      .catch((error) => {
        message.error("There was an issue while saving new job.");
      })
      .finally(() => {
        // setIsLoading(false);
      });

    // Perform form submission logic here (e.g., send data to server)
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="form-container">
      {/* User ID */}
      <div>
        <label htmlFor="User_ID">User ID (Required, min. 6 chars):</label>
        <input
          {...register("User_ID", {
            required: "User ID is required.",
            minLength: {
              value: 6,
              message: "User ID must be at least 6 characters long.",
            },
          })}
          id="User_ID"
          type="text"
          placeholder="Enter User ID"
        />
        {errors.User_ID && (
          <span className="error">{errors.User_ID.message}</span>
        )}
      </div>

      {/* Is Recruiter */}
      <div>
        <label>Is Recruiter (Required):</label>
        <select {...register("IsHiring")} id="IsHiring" type="text">
          <option value={true}>Yes</option>
          <option value={false}>No</option>
        </select>

        {errors.IsHiring && (
          <span className="error">{errors.IsHiring.message}</span>
        )}
      </div>

      {/* Name */}
      <div>
        <label htmlFor="Name">Name (Required):</label>
        <input
          {...register("Name", { required: "Name is required." })}
          id="Name"
          type="text"
          placeholder="Enter Name"
        />
        {errors.name && <span className="error">{errors.name.message}</span>}
      </div>

      {/* Highest Qualification */}
      <div>
        <label htmlFor="HighestQualification">
          Highest Qualification (Optional):
        </label>
        <input
          {...register("HighestQualification")}
          id="HighestQualification"
          type="text"
          placeholder="Enter Highest Qualification"
        />
      </div>

      {/* Domain */}
      <div>
        <label htmlFor="Domain">Domain (Required):</label>
        <input
          {...register("Domain", { required: true })}
          id="Domain"
          type="text"
          placeholder="Enter Domain"
        />
        {errors.Domain && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div>
        <label htmlFor="YearsOfExperience">
          Years of Experience (Required, Positive only):
        </label>
        <input
          {...register("YearsOfExperience", {
            required: "Years of Experience is required.",
            pattern: {
              value: /^[1-9][0-9]*$/,
              message: "Please enter a positive integer value.",
            },
          })}
          id="YearsOfExperience"
          type="number"
          min="0"
          placeholder="Enter Years of Experience"
        />
        {errors.YearsOfExperience && (
          <span className="error">{errors.YearsOfExperience.message}</span>
        )}
      </div>

      {/* Current Location */}
      <div>
        <label htmlFor="CurrentLocation">Current Location:</label>
        <Select
          {...register("CurrentLocation", {
            // required: "Current Location is required.",
          })}
          id="CurrentLocation"
          style={{ width: "100%" }}
          showSearch
          placeholder="Select Current Location"
          options={cities.map((city, index) => ({ value: city, label: city }))}
        ></Select>
        {/* {errors.currentLocation && (
          <span className="error">{errors.currentLocation.message}</span>
        )} */}
      </div>

      {/* Email */}
      <div>
        <label htmlFor="Email">Email (Required):</label>
        <input
          {...register("Email", { required: true })}
          id="Email"
          placeholder="Enter Email"
        />
        {errors.Email && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <button type="submit" style={{ marginTop: "2vh" }}>
        Submit
      </button>
    </form>
  );
};

export default UserForm;
