using System.ComponentModel.DataAnnotations;

namespace SchedulerJqxWebApi.Models
{
    public class ScheduleEvents
    {
        [Key]
        public int Id { get; set; }

        public int MasterId { get; set; }

        [StringLength(250)]
        public string MasterName { get; set; } = string.Empty;

        public int LocationId { get; set; }

        [StringLength(250)]
        public string NameLocation { get; set; } = string.Empty;

        public DateTime start_event { get; set; }

        public TimeSpan DurationTime { get; set; }

        public override string ToString()
        {
            return $"ScheduleEvents(Id = {Id}, MasterId = {MasterId}, MasterName = \"{MasterName}\", LocationId = {LocationId}, NameLocation = \"{NameLocation}\", StartEvent = {start_event:O}, DurationTime = {DurationTime})";
        }
    }
}
