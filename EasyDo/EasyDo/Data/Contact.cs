namespace EasyDo.Data
{
    using System;
    
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        //public SendEmail SendEmail { get; set; }
        //public int EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        //public int ContactTypeId { get; set; }
        ////public ContactType ContactType { get; set; }
        public string Profession { get; set; }
        public string Description { get; set; }
        //public IFormFile Image { get; set; }

    }
}
