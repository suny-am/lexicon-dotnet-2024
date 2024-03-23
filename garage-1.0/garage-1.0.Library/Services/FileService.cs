using Microsoft.Extensions.Configuration;

namespace Garage_1_0.Library.Services;

public class FileService : IService
{
    private readonly IConfiguration _configuration;
    private readonly string _filePath;

    public FileService(IConfiguration configuration)
    {
        _configuration = configuration;
        _filePath = ConfigureFilePath(Configuration.GetRequiredSection("filePath").Value!);
    }

    private static string ConfigureFilePath(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        return filePath;
    }

    public IConfiguration Configuration => _configuration;
    public string FilePath => _filePath;

}