using System.ComponentModel.DataAnnotations;

namespace SchedulerJqxWebApi.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string NameLocation { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Location(Id = {Id}, NameLocation = {NameLocation})";
        }
    }
}
