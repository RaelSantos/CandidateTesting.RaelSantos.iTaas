using CandidateTesting.RaelSantos.iTaas.Domain;
using CandidateTesting.RaelSantos.iTaas.Services;
using CandidateTesting.RaelSantos.iTaas.Utils;

namespace CandidateTesting.RaelSantos.iTaas.Tests
{
    public class LogMinhaCDNTests
    {
        const string _filePathCdn = @"C:\dev\log-minhacdn.txt";

        [Fact(DisplayName = "Coverte ArrayString para ListaLogMinhaCDN com Sucesso")]
        [Trait("Categoria", "LogAgora Mock Tests")]
        public void LogMinhaCDN_Converte_ArrayString_Para_ListaDeLogMinhaCDN_Sucesso()
        {
            // Arrange            
            var sourceUrl = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var logService = new LogService(sourceUrl);
            var dados = logService.GetAll();

            FileUtils.EscreverArquivo(_filePathCdn, dados);
            var data = FileUtils.LerArquivo(_filePathCdn);

            // Act 
            var logsMinhaCDN = new LogMinhaCDN().Converter(data);

            // Assert
            Assert.NotEmpty(logsMinhaCDN);
        }

        [Fact(DisplayName = "Coverte ArrayString para ListaLogMinhaCDN com Erro")]
        [Trait("Categoria", "LogAgora Mock Tests")]
        public void LogMinhaCDN_Converte_ArrayString_Para_ListaDeLogMinhaCDN_Erro()
        {
            // Arrange            
            var sourceUrl = "https://s3.amazonaws.com/uux-itaas-static/";
            var logService = new LogService(sourceUrl);
            var dados = logService.GetAll();

            FileUtils.EscreverArquivo(_filePathCdn, dados);
            var data = FileUtils.LerArquivo(_filePathCdn);

            // Act 
            var logsMinhaCDN = new LogMinhaCDN().Converter(data);

            // Assert
            Assert.Empty(logsMinhaCDN);
        }
    }
}