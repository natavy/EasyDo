
namespace EasyDo.Data
{
    using System;
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }


    }
}
