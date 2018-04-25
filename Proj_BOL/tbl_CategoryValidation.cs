using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_BOL
{
    /**
     * This class is a copy of partial class tbl_Category created from the db model
     * as a backup to save the data annotations or modifications in case we need to 
     * regenerate the db models. Regenerating the db models will delete all changes.
     **/
    public class tbl_CategoryValidation
    {
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Category Description")]
        public string CategoryDesc { get; set; }
    } //End class

    /**
     * Referencing the original db table to include the annotation validations
     * */
    [MetadataType(typeof(tbl_CategoryValidation))]
    public partial class tbl_Category
    {
    }

}
