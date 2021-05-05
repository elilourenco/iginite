using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using libongo;
using libongo.Models;
using Microsoft.IdentityModel.Tokens;

namespace libongo.Services {
  public class PasswordHash {

    public string EncodeTo64 (string PasswordHash) {
      try {
        byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes (PasswordHash);
        string returnValue = System.Convert.ToBase64String (toEncodeAsBytes);
        return returnValue;
      } catch (System.Exception) {

        throw;
      }

    }

    public string DecodeFrom64 (string PasswordHash) {
      try {
        byte[] encodedDataAsBytes = System.Convert.FromBase64String (PasswordHash);
        string returnValue = System.Text.ASCIIEncoding.ASCII.GetString (encodedDataAsBytes);
        return returnValue;
      } catch (System.Exception) {

        throw;
      }

    }

  }
}