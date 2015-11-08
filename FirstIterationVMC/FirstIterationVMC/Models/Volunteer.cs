using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FirstIterationVMC.Models
{
    public class Volunteer
    {
        //ID
        public int ID { get; set; }

        // First Name
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,25}$",
        ErrorMessage = "Numbers and special characters are not allowed in the first name.")]
        [Required]
        [StringLength(25)]
        [Display(Name ="First Name")]
        public string FName { get; set; }

        //Last Name
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$",
        ErrorMessage = "Numbers and special characters are not allowed in the last name.")]
        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        //date of birthday
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        //phone
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$", ErrorMessage = "Entered phone format is not valid. Use (999)999-9999 format.")]
        [StringLength(15)]
        public string phone { get; set; }

        //email
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        //street
        [Required]
        [StringLength(30)]
        public string Address { get; set; }

        //city
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,25}$")]
        [StringLength(25)]
        public string City { get; set; }

        //State
        [Required]
        [RegularExpression(@"^[A-Z\s]{2}$")]
        [StringLength(2)]
        public string State { get; set; }

        //zip
        [Required]
        [RegularExpression(@"^(\d{5})$")]
        [StringLength(5)]
        public string Zip { get; set; }

        //specialty
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$")]
        public string Specialty { get; set; }
    }

    public class VolunteerDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteer { get; set; }
    }
}