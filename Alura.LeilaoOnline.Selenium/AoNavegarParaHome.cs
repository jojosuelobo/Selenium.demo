using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome
    {
        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            // Arrange
            IWebDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

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