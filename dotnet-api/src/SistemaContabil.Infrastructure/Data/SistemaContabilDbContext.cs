using Microsoft.EntityFrameworkCore;
using SistemaContabil.Domain.Entities;

namespace SistemaContabil.Infrastructure.Data;

/// <summary>
/// Contexto do banco de dados para o sistema contábil
/// </summary>
public class SistemaContabilDbContext : DbContext
{
    public SistemaContabilDbContext(DbContextOptions<SistemaContabilDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Tabela de centros de custo
    /// </summary>
    public DbSet<CentroCusto> CentrosCusto { get; set; } = null!;

    /// <summary>
    /// Tabela de contas
    /// </summary>
    public DbSet<Conta> Contas { get; set; } = null!;

    /// <summary>
    /// Tabela de registros contábeis
    /// </summary>
    public DbSet<RegistroContabil> RegistrosContabeis { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da tabela CentroCusto
        modelBuilder.Entity<CentroCusto>(entity =>
        {
            entity.ToTable("CENTRO_CUSTO");
            entity.HasKey(e => e.IdCentroCusto);
            entity.Property(e => e.IdCentroCusto)
                .HasColumnName("ID_CENTRO_CUSTO")
                .HasColumnType("NUMBER(4)")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.NomeCentroCusto)
                .HasColumnName("NOME_CENTRO_CUSTO")
                .HasColumnType("VARCHAR2(70)")
                .IsRequired();

            // Relacionamento com registros contábeis
            entity.HasMany(e => e.RegistrosContabeis)
                .WithOne(e => e.CentroCusto)
                .HasForeignKey(e => e.CentroCustoIdCentroCusto)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuração da tabela Conta
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.ToTable("CONTA");
            entity.HasKey(e => e.IdConta);
            entity.Property(e => e.IdConta)
                .HasColumnName("ID_CONTA")
                .HasColumnType("NUMBER(4)")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.NomeConta)
                .HasColumnName("NOME_CONTA")
                .HasColumnType("VARCHAR2(70)")
                .IsRequired();
            entity.Property(e => e.Tipo)
                .HasColumnName("TIPO")
                .HasColumnType("CHAR(1)")
                .IsRequired();

            // Relacionamento com registros contábeis
            entity.HasMany(e => e.RegistrosContabeis)
                .WithOne(e => e.Conta)
                .HasForeignKey(e => e.ContaIdConta)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuração da tabela RegistroContabil
        modelBuilder.Entity<RegistroContabil>(entity =>
        {
            entity.ToTable("REGISTRO_CONTABIL");
            entity.HasKey(e => e.IdRegistroContabil);
            entity.Property(e => e.IdRegistroContabil)
                .HasColumnName("ID_REGISTRO_CONTABIL")
                .HasColumnType("NUMBER(4)")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("NUMBER(9,2)")
                .IsRequired();
            entity.Property(e => e.ContaIdConta)
                .HasColumnName("CONTA_ID_CONTA")
                .HasColumnType("NUMBER(4)")
                .IsRequired();
            entity.Property(e => e.CentroCustoIdCentroCusto)
                .HasColumnName("CENTRO_CUSTO_ID_CENTRO_CUSTO")
                .HasColumnType("NUMBER(4)")
                .IsRequired();
            entity.Property(e => e.DataCriacao)
                .HasColumnName("DATA_CRIACAO")
                .HasColumnType("DATE")
                .HasDefaultValueSql("SYSDATE");
            entity.Property(e => e.DataAtualizacao)
                .HasColumnName("DATA_ATUALIZACAO")
                .HasColumnType("DATE");

            // Relacionamentos
            entity.HasOne(e => e.Conta)
                .WithMany(e => e.RegistrosContabeis)
                .HasForeignKey(e => e.ContaIdConta)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.CentroCusto)
                .WithMany(e => e.RegistrosContabeis)
                .HasForeignKey(e => e.CentroCustoIdCentroCusto)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuração de índices para performance
        modelBuilder.Entity<RegistroContabil>()
            .HasIndex(e => e.ContaIdConta)
            .HasDatabaseName("IDX_REGISTRO_CONTABIL_CONTA");

        modelBuilder.Entity<RegistroContabil>()
            .HasIndex(e => e.CentroCustoIdCentroCusto)
            .HasDatabaseName("IDX_REGISTRO_CONTABIL_CENTRO_CUSTO");

        modelBuilder.Entity<RegistroContabil>()
            .HasIndex(e => e.DataCriacao)
            .HasDatabaseName("IDX_REGISTRO_CONTABIL_DATA_CRIACAO");

        // Configuração de sequências Oracle
        modelBuilder.HasSequence<int>("SEQ_CENTRO_CUSTO")
            .StartsAt(1)
            .IncrementsBy(1);

        modelBuilder.HasSequence<int>("SEQ_CONTA")
            .StartsAt(1)
            .IncrementsBy(1);

        modelBuilder.HasSequence<int>("SEQ_REGISTRO_CONTABIL")
            .StartsAt(1)
            .IncrementsBy(1);
    }
}
