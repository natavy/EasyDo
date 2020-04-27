
namespace EasyDo.Data
{
    public class SendEmail
    {
        
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}
