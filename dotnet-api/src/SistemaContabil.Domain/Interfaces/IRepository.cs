using System.Linq.Expressions;

namespace SistemaContabil.Domain.Interfaces;

/// <summary>
/// Interface genérica para repositórios
/// </summary>
/// <typeparam name="T">Tipo da entidade</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Obtém uma entidade por ID
    /// </summary>
    /// <param name="id">ID da entidade</param>
    /// <returns>Entidade encontrada ou null</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Obtém todas as entidades
    /// </summary>
    /// <returns>Lista de entidades</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Obtém entidades baseado em uma condição
    /// </summary>
    /// <param name="predicate">Condição para filtrar</param>
    /// <returns>Lista de entidades que atendem à condição</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Obtém a primeira entidade que atende à condição
    /// </summary>
    /// <param name="predicate">Condição para filtrar</param>
    /// <returns>Primeira entidade encontrada ou null</returns>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Adiciona uma nova entidade
    /// </summary>
    /// <param name="entity">Entidade a ser adicionada</param>
    /// <returns>Entidade adicionada</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Atualiza uma entidade existente
    /// </summary>
    /// <param name="entity">Entidade a ser atualizada</param>
    /// <returns>Entidade atualizada</returns>
    Task<T> UpdateAsync(T entity);

    /// <summary>
    /// Remove uma entidade
    /// </summary>
    /// <param name="entity">Entidade a ser removida</param>
    /// <returns>True se removida com sucesso</returns>
    Task<bool> RemoveAsync(T entity);

    /// <summary>
    /// Remove uma entidade por ID
    /// </summary>
    /// <param name="id">ID da entidade a ser removida</param>
    /// <returns>True se removida com sucesso</returns>
    Task<bool> RemoveByIdAsync(int id);

    /// <summary>
    /// Verifica se existe uma entidade com o ID especificado
    /// </summary>
    /// <param name="id">ID da entidade</param>
    /// <returns>True se existe, False caso contrário</returns>
    Task<bool> ExistsAsync(int id);

    /// <summary>
    /// Conta o número de entidades
    /// </summary>
    /// <returns>Número total de entidades</returns>
    Task<int> CountAsync();

    /// <summary>
    /// Conta o número de entidades baseado em uma condição
    /// </summary>
    /// <param name="predicate">Condição para filtrar</param>
    /// <returns>Número de entidades que atendem à condição</returns>
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
}
