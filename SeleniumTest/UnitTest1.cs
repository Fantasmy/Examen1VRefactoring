using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Vueling.Application.Dto;
using Vueling.Facade.Api.Controllers;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driverFF;
        static IWebDriver driverGC;

        [TestMethod]
        public void SetUp(TestContext context)
        {
            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver();
        }

        [TestMethod]
        public void TestFirefoxDriver()
        {
            driverFF.Navigate().GoToUrl("http://localhost:65162/");
            driverFF.FindElement(By.Id("name")).SendKeys("Selenium");
            driverFF.FindElement(By.Id("email")).SendKeys("Keys.Enter");
        }

        [TestMethod]
        public void TestChromeDriver()
        {
            driverFF.Navigate().GoToUrl("http://localhost:65162/");
            driverFF.FindElement(By.Id("name")).SendKeys("Selenium");
            driverFF.FindElement(By.Id("email")).SendKeys("Keys.Enter");
        }
    }
}
