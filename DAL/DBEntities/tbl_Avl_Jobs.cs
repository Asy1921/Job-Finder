using System.ComponentModel.DataAnnotations;

namespace DAL;

public class tbl_Avl_Jobs
{
    [Key]
    public int Job_ID { get; set; }
    public string UserID { get; set; }
    public string Job_Name { get; set; }
    public int AvailablePositions { get; set; }
    public int FilledPositions { get; set; }
    public bool JobOpen { get; set; }
    public string Domain { get; set; }
    public string SkillsRequired { get; set; }
}