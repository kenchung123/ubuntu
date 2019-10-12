using System.Collections.Generic;
using System.Threading.Tasks;
using ApiLoggin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoggin.Service
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<LogginModel>>> GetUser();
        Task<ActionResult> PostUser(string username, string password);
        Task<ActionResult<LogginModel>> ChangePassword(string usename, string oldpass, string newpass);
    }
}