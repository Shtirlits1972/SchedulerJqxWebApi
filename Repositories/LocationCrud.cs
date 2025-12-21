using Dapper;
using Microsoft.Data.SqlClient;
using SchedulerJqxWebApi.Models;
using System.Data;

namespace SchedulerJqxWebApi.Crud
{
    public class LocationCrud
    {
        private static readonly string strConn = Ut.GetConnetString();
        public static List<Location> GetAll()
        {
            List<Location> list = new List<Location>();

            using (IDbConnection db = new SqlConnection(strConn))
            {
                list = db.Query<Location>("SELECT Id, NameLocation, [Color] FROM Location").ToList();
            }

            return list;
        }

        public static Location GetOne(int Id)
        {
            Location model = null;

            using (IDbConnection db = new SqlConnection(strConn))
            {
                model = db.Query<Location>("SELECT Id, NameLocation, [Color] FROM Location WHERE Id = @Id;", new { Id }).FirstOrDefault();
            }

            return model;
        }

        public static void Del(int Id)
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                db.Execute("DELETE FROM Location WHERE Id = @Id;", new { Id });
            }
        }

        public static void Update(Location model)
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                var Query = "UPDATE Location SET NameLocation = @NameLocation, Color = @Color WHERE Id = @Id;";
                db.Execute(Query, model);
            }
        }

        public static Location Insert(Location model)
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                var Query = "INSERT INTO Location (NameLocation, Color) VALUES(@NameLocation, @Color); SELECT CAST(SCOPE_IDENTITY() as int)";
                int Id = db.Query<int>(Query, model).FirstOrDefault();
                model.Id = Id;
            }

            return model;
        }
    }
}

