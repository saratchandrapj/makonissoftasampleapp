using Microsoft.Extensions.Configuration;
using sampleservices.Services;

namespace samplemanager.Manager
{
    public class FileHandler : AbstractFileHandler
    {
        private readonly string _filePath;
        public FileHandler(IConfiguration config) : base(config)
        {
            _filePath = getFilePath();
        }


        /// <summary>
        /// Reads all data from the file.
        /// </summary>
        /// <returns> string of file data.</returns>
        /// <exception cref="Exception">exception incase of file not exits</exception>
        public async override Task<string> ReadFile()
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
        public async override Task<bool> UpdateFile(string data)
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
