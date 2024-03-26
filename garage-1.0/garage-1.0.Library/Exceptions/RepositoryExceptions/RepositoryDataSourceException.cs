namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

public class RepositoryDataSourceException(object dataSource) : Exception
{
    private object _dataSource = dataSource;
    public override string Message => $"Invalid Source {_dataSource.GetType().Name}";
}