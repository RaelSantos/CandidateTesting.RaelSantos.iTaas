using System.Globalization;

namespace CandidateTesting.RaelSantos.iTaas.Domain
{
    public interface ILogMinhaCDNService
    {
        public List<LogMinhaCDN> Converter(string[] data);
    }

    public class LogMinhaCDN : ILogMinhaCDNService
    {
        public int Id { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Endpoint { get; set; }
        public double Size { get; set; }

        public List<LogMinhaCDN> Converter(string[] data)
        {
            var logsMinhaCDN = new List<LogMinhaCDN>();

            foreach (var item in data)
            {
                var _logMinhaCDN = new LogMinhaCDN();
                _logMinhaCDN = item;
                logsMinhaCDN.Add(_logMinhaCDN);
            }

            return logsMinhaCDN;
        }

        public static implicit operator LogMinhaCDN(string log)
        {
            var data = log.Split("|");
            return new LogMinhaCDN
            {
                Id = Convert.ToInt32(data[0]),
                StatusCode = Convert.ToInt32(data[1]),
                Message = data[2],
                Endpoint = data[3],
                Size = Convert.ToDouble(data[4], CultureInfo.InvariantCulture),
            };
        }

        public static implicit operator string(LogMinhaCDN log)
        {
            return $"{log.Id}|{log.StatusCode}|{log.Message}|{log.Endpoint}|{log.Size}";
        }
    }
}
