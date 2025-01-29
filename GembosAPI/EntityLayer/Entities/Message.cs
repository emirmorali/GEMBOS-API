namespace GembosAPI.EntityLayer.Entities
{
    public class Message
    {
        public Guid ID { get; set; }
        public string Body { get; set; }

        public Guid SenderID { get; set; }
        public User Sender { get; set; }

        public Guid ReceiverID { get; set; }
        public User Receiver{ get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
