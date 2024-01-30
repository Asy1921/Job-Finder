using DAL;

namespace BAL;

public class BusinessOperations
{
    public string AddNewJob(int JobID, string JobName)
    {
        string status = new DBOperations().AddNewJob(new tbl_Avl_Jobs()
        {
            Job_ID = JobID,
            Job_Name = JobName
        });
        return status;
    }
}
