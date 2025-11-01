using Microsoft.EntityFrameworkCore;
using SistemaContabil.Domain.Entities;
using SistemaContabil.Domain.Interfaces;
using SistemaContabil.Infrastructure.Data;

namespace SistemaContabil.Infrastructure.Repositories;

/// <summary>
/// Implementação do repositório de Conta
/// </summary>
public class ContaRepository : Repository<Conta>, IContaRepository
{
    public ContaRepository(SistemaContabilDbContext context) : base(context)
    {
    }

    public async Task<Conta?> GetByNomeAsync(string nome)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.NomeConta == nome);
    }

    public async Task<bool> ExistsByNomeAsync(string nome, int? excludeId = null)
    {
        var query = _dbSet.Where(c => c.NomeConta == nome);
        
        if (excludeId.HasValue)
        {
            query = query.Where(c => c.IdConta != excludeId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<IEnumerable<Conta>> GetByTipoAsync(char tipo)
    {
        return await _dbSet
            .Where(c => c.Tipo == tipo)
            .OrderBy(c => c.NomeConta)
            .ToListAsync();
    }

    public async Task<IEnumerable<Conta>> SearchByNomeAsync(string texto)
    {
        return await _dbSet
            .Where(c => c.NomeConta.Contains(texto))
            .OrderBy(c => c.NomeConta)
            .ToListAsync();
    }

    public async Task<IEnumerable<Conta>> GetWithRegistrosAsync()
    {
        return await _dbSet
            .Include(c => c.RegistrosContabeis)
            .Where(c => c.RegistrosContabeis.Any())
            .OrderBy(c => c.NomeConta)
            .ToListAsync();
    }

    public async Task<Conta?> GetWithRegistrosAsync(int id)
    {
        return await _dbSet
            .Include(c => c.RegistrosContabeis)
            .ThenInclude(rc => rc.CentroCusto)
            .FirstOrDefaultAsync(c => c.IdConta == id);
    }

    public async Task<IEnumerable<Conta>> GetContasDebitoAsync()
    {
        return await GetByTipoAsync('D');
    }

    public async Task<IEnumerable<Conta>> GetContasCreditoAsync()
    {
        return await GetByTipoAsync('C');
    }

    // Métodos da interface IContaRepository
    public async Task<IEnumerable<Conta>> BuscarPorNomeAsync(string nome)
    {
        return await SearchByNomeAsync(nome);
    }

    public async Task<IEnumerable<Conta>> ObterPorTipoAsync(char tipo)
    {
        return await GetByTipoAsync(tipo);
    }

    public async Task<IEnumerable<Conta>> ObterContasDebitoAsync()
    {
        return await GetContasDebitoAsync();
    }

    public async Task<IEnumerable<Conta>> ObterContasCreditoAsync()
    {
        return await GetContasCreditoAsync();
    }

    public async Task<IEnumerable<Conta>> ObterComRegistrosAsync()
    {
        return await GetWithRegistrosAsync();
    }

    // Implementação dos métodos da interface para compatibilidade com serviços de domínio
    public async Task<Conta?> ObterPorIdAsync(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task<IEnumerable<Conta>> ObterTodosAsync()
    {
        return await GetAllAsync();
    }

    public async Task<Conta> AdicionarAsync(Conta entity)
    {
        return await AddAsync(entity);
    }

    public async Task<Conta> AtualizarAsync(Conta entity)
    {
        return await UpdateAsync(entity);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await RemoveByIdAsync(id);
    }
}
