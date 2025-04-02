using LM.BussinessLayer.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LM.DataAccessLayer.Repository
{
    public class BooksRepo : IBooksRepo
    {
        private readonly string _connstring = "Server = localhost; Database=LM; Integrated Security=True; TrustServerCertificate=True";
        public int Create(Books book)
        {
            SqlConnection conn = new SqlConnection(_connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("CreateEntry", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@BookAuthor", book.BookAuthor);
            cmd.Parameters.AddWithValue("@CreatedBy", book.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", book.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@IsAvailable", book.IsAvailable? 1 : 0);
            var result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public List<Books> List()
        {
            List<Books> list= new List<Books>();
            SqlConnection conn = new SqlConnection(_connstring);
            SqlCommand cmd = new SqlCommand("ReadEntry", conn);
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                list.Add(new Books
                {
                    BookId = Convert.ToInt32(reader["BookId"]),
                    BookName = Convert.ToString(reader["BookName"]),
                    BookAuthor = Convert.ToString(reader["BookAuthor"]),
                    IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                    CreatedOn = Convert.ToDateTime(reader["CreatedOn"]),
                    UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"])

                });

            }
            return list;
        }
        public int Update(Books book)
        {
           SqlConnection conn = new SqlConnection(_connstring);
           conn.Open();
           SqlCommand cmd = new SqlCommand("UpdateEntry", conn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", book.BookId);
            cmd.Parameters.AddWithValue("@BookName", book.BookName);
            cmd.Parameters.AddWithValue("@BookAuthor", book.BookAuthor);
            cmd.Parameters.AddWithValue("@IsAvailable", book.IsAvailable);
            cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@UpdatedBy", book.UpdatedBy);
            return cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(_connstring);
            SqlCommand cmd = new SqlCommand("DeleteEntry", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
