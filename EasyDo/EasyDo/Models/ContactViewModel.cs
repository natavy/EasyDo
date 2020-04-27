
namespace EasyDo.Models
{
    using EasyDo.Data;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ContactViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        //public int ContactTypeId { get; set; }
        //public ContactType ContactType { get; set; }
        public string Profession { get; set; }
        public string Description { get; set; }
        //public IFormFile Image { get; set; }
    }
}
