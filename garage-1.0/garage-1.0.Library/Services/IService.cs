using Microsoft.Extensions.Configuration;

namespace Garage_1_0.Library.Services;

public interface IService
{
    public IConfiguration Configuration { get; }
}