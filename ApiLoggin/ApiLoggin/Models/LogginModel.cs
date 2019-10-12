using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiLoggin.Models
{
    public class LogginModel
    {
        [Key]     
        public string UserNamme { get; set; }
        public string Password { get; set; }
    }
}