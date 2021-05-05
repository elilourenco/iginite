using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using libongo.InMemory;
using libongo.Models;

namespace libongo.Helpers {

  public interface IAReadFile {
    void GerarModelsTable (string tabela);
  }

  public class ReadFile : IAReadFile {

    public static readonly string GlobalRootPath = BackFolder (AppDomain.CurrentDomain.BaseDirectory, 5) + "\\"; // internacionalSeguros/...
    static string BackFolder (string path, int n) {
      for (int i = 0; i < n; i++)
        path = Directory.GetParent (path).FullName;

      return path;
    }
    public static Dictionary<string, string> mapTypes = new Dictionary<string, string> { { "String", "string" },
      { "string", "String" },
      { "Int", "int" },
      { "date", "Date" },
      { "Date", "Date" },
      { "int identity", "Int" },
      { "Double", "double" },
      { "double", "Float" },
      { "bool", "Boolean" },
      { "Float", "float" },
      { "Bool", "bool" },
      { "DateTime", "DateTime" },
      { "varchar", "string" },
      { "datetime", "DateTime" },
      { "float", "double" },
      { "int", "int" },
      { "bit", "bool" },
      { "text", "string" },
      { "money", "double" },
      { "nvarchar", "string" },
      { "datetime2", "DateTime" },
      { "ntext", "string" },
      { "datetimeoffset", "DateTime" }
    };
    static readonly string solutionPath = GlobalRootPath;

