using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DAL;

public class tbl_User_Skill
{
    [Key]
    public string User_ID { get; set; }

    public string Skill_Name { get; set; }



    [ForeignKey("User_ID")]
    public tbl_User Users { get; set; }

}