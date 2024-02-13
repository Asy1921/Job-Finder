using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DAL;

public class tbl_User_Qualification
{
    [Key]
    public string User_ID { get; set; }

    public string Name { get; set; }
    public string Institute { get; set; }
    public string Location { get; set; }



    [ForeignKey("User_ID")]
    public tbl_Users Users { get; set; }

}