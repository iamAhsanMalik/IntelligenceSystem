namespace IFC.Application.Contracts.Persistence;

public interface ISeedDatabase
{
    Task DatabaseSeederAsync();
}