using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA
{
    public class ApiTest
    {
        IWebDriver driver;

        [Setup]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        [Test]
        public void OpenApptest()
        {
            driver.Close();
        }
        [Teardown]
        public void EndTest()
        {
            driver = new FirefoxDriver();
        }
            
    }
}
