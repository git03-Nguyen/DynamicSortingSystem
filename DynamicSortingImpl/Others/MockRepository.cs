using DynamicSortingImpl.Entities;

namespace DynamicSortingImpl.Others;

public interface IMockRepository
{
    IQueryable<AbcModel> GetMockData();
}

public class MockRepository : IMockRepository
{
    private readonly AbcModel[] _mockData = new[]
    {
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Alice",
            Age = 28,
            CreatedAt = DateTime.Now.AddDays(-10),
            UpdatedAt = DateTime.Now.AddDays(-5),
            IsActive = true
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Bob",
            Age = 34,
            CreatedAt = DateTime.Now.AddDays(-20),
            UpdatedAt = DateTime.Now.AddDays(-10),
            IsActive = true
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Charlie",
            Age = 22,
            CreatedAt = DateTime.Now.AddDays(-15),
            UpdatedAt = DateTime.Now.AddDays(-7),
            IsActive = false
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "David",
            Age = 40,
            CreatedAt = DateTime.Now.AddDays(-5),
            UpdatedAt = DateTime.Now.AddDays(-2),
            IsActive = true
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Eva",
            Age = 31,
            CreatedAt = DateTime.Now.AddDays(-8),
            UpdatedAt = DateTime.Now.AddDays(-4),
            IsActive = false
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Frank",
            Age = 45,
            CreatedAt = DateTime.Now.AddDays(-30),
            UpdatedAt = DateTime.Now.AddDays(-15),
            IsActive = true
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Grace",
            Age = 29,
            CreatedAt = DateTime.Now.AddDays(-12),
            UpdatedAt = DateTime.Now.AddDays(-6),
            IsActive = false
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Hank",
            Age = 50,
            CreatedAt = DateTime.Now.AddDays(-1),
            UpdatedAt = DateTime.Now,
            IsActive = true
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Ivy",
            Age = 37,
            CreatedAt = DateTime.Now.AddDays(-25),
            UpdatedAt = DateTime.Now.AddDays(-12),
            IsActive = true
        },
        new AbcModel 
        {
            Id = Guid.NewGuid(),
            Name = "Jack",
            Age = 24,
            CreatedAt = DateTime.Now.AddDays(-3),
            UpdatedAt = DateTime.Now.AddDays(-1),
            IsActive = false
        }
    };
    
    public IQueryable<AbcModel> GetMockData()
    {
        return _mockData.AsQueryable();
    }
}