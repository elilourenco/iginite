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

[assembly : SecurityPermission (SecurityAction.RequestMinimum, Execution = true)]
[assembly : DirectoryServicesPermission (SecurityAction.RequestMinimum)]

namespace libongo.Services {
  public  class Conecnation{

    public  DirectorySearcher GetDirectorySearch (Login user) {
      
      DirectorySearcher dirSearcher = null;

      if (dirSearcher == null) {
        try {
          dirSearcher = new DirectorySearcher(new DirectoryEntry("LDAP://"+user.Domain,user.UserName,user.PasswordHash));

        } catch (DirectoryServicesCOMException e) {
          user.message= e.Message.ToString();
          throw;
        }
        return dirSearcher;
      }
      else
      {
        return dirSearcher;
      }
    }
  }
}