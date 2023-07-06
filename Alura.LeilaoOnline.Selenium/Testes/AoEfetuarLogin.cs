using Alura.LeilaoOnline.Selenium.Fixure;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaDashboard()
        {
            // Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherForm("fulano@example.org", "123");

            // Act
            loginPO.SubmeterForm();

            // Assert
            Assert.Contains("Dashboard", driver.Title);
        }
        [Fact]
        public void DadoLoginInvalidoDeveContinuarLogin()
        {
            // Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherForm("fulano@example.org", "");

            // Act
            loginPO.SubmeterForm();

            // Assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
