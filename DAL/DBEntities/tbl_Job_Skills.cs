using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DAL;

public class tbl_Job_Skill
{
    [Key]
    public string Job_ID { get; set; }

    public string Skill_Name { get; set; }
    public bool Required { get; set; }



    [ForeignKey("Job_ID")]
    public tbl_Avl_Job Job { get; set; }

}