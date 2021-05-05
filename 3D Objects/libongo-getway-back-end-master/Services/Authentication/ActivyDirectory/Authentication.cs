using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using libongo;
using libongo.Models;

namespace libongo.Services {
  public class Authentications {

    public SearchResult Query (DirectorySearcher ds, string username) {

      try
      {
        ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(samaccountname=" + username + "))";
        ds.SearchScope = SearchScope.Subtree;
        ds.ServerTimeLimit = TimeSpan.FromSeconds (90);
        var f = ds.FindOne();
        SearchResult userObject = ds.FindOne();
        return userObject;
      }
      catch (System.Exception)
      {
        return null;
        
      }
      
    }
  }
}