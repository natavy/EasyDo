
namespace EasyDo.Services.Events
{
    using EasyDo.Data;
    using EasyDo.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsService : IEventsService
    {
        private readonly EasyDoDbContext db;
        public EventsService(EasyDoDbContext db)
        {
            this.db = db;
        }

        public List<EventViewModel> GetAll()
        {
            if (this.db.Events == null)
            {
                throw new System.Exception("No contacts");
            }
            return this.db.Events
              .Select(t => new EventViewModel
              {
                  Id = t.Id,
                  Title = t.Title,
                  Description = t.Description,
                  Start = t.Start,
                  End = t.End,
                  ThemeColor = t.ThemeColor,
                  IsFullDay = t.IsFullDay,
              }).ToList();


        }

        public EventViewModel GetEventById(int id)
        {
            var eventView = db.Events.Where(c => c.Id == id).FirstOrDefault();
            return new EventViewModel
            {
                Id = eventView.Id
            };
        }

        public EventViewModel Insert(EventViewModel model)
        {
            Event eventView = new Event
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                ThemeColor = model.ThemeColor,
                IsFullDay = model.IsFullDay,
            };
            db.Events.Add(eventView);
            db.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            EventViewModel model = new EventViewModel();
            model.Id = id;
            var eventToDelete = db.Events.SingleOrDefault(c => c.Id == model.Id);

            if (eventToDelete != null)
            {
                db.Events.Remove(eventToDelete);
                db.SaveChanges();

            }
        }

        public void Details(EventViewModel model)
        {
            var evenDetail = db.Events.SingleOrDefault(c => c.Id == model.Id);
            evenDetail.Id = model.Id;
            evenDetail.Title = model.Title;
            evenDetail.Description = model.Description;
            evenDetail.Start = model.Start;
            evenDetail.End = model.End;
            evenDetail.ThemeColor = model.ThemeColor;
            evenDetail.IsFullDay = model.IsFullDay;
        }


        public void Update(EventViewModel model)
        {
            var eventToEdit = db.Events.SingleOrDefault(c => c.Id == model.Id);
            eventToEdit.Title = model.Title;
            eventToEdit.Description = model.Description;
            eventToEdit.Start = model.Start;
            eventToEdit.End = model.End;
            eventToEdit.ThemeColor = model.ThemeColor;
            eventToEdit.IsFullDay = model.IsFullDay;
            db.SaveChanges();
        }
    }
}
