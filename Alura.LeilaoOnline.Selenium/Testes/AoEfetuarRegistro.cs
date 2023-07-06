using Alura.LeilaoOnline.Selenium.Fixure;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;
        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento() 
        {
            // Arrage - Chrome Aberto na página inicial do sistema
            // Dados de registro válidos
            driver.Navigate().GoToUrl("http://localhost:5000");
                // nome
            var inputNome = driver.FindElement(By.Id("Nome"));
            //driver.FindElement(By.Id("Nome")).SendKeys("Josue");
            // email
            var inputEmail = driver.FindElement(By.Id("Email"));
                // senha
            var inputPassowrd = driver.FindElement(By.Id("Password"));
                // confirmar senha
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            inputNome.SendKeys("Josue Lobo");
            inputEmail.SendKeys("josuelobo@email.com");
            inputPassowrd.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            // Act - Efetuo Registro 
                // botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));
            botaoRegistro.Click();

            // Assert - Devo ser redirecionado a página de registro
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "josuelobo@email.com", "123", "123")] 
        [InlineData("Josue", "josueloboemail", "123", "123")]
        [InlineData("Josue", "josuelobo@email.com", "123", "456")]
        [InlineData("Josue", "josuelobo@email.com", "123", "")]
        public void DadoInformacoesInvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            // Arrage - Chrome Aberto na página inicial do sistema
            // Dados de registro válidos
            driver.Navigate().GoToUrl("http://localhost:5000");
            // nome
            var inputNome = driver.FindElement(By.Id("Nome"));
            // email
            var inputEmail = driver.FindElement(By.Id("Email"));
            // senha
            var inputPassowrd = driver.FindElement(By.Id("Password"));
            // confirmar senha
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputPassowrd.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            // Act - Efetuo Registro 
            // botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));
            botaoRegistro.Click();

            // Assert - Devo ser redirecionado a página de registro
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            // Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            // Act
            botaoRegistro.Click();

            // Aseert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoNavegadorAbertoFormRegistroNaoDeveMostrarMensagemDeErro()
        {
            // Arrange

            // Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Aseert
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
