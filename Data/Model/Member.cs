using System.ComponentModel.DataAnnotations;


namespace Coursework.Data.Model
{
    public class Member
    {
        // Gets or sets the phone number of the member.
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNumber { get; set; }

        
        // Gets or sets the start date of the membership.
        public DateTime MembershipStartDate { get; set; }

        // Gets or sets the end date of the membership.
        public DateTime MembershipEndDate { get; set; }
    }
}
