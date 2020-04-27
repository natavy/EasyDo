
namespace EasyDo.Models
{
    using EasyDo.Data;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;

    public class ContactListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public SendEmail SendEmail { get; set; }


        //public IFormFile Image { get; set; }
        //public List<ContactViewModel> Contacts { get; set; }
    }
}
