using Microsoft.Extensions.Configuration;

namespace sampleservices.Services
{
    public abstract class AbstractFileHandler
    {
        private readonly IConfiguration _config;
        private readonly string _filePath;
        protected AbstractFileHandler(IConfiguration config)
        {
            _config = config;
            _filePath = Path.Combine(Environment.CurrentDirectory, _config.GetRequiredSection("JsonFilePath").Value?.ToString() ?? string.Empty);

            if (!string.IsNullOrEmpty(_filePath) && !File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }
        public abstract Task<string> ReadFile();
        public abstract Task<bool> UpdateFile(string data);

        protected string getFilePath()
        {
            return _filePath;
        }
        
    }
}
