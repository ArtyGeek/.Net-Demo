using ArtyGeek.Api.Controllers.Abstract;
using ArtyGeek.DataModel.Models;
using ArtyGeek.Operations.Abstraction;
using ArtyGeek.Operations.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

// update-package -reinstall -ignoreDependencies

namespace ArtyGeek.Api.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IAuthenticationOperations _authOperations;

        public AccountController(IAuthenticationOperations authOperations, ICurrentUserProvider currentUserProvider)
            : base(currentUserProvider)
        {
            _authOperations = authOperations;
        }

        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(AuthenticationModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _authOperations.RegisterUser(userModel);
            }
            catch (InvalidOperationException ioex)
            {
                return BadRequest(ioex.Message);
            }

            return Ok();
        }
    }
}