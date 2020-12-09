using Dapper;
using DocumentService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcGreeter.DatabaseHelper
{
    public class DocumentDapper
    {
        private string tableName = "[dbo].[EDM_Document]";

        public SqlConnection GetConnection()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=SMART_Amaris;integrated security=True;MultipleActiveResultSets=True;App=WebDav_App providerName = System.Data.EntityClient />";
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        public List<Document> GetDocument()
        {
            var connection = GetConnection();
            connection.Open();
            var query = $"select top 10 DocumentId, Label as DocumentName from {tableName}";
            var data = connection.QueryAsync<Document>(query).Result.ToList();
            return data;
        }
    }
}
