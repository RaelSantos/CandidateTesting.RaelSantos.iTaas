namespace CandidateTesting.RaelSantos.iTaas.Domain
{
    public interface ILogAgoraService
    {
        public List<LogAgora> Converter(List<LogMinhaCDN> logsMinhaCDN);
        public List<string> Converter(List<LogAgora> logsAgora);
    }

    public class LogAgora : ILogAgoraService
    {
        public string Verb { get; set; }
        public int StatusCode { get; set; }
        public string File { get; set; }
        public int Size { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }

        public List<LogAgora> Converter(List<LogMinhaCDN> logsMinhaCDN)
        {
            var logsAgora = new List<LogAgora>();

            foreach (var item in logsMinhaCDN)
            {
                var _logAgora = new LogAgora();
                _logAgora = item;
                logsAgora.Add(_logAgora);
            }

            return logsAgora;
        }
        public List<string> Converter(List<LogAgora> logsAgora)
        {
            var _list = new List<string>();

            foreach (var item in logsAgora)
            {
                var _logAgora = new LogAgora();
                _logAgora = item;
                _list.Add(_logAgora);
            }

            return _list;
        }

        public static implicit operator LogAgora(LogMinhaCDN logMinhaCDN)
        {
            var _endpoint = logMinhaCDN.Endpoint.Split('/');
            var _verbo = _endpoint[0].Remove(0, 1);
            var _file = _endpoint[1].Replace(" ", "").Replace("HTTP", "").Trim();

            return new LogAgora
            {
                Verb = _verbo,
                StatusCode = logMinhaCDN.StatusCode,
                File = _file,
                Size = Convert.ToInt32(logMinhaCDN.Size),
                Id = logMinhaCDN.Id,
                Message = logMinhaCDN.Message.Equals("INVALIDATE") ? "REFRESH_HIT" : logMinhaCDN.Message,
            };
        }

        public static implicit operator string(LogAgora logAgora)
        {
            return $"{"MINHA CDN"} {logAgora.Verb} {logAgora.StatusCode}/{logAgora.File} {logAgora.Size} {logAgora.Id} {logAgora.Message}";
        }
    }
}
