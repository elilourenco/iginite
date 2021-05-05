using System.Collections.Generic;
using IdentityServer4.EntityFramework.DbContexts;
using libongo.plugin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace libongo.InMemory
{
  public interface Imanipulacao
  {


    //Interface do Metodo de adcionar
    T create<T>(T model);

    //Interface do Metodo de Listar dados
    IEnumerable<T> select<T>(string table);

    //Interface do Metodo de Eliminar dados
    void Delete(string table, string seach);

    //Interface do Metodo Para pesquisar dados 
    IEnumerable<T> selectOne<T>(T model, string seach);

    //Interface do Metodo Para Editar
    T update<T>(T model, string id);
  }

  public class manipulacao : Imanipulacao
  {
    //public IServiceScopeFactory app;
    public IConnect connect => this.connect;
    public manipulacao()
    {
      //connect = _connect;
      //app = _app;
    }



    //######################## Metodo generico de adicionar dados ####################### 
    public T create<T>(T model)
    {
      var type = model.GetType();
      var table = type.Name;
      var prop = "";
      var values = "";
      foreach (var item in type.GetProperties())
      {
        if (!item.GetMethod.IsVirtual)
        {
          if (item.PropertyType.Name != "ICollection`1" && item.GetValue(model) != null)
          {
            if (item.PropertyType.Name == "DateTime")
            {
              values += $"'{item.GetValue(model)}',";
              var data = $"{values}";
              data = data.Replace(@" 00:00:00", string.Empty);
              string[] palavras = data.Split('/');
              string ano = palavras[palavras.Length - 1];
              string mes = palavras[palavras.Length - 2];
              string dia = palavras[palavras.Length - 3];
              values += $"'{ano}-{mes}-{dia} {00:00:00}'";
            }
            else
            {
              prop += $"{item.Name},";
              values += $"'{item.GetValue(model)}',";
            }

          }
        }
      }
      prop = $"{prop},";
      values = $"{values},";
      prop = prop.Replace(",,", "");
      values = values.Replace(",,", "");

      var query = $"Insert into {table} ({prop}) values({values})";
      new Connect().executeSQL(query);

      return model;
    }
    //######################## Metodo generico de Editar dados ######################### 
    public T update<T>(T model, string id)
    {
      var type = model.GetType();
      var table = type.Name;
      var prop = "";
      foreach (var item in type.GetProperties())
      {
        if (!item.GetMethod.IsVirtual)
        {
          prop += $"{item.Name}='{item.GetValue(model)}',";
        }
      }
      var query = $"Update {table} set  ({prop}) where id='{id}'";
      new Connect().executeSQL(query);
      return model;
    }
    //######################### Metdo generico de Listar dados ######################### 
    public IEnumerable<T> select<T>(string table)
    {
       var dados = new Connect().executeAd<T>($"Select*from {table}");

       return dados;
    }


    //######################## Metdo generico de Eliminar dados ########################


    public void Delete(string table, string seach)
    {
      new Connect().executeSQL($"Delete from {table}  where Id='{seach}'");

    }

    //######################## Metdo generico de efectuar pesquisa dados ###############
    public IEnumerable<T> selectOne<T>(T model, string seach)
    {
      var type = model.GetType();
      var table = type.Name;
      var prop = "";
      foreach (var item in type.GetProperties())
      {
          if (item.PropertyType.Name != "ICollection`1" && item.PropertyType.Name == "String")
          {
            prop += $"{item.Name}='{seach}' or ";
          }
        
      }
      prop = $"{prop},";
      prop = prop.Replace("or ,", "");
      return new Connect().executeAd<T>($"Select*from {table}  where {prop}");
    }
  }
}