using DAL;
using Models;

namespace BAL;

public class BusinessOperations
{
    public string AddNewJob(Job NewJob)
    {
        DBOperations Dbo = new();
        string status = Dbo.AddNewJob(new tbl_Avl_Job()
        {
            Job_ID = NewJob.Job_ID,
            Job_Name = NewJob.Job_Name,
            JobOpen = NewJob.JobOpen,
            CreatorUserID = NewJob.CreatorUserID,
            AvailablePositions = NewJob.AvailablePositions,
            FilledPositions = NewJob.FilledPositions,
            Domain = NewJob.Domain,
            Coy_ID = NewJob.Coy_ID,
            Job_Description = NewJob.Job_Description,
            YearsOfExperienceRequired = NewJob.YearsOfExperienceRequired

        }, new List<tbl_Job_Qualification>(), new List<tbl_Job_Skill>());
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
                    CreatorUserID = avl_Jobs.CreatorUserID,
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
