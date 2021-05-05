using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using libongo.Data;
using libongo.plugin;
using Newtonsoft.Json;

namespace libongo.InMemory {
    public class Repository : IRepository {

        

        //private readonly List<TModel> _players = new List<TModel> {
        // new TModel() { Id = 1, Name = "Connor McDavid" }
        // };
        //contextServiceLocator.Repository.
        public Task<TModel> Get<TModel> (int id) {
            return default; //Task.FromResult(_players.FirstOrDefault(p => p.Id == id));
        }
        public Task<TModel> GetRandom<TModel> () {
            throw new System.NotImplementedException ();
        }
        public Task<List<TModel>> All<TModel> () {
            throw new System.NotImplementedException ();
        }
        public void Delete (string table, string seach) {
            new Connect ().executeSQL ($"Delete from {table}  where Id='{seach}'");
        }
        
        public IEnumerable<T> select<T> (string table) {
            
            var dados = new Connect ().executeAd<T> ($"Select*from {table}");
            
            var plugin = new pluginconfig ().Checkconnection(9200, "KIBANA", table, dados.ToList(), $"query{table}");
            return dados;
        }
        public IEnumerable<T> selectOn<T> (T model, string seach) {

            var type = model.GetType ();
            var table = type.Name;
            var prop = "";
            foreach (var item in type.GetProperties ()) {
                if (item.PropertyType.Name != "ICollection`1" && item.PropertyType.Name == "String") {
                    if (!item.GetMethod.IsVirtual) {
                        prop += $"{item.Name}='{seach}' or ";
                    }
                }
            }
            prop = $"{prop},";
            prop = prop.Replace ("or ,", "");

            var dados = new Connect ().executeAd<T> ($"Select*from {table}  where {prop}");

            var plugin = new pluginconfig ().Checkconnection(9200, "KIBANA",table, dados.ToList(), $"querysearch{table}");

            return dados;
        }
        public IEnumerable<T> selectOne<T> (T model, string seach) {

            var type = model.GetType ();
            var table = type.Name;
            var prop = "";
            foreach (var item in type.GetProperties ()) {

                if (item.PropertyType.Name != "ICollection`1" && item.PropertyType.Name == "String") {
                    if (!item.GetMethod.IsVirtual) {
                        prop += $"{item.Name}='{seach}' or ";
                    }
                }

            }
            prop = $"{prop},";
            prop = prop.Replace ("or ,", "");

            var dados = new Connect ().executeAd<T> ($"Select*from {table}  where {prop}");

            var plugin = new pluginconfig ().Checkconnection(9200, "KIBANA", table, dados.ToList(), $"querysearch{table}");

            return dados;
        }

        public IEnumerable<T> sub_search<T, TModel> (T model, string seach, TModel v) {
            var type = model.GetType ();
            var types = v.GetType ();
            var tables = types.Name;
            var table = type.Name;
            var prop = "";
            var _n = new List<string> ();
            var _nlist = new List<string> ();
            foreach (var item in type.GetProperties ()) {

                if (item.PropertyType.Name != "ICollection`1" && item.PropertyType.Name == "String" && !item.PropertyType.AssemblyQualifiedName.Contains ("libongo.Models")) {
                    if (!item.GetMethod.IsVirtual) {
                        prop += $"{item.Name}='{seach}' or ";
                    }

                }
                if (item.PropertyType.AssemblyQualifiedName.Contains ("libongo.Models")) {
                    //model.GetType().GetProperty($"{item.Name}").SetValue(model, selectOne(item.Name,$"{item.Name}Id").FirstOrDefault());
                    _n.Add (item.Name);
                }
                if (item.PropertyType.Name == "ICollection`1") {
                    //model.GetType().GetProperty($"{item.Name}").SetValue(model, selectOne(item.Name,$"{item.Name}Id").FirstOrDefault());
                    _nlist.Add (item.Name);
                }

            }
            prop = $"{prop},";
            prop = prop.Replace ("or ,", "");
            var obj = new Connect ().executeAd<T> ($"Select*from {table}  where {prop}");
            for (int it = 0; it < obj.Count (); it++) {
                var typess = obj.ElementAt (it).GetType ();
                foreach (var items in typess.GetProperties ()) {

                    if (items.Name == $"{tables}") {
                        if (items.Name == "MicroServices") {
                            var dt = typess.GetProperty ($"MicroServiceId").GetValue (obj.ElementAt (it));
                            var mo = items.PropertyType;
                            var fg = items.GetType ();
                            obj.ElementAt (it).GetType ().GetProperty ($"{items.Name}").SetValue (obj.ElementAt (it), selectOne (v, $"{dt}").FirstOrDefault ());
                        } else {
                            var dt = typess.GetProperty ($"{items.Name}Id").GetValue (obj.ElementAt (it));
                            var mo = items.PropertyType;
                            var fg = items.GetType ();
                            obj.ElementAt (it).GetType ().GetProperty ($"{items.Name}").SetValue (obj.ElementAt (it), selectOne (v, $"{dt}").FirstOrDefault ());
                        }
                    }

                }

            }
            return obj;
        }
        public TModel UpDate<TModel> (TModel model, string id) {
            var type = model.GetType ();
            var table = type.Name;
            var prop = "";
            foreach (var item in type.GetProperties ()) {
                if (!item.GetMethod.IsVirtual) {
                    if (!item.PropertyType.AssemblyQualifiedName.Contains ("libongo.Models") && item.PropertyType.Name != "ICollection`1" && item.GetValue (model) != null) {
                        prop += $"{item.Name}='{item.GetValue(model)}',";
                    }
                }

            }
            prop += ",";
            prop = prop.Replace (",,", "");
            var query = $"Update {table} set  {prop} where id='{id}'";
            new Connect ().executeSQL (query);

            List <TModel> dados = new List<TModel>();
            dados.Add(model);
            var plugin = new pluginconfig ().Checkconnection(9200, "KIBANA", table, dados.ToList(), $"mutationupdate{table}");

            return model;
        }
        public TModel Add<TModel> (TModel model) {

            var type = model.GetType ();
            var primary = type.GetProperties ().FirstOrDefault (x => x.CustomAttributes.Any (x => x.AttributeType.Name.Equals ("KeyAttribute")));
            var table = type.Name;
            var prop = "";
            var values = "";
            var Id = Guid.NewGuid ();
            object m = Id.ToString ();
            model.GetType ().GetProperty ("Id").SetValue (model, m);
            foreach (var item in type.GetProperties ()) {

                if (!item.PropertyType.AssemblyQualifiedName.Contains ("libongo.Models") && item.PropertyType.Name != "ICollection`1" && item.GetValue (model) != null) {
                    if (!item.GetMethod.IsVirtual) {
                        if (item.PropertyType.Name == "DateTime")
                            continue;
                        else {
                            if (item.Name == primary.Name) {
                                prop += $"{item.Name},";
                                values += $"'{Id}',";
                            } else {
                                prop += $"{item.Name},";
                                values += $"'{item.GetValue(model)}',";
                            }
                        }
                    }
                }

            }

            prop = $"{prop},";
            values = $"{values},";
            prop = prop.Replace (",,", "");
            values = values.Replace (",,", "");
            var query = $"Insert into {table} ({prop}) values({values})";
            new Connect ().executeSQL (query);
            model.GetType ().GetProperty ("Id").SetValue (model, m);

            List <TModel> dados = new List<TModel>();
            dados.Add(model);
            var plugin = new pluginconfig ().Checkconnection(9200, "KIBANA", table, dados.ToList(), $"mutationadd{table}");
            return model;
        }
    }
}