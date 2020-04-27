namespace EasyDo.Controllers
{
    using EasyDo.Data;
    using EasyDo.Models;
    using EasyDo.Services;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Data;
    using System.Linq;

    public class ContactsController : Controller
    {
        private readonly EasyDoDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IContactsService contacts;

        public ContactsController(EasyDoDbContext db, UserManager<IdentityUser> userManager, IContactsService contacts)
        {
            this.db = db;
            this.userManager = userManager;
            this.contacts = contacts;
        }

        // GET: Contacts
        public ActionResult All(int page = 1, int pageSize = 6, string search = null)
        {
            var countAlbums = 0;
            if (search != null)
            {
                countAlbums = db.Contacts.Count(ca => ca.FirstName.ToLower().Contains(search.ToLower()));
            }
            else
            {
                countAlbums = db.Contacts.Count();
            }
            if (pageSize > 50)
            {
                return BadRequest();

            }
            var totalPages = Math.Ceiling((double)countAlbums / pageSize);
            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = (int)totalPages;
            }

            
            var model = new ContactPageViewModel()
            {
                Search = search,
                CurrentPage = page,
                PageSize = page,
                TotalPages = (int)totalPages,
                Contacts = this.contacts.GetAll(page, pageSize, search)

            };
            
            return View(model);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {

            return View(contacts.GetContactById(id));
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contacts.Insert(model);
                    ViewBag.Success = "";
                    return View();
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            else
            {
                ViewBag.Failed = "";
                return View();
            }
           
        }

        // GET: Contacts/Edit
        public ActionResult Edit(int id)
        {
            return View(contacts.GetContactById(id));
        }

        // POST: Contacts/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contacts.Update(model);
                    return RedirectToAction(nameof(All));
                }
                catch (Exception ex)
                {

                    return View(ex.Message);
                }
            }
            else
            {
                ViewBag.Failed = "";
                return View();
            }
            

        }

        //GET: Contacts/Delete
        public ActionResult Delete(int id)
        {
            if (id==0)
            {
                return NotFound();
            }

            ContactViewModel contactToDelete =contacts.GetContactById(id);
            return View(contactToDelete);
        }

        // POST: Contacts/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contacts.Delete(id);
                    ViewBag.Success = "";
                    return View();
                }
                catch (Exception ex)
                {
                    return View(ex.Message);

                }
               
            }
            else
            {
                ViewBag.Failed = "This action could not be completed. Try again!";
                return View();
            }


        }
    }
}