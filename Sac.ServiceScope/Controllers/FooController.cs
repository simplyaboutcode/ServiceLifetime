using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Sac.ServiceScope.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {

        private ISingletonService _singleton1;
        private ISingletonService _singleton2;
        private IScopedService _scoped1;
        private IScopedService _scoped2;
        private ITransientService _transient1;
        private ITransientService _transient2;

        public FooController(
            ISingletonService singleton1,
            ISingletonService singleton2,
            IScopedService scoped1,
            IScopedService scoped2,
            ITransientService transient1,
            ITransientService transient2)
        {
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        [HttpGet]
        [Route("Singleton")]
        public List<string> Singleton()
        {
            return new List<string> { _singleton1.GetGuid(), _singleton2.GetGuid() };
        }

        [HttpGet]
        [Route("Scoped")]
        public List<string> Scoped()
        {
            return new List<string> { _scoped1.GetGuid(), _scoped2.GetGuid() };
        }

        [HttpGet]
        [Route("Transient")]
        public List<string> Transient()
        {
            return new List<string> { _transient1.GetGuid(), _transient2.GetGuid() };
        }
    }
}
