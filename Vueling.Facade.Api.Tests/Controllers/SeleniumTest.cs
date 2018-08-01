using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Vueling.Application.Dto;

namespace Vueling.Facade.Api.Tests.Controllers
{
    [TestClass()]
    public class ClientsControllerTests
    {
        public IWebDriver browser;

        [TestInitialize()]
        public void ClientsControllerTest()
        {
            browser = new ChromeDriver();
            browser = new FirefoxDriver();
            browser.Manage().Window.Maximize();
        }


        // GET: api/Clients
        [TestMethod()]
        public void GetAllTest()
        {
            List<ClientDto> listado = new List<ClientDto>();

            // Apartado Selenium
            browser.Navigate().GoToUrl("http://localhost:60480/api/Clients");

            var responseElement = browser.FindElements(By.TagName("ClientsDto"));

            foreach (var n in responseElement)
            {
                var nombre = n.FindElement(By.TagName("nombre"));
                var email = n.FindElement(By.TagName("email"));
                var id = n.FindElement(By.TagName("id"));
                var role = n.FindElement(By.TagName("role"));

                //ClientDto client = new ClientDto(id.ToString(), nombre.ToString(), email.ToString(), role.ToString());
                ClientDto client = new ClientDto();
                listado.Add(client);
            }

            Assert.IsTrue(listado != null);
        }


        // GET api/Clients/id/{id}
        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }


        // GET api/Clients/name/{name}
        [TestMethod()]
        public void GetByNameTest()
        {
            Assert.Fail();
        }
    }
}