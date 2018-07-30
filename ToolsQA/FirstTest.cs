using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace ToolsQA
{
    class FirstTest
    {
        static void Main(string[] args)
        {

            //Create the reference for our browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.google.com");

            //Find the Search text box UI Element
            IWebElement element = driver.FindElement(By.Name("q"));

            //Perform Ops
            element.SendKeys("executeautomation");



            public static void EnterText(IWebDriver driver, string element, string value, string elementtype)
            {
                if (elementtype == "Id")
                    driver.FindElement(By.Id(element)).SendKeys(value);
                if (elementtype == "Name")
                    driver.FindElement(By.Name(element)).SendKeys(value);
            }
            
     public static void EnterText(IWebDriver driver, string element, string value, string elementtype)
                {
                    if (elementtype == "Id")
                        driver.FindElement(By.Id(element)).SendKeys(value);
                    if (elementtype == "Name")
                        driver.FindElement(By.Name(element)).SendKeys(value);
                }

            //Close the browser
            driver.Close();

            //IWebDriver driver = new FirefoxDriver();
            //driver.Url = "http://www.demoqa.com";

            //IWebDriver driver;
            //DesiredCapabilities capability = DesiredCapabilities.Firefox();
            //capability.SetCapability("key", "key");
            //capability.SetCapability("secret", "secret");
            //capability.SetCapability("version", "latest-1");
            //driver = new RemoteWebDriver(
            //  new Uri("localhost:65162"), capability
            //);
            //driver.Navigate().GoToUrl("http://www.google.com/ncr");
            //Console.WriteLine(driver.Title);

            //IWebElement query = driver.FindElement(By.Name("q"));
            //query.SendKeys("TestingBot");
            //query.Submit();
            //Console.WriteLine(driver.Title);

            //driver.Quit();

            //[TestMethod]
            //public void SeleniumGetAllTests()
            //{

            //var baseUrl = "http://localhost.com:65162/api/Client";

            //chrome.Navigate().GoToUrl(baseUrl);
            //var responseElement = chrome.FindElement(By.TagName("pre"));
            //var displayedResult = responseElement.Text;


            //Assert.IsTrue(displayedResult.Contains("Name"));
            //Assert.IsTrue(displayedResult.Contains("Name"));
            //Assert.IsTrue(displayedResult.Contains("Name"));
            //Assert.IsTrue(displayedResult.Contains("Name"));
            //Assert.IsTrue(displayedResult.Contains("Name"));
            //Assert.IsTrue(displayedResult.Contains("Name"));


        }

        }
    }
}
