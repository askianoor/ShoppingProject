using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Models
{
  public class UserRole : IdentityRole
  {
    public int RoleID { get; set; }
    public string RoleName { get; set; }
  }
}
