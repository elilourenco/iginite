using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libongo.Models
{
    public partial class Login
    {
        [Key]
        public string Id { get; set; }
        public string UserName {get;set;} 
        public string Email {get;set;} 
        public string PasswordHash {get;set;} 
        public string token {get;set;} 
        public string Role {get;set;} 
        public string message {get;set;} 
        public string Domain {get;set;}
        public string City {get;set;}
        public string Company {get;set;}
        public string Country {get;set;}
        public string TelephoneNumber {get;set;}
        public string LastName {get;set;}
        public string FirstName {get;set;}
        public virtual Persons AspNetUsers {get;set;}
    }
    
}
