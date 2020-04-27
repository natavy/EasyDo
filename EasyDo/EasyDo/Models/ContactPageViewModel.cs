using System.Collections.Generic;

namespace EasyDo.Models
{
    public class ContactPageViewModel
    {
        public string Search { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<ContactListViewModel> Contacts { get; set; }
    }
}
