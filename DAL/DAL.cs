﻿namespace DAL;

public class DBOperations
{
    JobFinderDataContext context = new JobFinderDataContext();

    public string AddNewJob(tbl_Avl_Jobs newJob)
    {
        string status = "";
        try
        {

            context.tbl_Avl_Jobs.Add(newJob);
            context.SaveChanges();
            status = $"Added Job:{newJob.Job_Name} successfully";
        }
        catch (Exception Ex)
        {
            status += System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException;
        }
        return status;
    }
}
