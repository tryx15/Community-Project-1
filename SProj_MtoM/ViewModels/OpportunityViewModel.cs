using Proj_BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SProj_MtoM.ViewModels
{
    public class OpportunityViewModel
    {
        public OpportunityViewModel()
        {
            this.BasketLines = new HashSet<BasketLine>();
            this.OPPOR_HAS_CATEGORY = new HashSet<OPPOR_HAS_CATEGORY>();
            this.OPPOR_HAS_VOLUN = new HashSet<OPPOR_HAS_VOLUN>();
            this.OrderLines = new HashSet<OrderLine>();
        }


        public int Oppor_Id { get; set; }

        [Required(ErrorMessage = "Please enter Event Name.")]
        [Display(Name = "Opportunity Name")]
        public string Oppor_Name { get; set; }

        [Required(ErrorMessage = "Please enter a Description.")]
        [Display(Name = "Description")]
        public string Oppor_Description { get; set; }

        [Required(ErrorMessage = "You must enter a date.")]
        [DataType(DataType.Date, ErrorMessage = "Must be a valid date.")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Event")]
        public System.DateTime Oppor_Dateofevent { get; set; }

        [Display(Name = "Image")]
        public byte[] ImageData { get; set; }

        [Display(Name = "ImageM")]
        public string ImageMimeType { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        [Display(Name = "Street Address")]
        public string Oppor_Streetaddress { get; set; }

        [Display(Name = "Street Address")]
        public string Oppor_Streetaddress2 { get; set; }

        [Required(ErrorMessage = "Please enter a City")]
        [Display(Name = "City")]
        public string Oppor_City { get; set; }

        [Required(ErrorMessage = "Please enter a State")]
        [Display(Name = "State")]
        public string Oppor_State { get; set; }

        [Required(ErrorMessage = "Please enter a ZipCode")]
        [Display(Name = "Zip Code")]
        public string Oppor_Zip { get; set; }

        [Required(ErrorMessage = "Please enter a County")]
        [Display(Name = "County")]
        public string Oppor_County { get; set; }

        [Display(Name = "By Eldersource")]
        public Nullable<bool> Oppor_Eldersource { get; set; }

        [Display(Name = "By Eldersource Institute")]
        public Nullable<bool> Oppor_Eldersourceinstitute { get; set; }

        [Display(Name = "Requires Background Check")]
        public Nullable<bool> Oppor_RequiresBackgroundCheck { get; set; }

        [Display(Name = "Featured Event")]
        public Nullable<bool> Oppor_IsFeatured { get; set; }

        [Required(ErrorMessage = "You must enter a date.")]
        [DataType(DataType.Date, ErrorMessage = "Must be a valid date.")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public System.DateTime Oppor_CreatedOn { get; set; }

        [Display(Name = "User Identification")]
        public Nullable<int> UserId { get; set; }

        public string Role { get; set; }

        public List<CheckBoxViewModel> Categories { get; set; }

        public virtual ICollection<BasketLine> BasketLines { get; set; }
        public virtual ICollection<OPPOR_HAS_CATEGORY> OPPOR_HAS_CATEGORY { get; set; }
        public virtual ICollection<OPPOR_HAS_VOLUN> OPPOR_HAS_VOLUN { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}