
namespace EasyDo.Services.Events
{

    using EasyDo.Models;
    using System.Collections.Generic;
    public interface IEventsService
    {
        public List<EventViewModel> GetAll();
        public EventViewModel GetEventById(int id);
        public EventViewModel Insert(EventViewModel model);
        public void Update(EventViewModel model);
        public void Delete(int id);
        public void Details(EventViewModel model);
    }
}
