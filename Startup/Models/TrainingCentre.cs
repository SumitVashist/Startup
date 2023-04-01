using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Startup.Models
{
    public class TrainingCenter
    {   
        public int ID { get; set; }
        [Required(ErrorMessage = "Center name is required.")]
        [MaxLength(40, ErrorMessage = "Center name should be less than 40 characters.")]
        public string? CenterName { get; set; }



        [Required(ErrorMessage = "Center code is required.")]
        [RegularExpression(@"^[a-zA-Z0-9]{12}$", ErrorMessage = "Center code should be exactly 12 character alphanumeric.")]
        public string? CenterCode { get; set; }



        [Required(ErrorMessage = "Address is required.")]
        public CompleteAddress? Address { get; set; }



        [Range(0, int.MaxValue, ErrorMessage = "Student capacity should be a positive number.")]
        public int StudentCapacity { get; set; }


        [NotMapped]
        public List<string>? CoursesOffered { get; set; }



        [JsonIgnore]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;



        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? ContactEmail { get; set; }



        [Required(ErrorMessage = "Contact phone number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid phone number.")]
        public string? ContactPhone { get; set; }
    }



    public class CompleteAddress
    {
        public string? DetailedAddress { get; set; }



        public string? City { get; set; }



        public string? State { get; set; }


        [Key]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Invalid pincode.")]
        public string? Pincode { get; set; }
    }

}
