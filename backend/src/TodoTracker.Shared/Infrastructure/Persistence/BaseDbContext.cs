using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TodoTracker.Shared.Domain;

namespace TodoTracker.Shared.Infrastructure.Persistence;

public abstract class BaseDbContext : DbContext
{
    private IDbContextTransaction? _currentTransaction;
    
    protected BaseDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        AddAuditableConfiguration(modelBuilder);
    }

    private void AddAuditableConfiguration(ModelBuilder modelBuilder)
    {
        var types = modelBuilder.Model.GetEntityTypes()
            .Where(x => x.ClrType.IsAssignableFrom(typeof(IHaveAudit)));
        
        foreach (var entityType in types)
        {
            modelBuilder.Entity(entityType.ClrType).Property<string>("CreatedBy");
            modelBuilder.Entity(entityType.ClrType).Property<DateTimeOffset>("CreatedDate");
                
            modelBuilder.Entity(entityType.ClrType).Property<string>("LastModifiedBy");
            modelBuilder.Entity(entityType.ClrType).Property<DateTimeOffset?>("LastModifiedDate");
        }
    }

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            return;
        }

        _currentTransaction = await Database.BeginTransactionAsync();
    }
    
    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await SaveChangesAsync();
            await (_currentTransaction?.CommitAsync() ?? Task.CompletedTask);
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await (_currentTransaction?.RollbackAsync(cancellationToken) ?? Task.CompletedTask);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during transaction rollback: {ex.Message}");
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}