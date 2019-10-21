using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Models
{
  public class UserModel : IdentityUser
  {
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int RoleID { get; set; }
  }
}
