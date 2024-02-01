namespace Models;

public class Job
{
    public int Job_ID { get; set; } = 0;
    public string UserID { get; set; } = "";
    public string Job_Name { get; set; } = "";
    public int AvailablePositions { get; set; } = 0;
    public int FilledPositions { get; set; } = 0;
    public bool JobOpen { get; set; } = false;
}
