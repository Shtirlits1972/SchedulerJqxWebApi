using System.ComponentModel.DataAnnotations;

namespace SchedulerJqxWebApi.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string NameLocation { get; set; } = string.Empty;

        [StringLength(50)]
        public string Color { get; set; } = "#0078D4";

        public override string ToString()
        {
            return $"Location(Id = {Id}, NameLocation = {NameLocation}, Color = {Color})";
        }
    }
}
