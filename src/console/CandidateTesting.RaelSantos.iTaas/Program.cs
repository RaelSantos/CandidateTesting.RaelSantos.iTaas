using CandidateTesting.RaelSantos.iTaas.Domain;
using CandidateTesting.RaelSantos.iTaas.Services;
using CandidateTesting.RaelSantos.iTaas.Utils;

const string _filePathAgora = @"C:\dev\log-agora.txt";
Converter("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", _filePathAgora);

static void Converter(string sourceUrl, string targetPath)
{
    const string _filePathCdn = @"C:\dev\log-minhacdn.txt";

    var logService = new LogService(sourceUrl);
    var dados = logService.GetAll();

    FileUtils.EscreverArquivo(_filePathCdn, dados);
    var data = FileUtils.LerArquivo(_filePathCdn);
    var logsMinhaCDN = new LogMinhaCDN().Converter(data);
    EscreveLogMinhaCDN(logsMinhaCDN);

    var logsAgora = new LogAgora().Converter(logsMinhaCDN);
    var itens = new LogAgora().Converter(logsAgora);

    FileUtils.EscreverArquivo(targetPath, itens);

    EscreverLogAgora(itens);
}

static void EscreveLogMinhaCDN(List<LogMinhaCDN> logMinhaCDNs)
{
    Console.WriteLine("Log MinhaCDN");
    foreach (var lg in logMinhaCDNs)
        Console.WriteLine($"{lg.Id}|{lg.StatusCode}|{lg.Message}|{lg.Endpoint}|{lg.Size}");

}

static void EscreverLogAgora(List<string> dados)
{
    Console.WriteLine("Log MinhaCDN");
    foreach (var item in dados)
        Console.WriteLine(item);
}