
namespace EasyDo.Models
{
    using EasyDo.Data;

    public class EmailViewModel
    {
        
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}

