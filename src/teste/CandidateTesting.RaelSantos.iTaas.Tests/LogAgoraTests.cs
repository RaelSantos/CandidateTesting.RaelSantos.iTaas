using CandidateTesting.RaelSantos.iTaas.Domain;
using CandidateTesting.RaelSantos.iTaas.Services;
using CandidateTesting.RaelSantos.iTaas.Utils;
using Moq;

namespace CandidateTesting.RaelSantos.iTaas.Tests
{
    public class LogAgoraTests
    {
        const string _filePathCdn = @"C:\dev\log-minhacdn.txt";


        [Fact(DisplayName = "Coverte ListaLogMinhaCDN para ListaLogAgora com Sucesso")]
        [Trait("Categoria", "LogAgora Mock Tests")]
        public void LogAgora_Converte_ListaLogMinhaCDN_Para_ListaLogAgora_Sucesso()
        {
            // Arrange          
            var sourceUrl = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var logService = new LogService(sourceUrl);
            var dados = logService.GetAll();

            FileUtils.EscreverArquivo(_filePathCdn, dados);
            var data = FileUtils.LerArquivo(_filePathCdn);

            // Act 
            var logsMinhaCDN = new LogMinhaCDN().Converter(data);
            var logsAgora = new LogAgora().Converter(logsMinhaCDN);

            // Assert
            Assert.NotEmpty(logsAgora);
        }

        [Fact(DisplayName = "Coverte ListaLogMinhaCDN para ListaLogAgora com Erro")]
        [Trait("Categoria", "LogAgora Mock Tests")]
        public void LogAgora_Converte_ListaLogMinhaCDN_Para_ListaLogAgora_Erro()
        {
            // Arrange          
            var sourceUrl = "https://s3.amazonaws.com/uux-itaas-static/";
            var logService = new LogService(sourceUrl);
            var dados = logService.GetAll();

            FileUtils.EscreverArquivo(_filePathCdn, dados);
            var data = FileUtils.LerArquivo(_filePathCdn);

            // Act 
            var logsMinhaCDN = new LogMinhaCDN().Converter(data);
            var logsAgora = new LogAgora().Converter(logsMinhaCDN);

            // Assert
            Assert.Empty(logsAgora);
        }
    }
}