using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using empform_ajax.CustomValidations;

namespace empform_ajax.Models;


public partial class As1Employee
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is required")]
    public string Firstname { get; set; } = null!;

    [Required(ErrorMessage = "Lastname is required")]
    public string? Lastname { get; set; }


    [Required(ErrorMessage = "Please enter Dateofbirth")]
    [dobvalidation(ErrorMessage = "Your age should be greater than 18")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Dateofbirth { get; set; }

    [Required(ErrorMessage = "Please enter Gender")]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "Please enter Salary")]
    //[salvalidation(ErrorMessage = "Salary should be greater than 5k")]
    [Range(5000, int.MaxValue, ErrorMessage = "Salary should be greater than 5k")]
    public int? Salary { get; set; }

    [Required(ErrorMessage = "Please enter Doj")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Doj { get; set; }

    
    public int? Departmentid { get; set; }

    
    public int? Designationid { get; set; }

    public virtual As1Department? Department { get; set; }

    public virtual As1Designation? Designation { get; set; }

    public List<As1Skill> Skills { get; set; } = new List<As1Skill>();

  
}


public partial class passSkills 
{
    public int id { get; set; }
    public string ids { get; set; }
}
