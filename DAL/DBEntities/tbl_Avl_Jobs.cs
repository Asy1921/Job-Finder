using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

public class tbl_Avl_Jobs
{
    [Key]
    public string Job_ID { get; set; }
    public string CreatorUserID { get; set; }
    public string Job_Name { get; set; }
    public string Coy_ID { get; set; }
    public int AvailablePositions { get; set; }
    public int FilledPositions { get; set; }
    public bool JobOpen { get; set; }
    public string Domain { get; set; }
    public string SkillsRequired { get; set; }

    [ForeignKey("Coy_ID")]
    public tbl_Companies Company { get; set; }
}