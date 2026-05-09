using _17_Ado.Net.DbService.Abstract;
using _17_Ado.Net.Models;
using Microsoft.Data.SqlClient;

namespace _17_Ado.Net.DbService.Concrete
{
    public class DbService : IDbService
    {
        private readonly string _context;
        public DbService(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine("Bağlantı başarılı");
        }
        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SqlConnection(_context))//Sql bağlantı dizisi
            {
                using (var command = new SqlCommand(query, connection))//Sql sorgusu ve bağlantı yapısı
                {
                    connection.Open();//Bağlantıyı aç
                    command.ExecuteNonQuery();//İşlemleri başlat
                }
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_context))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Students> ExecuteReader(string query)
        {
            var result=new List<Students>();
            using (var connection = new SqlConnection(_context))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var model = new Students()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Age = Convert.ToInt32(reader["Age"])
                            };
                            result.Add(model);
                        }
                    }
                }
            }
            return result;
        }

        public object ExecuteScalar(string query)
        {
            using (var connection = new SqlConnection(_context))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
