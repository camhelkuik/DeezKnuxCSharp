using DeezKnuxApi.Models;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace DeezKnuxApi.Controllers
{
   // [Route("api/v1/[controller]")]
    public class KnuxPhrasesController : JsonApiController<KnuxPhrase>
    {
        public KnuxPhrasesController(
            IJsonApiContext jsonApiContext,
            IResourceService<KnuxPhrase> resourceService, 
            ILoggerFactory loggerFactory)
            : base(jsonApiContext, resourceService, loggerFactory)
        { }
    }
}