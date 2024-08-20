using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Buoi8_Exam
{
    internal class Test_Add_Catalog
    {
        public IWebDriver driver;
        public IWebDriver dr;
        public IDictionary<string, object> vars { get; private set; }
        public Read_Write_Catalog readWrite_catalog;
        public string path = "https://localhost:44340/";
        public string path_excel = "D:\\TestData_Web_Phones.xlsx";
        public Login_Web_Phones login_web_phones;
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = SetUpDriver.GetDriver();
            dr = SetUpDriver.GetDriver();
            readWrite_catalog = new Read_Write_Catalog();
            login_web_phones = new Login_Web_Phones();
            vars = new Dictionary<string, object>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            js = (IJavaScriptExecutor)driver;

        }

        [Test]
        public void Test_Add_CataLog()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
            int a = 2;

            driver.FindElement(By.CssSelector(".menu-item:nth-child(6) .menu-title")).Click();
            Thread.Sleep(2000);

            // Đọc dữ liệu từ Excel
            IEnumerable<TestCaseData> testData = Read_Write_Catalog.GetTestCaseDataFromExcel(path_excel, "Add_CataLog");

            foreach (var data in testData)
            {
                // Thay thế dữ liệu đăng nhập cứng bằng dữ liệu từ Excel
                string catalog = data.Arguments[0] as string ?? "";

                dr.FindElement(By.Id("create__open")).Click();
                Thread.Sleep(2000);

                
                // 6 | click | id=create__input | 
                dr.FindElement(By.Id("create__input")).SendKeys(catalog);
                Thread.Sleep(2000);


                dr.FindElement(By.Id("create__save")).Click();
                Thread.Sleep(6000);

                bool form = dr.FindElement(By.XPath("//div[@id='create-modal']//form[@id='kt_modal_new_target_form']")).Displayed;



                //IWebElement successElement = dr.FindElement(By.CssSelector("#swal2-title"));



                if (form == false) //true
                {
                    string text = dr.FindElement(By.XPath("//h2[@id='swal2-title']")).Text;
                    Thread.Sleep(7000);
                    readWrite_catalog.WriteResultToExcel(path_excel, "Add_CataLog", text, a);
                    Thread.Sleep(6000);
                    
                }
                else if (form == true)
                {

                        string text = dr.FindElement(By.XPath("//h2[@id='swal2-title']")).Text;
                        readWrite_catalog.WriteResultToExcel(path_excel, "Add_CataLog", text,a);
                        Thread.Sleep(4000);
                        dr.FindElement(By.XPath("(//button[@type='button'][contains(text(),'Hủy bỏ')])[1]"));
                        Thread.Sleep(2000);
                   
                }
                a++;

            }
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
