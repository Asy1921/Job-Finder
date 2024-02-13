using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DAL;

public class tbl_Job_Qualifications
{
    [Key]
    public string Job_ID { get; set; }
    public string QualificationRequired { get; set; }
    public bool Required { get; set; }



    [ForeignKey("Job_ID")]
    public tbl_Avl_Jobs Job { get; set; }

}