namespace Models;

public class Job
{
    public string Job_ID { get; set; } = "";
    public string CreatorUserID { get; set; } = "";
    public string Job_Name { get; set; } = "";
    public int AvailablePositions { get; set; } = 0;
    public int FilledPositions { get; set; } = 0;
    public bool JobOpen { get; set; } = false;
}
