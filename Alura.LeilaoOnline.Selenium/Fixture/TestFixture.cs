using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Fixure
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        // Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
        }

        // TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
