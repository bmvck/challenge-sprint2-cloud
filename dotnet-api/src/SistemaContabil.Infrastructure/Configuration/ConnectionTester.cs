using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Logging;

namespace SistemaContabil.Infrastructure.Configuration;

/// <summary>
/// Testador de conexões Oracle
/// </summary>
public static class ConnectionTester
{
    /// <summary>
    /// Testa todas as strings de conexão e retorna a primeira que funciona
    /// </summary>
    /// <param name="logger">Logger para registrar resultados (opcional)</param>
    /// <returns>String de conexão que funciona ou null se nenhuma funcionar</returns>
    public static async Task<string?> TestConnectionsAsync(ILogger? logger = null)
    {
        foreach (var connectionString in DatabaseConfiguration.ConnectionStrings)
        {
            try
            {
                logger?.LogInformation("Testando conexão: {ConnectionString}", 
                    connectionString.Replace("Password=AppPass#2025;", "Password=***;"));

                using var connection = new OracleConnection(connectionString);
                await connection.OpenAsync();
                
                logger?.LogInformation("✅ Conexão bem-sucedida!");
                return connectionString;
            }
            catch (Exception ex)
            {
                logger?.LogWarning("❌ Falha na conexão: {Error}", ex.Message);
            }
        }

        logger?.LogError("❌ Nenhuma string de conexão funcionou!");
        return null;
    }

    /// <summary>
    /// Testa uma string de conexão específica
    /// </summary>
    /// <param name="connectionString">String de conexão para testar</param>
    /// <param name="logger">Logger para registrar resultados</param>
    /// <returns>True se a conexão funcionar</returns>
    public static async Task<bool> TestConnectionAsync(string connectionString, ILogger? logger = null)
    {
        try
        {
            logger?.LogInformation("Testando conexão: {ConnectionString}", 
                connectionString.Replace("Password=AppPass#2025;", "Password=***;"));

            using var connection = new OracleConnection(connectionString);
            await connection.OpenAsync();
            
            logger?.LogInformation("✅ Conexão bem-sucedida!");
            return true;
        }
        catch (Exception ex)
        {
            logger?.LogWarning("❌ Falha na conexão: {Error}", ex.Message);
            return false;
        }
    }
}
