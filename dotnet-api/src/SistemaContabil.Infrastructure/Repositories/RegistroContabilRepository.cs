using Microsoft.EntityFrameworkCore;
using SistemaContabil.Domain.Entities;
using SistemaContabil.Domain.Interfaces;
using SistemaContabil.Infrastructure.Data;

namespace SistemaContabil.Infrastructure.Repositories;

/// <summary>
/// Implementação do repositório de Registro Contábil
/// </summary>
public class RegistroContabilRepository : Repository<RegistroContabil>, IRegistroContabilRepository
{
    public RegistroContabilRepository(SistemaContabilDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RegistroContabil>> GetByContaAsync(int contaId)
    {
        return await _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .Where(rc => rc.ContaIdConta == contaId)
            .OrderByDescending(rc => rc.DataCriacao)
            .ToListAsync();
    }

    public async Task<IEnumerable<RegistroContabil>> GetByCentroCustoAsync(int centroCustoId)
    {
        return await _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .Where(rc => rc.CentroCustoIdCentroCusto == centroCustoId)
            .OrderByDescending(rc => rc.DataCriacao)
            .ToListAsync();
    }

    public async Task<IEnumerable<RegistroContabil>> GetByPeriodoAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .Where(rc => rc.DataCriacao >= dataInicio && rc.DataCriacao <= dataFim)
            .OrderByDescending(rc => rc.DataCriacao)
            .ToListAsync();
    }

    public async Task<IEnumerable<RegistroContabil>> GetByValorAsync(decimal valorMinimo, decimal valorMaximo)
    {
        return await _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .Where(rc => rc.Valor >= valorMinimo && rc.Valor <= valorMaximo)
            .OrderByDescending(rc => rc.DataCriacao)
            .ToListAsync();
    }

    public async Task<IEnumerable<RegistroContabil>> GetWithDetailsAsync()
    {
        return await _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .OrderByDescending(rc => rc.DataCriacao)
            .ToListAsync();
    }

    public async Task<RegistroContabil?> GetWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .FirstOrDefaultAsync(rc => rc.IdRegistroContabil == id);
    }

    public async Task<decimal> GetTotalByContaAsync(int contaId)
    {
        return await _dbSet
            .Where(rc => rc.ContaIdConta == contaId)
            .SumAsync(rc => rc.Valor);
    }

    public async Task<decimal> GetTotalByCentroCustoAsync(int centroCustoId)
    {
        return await _dbSet
            .Where(rc => rc.CentroCustoIdCentroCusto == centroCustoId)
            .SumAsync(rc => rc.Valor);
    }

    public async Task<decimal> GetTotalByPeriodoAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await _dbSet
            .Where(rc => rc.DataCriacao >= dataInicio && rc.DataCriacao <= dataFim)
            .SumAsync(rc => rc.Valor);
    }

    public async Task<IEnumerable<RegistroContabil>> GetOrderedByDataAsync(bool ascending = true)
    {
        var query = _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .AsQueryable();

        return ascending 
            ? await query.OrderBy(rc => rc.DataCriacao).ToListAsync()
            : await query.OrderByDescending(rc => rc.DataCriacao).ToListAsync();
    }

    public async Task<IEnumerable<RegistroContabil>> GetOrderedByValorAsync(bool ascending = true)
    {
        var query = _dbSet
            .Include(rc => rc.Conta)
            .Include(rc => rc.CentroCusto)
            .AsQueryable();

        return ascending 
            ? await query.OrderBy(rc => rc.Valor).ToListAsync()
            : await query.OrderByDescending(rc => rc.Valor).ToListAsync();
    }

    // Métodos da interface IRegistroContabilRepository
    public async Task<IEnumerable<RegistroContabil>> ObterPorContaAsync(int contaId)
    {
        return await GetByContaAsync(contaId);
    }

    public async Task<IEnumerable<RegistroContabil>> ObterPorCentroCustoAsync(int centroCustoId)
    {
        return await GetByCentroCustoAsync(centroCustoId);
    }

    public async Task<IEnumerable<RegistroContabil>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await GetByPeriodoAsync(dataInicio, dataFim);
    }

    public async Task<IEnumerable<RegistroContabil>> ObterPorValorAsync(decimal valorMinimo, decimal valorMaximo)
    {
        return await GetByValorAsync(valorMinimo, valorMaximo);
    }

    public async Task<IEnumerable<RegistroContabil>> ObterComDetalhesAsync()
    {
        return await GetWithDetailsAsync();
    }

    public async Task<RegistroContabil?> ObterComDetalhesAsync(int id)
    {
        return await GetWithDetailsAsync(id);
    }

    public async Task<decimal> CalcularTotalPorContaAsync(int contaId)
    {
        return await GetTotalByContaAsync(contaId);
    }

    public async Task<decimal> CalcularTotalPorCentroCustoAsync(int centroCustoId)
    {
        return await GetTotalByCentroCustoAsync(centroCustoId);
    }

    public async Task<decimal> CalcularTotalPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
    {
        return await GetTotalByPeriodoAsync(dataInicio, dataFim);
    }

    // Implementação dos métodos da interface para compatibilidade com serviços de domínio
    public async Task<RegistroContabil?> ObterPorIdAsync(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task<IEnumerable<RegistroContabil>> ObterTodosAsync()
    {
        return await GetAllAsync();
    }

    public async Task<RegistroContabil> AdicionarAsync(RegistroContabil entity)
    {
        return await AddAsync(entity);
    }

    public async Task<RegistroContabil> AtualizarAsync(RegistroContabil entity)
    {
        return await UpdateAsync(entity);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        return await RemoveByIdAsync(id);
    }
}
