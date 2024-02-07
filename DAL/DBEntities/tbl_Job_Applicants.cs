using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL;

public class tbl_Job_Applicants
{
    [Key]
    public string Applicant_ID { get; set; }
    public int Job_ID { get; set; }


    [ForeignKey("Job_ID")]
    public tbl_Avl_Jobs AvailableJobs { get; set; }

    [ForeignKey("Applicant_ID")]
    public tbl_Users Users { get; set; }

}