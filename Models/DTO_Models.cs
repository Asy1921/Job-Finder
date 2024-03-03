namespace Models;

public class Job
{
    public string Job_ID { get; set; } = "";
    public string CreatorUserID { get; set; } = "";
    public string Job_Name { get; set; } = "";
    public int AvailablePositions { get; set; } = 0;
    public int FilledPositions { get; set; } = 0;
    public bool JobOpen { get; set; } = false;
    public string Domain { get; set; } = "";
    public string Coy_ID { get; set; } = "";
    public string Job_Description { get; set; } = "";
    public int YearsOfExperienceRequired { get; set; } = 0;
    public List<Job_Qualification_Required> Qualifications_Required { get; set; } = new();
    public List<Job_Skill_Required> Skills_Required { get; set; } = new();

}

public class Job_Qualification_Required
{
    public string Qualification_Name { get; set; } = "";
    public bool Required { get; set; } = false;
}
public class Job_Skill_Required
{
    public string Skill_Name { get; set; } = "";
    public bool Required { get; set; } = false;
}

