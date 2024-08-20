using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Exam
{
    internal class Test_Intergation
    {
        public IWebDriver driver;
        public IWebDriver dr;
        public IDictionary<string, object> vars { get; private set; }
        
       
        public Login_Web_Phones login_web_phones;
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = SetUpDriver.GetDriver();
            dr = SetUpDriver.GetDriver();
            login_web_phones = new Login_Web_Phones();
            vars = new Dictionary<string, object>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            js = (IJavaScriptExecutor)driver;

        }

        [Test]
        public void User_View_Item_Insert()
        {
            login_web_phones.SetUp();
            login_web_phones.login_user();
            dr = login_web_phones.driver;
            

      
        }
        public void User_View_Item_Update()
        {
            login_web_phones.SetUp();
            login_web_phones.login_user();
            dr = login_web_phones.driver;
        }

        public void User_View_Delete()
        {
            login_web_phones.SetUp();
            login_web_phones.login_user();
            dr = login_web_phones.driver;
        }

        public void Admin_View_Catalog_New()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
        }

        public void Admin_View_Catalog_Update()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
        }

        public void Admin_View_Catalog_Delete()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
        }
        public void Admin_View_Brand_New()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
        }

        public void Admin_View_Brand_Update()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
        }

        public void Admin_View_Brand_Delete()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
        }

        [TearDown]
        public void TearDown1()
        {
            try
            {
                if (driver != null)
                {
                    driver.SwitchTo().Alert().Accept();
                }
                if (dr != null)
                {
                    dr.SwitchTo().Alert().Accept();
                }


            }
            catch (NoAlertPresentException)
            {

            }
            if (driver != null)
            {
                driver.Close();
                return;
            }
            else

            if (dr != null)
            {
                dr.Close();
                return;
            }
        }
    }
}
