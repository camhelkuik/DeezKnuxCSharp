using System.Linq;
using DeezKnuxApi.Data;
using DeezKnuxApi.Models;
using DeezKnuxApi.Services;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;

namespace DeezKnuxApi.Repositories
{
    public class KnuxPhraseRepository : DefaultEntityRepository<KnuxPhrase>
    {
        private readonly ILogger _logger;
         private readonly AppDbcontext _context;
        private readonly IAuthenticationService _authenticationService;

    public KnuxPhraseRepository(
            AppDbcontext context,
            ILoggerFactory loggerFactory,
            IJsonApiContext jsonApiContext,
            IAuthenticationService authenticationService)
        : base(loggerFactory, jsonApiContext)
        {
             _context = context;
            _logger = loggerFactory.CreateLogger<KnuxPhraseRepository>();
            _authenticationService = authenticationService;
        }

        public override IQueryable<KnuxPhrase> Get()
        {
            return base.Get().Where(e => e.OwnerId == _authenticationService.GetUserId());
        }
    }
}