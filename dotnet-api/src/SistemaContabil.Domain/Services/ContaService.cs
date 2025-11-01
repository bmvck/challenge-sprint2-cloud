using SistemaContabil.Domain.Entities;
using SistemaContabil.Domain.Interfaces;

namespace SistemaContabil.Domain.Services;

/// <summary>
/// Serviço de domínio para Conta
/// </summary>
public class ContaService : IContaService
{
    private readonly IContaRepository _repository;
    private readonly IRegistroContabilRepository _registroRepository;

    public ContaService(IContaRepository repository, IRegistroContabilRepository registroRepository)
    {
        _repository = repository;
        _registroRepository = registroRepository;
    }

    public async Task<Conta> CriarAsync(string nome, char tipo)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome da conta é obrigatório", nameof(nome));

        if (nome.Length > 70)
            throw new ArgumentException("Nome da conta deve ter no máximo 70 caracteres", nameof(nome));

        if (tipo != 'D' && tipo != 'C')
            throw new ArgumentException("Tipo da conta deve ser 'D' (Débito) ou 'C' (Crédito)", nameof(tipo));

        // Verificar se já existe uma conta com o mesmo nome
        var existente = await _repository.BuscarPorNomeAsync(nome);
        if (existente.Any())
            throw new ArgumentException("Já existe uma conta com este nome", nameof(nome));

        var conta = new Conta
        {
            NomeConta = nome.Trim(),
            Tipo = tipo
        };

        return await _repository.AdicionarAsync(conta);
    }

    public async Task<Conta> AtualizarAsync(int id, string nome, char tipo)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome da conta é obrigatório", nameof(nome));

        if (nome.Length > 70)
            throw new ArgumentException("Nome da conta deve ter no máximo 70 caracteres", nameof(nome));

        if (tipo != 'D' && tipo != 'C')
            throw new ArgumentException("Tipo da conta deve ser 'D' (Débito) ou 'C' (Crédito)", nameof(tipo));

        var conta = await _repository.ObterPorIdAsync(id);
        if (conta == null)
            throw new InvalidOperationException($"Conta com ID {id} não encontrada");

        // Verificar se já existe outra conta com o mesmo nome
        var existente = await _repository.BuscarPorNomeAsync(nome);
        if (existente.Any(c => c.IdConta != id))
            throw new ArgumentException("Já existe outra conta com este nome", nameof(nome));

        conta.NomeConta = nome.Trim();
        conta.Tipo = tipo;
        return await _repository.AtualizarAsync(conta);
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var conta = await _repository.ObterPorIdAsync(id);
        if (conta == null)
            throw new InvalidOperationException($"Conta com ID {id} não encontrada");

        // Verificar se pode ser removida (não possui registros contábeis)
        var podeSerRemovida = await PodeSerRemovidaAsync(id);
        if (!podeSerRemovida)
            throw new InvalidOperationException("Conta não pode ser removida pois possui registros contábeis");

        return await _repository.RemoverAsync(id);
    }

    public async Task<Conta?> ObterPorIdAsync(int id)
    {
        return await _repository.ObterPorIdAsync(id);
    }

    public async Task<IEnumerable<Conta>> ObterTodasAsync()
    {
        return await _repository.ObterTodosAsync();
    }

    public async Task<IEnumerable<Conta>> ObterPorTipoAsync(char tipo)
    {
        if (tipo != 'D' && tipo != 'C')
            throw new ArgumentException("Tipo da conta deve ser 'D' (Débito) ou 'C' (Crédito)", nameof(tipo));

        return await _repository.ObterPorTipoAsync(tipo);
    }

    public async Task<IEnumerable<Conta>> BuscarPorNomeAsync(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return Enumerable.Empty<Conta>();

        return await _repository.BuscarPorNomeAsync(nome);
    }

    public async Task<IEnumerable<Conta>> ObterContasDebitoAsync()
    {
        return await _repository.ObterPorTipoAsync('D');
    }

    public async Task<IEnumerable<Conta>> ObterContasCreditoAsync()
    {
        return await _repository.ObterPorTipoAsync('C');
    }

    public async Task<bool> PodeSerRemovidaAsync(int id)
    {
        var registros = await _registroRepository.ObterPorContaAsync(id);
        return !registros.Any();
    }

    public async Task<IEnumerable<Conta>> ObterComRegistrosAsync()
    {
        var todas = await _repository.ObterTodosAsync();
        var comRegistros = new List<Conta>();

        foreach (var conta in todas)
        {
            var registros = await _registroRepository.ObterPorContaAsync(conta.IdConta);
            if (registros.Any())
            {
                comRegistros.Add(conta);
            }
        }

        return comRegistros;
    }
}
