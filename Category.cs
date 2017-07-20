using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTraining.Models
{
    [Table("Categories")]
    public class Category
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }

    [Table("Student")]
    public class StudentModel
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Studentid { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Student address is required")]
        public string StudentAddress { get; set; }

        [Required(ErrorMessage = "Student phone no is required")]
        public string StudentPhoneNo { get; set; }
    }
}