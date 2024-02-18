import React, { useState } from "react";
import { useForm } from "react-hook-form";
import "./jobForm.css";

const JobForm = () => {
  const [qualifications, setQualifications] = useState([
    { name: "", required: "Optional" },
  ]);
  const [skills, setSkills] = useState([{ name: "", required: "Optional" }]);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();
  const handleAddSkill = () => {
    setSkills([...skills, { name: "", required: "Optional" }]);
  };

  const handleSkillChange = (index, event) => {
    const { value } = event.target;
    const updatedSkills = [...skills];
    updatedSkills[index].name = value;
    setSkills(updatedSkills);
  };

  const handleRemoveSkill = (index) => {
    const updatedSkills = [...skills];
    updatedSkills.splice(index, 1);
    setSkills(updatedSkills);
  };
  const handleAddQualification = () => {
    setQualifications([...qualifications, { name: "", required: "Optional" }]);
  };

  const handleQualificationChange = (index, event) => {
    const { value } = event.target;
    const updatedQualifications = [...qualifications];
    updatedQualifications[index].name = value;

    setQualifications(updatedQualifications);
  };

  const handleRemoveQualification = (index) => {
    const updatedQualifications = [...qualifications];
    updatedQualifications.splice(index, 1);
    setQualifications(updatedQualifications);
  };

  const onSubmit = (data) => {
    // Include qualifications and skills in the form data
    data.qualifications = qualifications;
    data.skills = skills;
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
        <label>Job Open (You can open it later)</label>
        <select {...register("jobOpen")}>
          <option value="Yes">Yes</option>
          <option value="No">No</option>
        </select>
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
        <label>Qualifications required</label>
        {qualifications.map((qualification, index) => (
          <div key={index} className="multi-row">
            <input
              type="text"
              value={qualification.name}
              onChange={(e) => handleQualificationChange(index, e)}
              name={`qualifications[${index}].name`}
              placeholder="Qualification"
            />
            <select
              value={qualification.required}
              onChange={(e) => handleQualificationChange(index, e)}
              name="required"
            >
              <option value="Optional">Optional</option>
              <option value="Mandatory">Mandatory</option>
            </select>
            <button
              type="button"
              onClick={() => handleRemoveQualification(index)}
            >
              Remove
            </button>
          </div>
        ))}
        <button type="button" onClick={handleAddQualification}>
          Add New Qualification
        </button>
      </div>

      <div className="form-group">
        <label>Skills required</label>
        {skills.map((skill, index) => (
          <div key={index} className="multi-row">
            <input
              type="text"
              value={skill.name}
              onChange={(e) => handleSkillChange(index, e)}
              name={`skills[${index}].name`}
              placeholder="Skill"
            />
            <select
              value={skill.required}
              onChange={(e) => handleSkillChange(index, e)}
              name={`skills[${index}].required`}
            >
              <option value="Optional">Optional</option>
              <option value="Mandatory">Mandatory</option>
            </select>
            <button type="button" onClick={() => handleRemoveSkill(index)}>
              Remove
            </button>
          </div>
        ))}
        <button type="button" onClick={handleAddSkill}>
          Add New Skill
        </button>
      </div>

      <button type="submit">Submit</button>
    </form>
  );
};

export default JobForm;
