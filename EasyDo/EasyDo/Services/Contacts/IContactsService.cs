namespace EasyDo.Services
{
    using EasyDo.Models;
    using System.Collections.Generic;
    
    public interface IContactsService
    {
        public List<ContactListViewModel> GetAll(int page = 1, int pageSize = 6, string search = null);
        public ContactViewModel GetContactById(int id);
        public ContactViewModel Insert(ContactViewModel contact);
        public void Update(ContactViewModel contact);
        public void Delete(int id);
        public void Details(ContactViewModel model);
        public List<ContactTypeViewModel> GetAllTypes();
        public ContactTypeViewModel InsertType(ContactTypeViewModel contactType);

    }
}
