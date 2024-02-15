import React from "react";
import { useForm } from "react-hook-form";
import "./jobForm.css";

const JobForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    console.log(data);
    // Submit logic here
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="job-form">
      <div className="form-group">
        <label>Job ID</label>
        <input {...register("jobId", { required: true })} />
        {errors.jobId && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Job Name</label>
        <input {...register("jobName", { required: true })} />
        {errors.jobName && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Job Open</label>
        <select {...register("jobOpen")}>
          <option value="Yes">Yes</option>
          <option value="No">No</option>
        </select>
      </div>

      <div className="form-group">
        <label>Company ID</label>
        <input {...register("companyId", { required: true })} />
        {errors.companyId && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Available Opening</label>
        <input
          type="number"
          {...register("availableOpening", { required: true, min: 0 })}
        />
        {errors.availableOpening && (
          <span className="error-message">
            This field is required and must be non-negative
          </span>
        )}
      </div>

      <div className="form-group">
        <label>Domain</label>
        <input {...register("domain", { required: true })} />
        {errors.domain && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Job Description</label>
        <textarea {...register("jobDescription", { required: true })} />
        {errors.jobDescription && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Years Of Experience Required</label>
        <input
          type="number"
          {...register("yearsOfExperienceRequired", { required: true, min: 0 })}
        />
        {errors.yearsOfExperienceRequired && (
          <span className="error-message">
            This field is required and must be non-negative
          </span>
        )}
      </div>

      <div className="form-group">
        <label>Qualification required</label>
        <select multiple {...register("qualificationRequired")}>
          <option value="Bachelor">Bachelor</option>
          <option value="Master">Master</option>
          <option value="PhD">PhD</option>
        </select>
      </div>

      <div className="form-group">
        <label>Skills required</label>
        <select multiple {...register("skillsRequired")}>
          <option value="JavaScript">JavaScript</option>
          <option value="React">React</option>
          <option value="Node.js">Node.js</option>
        </select>
      </div>

      <button type="submit">Submit</button>
    </form>
  );
};

export default JobForm;
