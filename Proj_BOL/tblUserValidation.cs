using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_BOL
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DB_Models db = new DB_Models();
            string userEmailValue = value.ToString();
            int count = db.tbl_User.Where(x => x.UserEmail == userEmailValue).ToList().Count();
            if (count != 0)
                return new ValidationResult("User Already Exist With This Email ID");
            return ValidationResult.Success;
        }
    }
   public class tblUserValidation
    {
       [Required]
       [EmailAddress]
       [UniqueEmail]
        public string UserEmail { get; set; }

       [DataType(DataType.Password)]
       [Required]
      
        public string Password { get; set; }

        /**
         * Confirm password was not a column in the database but i added it
         * here to be implemented by the Register View cshtml.
         * */
       [DataType(DataType.Password)]
       [Required]       
       [Compare("Password")]
       public string ConfirmPassword { get; set; }

    }

    [MetadataType(typeof(tblUserValidation))]
    public partial class tbl_User
    {
        public string ConfirmPassword { get; set; }
    }
}
