using Microsoft.EntityFrameworkCore;

namespace DAL;

public class DBOperations
{
    JobFinderDataContext context = new JobFinderDataContext();

    public string AddNewJob(tbl_Avl_Job NewJob, List<tbl_Job_Qualification> Qualifications, List<tbl_Job_Skill> Skills)
    {
        string status = "";
        try
        {

            context.tbl_Avl_Jobs.Add(NewJob);
            context.SaveChanges();
            status = $"Added Job:{NewJob.Job_Name} successfully\n";
            // context.tbl_Qualifications.Add(Qualifications);
        }
        catch (Exception Ex)
        {
            status += System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException;
        }
        return status;
    }

    public (List<tbl_Avl_Job>, string) GetAllJobs()
    {
        string status = "";
        List<tbl_Avl_Job> ReturnData = new List<tbl_Avl_Job>();
        try
        {

            ReturnData = context.tbl_Avl_Jobs.AsNoTracking().ToList();

            status = $"Fetched {ReturnData.Count} jobs successfully";
        }
        catch (Exception Ex)
        {
            status += System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException;
            Console.WriteLine(status);
        }
        return (ReturnData, status);
    }
}
