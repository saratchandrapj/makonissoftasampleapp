namespace samplewebapi.Services
{
    public class FileHandler : IFileHandler
    {
        private readonly IConfiguration _config;
        private readonly string _filePath;
        public FileHandler(IConfiguration config)
        {
            _config = config;
            _filePath = Path.Combine(Environment.CurrentDirectory, _config.GetValue<string>("JsonFilePath"));

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
            }
        }

        /// <summary>
        /// Reads all data from the file.
        /// </summary>
        /// <returns> string of file data.</returns>
        /// <exception cref="Exception">exception incase of file not exits</exception>
        public async Task<string> ReadFile()
        {
            if (File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
            else
            {
                throw new Exception("File Not Exits");
            }
        }

        /// <summary>
        /// updates the file with data
        /// </summary>
        /// <param name="data">data to be inserted into file</param>
        /// <returns>true if success : false if fails</returns>
        public async Task<bool> UpdateFile(string data)
        {
            try
            {
                File.WriteAllText(_filePath, data);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
