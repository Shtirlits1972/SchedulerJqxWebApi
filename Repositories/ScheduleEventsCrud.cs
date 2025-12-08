using Dapper;
using Microsoft.Data.SqlClient;
using SchedulerJqxWebApi.Models;
using System.Data;

namespace SchedulerJqxWebApi.Repositories
{
    public class ScheduleEventsCrud
    {
        private static readonly string strConn = Ut.GetConnetString();

        public static List<ScheduleEvents> GetAll(DateTime? dateNow)
        {
            List<ScheduleEvents> list = new List<ScheduleEvents>();

            try
            {
                if (dateNow == null)
                {
                    dateNow = DateTime.Now;
                }

                // Исправлено: используем dateNow.Value для доступа к Year и Month
                DateTime startDate = new DateTime(dateNow.Value.Year, dateNow.Value.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                using (IDbConnection db = new SqlConnection(strConn))
                {
                    list = db.Query<ScheduleEvents>(
                        "SELECT Id, masterID, MasterName, locationID, NameLocation, start_event, DurationTime FROM ScheduleEventsView   WHERE start_event BETWEEN @startDate AND @endDate", new { startDate, endDate}
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            return list;
        }

        public static ScheduleEvents GetOne(int Id)
        {
            ScheduleEvents model = null;

            using (IDbConnection db = new SqlConnection(strConn))
            {
                model = db.Query<ScheduleEvents>(
                    "SELECT Id, masterID, MasterName, locationID, NameLocation, start_event, DurationTime FROM ScheduleEventsView WHERE Id = @Id;",
                    new { Id }
                ).FirstOrDefault();
            }

            return model;
        }

        public static void Del(int Id)
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                db.Execute("DELETE FROM ScheduleEvents WHERE Id = @Id;", new { Id });
            }
        }

        public static void Update(ScheduleEvents model)
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                var Query = @"
                    UPDATE ScheduleEvents
                    SET masterID = @masterID,
                        locationID = @locationID,
                        start_event = @start_event,
                        DurationTime = @DurationTime
                    WHERE Id = @Id;";
                db.Execute(Query, model);
            }
        }

        public static ScheduleEvents Insert(ScheduleEvents model)
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                var Query = @"
                    INSERT INTO ScheduleEvents (masterID, locationID, start_event, DurationTime)
                    VALUES (@masterID, @locationID, @start_event, @DurationTime);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                int Id = db.Query<int>(Query, model).FirstOrDefault();
                model.Id = Id;
            }

            return model;
        }
    }
}
