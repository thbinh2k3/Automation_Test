using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Buoi8_Exam
{
    internal class SetUpDriver
    {
        public static IWebDriver driver;
        public static bool isDriverInitialized = false;

        public static IWebDriver GetDriver()
        {
            if (!isDriverInitialized)
            {
                driver = new ChromeDriver();
                isDriverInitialized = true;
            }

            return driver;
            
        }

        public static void CloseDriver(IWebDriver dr)
        {
            if (dr != null)
            {

                dr = null;
                isDriverInitialized = false;
            }
        }

    }
}
