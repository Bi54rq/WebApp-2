using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

    }
}
