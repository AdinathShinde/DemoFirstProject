using Microsoft.Data.SqlClient;
using System.Data;

public class SqlFunctionExecutor
{
    private readonly IConfiguration _configuration;

    public SqlFunctionExecutor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<DataTable> ExecuteFunctionAsync(string functionName, Dictionary<string, string> parameters)
    {
        var dt = new DataTable();
        using var con = new SqlConnection(_configuration.GetConnectionString("shadimuharathConStr"));

        string paramList = string.Join(", ", parameters.Keys.Select(k => "@" + k));
        string query = $"SELECT * FROM {functionName}({paramList})";

        using var cmd = new SqlCommand(query, con);

        foreach (var param in parameters)
        {
            cmd.Parameters.AddWithValue("@" + param.Key, param.Value ?? (object)DBNull.Value);
        }

        await con.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();
        dt.Load(reader);  // Load is sync but acceptable after async call

        return dt;
    }
}
