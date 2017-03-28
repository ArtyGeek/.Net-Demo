using ArtyGeek.Operations.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ArtyGeek.Api.Controllers.Abstract
{
    public abstract class ApiControllerBase : ApiController
    {

        public readonly ICurrentUserProvider _currentUserProvider;

        public ApiControllerBase(ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
        }
    }
}