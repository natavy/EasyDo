
namespace EasyDo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Start { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
       
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }

    }
}
