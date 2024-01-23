using System.ComponentModel.DataAnnotations;

namespace DAL;

public class tbl_Avl_Jobs
{
    [Key]
    public int Job_ID { get; set; }
    public string Job_Name { get; set; }
}