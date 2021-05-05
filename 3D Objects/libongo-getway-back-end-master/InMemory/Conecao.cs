using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.IO;
using Newtonsoft.Json;
using System;

namespace libongo.InMemory

{
  
  class DbConfig
  {
    public List<string> database{get;set;}
  }
  public class Connect : IConnect
  {
    public SqlConnection conn{ get;set;}
    public static SqlCommand _command;
    public static SqlDataReader _read;
    public static SqlDataAdapter _adapter;
    public static SqlConnection _connection;
    public SqlConnection strConn(string values){
      return new SqlConnection(@"Data Source=157.245.98.158;Initial Catalog="+values+";User ID=sa;Password=snirdb.123;MultipleActiveResultSets=True;");
    }
   
    public IEnumerable<TModel> connR<TModel>(string query,string values)
    {
      var  con = strConn(values);
      var  res = con.Query<TModel>(query);
      return res;
    }

    public string valor; 
    public SqlConnection Connection()
    {
      var db=File.ReadAllText("Databases/DBIS_NAMES.json");
      var _db=JsonConvert.DeserializeObject<DbConfig>(db);
      foreach (var item in _db.GetType().GetProperties())
      {
        foreach(var database in item.GetValue(_db) as List<string>)
        {
          var values=$"{database}";
          //var conn = new SqlConnection("Data Source=172.16.16.53;Initial Catalog="+values+";User ID=sa;Password=snirdb!2020;MultipleActiveResultSets=True;");
          strConn(values).Open();
          strConn(values).Close();
          //conn .Open();
        }
      }
      return conn;

    }
    public void Desconectar()
    {
      Connection().Close();
    }
    public int executeSQL(string query)
    {
      
    //  _command = new SqlCommand(query, _connection);
      var db=File.ReadAllText("Databases/DBIS_NAMES.json");
      int vt=0;
      var _db=JsonConvert.DeserializeObject<DbConfig>(db);
      foreach (var item in _db.GetType().GetProperties())
      {
        var data=item.GetValue(_db) as List<string>;
        
        for(var t=0;t<data.Count;t++)
        {
          var values=$"{data[t]}";
          
          try
          {
            var cond= strConn(values); 
            cond.Open();
            _command = new SqlCommand(query, cond);
             vt=_command.ExecuteNonQuery();
             cond.Close();
            break;
            
          }
          catch(Exception ex)
          { 
            var cond= strConn(data[t+1]); 
            cond.Open();
            _command = new SqlCommand(query, cond);
            
            vt=_command.ExecuteNonQuery();
            cond.Close();
            break;
          }
        }
      }
      
      return vt;
    }
    public SqlDataReader executeRead(string query)
    {
      this.Connection();
      _command = new SqlCommand(query, _connection);
      _command.Connection = _connection;
      _read = _command.ExecuteReader();
      return _read;
    }
    public IEnumerable<TModel> executeAd<TModel>(string query)
    {
      //SqlConnection con;
       //IEnumerable<TModel> res;
      var db=File.ReadAllText("Databases/DBIS_NAMES.json");
      var resJson="";
      var _db=JsonConvert.DeserializeObject<DbConfig>(db);
      foreach (var item in _db.GetType().GetProperties())
      {
        var data=item.GetValue(_db) as List<string>;
        
        for(var t=0;t<data.Count;t++)
        {
          var values=$"{data[t]}";
          
          try
          {
            var res=connR<TModel>(query, values);
            resJson=JsonConvert.SerializeObject(res);
            break;
            
          }
          catch(Exception ex)
          {
            var res=connR<TModel>(query,data[t+1]);
            resJson=JsonConvert.SerializeObject(res);
            break;
          }
        }
      }
     
      //Data Source=172.16.16.18;Initial Catalog=KONGSNIR;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;
      //var con = new SqlConnection(@"Data Source=172.16.16.53;Initial Catalog=KONGSNIR;User ID=sa;Password=snirdb!2020;MultipleActiveResultSets=True;");
     
      return JsonConvert.DeserializeObject<IEnumerable<TModel>>(resJson);
    }
    public SqlDataReader Exec(string exec)
    {
      var db=File.ReadAllText("Databases/DBIS_NAMES.json");
    
      var _db=JsonConvert.DeserializeObject<DbConfig>(db);
      foreach (var item in _db.GetType().GetProperties())
      {
        var data=item.GetValue(_db) as List<string>;
        
        for(var t=0;t<data.Count;t++)
        {
          var values=$"{data[t]}";
          
          try
          {
            var cond=strConn(values);
            cond.Open();
            _command = new SqlCommand($"{exec}", cond);
            _command.Connection = cond;
            _read = _command.ExecuteReader();
            
            break;
            
          }
          catch(Exception ex)
          {
            var cond=strConn(data[t+1]);
            cond.Open();
            _command = new SqlCommand($"{exec}", cond);
            _command.Connection = cond;
            _read = _command.ExecuteReader();
            //cond.Close();
            break;
          }
        }
      }
      
      return _read;
    }
    public SqlDataReader executeRead(string table, string prop, string valor)
    {
      this.Connection();
      _command = new SqlCommand($"SELECT*FROM {table} where {prop}='{valor}'", _connection);
      _command.Connection = _connection;
      _read = _command.ExecuteReader();
      return _read;
    }
  }
  public interface IConnect
  {
    IEnumerable<TModel> executeAd<TModel>(string query);
    SqlDataReader Exec(string exec);
    SqlDataReader executeRead(string query);
    SqlDataReader executeRead(string table, string prop, string valor);
    int executeSQL(string query);
    void Desconectar();
    SqlConnection Connection();
  }
}