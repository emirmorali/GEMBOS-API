using System.ComponentModel.DataAnnotations;

namespace GembosAPI.EntityLayer.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Sender { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }

        public bool IsSynced { get; set; } = true;
    }
}
