using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Exam
{
    internal class Test_Add_Item
    {
        public IWebDriver driver;
        public IWebDriver dr;
        public IDictionary<string, object> vars { get; private set; }
        public Read_Write_Item read_Write_Item;
        public string path = "https://localhost:44340/";
        public string path_excel = "D:\\TestData_Web_Phones.xlsx";
        public Login_Web_Phones login_web_phones;
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = SetUpDriver.GetDriver();
            dr = SetUpDriver.GetDriver();
            read_Write_Item = new Read_Write_Item();
            login_web_phones = new Login_Web_Phones();
            vars = new Dictionary<string, object>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            js = (IJavaScriptExecutor)driver;

        }

        [Test]
        public void Test_Add_item()
        {
            login_web_phones.SetUp();
            login_web_phones.login_admin();
            dr = login_web_phones.driver;
            int index = 2;
            dr.FindElement(By.CssSelector("#\\#kt_aside_menu > .menu-item:nth-child(4) .menu-title")).Click();
            Thread.Sleep(2000);

            // Đọc dữ liệu từ Excel
            IEnumerable<TestCaseData> testData = Read_Write_Item.GetTestCaseDataFromExcel(path_excel, "ADD_item");

            foreach (var data in testData)
            {
                // Thay thế dữ liệu đăng nhập cứng bằng dữ liệu từ Excel
                string item = data.Arguments[0] as string ?? "";
                string brand = data.Arguments[1] as string ?? "";
                string discount = data.Arguments[2] as string ?? "";
                string name = data.Arguments[3] as string ?? "";
                string price = data.Arguments[4] as string ?? "";
                string quantity = data.Arguments[5] as string ?? "";
                string img = data.Arguments[6] as string ?? "";
                string parameter = data.Arguments[7] as string ?? "";
                string detail = data.Arguments[8] as string ?? "";

                dr.FindElement(By.LinkText("Thêm mới")).Click();
                Thread.Sleep(2000);

                // 12 | select | id=cate_id | label=Laptop văn phòng
                {
                    dr.FindElement(By.Id("cate_id")).SendKeys(item);
                    Thread.Sleep(2000);

                }
                // 13 | click | id=brand_id | 
                dr.FindElement(By.Id("brand_id")).SendKeys(brand);
                Thread.Sleep(2000);
                // 14 | select | id=brand_id | label=HP

                // 15 | click | id=discount_id | 
                dr.FindElement(By.Id("discount_id")).SendKeys(discount);
                Thread.Sleep(2000);

                // 17 | click | id=pro_name | 
                dr.FindElement(By.Id("pro_name")).SendKeys(name);
                Thread.Sleep(2000);

                // 19 | click | id=price | 
                dr.FindElement(By.Id("price")).SendKeys(price);
                Thread.Sleep(2000);

                Thread.Sleep(2000);
                // 21 | click | id=quantity | 
                dr.FindElement(By.Id("quantity")).SendKeys(quantity);
                Thread.Sleep(2000);
                // 22 | type | id=quantity | 13

                // 23 | click | id=ImageUpload | 
                dr.FindElement(By.XPath("//input[@id='ImageUpload']")).SendKeys(img);
                Thread.Sleep(4000);
                // Thực thi lệnh 
                js.ExecuteScript("window.scrollTo(0, 1000)");
                Thread.Sleep(3000);

                dr.FindElement(By.XPath("(//p)[1]")).SendKeys(detail);
                Thread.Sleep(3000); // Dừng 2 giây

                // Gửi phím "dep lam" vào phần tử có ID là "editor2"
                dr.FindElement(By.XPath("(//p)[2]")).SendKeys(parameter);
                Thread.Sleep(3000);

                dr.FindElement(By.CssSelector("button[class='btn btn-primary']")).Click();
                Thread.Sleep(2000);

                ReadOnlyCollection<IWebElement> CateErrorElements = dr.FindElements(By.XPath("//span[@id='cate_id-error']"));

                ReadOnlyCollection<IWebElement> BrandErrorElements = dr.FindElements(By.XPath("//span[@id='brand_id-error']"));

                ReadOnlyCollection<IWebElement> DiscountErrorElements = dr.FindElements(By.XPath("//span[@id='discount_id-error']"));

                ReadOnlyCollection<IWebElement> PriceErrorElements = dr.FindElements(By.XPath("//span[@id='price-error']"));


                
                ReadOnlyCollection<IWebElement> swalElements = dr.FindElements(By.XPath("//h2[@id='swal2-title']"));


                if (swalElements.Count > 0 && swalElements[0].Displayed)
                {
                    string text = swalElements[0].Text;
                    Thread.Sleep(1000);
                    read_Write_Item.WriteResultToExcel(path_excel, "TestData_Thanhtoan", text, index);
                }
                else if (BrandErrorElements.Count > 0 && BrandErrorElements[0].Displayed)
                {
                    string text = BrandErrorElements[0].Text;
                    Thread.Sleep(1000);
                    read_Write_Item.WriteResultToExcel(path_excel, "TestData_Thanhtoan", text, index);
                }
                else if (DiscountErrorElements.Count > 0 && DiscountErrorElements[0].Displayed)
                {
                    string text = DiscountErrorElements[0].Text;
                    Thread.Sleep(1000);
                    read_Write_Item.WriteResultToExcel(path_excel, "TestData_Thanhtoan", text, index);
                }
                else if (PriceErrorElements.Count > 0 && PriceErrorElements[0].Displayed)
                {
                    string text = PriceErrorElements[0].Text;
                    Thread.Sleep(1000);
                    read_Write_Item.WriteResultToExcel(path_excel, "TestData_Thanhtoan", text, index);
                }
                //Cập nhât số dòng lên 1
                index++;

            }
        }
        [Test]
        public void Test_Update_item()
        {

        }
        [Test]
        public void Test_Delete_item()
        {

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
