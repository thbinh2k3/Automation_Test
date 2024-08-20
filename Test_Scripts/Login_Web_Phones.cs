using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Exam
{
    internal class Login_Web_Phones
    {
        public IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = SetUpDriver.GetDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void login_user()
        {
            driver.Navigate().GoToUrl("https://localhost:44340/");
            // 2 | setWindowSize | 1936x1048 | 
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            Thread.Sleep(2000);
            // 3 | click | css=.has-dropdown > a | 
            driver.FindElement(By.CssSelector(".has-dropdown > a")).Click();
            Thread.Sleep(2000);
            // 4 | type | id=email | binhne@gmail.com
            driver.FindElement(By.Id("email")).SendKeys("binhne@gmail.com");
            Thread.Sleep(2000);
            // 5 | type | id=acc_password | 1234567dA
            driver.FindElement(By.Id("acc_password")).SendKeys("1234567dA");
            Thread.Sleep(2000);
            // 6 | click | id=email | 
            driver.FindElement(By.Id("email")).Click();
            Thread.Sleep(2000);
            // 7 | click | css=.btn-md | 
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            Thread.Sleep(2000);
        }
        public void login_admin()
        {
            // 1 | open | / | 
            driver.Navigate().GoToUrl("https://localhost:44340/");
            // 2 | setWindowSize | 1936x1048 | 
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
            // 3 | click | css=.has-dropdown > a | 
            driver.FindElement(By.CssSelector(".has-dropdown > a")).Click();
            // 4 | type | id=email | binh123@gmail.com
            driver.FindElement(By.Id("email")).SendKeys("binh123@gmail.com");
            Thread.Sleep(2000);
            // 5 | type | id=acc_password | 123
            driver.FindElement(By.Id("acc_password")).SendKeys("123");
            Thread.Sleep(2000);
            // 7 | click | css=.btn-md | 
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("nav > ul > li:nth-child(3) > a")).Click();
            Thread.Sleep(2000);
            
        }
    }
}
