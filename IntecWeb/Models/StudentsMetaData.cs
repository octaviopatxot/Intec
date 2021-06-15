using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace IntecWeb.Models
{ 
 [ModelMetadataType(typeof(StudentsMetaData))]
public partial class Student
{
}

public class StudentsMetaData
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

 
}
}
