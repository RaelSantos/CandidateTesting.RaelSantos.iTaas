using CandidateTesting.RaelSantos.iTaas.Services;
using Moq;

namespace CandidateTesting.RaelSantos.iTaas.Tests
{
    public class LogServiceTests
    {
        [Fact(DisplayName = "Obter TxtUrl com Sucesso")]
        [Trait("Categoria", "Log Service Mock Tests")]
        public void LogService_ObterTxtUrl_DeveExecutarComSucesso()
        {
            // Arrange
            var sourcePath = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var logService = new LogService(sourcePath);

            // Act
            var result = logService.GetAll();

            // Assert
            Assert.NotEmpty(result);                           
        }

        [Fact(DisplayName = "Obter TxtUrl com Erro")]
        [Trait("Categoria", "Log Service Mock Tests")]
        public void LogService_ObterTxtUrl_DeveExecutarComErro()
        {
            // Arrange
            var sourcePath = "https://s3.amazonaws.com/uux-itaas-static/";
            var logService = new LogService(sourcePath);

            // Act
            var result = logService.GetAll();

            // Assert
            Assert.Empty(result);
        }
    }
}

