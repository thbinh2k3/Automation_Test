// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class SignupTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void signup() {
        // Test name: Signup
        // Step # | name | target | value
        // 1 | open | / | 
        driver.Navigate().GoToUrl("https://www.demoblaze.com/");
        Thread.Sleep(1000);
        // 2 | setWindowSize | 1552x832 | 
        driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
        // 3 | click | id=signin2 | 
        driver.FindElement(By.Id("signin2")).Click();
        Thread.Sleep(1000);
        // 4 | click | id=sign-username | 
        driver.FindElement(By.Id("sign-username")).Click();
        // 5 | type | id=sign-username | abc4646
        Thread.Sleep(1000);
        driver.FindElement(By.Id("sign-username")).SendKeys("abc133456");
        // 6 | click | id=sign-password | 
        Thread.Sleep(1000);
        driver.FindElement(By.Id("sign-password")).Click();
        Thread.Sleep(1000);
        // 7 | type | id=sign-password | 123123asdadqw
        driver.FindElement(By.Id("sign-password")).SendKeys("123123asdadqw");
        Thread.Sleep(1000);
        // 8 | click | css=#signInModal .btn-primary | 
        driver.FindElement(By.CssSelector("#signInModal .btn-primary")).Click();
        Thread.Sleep(1000);
        // 9 | assertAlert | Sign up successful. | 
        Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Sign up successful."));
    }
    
    public void SignUp(string username, string password, string expectedResult)
    {
        driver.Navigate().GoToUrl("https://www.demoblaze.com/");
        Thread.Sleep(1000);
        // 2 | setWindowSize | 1552x832 | 
        driver.Manage().Window.Size = new System.Drawing.Size(1936, 1048);
        Thread.Sleep(1000);
        driver.FindElement(By.Id("signin2")).Click();
        Thread.Sleep(1000);
        driver.FindElement(By.Id("sign-username")).SendKeys(username);
        Thread.Sleep(1000);
        driver.FindElement(By.Id("sign-password")).SendKeys(password);
        Thread.Sleep(1000);
        driver.FindElement(By.CssSelector("#signInModal .btn-primary")).Click();
        Thread.Sleep(1000);
        Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo(expectedResult));
    }
    [Test]
    public void SignupWithValidCredentials()
    {
        SignUp("validuser123445", "validpassword123", "Sign up successful.");
    }

    [Test]
    public void SignupWithExistingUsername()
    {
        SignUp("validuser12344", "password123", "This user already exist.");
    }

    [Test]
    public void SignupWithShortPassword()
    {
        SignUp("validuser12344", "pass", "Password must be at least 8 characters long.");
    }

    [Test]
    public void SignupWithShortUsername()
    {
        SignUp("usr", "password123", "Username must be at least 5 characters long.");
    }

    [Test]
    public void SignupWithInvalidUsername()
    {
        SignUp("user!@#", "password123", "Username can only contain alphanumeric characters and underscore.");
    }

    [Test]
    public void SignupWithInvalidPassword()
    {
        SignUp("validuser12344890998", "invalidpassword##", "Password must contain at least one letter and one number.");
    }

    [Test]
    public void SignupWithEmptyFields()
    {
        SignUp("", "", "Please fill out Username and Password.");
    }  
}
