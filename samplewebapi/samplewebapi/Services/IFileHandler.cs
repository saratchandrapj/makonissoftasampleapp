namespace samplewebapi.Services
{
    public interface IFileHandler
    {
        public Task<string> ReadFile();
        public Task<bool> UpdateFile(string data);
    }
}
