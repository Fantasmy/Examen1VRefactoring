using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class SeleniumTest
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
    }
}
