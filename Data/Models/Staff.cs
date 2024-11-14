using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Models
{
    public class Staff
    {
        [Key]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public ICollection<Programme> ProgrammeLeaderships { get; } = new List<Programme>();
    }
}
