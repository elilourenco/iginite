using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using libongo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace libongo.Controllers
{
    [Authorize(Roles ="Administrador")]
    [ApiController]
    [Route("[controller]")] 
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {           

            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };
            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
            if (result.Errors?.Count > 0)
            {
                var erro = new SmsError();
                erro.SqlError_1 = result.Errors.ToList().ElementAt(0).InnerException.Message;
                erro.SqlError_2 = result.Errors.ToList().ElementAt(0).InnerException.Source;
                erro.recomendation="Entra em contacto com a equipa de suporte do Libongo";

                return Problem(detail: result.Errors.Select(_ => _.Message).FirstOrDefault(), statusCode: 500);
            }
            return Ok(result);
        }
    }
}