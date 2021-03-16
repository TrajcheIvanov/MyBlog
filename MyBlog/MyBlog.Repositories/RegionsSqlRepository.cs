using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyBlog.Repositories
{
    public class RegionsSqlRepository : IRegionsRepository
    {
        public void Add(Region region)
        {
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = @"insert into Regions(Name, Location, PointsOFInterest, ExternalLink) 
                               values(@Name, @Location, @PointsOfInterest, @ExternalLink)";

                var cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@Name", region.Name);
                cmd.Parameters.AddWithValue("@Location", region.Location);
                cmd.Parameters.AddWithValue("@PointsOfInterest", region.PointsOfInterest);
                cmd.Parameters.AddWithValue("@ExternalLink", region.ExternalLink);
               
                cmd.ExecuteNonQuery();
            }
        }

        public List<Region> GetAll()
        {
            var result = new List<Region>();

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = "Select * from Regions";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var region = new Region();

                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);
                    region.Location = reader.GetString(2);
                    region.PointsOfInterest = reader.GetString(3);
                    region.ExternalLink = reader.GetString(4);
                    

                    result.Add(region);
                }

            }

            return result;
        }

        public Region GetById(int id)
        {
            Region result = null;

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyBlogSql;Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = @"Select * from Regions where id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Region();

                    result.Id = reader.GetInt32(0);
                    result.Name = reader.GetString(1);
                    result.Location = reader.GetString(2);
                    result.PointsOfInterest = reader.GetString(3);
                    result.ExternalLink = reader.GetString(4);
                }

            }

            return result;
        }
    }
}
