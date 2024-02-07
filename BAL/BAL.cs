using DAL;
using Models;

namespace BAL;

public class BusinessOperations
{
    public string AddNewJob(Job NewJob)
    {
        string status = new DBOperations().AddNewJob(new tbl_Avl_Jobs()
        {
            Job_ID = NewJob.Job_ID,
            Job_Name = NewJob.Job_Name,
            JobOpen = NewJob.JobOpen,
            CreatorUserID = NewJob.CreatorUserID,
            AvailablePositions = NewJob.AvailablePositions,
            FilledPositions = NewJob.FilledPositions
        });
        return status;
    }
    public (List<Job>, string) GetAllJobs()
    {
        List<Job> ReturnData = new List<Job>();
        string status = "";
        try
        {
            (List<tbl_Avl_Jobs> JobDB, status) = new DBOperations().GetAllJobs();
            foreach (tbl_Avl_Jobs avl_Jobs in JobDB)
            {
                Job Job = new Job()
                {
                    Job_ID = avl_Jobs.Job_ID,
                    Job_Name = avl_Jobs.Job_Name,
                    JobOpen = avl_Jobs.JobOpen,
                    CreatorUserID = avl_Jobs.CreatorUserID,
                    AvailablePositions = avl_Jobs.AvailablePositions,
                    FilledPositions = avl_Jobs.FilledPositions
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
