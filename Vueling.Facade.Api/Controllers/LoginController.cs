﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Vueling.Facade.Api.Models;
using Vueling.Utils.LogHelper;

namespace Vueling.Facade.Api.Controllers
{
    /// <summary>
    /// login controller class to authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        /// <summary>
        /// Echoes the ping.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            log.Debug(Resource.eP);
            return Ok(true);
        }

        /// <summary>
        /// Echoes the user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            log.Debug(Resource.eU);
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        /// <summary>
        /// Authenticates the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            bool isCredentialValid = (login.email == "fake@user.com");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.email);
                log.Debug(Resource.sT);
                return Ok(token);
            }
            else
            {
                log.Debug(Resource.Unauth);
                return Unauthorized();
            }
        }
    }
}
