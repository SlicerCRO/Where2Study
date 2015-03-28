using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Where2Study.Models
{
    public class Faculty
    {
        [Display(Name = "UniversityTitle", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "UniversityTitleRequired")]
        [StringLength(80, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "UniversityTitleLong")]
        public string University { get; set; }
        [Display(Name = "FacultyTitle", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "FacultyTitleRequired")]
        [StringLength(80, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "FacultyTitleLong")]
        public string Title { get; set; }
        [Display(Name = "FacultyDescription", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "FacultyDescriptionRequired")]
        [StringLength(10000, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "FacultyDescriptionLong")]
        public string Description { get; set; }
        [Display(Name = "Address", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "AddressRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "AddressLong")]
        public string Address { get; set; }
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "PhoneNumberRequired")]
        [StringLength(16, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "PhoneNumberLong")]
        public string Phone { get; set; }
        [Display(Name = "WebSite", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "WebSiteRequired")]
        [StringLength(34, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "WebSiteLong")]
        public string WebSite { get; set; }
        [Display(Name = "CityTitle", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "CityTitleRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "CityTitleLong")]
        public string City { get; set; }
        [Display(Name = "CountryTitle", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "CountryTitleRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "CountryTitleLong")]
        public string Country { get; set; }
        [Display(Name = "ContinentTitle", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "ContinentTitleRequired")]
        [StringLength(14, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "ContinentTitleLong")]
        public string Continent { get; set; }
        public string Photo { get; set; }
        public List<Where2Study.Models.DegreeSpecialization> Specializations { get; set; }
    }
}