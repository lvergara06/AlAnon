using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlAnonFront.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeetingType { get; set; }
        public string Area { get; set; }
        public string Address { get; set; } 
        public string Days { get; set; }
        public string Hours { get; set; }
        public string Alateen { get; set; }
        public string PhoneNumber { get; set; }
        public string RoomNumber { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

    }
}
