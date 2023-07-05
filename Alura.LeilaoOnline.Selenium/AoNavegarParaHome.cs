using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome : IDisposable
    {
        private ChromeDriver driver;

        // Setup
        public AoNavegarParaHome()
        {
            IWebDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
        }

        // TearDown
        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // Arrange

            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            // Arrange
            IWebDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}