using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Proj_BOL
{
    public class tbl_VolunteerValidation
    {


        public tbl_VolunteerValidation()
        {
            this.OPPOR_HAS_VOLUN = new HashSet<OPPOR_HAS_VOLUN>();
            this.OrderLines = new HashSet<OrderLine>();
        }

        [BindNever]
        public int Volun_Id { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string VolunFname { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string VolunLname { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string VolunEmail { get; set; }

        //[DisplayFormat(DataFormatString ="{0:d",ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "Date Of Birth is Required")]
        [Display(Name = "Date of Birth")]
        public DateTime VolunDateofbirth { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string VolunStreetaddress { get; set; }

        [Display(Name = "Address Line 2")]
        public string VolunStreetaddress2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        [StringLength(50)]
        [Display(Name = "City")]
        public string VolunCity { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        [StringLength(20)]
        [Display(Name = "State")]
        public string VolunState { get; set; }

        [Required(ErrorMessage = "Please enter a ZipCode")]
        [Display(Name = "ZipCode")]
        public string VolunZip { get; set; }
        public string County { get; set; }

        [Display(Name = "Available Monday")]
        public Boolean VolunAvailableMonday { get; set; }
        [Display(Name = "Available Monday Morning")]
        public Boolean VolunAvailableMondayMorning { get; set; }
        [Display(Name = "Available Monday Afternoon")]
        public Boolean VolunAvailableMondayAfternoon { get; set; }
        [Display(Name = "Available Monday Evening")]
        public Boolean VolunAvailableMondayEvening { get; set; }
        [Display(Name = "Available Tuesday")]
        public Boolean VolunAvailableTuesday { get; set; }
        [Display(Name = "Available Tuesday Morning")]
        public Boolean VolunAvailableTuesdayMorning { get; set; }
        [Display(Name = "Available Tuesday Afternoon")]
        public Boolean VolunAvailableTuesdayAfternoon { get; set; }
        [Display(Name = "Available Tuesday Evening")]
        public Boolean VolunAvailableTuesdayEvening { get; set; }
        [Display(Name = "Available Wednesday")]
        public Boolean VolunAvailableWednesday { get; set; }
        [Display(Name = "Available Wednesday Morning")]
        public Boolean VolunAvailableWednesdayMorning { get; set; }
        [Display(Name = "Available Wednesday Afternoon")]
        public Boolean VolunAvailableWednesdayAfternoon { get; set; }
        [Display(Name = "Available Wednesday Evening")]
        public Boolean VolunAvailableWednesdayEvening { get; set; }
        [Display(Name = "Available Thursday")]
        public Boolean VolunAvailableThursday { get; set; }
        [Display(Name = "Available Thursday Morning")]
        public Boolean VolunAvailableThursdayMorning { get; set; }
        [Display(Name = "Available Thursday Afternoon")]
        public Boolean VolunAvailableThursdayAfternoon { get; set; }
        [Display(Name = "Available Thursday Evening")]
        public Boolean VolunAvailableThursdayEvening { get; set; }
        [Display(Name = "Available Friday")]
        public Boolean VolunAvailableFriday { get; set; }
        [Display(Name = "Available Friday Morning")]
        public Boolean VolunAvailableFridayMorning { get; set; }
        [Display(Name = "Available Friday Afternoon")]
        public Boolean VolunAvailableFridayAfternoon { get; set; }
        [Display(Name = "Available Friday Evening")]
        public Boolean VolunAvailableFridayEvening { get; set; }
        [Display(Name = "Available Saturday")]
        public Boolean VolunAvailableSaturday { get; set; }
        [Display(Name = "Available Saturday Morning")]
        public Boolean VolunAvailableSaturdayMorning { get; set; }
        [Display(Name = "Available Saturday Afternoon")]
        public Boolean VolunAvailableSaturdayAfternoon { get; set; }
        [Display(Name = "Available Saturday Evening")]
        public Boolean VolunAvailableSaturdayEvening { get; set; }
        [Display(Name = "Available Sunday")]
        public Boolean VolunAvailableSunday { get; set; }
        [Display(Name = "Available Sunday Morning")]
        public Boolean VolunAvailableSundayMorning { get; set; }
        [Display(Name = "Available Sunday Afternoon")]
        public Boolean VolunAvailableSundayAfternoon { get; set; }
        [Display(Name = "Available Sunday Evening")]
        public Boolean VolunAvailableSundayEvening { get; set; }
        [Display(Name = "Nutrition")]
        public Boolean VoluntNutrition { get; set; }
        [Display(Name = "Training Facilitator")]
        public Boolean VolunTrainingFacilitator { get; set; }
        [Display(Name = "Admin")]
        public Boolean VolunAdmin { get; set; }
        [Display(Name = "General")]
        public Boolean VolunGeneral { get; set; }
        [Display(Name = "Healthy living")]
        public Boolean VolunHealthyliving { get; set; }
        [Display(Name = "Disease Management")]
        public Boolean VolunDiseaseManagement { get; set; }
        [Display(Name = "Falls Prevention")]
        public Boolean VolunFallsPrevention { get; set; }
        [Display(Name = "Caregiver")]
        public Boolean VolunCaregiver { get; set; }
        [Display(Name = "Mental Wellness")]
        public Boolean VolunMentalWellness { get; set; }
        [Display(Name = "Events")]
        public Boolean VolunEvents { get; set; }
        [Display(Name = "Social Media")]
        public Boolean VolunSocialMedia { get; set; }

        [Display(Name = "Other Interest")]
        [DataType(DataType.MultilineText)]
        public string VolunOtherInterest { get; set; }
        [Display(Name = "Background Check Required")]
        public Boolean VolunBackgroundCheckRequired { get; set; }
        [Display(Name = "Background Check Completed On")]
        public Nullable<System.DateTime> VolunBackgroundCheckCompletedOn { get; set; }
        [Display(Name = "Background Check Expires On")]
        public Nullable<System.DateTime> VolunBackgroundCheckExpiresOn { get; set; }
        [Display(Name = "Activities Participated")]
        public string VolunActivitiesParticipated { get; set; }
        [Display(Name = "Mark Volunteer")]
        public Boolean VolunMarkVolunteer { get; set; }
        [Display(Name = "Flagged")]
        public Boolean VolunFlagged { get; set; }

        [Display(Name = "Flagged Information")]
        public string VolunFlaggedInformation { get; set; }

        [Display(Name = "General Notes")]
        public string VolunGeneralNotes { get; set; }

        [Display(Name = "Update Hours")]
        public Nullable<decimal> VolunUpdateHours { get; set; }
        [Display(Name = "Date of Application")]
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string IsApproved { get; set; }
        public string Password { get; set; }

        public virtual ICollection<OPPOR_HAS_VOLUN> OPPOR_HAS_VOLUN { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
    [MetadataType(typeof(tbl_VolunteerValidation))]
    public partial class tbl_Volunteer
    {

    }

}