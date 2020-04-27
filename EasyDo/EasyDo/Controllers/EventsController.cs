using EasyDo.Services.Events;
using Microsoft.AspNetCore.Mvc;


namespace EasyDo.Controllers
{
    public class EventsController : Controller
    {
        
        private readonly IEventsService events;
        public EventsController(IEventsService events)
        {
           
            this.events = events;
        }
        public IActionResult Index()
        {
            
            return View();

        }

        public IActionResult GetEvents()
        {
            var events = this.events.GetAll();
            return Json(events);
          
        }
    }
}