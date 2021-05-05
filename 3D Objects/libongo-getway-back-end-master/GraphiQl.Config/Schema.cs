 
using GraphQL;
using GraphQL.Types;
using libongo.Helpers;

namespace libongo.GraphiQl.Config
{
    public class GraphiQlSchema : Schema
    {
        public GraphiQlSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<Query>();
            Mutation = resolver.Resolve<Mutation>();
            //Subscription = resolver.Resolve<AppMutations>();
            RegisterType<ObjectGraphType>();
        }
    }
}