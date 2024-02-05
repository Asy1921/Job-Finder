using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL;

public class tbl_Users
{
    [Key]
    public string User_ID { get; set; }
    public string HighestQualification { get; set; }
    public string Domain { get; set; }
    public int YearsOfExperience { get; set; }


}