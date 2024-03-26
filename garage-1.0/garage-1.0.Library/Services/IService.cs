namespace Garage_1_0.Library.Services;

using Microsoft.Extensions.Configuration;

public interface IService
{
    public IConfiguration Configuration { get; }
}