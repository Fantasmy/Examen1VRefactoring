﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Facade.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Application.Dto;
using Vueling.Utils.LogHelper;
using System.Resources;
using System.Web.Http;
using System.Web.Http.Results;
using Vueling.Infrastructure.Repository.DataModel;
using Vueling.Facade.Api.Tests;

namespace Vueling.Facade.Api.Controllers.Tests
{
    [TestClass()]
    public class ClientControllerTests
    {
        private readonly ILogger log;

        [TestMethod()]
        public void ClientControllerTest()
        {
            Assert.Fail();
        }

        //[TestMethod()]
        //public void ClientControllerTest1();
        //{
        //    ClientController controller = new ClientController();

        //    ClientDto clientDto = controller.Get(id);

        //    Assert.IsNotNull(clientDto);
        //    Assert.AreEqual(1, clientDto.id);
        //}

        /// <summary>
        /// Tests the get mthod.
        /// </summary>
        [TestMethod()]
        public void GetTest()
        {
            //ClientController controller = new ClientController();
            ClientDto clientDto = new ClientDto();
            //IEnumerable<ClientDto> clients = controller.GetAll();
            //Assert.IsTrue(clients.Count<ClientDto>() > 0);
            log.Debug(Resource5.GetCAll);
        }

        [TestMethod()]
        public void GetTest1()
        {
            Assert.Fail();
        }

        /// <summary>
        /// Tests the post method
        /// </summary>
        [TestMethod()]
        public void PostTest()
        {
            //ClientController controller = new ClientController();

            //ClientDto clientDto = new ClientDto();
            //clientDto.id = new Guid();
            //clientDto.name = "Josh";
            //clientDto.email = "josh@mail.com";
            //clientDto.role = "admin";
            //IHttpActionResult actionResult =
            //    controller.Post(clientDto);

            //var contentResult = actionResult as
            //    CreatedAtRouteNegotiatedContentResult<Clients>;

            //Assert.IsNotNull(actionResult);
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}