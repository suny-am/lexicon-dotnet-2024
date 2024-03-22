namespace Garage_1_0.Library.Exceptions.RepositoryExceptions;

public class RepositoryInvalidDataSourceException(object dataSource) : Exception
{
    private object _dataSource = dataSource;
    public override string Message => $"Source {_dataSource.GetType().Name}";
}