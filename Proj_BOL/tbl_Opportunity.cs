//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proj_BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Opportunity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Opportunity()
        {
            this.BasketLines = new HashSet<BasketLine>();
            this.OPPOR_HAS_CATEGORY = new HashSet<OPPOR_HAS_CATEGORY>();
            this.OPPOR_HAS_VOLUN = new HashSet<OPPOR_HAS_VOLUN>();
            this.OrderLines = new HashSet<OrderLine>();
        }
    
        public int Oppor_Id { get; set; }
        public string Oppor_Name { get; set; }
        public string Oppor_Description { get; set; }
        public System.DateTime Oppor_Dateofevent { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Oppor_Streetaddress { get; set; }
        public string Oppor_Streetaddress2 { get; set; }
        public string Oppor_City { get; set; }
        public string Oppor_State { get; set; }
        public string Oppor_Zip { get; set; }
        public string Oppor_County { get; set; }
        public Nullable<bool> Oppor_Eldersource { get; set; }
        public Nullable<bool> Oppor_Eldersourceinstitute { get; set; }
        public Nullable<bool> Oppor_RequiresBackgroundCheck { get; set; }
        public Nullable<bool> Oppor_IsFeatured { get; set; }
        public System.DateTime Oppor_CreatedOn { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketLine> BasketLines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OPPOR_HAS_CATEGORY> OPPOR_HAS_CATEGORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OPPOR_HAS_VOLUN> OPPOR_HAS_VOLUN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
