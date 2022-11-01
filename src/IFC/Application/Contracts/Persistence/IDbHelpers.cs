namespace IFC.Application.Contracts.Persistence;

public interface IDbHelpers
{
    Task<int> BulkDeleteAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "SqlServerConnection");
    Task<int> BulkDeleteByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "SqlServerConnection");
    Task<int> BulkInsertAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "SqlServerConnection");
    Task<int> BulkInsertByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "SqlServerConnection");
    Task<int> BulkUpdateAsync<InputParemeters>(string sqlQuery, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "SqlServerConnection");
    Task<int> BulkUpdateByStoreProcedureAsync<InputParemeters>(string storeProcedureName, IEnumerable<InputParemeters>? inputParameters = null, string connectionStringName = "SqlServerConnection");
    Task<int> DeleteOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<int> DeleteOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<List<ReturnType>> GetAllAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<List<ReturnType>> GetAllAsync<ReturnType>(string sqlQuery, string connectionStringName = "SqlServerConnection");
    Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<List<ReturnType>> GetAllByStoreProcedureAsync<ReturnType>(string storeProcedureName, string connectionStringName = "SqlServerConnection");
    Task<ReturnType> GetOneAsync<ReturnType, InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<ReturnType> GetOneAsync<ReturnType>(string sqlQuery, string connectionStringName = "SqlServerConnection");
    Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType, InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<ReturnType> GetOneByStoreProcedureAsync<ReturnType>(string storeProcedureName, string connectionStringName = "SqlServerConnection");
    Task<int> InsertOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<int> InsertOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<int> UpdateOneAsync<InputParemeters>(string sqlQuery, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
    Task<int> UpdateOneByStoreProcedureAsync<InputParemeters>(string storeProcedureName, InputParemeters? inputParameters = default, string connectionStringName = "SqlServerConnection");
}