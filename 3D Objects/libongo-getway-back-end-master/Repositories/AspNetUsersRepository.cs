using System.Reflection.Metadata;
using System.Linq;
using libongo.InMemory;
using libongo.Models;
using libongo.Services;

namespace libongo.Repositories
{
  public static class AspNetUserspository
  {
    public static AspNetUsers Get(string username, string password, string email)
    {
      var users = new Connect().executeAd<AspNetUsers>($"Select *from AspNetUsers where UserName='{username}' and PasswordHash='{password}' or Email='{email}' and PasswordHash='{password}'").FirstOrDefault();
      return users;
    }
  }
}