using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DAL;

public class tbl_Job_Applicants
{
    [Key]
    public string Applicant_ID { get; set; }
    public string Job_ID { get; set; }
    public DateTime SubmittedOn { get; set; }
    public string Status { get; set; }


    [ForeignKey("Job_ID")]
    public tbl_Avl_Jobs AvailableJobs { get; set; }

    [ForeignKey("Applicant_ID")]
    public tbl_Users Users { get; set; }

}