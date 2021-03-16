using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyBlog.Repositories
{
    public class EventsSqlRepository : IEventsRepository
    {
        public void Add(Event even)
        {
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = @"insert into events(Name, Location, Date, Description, OrganizedBy, ImgUrl) 
                               values(@Name, @Location, @Date, @Description, @OrganizedBy, @ImgUrl)";

                var cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@Name", even.Name);
                cmd.Parameters.AddWithValue("@Location", even.Location);
                cmd.Parameters.AddWithValue("@Date", even.Date);
                cmd.Parameters.AddWithValue("@Description", even.Description);
                cmd.Parameters.AddWithValue("@OrganizedBy", even.OrganizedBy);
                cmd.Parameters.AddWithValue("@ImgUrl", even.ImgUrl);


                cmd.ExecuteNonQuery();

            }
        }

        public List<Event> GetAll()
        {
            var result = new List<Event>();

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = "Select * from Events";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var even = new Event();

                    even.Id = reader.GetInt32(0);
                    even.Name = reader.GetString(1);
                    even.Location = reader.GetString(2);
                    even.Date = reader.GetString(3);
                    even.Description = reader.GetString(4);
                    even.OrganizedBy = reader.GetString(5);
                    even.ImgUrl = reader.GetString(6);

                    result.Add(even);
                }

            }

            return result;
        }

        public Event GetById(int id)
        {
            Event result = null;

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = @"Select * from Events where id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id",id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Event();

                    result.Id = reader.GetInt32(0);
                    result.Name = reader.GetString(1);
                    result.Location = reader.GetString(2);
                    result.Date = reader.GetString(3);
                    result.Description = reader.GetString(4);
                    result.OrganizedBy = reader.GetString(5);
                    result.ImgUrl = reader.GetString(6);
                }
                
            }

            return result;
        }
    }
}