    public string MapTypes (string str) {
      // Verificar a str
      if (string.IsNullOrEmpty (str)) return null;
      // Verificar .pdf / pdf
      str = str.Replace (".", "");
      return mapTypes.FirstOrDefault (x => x.Key == str).Value;
    }
    public string infoTable (string tabela, string or) {
      var dr = new Connect ().Exec ($"EXEC sp_constr_col_usage_rowset '{tabela}'");
      var props = "";
      while (dr.Read ()) {
        var _constraint = dr["CONSTRAINT_NAME"].ToString ();
        var _column = dr["COLUMN_NAME"].ToString ();

        if (_column.Contains ("ID") || _column != $"Id{tabela}") {
          var _olderTex = _column.Replace ("ID", string.Empty);
          var _tableName = _column.Substring (-2);
          _tableName = _column.Replace ("Id", "");
          _tableName = _column.Replace ("id", "");
          var _primaryKey = $"Id{_tableName}";
        }

      }
      props += ",";
      var f = props.Replace (",,", "");
      var fd = f.Replace (",", " or ");
      new Connect ().Desconectar ();
      return fd;

    }
 public void creatController(ApiResources model)
 {
    var controllerFolder = @$"{solutionPath}libongo\Controllers\{model.Name}Controller.cs";
    var tmpcontroller = File.ReadAllText ($@"{solutionPath}libongo\Template\controller.txt");
     tmpcontroller=tmpcontroller.Replace("ApiName",model.Name);
     tmpcontroller=tmpcontroller.Replace("pathUrl",model.path.Replace("/",""));
     //model.path=model.path.Replace("/","");
    if(model.port!=80)
      tmpcontroller=tmpcontroller.Replace("urlApplication",$"{model.Protocol}://{model.host}:{model.port}");
    else
      tmpcontroller=tmpcontroller.Replace("urlApplication",$"{model.Protocol}://{model.host}{model.path}");
      CreateFile(controllerFolder,tmpcontroller);
 }
    public void GerarModelsTable (string tabela) {
      var dr = new Connect ().Exec ($"EXEC sp_columns '{tabela}'");
      var _prop = "";
      var _propType = "";
      var _propInputType = "";
      while (dr.Read ()) {
        var _inverTable = "";
        var _column = dr["COLUMN_NAME"].ToString ();
        var _type = dr["TYPE_NAME"].ToString ();
        var type = MapTypes (_type);
        var _enc = "{get;set;} ";
        if (_column.Contains ("Id") == true || _column == $"Id" || _column.Contains ("ID") == true) {
          var tan = _column.Length - 2;
          var _tan = _column.Split ();
          _inverTable = _column.Replace ("Id", "");
          _inverTable = _inverTable.Replace ("ID", "");

          if (_column == $"Id{tabela}") {
            _prop += $"[Key] public {type} {_column} {_enc}";
            _propType += $" Field(x => x.{_column}, nullable: true);";

          } else {
            var drs = new Connect ().Exec ($"select*from infoTable where ReferenceTableName='{tabela}' and ReferenceColumnName='{_column}'");
            while (drs.Read ()) {
              // FieldAsync<ListGraphType<ApiScopesType>>("ApiScopes", resolve : async c => new manipulacao ().selectOne<ApiScopes> (new ApiScopes (), "ApiScopes"));
              _propType += $"FieldAsync<ListGraphType<{drs["PrimaryTableName"].ToString()}Type>>('{drs["PrimaryTableName"].ToString()}', resolve : async c =>c.Source.{_column} == null?null :  new manipulacao().selectOne<{drs["PrimaryTableName"].ToString()}> (new {drs["PrimaryTableName"].ToString()}(),c.Source.{_column}.ToString()));";
              //_propType += $"FieldAsync<{drs["PrimaryTableName"].ToString()}Type>('{drs["PrimaryTableName"].ToString()}', resolve: async c => c.Resolve(await c.GetRepository().GetAsync<{drs["PrimaryTableName"].ToString()}>(c.Source.{_column})));";
              _propInputType += $"Field<{type.ToUpper()[0]}{type.Substring(1)}GraphType>('{_column}');";
              _propInputType += $"Field<{drs["PrimaryTableName"].ToString()}InputType>('{drs["PrimaryTableName"].ToString()}');";
              var _F = $"[ForeignKey('{_column}')][InverseProperty('{tabela}')]";
              _prop += $"public {type} {_column} {_enc}";
              _prop += $"{_F} public virtual {drs["PrimaryTableName"].ToString()} { drs["PrimaryTableName"].ToString()} {_enc}";
            }

          }

        } else {
          if (_column == "CaminhoFicheiro")
            _propInputType += $"Field<ListGraphType<FileDtoInputType>>('ficheiro');";
          var _types = MapTypes (type);
          _propType += $" Field(x => x.{_column}, nullable: true);";
          _propInputType += $"Field<{_types.ToUpper()[0]}{_types.Substring(1)}GraphType>('{_column}');";
          _prop += $"public {type} {_column} {_enc}";
        }
      }


      var modelFolder = @$"{solutionPath}libongo\GraphiQl.Models\Models\{tabela}.cs";
      var modelFolders = @$"{solutionPath}libongo\GraphiQl.Models\Type\{tabela}Type.cs";
      var modelFolderappQuery = @$"{solutionPath}libongo\GraphiQl.Config\Query.cs";
      var modelFolderahelps = @$"{solutionPath}libongo\Helpers\help.cs";
      var modelFolderappMutation = @$"{solutionPath}libongo\GraphiQl.Config\Mutation.cs";
      var tmp = File.ReadAllText ($@"{solutionPath}libongo\Template\AppFields.txt");
      var tmps = File.ReadAllText ($@"{solutionPath}libongo\Template\AppModels.txt");
      var appQuery = File.ReadAllText ($@"{solutionPath}libongo\GraphiQl.Config\Query.cs");
      var helps = File.ReadAllText ($@"{solutionPath}libongo\Helpers\help.cs");
      var AppMutation = File.ReadAllText ($@"{solutionPath}libongo\GraphiQl.Config\Mutation.cs");
      var tmptype = File.ReadAllText ($@"{solutionPath}libongo\Template\AppQuery.txt");
      tmptype = tmptype.Replace ("tabelaName", $"{tabela}");
      var tmptypes = File.ReadAllText ($@"{solutionPath}libongo\Template\AppMutation.txt");
      tmptypes = tmptypes.Replace ("tabelaName", $"{tabela}");
      var pp = "\"";
      helps = helps.Replace ("//serviceaddSfgghhhghgh", $"services.AddSingleton<{tabela}Type>();services.AddSingleton<{tabela}InputType>();  //serviceaddSfgghhhghgh");
      AppMutation = AppMutation.Replace ("//AppMutationFields", $"{tmptypes}");
      appQuery = appQuery.Replace ("//AppQueryFields", $"{tmptype}");
      tmp = tmp.Replace ("tabelaName", $"{tabela}");
      tmp = tmp.Replace ("propiiiType", $"{_propType}");
      tmp = tmp.Replace ("propinputType", $"{_propInputType}");
      tmp = tmp.Replace ("'", $"{pp}");
      tmp = tmp.Replace (@"\", "");
      tmps = tmps.Replace ("tabelaName", $"{tabela}");
      tmps = tmps.Replace ("proplist", $"{_prop}");
      tmps = tmps.Replace ("'", $"{pp}");
      tmps = tmps.Replace (@"\", "");
      CreateFile (modelFolderappMutation, AppMutation);
      CreateFile (modelFolderappQuery, appQuery);
      CreateFile (modelFolders, tmp);
      CreateFile (modelFolder, tmps);
      CreateFile (modelFolderahelps, helps);
      //var files = Directory.GetFiles(modelFolder).Select(s => new{Name = s.Split("\\").LastOrDefault().Replace(".cs", ""),Path = s,Content = File.ReadAllLines(s)}).ToList();
    }

    public void CreateFile (string caminho, string conteudo) {
      caminho = caminho.Replace ("\\", "/");
      FileStream fs = File.Create (caminho);
      StreamWriter sws = new StreamWriter (fs);
      sws.WriteLine (conteudo);
      sws.Flush ();
      sws.Close ();
      fs.Close ();
    }
    
  }
}