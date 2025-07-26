using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ACPD_WebAPI.Services
{
    public class AcpdService
    {
        private readonly string _connectionString;

        public AcpdService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string ExecuteStoredProcedure(string spName, string jsonInput)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@JsonData", SqlDbType.NVarChar) { Value = jsonInput });

            var outputParam = new SqlParameter("@ReturnMessage", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            conn.Open();
            cmd.ExecuteNonQuery();
            return outputParam.Value?.ToString();
        }
    }
}
