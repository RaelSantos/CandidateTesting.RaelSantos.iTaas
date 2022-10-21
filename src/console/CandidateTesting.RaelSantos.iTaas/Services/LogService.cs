namespace CandidateTesting.RaelSantos.iTaas.Services
{
    public interface ILogService
    {
        string GetAll();
    }

    public class LogService : ILogService
    {
        private readonly HttpClient _httpClient;

        public LogService(string sourcePath)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(sourcePath);
        }

        public string GetAll()
        {
            try
            {
                return _httpClient.GetStringAsync("").Result;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
