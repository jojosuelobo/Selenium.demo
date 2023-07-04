using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelpers
    {
        public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
