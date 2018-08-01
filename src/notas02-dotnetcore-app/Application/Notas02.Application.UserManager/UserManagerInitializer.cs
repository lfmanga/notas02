using Microsoft.AspNetCore.Identity;
using Notas02.Application.UserManager.Identity.Context;
using Notas02.Application.UserManager.Identity.Models;
using System;

namespace Notas02.Application.UserManager
{
    public class UserManagerInitializer
    {
        private readonly UserManager<Notas02User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagerInitializer(UserManager<Notas02User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            CreateUser(new Notas02User()
            {
                UserName = "admin",
                Email = "admin@notas02.com.br",
                EmailConfirmed = true
            }, "ADMIN@notas02");
        }

        private void CreateUser(Notas02User user, string password, string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var result = _userManager.CreateAsync(user, password).Result;

                if (result.Succeeded && !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
