using DAL;
using Models;

namespace BAL;

public class BusinessOperations
{
    public string AddNewJob(JobData Job)
    {
        DBOperations Dbo = new();
        List<tbl_Job_Qualification> QualsToSave = Job.Qualifications_Required.Select(x => new tbl_Job_Qualification()
        {
            Job_ID = Job.JobBasicData.Job_ID,
            QualificationRequired = x.Qualification_Name,
            Required = x.Required
        }).ToList();
        List<tbl_Job_Skill> SkillsToSave = Job.Skills_Required.Select(x => new tbl_Job_Skill()
        {
            Job_ID = Job.JobBasicData.Job_ID,
            Skill_Name = x.Skill_Name,
            Required = x.Required
        }).ToList();
        string status = Dbo.AddNewJob(new tbl_Avl_Job()
        {
            Job_ID = Job.JobBasicData.Job_ID,
            Job_Name = Job.JobBasicData.Job_Name,
            JobOpen = Job.JobBasicData.JobOpen,
            AvailablePositions = Job.JobBasicData.AvailablePositions,
            FilledPositions = Job.JobBasicData.FilledPositions,
            Domain = Job.JobBasicData.Domain,
            Coy_ID = Job.JobBasicData.Coy_ID,
            Job_Description = Job.JobBasicData.Job_Description,
            YearsOfExperienceRequired = Job.JobBasicData.YearsOfExperienceRequired

        }, QualsToSave, SkillsToSave);
        return status;
    }
    public (List<Job>, string) GetAllJobs()
    {
        List<Job> ReturnData = new List<Job>();
        string status = "";
        try
        {
            (List<tbl_Avl_Job> JobDB, status) = new DBOperations().GetAllJobs();
            foreach (tbl_Avl_Job avl_Jobs in JobDB)
            {
                Job Job = new Job()
                {
                    Job_ID = avl_Jobs.Job_ID,
                    Job_Name = avl_Jobs.Job_Name,
                    JobOpen = avl_Jobs.JobOpen,

                    AvailablePositions = avl_Jobs.AvailablePositions,
                    FilledPositions = avl_Jobs.FilledPositions,
                    Domain = avl_Jobs.Domain,
                    Coy_ID = avl_Jobs.Coy_ID,
                    Job_Description = avl_Jobs.Job_Description,
                    YearsOfExperienceRequired = avl_Jobs.YearsOfExperienceRequired
                };
                ReturnData.Add(Job);
            }
        }
        catch (Exception Ex)
        {
            status += System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException;
            Console.WriteLine(status);
        }
        return (ReturnData, status);

    }
}
