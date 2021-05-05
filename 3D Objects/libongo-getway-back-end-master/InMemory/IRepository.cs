
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;


namespace libongo.InMemory
{
    public interface IRepository
    {

        IEnumerable<T> select<T>(string table);
        TModel UpDate<TModel>(TModel model, string id);
        Task<TModel> Get<TModel>(int id);
        Task<TModel> GetRandom<TModel>();
        Task<List<TModel>> All<TModel>();
        TModel Add<TModel>(TModel player);
        void Delete(string table, string seach);
        IEnumerable<T> selectOne<T>(T model, string seach);
        IEnumerable<T> sub_search<T,TModel>(T model, string seach, TModel v);


    }
}
