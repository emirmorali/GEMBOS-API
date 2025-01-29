namespace GembosAPI.EntityLayer.DTOs
{
    public class MessageDTO
    {
        public Guid ID { get; set; }
        public string Body { get; set; }
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
