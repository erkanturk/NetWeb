using _17_Ado.Net.Models;
using Microsoft.Data.SqlClient;

namespace _17_Ado.Net.DbService.Abstract
{
    public interface IDbService
    {
        void ExecuteNonQuery(string query);//Sql tarafın (Insert(Create),Update,Delete)
        void ExecuteNonQuery(string query, SqlParameter[] parameters);
        List<Students> ExecuteReader(string query);//Select Sorgusunu çalıştırır
        object ExecuteScalar(string query);//Aggregate funct yapılarını döndürür Count Sum Avg Max Min 

    }
}
