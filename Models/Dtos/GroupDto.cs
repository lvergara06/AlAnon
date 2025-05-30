using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlAnonFront.Models.Dtos
{
    public class GroupDto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Group name is necessary")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Meeting Type is necessary: InPerson, Hybrid, o Online")]
        public string MeetingType { get; set; }
        public string Area { get; set; }
        public string Address { get; set; } 
        [Required (ErrorMessage = "Meeting days is necessary")]
        public string Days { get; set; }
        [Required (ErrorMessage = "Meeting time is necessary")]
        public string Hours { get; set; }
        [Required(ErrorMessage = "Alanon or Alateen is necessary")]
        public string Alateen { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";
        public string RoomNumber { get; set; } = "";
        public string Password { get; set; } = "";
        public string Notes { get; set; } = "";

    }
}
