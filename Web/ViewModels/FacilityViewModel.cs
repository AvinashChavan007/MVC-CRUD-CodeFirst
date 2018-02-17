using Core.Domains;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class FacilityViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Display(Name = "Land Mark")]
        public string Landmark { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Address Line 2")]
        [MaxLength(100)]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(10)]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [MaxLength(60)]
        public string ZipCode { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public FacilityViewModel(Facility facility)
        {

            Id = facility.Id;
            Name = facility.Name;
            Landmark = facility.Landmark;
            Address = facility.Address;
            Address2 = facility.Address2;
            City = facility.City;
            State = facility.State;
            ZipCode = facility.ZipCode;
            IsActive = facility.IsActive;

        }


        public FacilityViewModel()
        {

        }
    }
}

