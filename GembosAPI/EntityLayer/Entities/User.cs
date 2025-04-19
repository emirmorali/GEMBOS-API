using System.ComponentModel.DataAnnotations;

namespace GembosAPI.EntityLayer.Entities
{
    public class User
    {
        [Key]
        public string PhoneNumber { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
