namespace GembosAPI.EntityLayer.DTOs
{
    public class CreateMessageDTO
    {
        public string Body { get; set; }
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
    }
}
