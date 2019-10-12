using System;
using System.ComponentModel;

namespace CodeFirstMigration.Context  
{  
    public class Login  
    {  
      
        public int Id { get; set; }  
        [DisplayName("chung kens")]
        public string Username { get; set; }  
        [DisplayName("chung kens")]
        public string Password { get; set; }  
    }

   
} 