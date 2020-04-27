namespace EasyDo.Services
{
    using EasyDo.Data;
    using EasyDo.Models;
    using System.Collections.Generic;
    using System.Linq;
    public class ContactsService : IContactsService
    {
        private readonly EasyDoDbContext db;
        public ContactsService(EasyDoDbContext db)
        {
            this.db = db;
        }

        public List<ContactListViewModel> GetAll(int page = 1, int pageSize = 6, string search = null)
        {
            var contact = this.db.Contacts.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                contact = contact.Where(a => a.FirstName.ToLower().Contains(search.ToLower()));
            }

            if (db.Contacts.Count() == 0)
            {
                page = 1;
            }
            var contacts = contact
                .OrderBy(o => o.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new ContactListViewModel
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    PhoneNumber=t.PhoneNumber,
                    Email=t.Email,
                    City=t.City

                }).ToList();
            return contacts;
        }

        public List<ContactTypeViewModel> GetAllTypes()
        {
            if (this.db.Contacts==null)
            {
                 throw new System.Exception("No contacts");
            }
            return this.db.ContactTypes
              .Select(t => new ContactTypeViewModel
              {
                  Id = t.Id,
                  Name = t.Name
              }).ToList();
        }

        public ContactViewModel  GetContactById(int id)
        {
            var contact = db.Contacts.Where(c => c.Id == id).FirstOrDefault();
            return new ContactViewModel 
            { 
                Id = contact.Id,
                FirstName= contact.FirstName,
                LastName=contact.LastName,
                Birthday = contact.Birthday,
                PhoneNumber = contact.PhoneNumber,
                City = contact.City,
                Email = contact.Email,
                //ContactType = model.ContactType,
                Profession = contact.Profession,
                //Image = model.Image,
                Description = contact.Description,
            };

        }

        public ContactViewModel Insert(ContactViewModel model)
        {

            Contact contact = new Contact
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName, 
                Birthday = model.Birthday,
                PhoneNumber=model.PhoneNumber,
                City=model.City,
                Email=model.Email,
                //ContactType = model.ContactType,
                Profession = model.Profession,
                //Image = model.Image,
                Description = model.Description,
            };
            db.Contacts.Add(contact);
            db.SaveChanges();
            return model;
        }

        public ContactTypeViewModel InsertType(ContactTypeViewModel model)
        {
            ContactType contactType = new ContactType
            {
                Id = model.Id,
                Name = model.Name
            };
            db.ContactTypes.Add(contactType);
            db.SaveChanges();
            return model;
        }

        public void Update(ContactViewModel model)
        {
            var contactToEdit = db.Contacts.SingleOrDefault(c => c.Id == model.Id);
            contactToEdit.FirstName = model.FirstName;
            contactToEdit.LastName = model.LastName;
            contactToEdit.PhoneNumber = model.PhoneNumber;
            contactToEdit.City = model.City;
            contactToEdit.Email = model.Email;
            contactToEdit.Birthday = model.Birthday;
            //contactToEdit.ContactType = model.ContactType;
            contactToEdit.Profession = model.Profession;
            //contactToEdit.Image = model.Image;
            contactToEdit.Description = model.Description;
            db.SaveChanges();
          
        }
        public void Delete(int id)
        {
            ContactViewModel model = new ContactViewModel();
            model.Id = id;
            var contactToDelete = db.Contacts.SingleOrDefault(c => c.Id == model.Id);
            
            if (contactToDelete != null) 
            {
                db.Contacts.Remove(contactToDelete);
                db.SaveChanges();
                
            }
                
            
        }

        public void Details(ContactViewModel model)
        {
            var contactToEdit = db.Contacts.SingleOrDefault(c => c.Id == model.Id);
            contactToEdit.FirstName = model.FirstName;
            contactToEdit.LastName = model.LastName;
            contactToEdit.PhoneNumber = model.PhoneNumber;
            contactToEdit.City = model.City;
            contactToEdit.Email = model.Email;
            contactToEdit.Birthday = model.Birthday;
            //contactToEdit.ContactType = model.ContactType;
            contactToEdit.Profession = model.Profession;
            //contactToEdit.Image = model.Image;
            contactToEdit.Description = model.Description;
        }
    }
}
