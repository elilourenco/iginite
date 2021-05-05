using libongo.Data;
using libongo.InMemory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;



namespace libongo.Helpers
{
    // https://github.com/graphql-dotnet/graphql-dotnet/issues/648#issuecomment-431489339
    public class ContextServiceLocator
    {
        public IRepository Repository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IRepository>();
       // public ISkaterStatisticRepository SkaterStatisticRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ISkaterStatisticRepository>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
