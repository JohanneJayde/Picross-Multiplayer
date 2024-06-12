﻿using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;
using System;
using Picross_Unlimited.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Picross_Unlimited.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext db)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles

    }

    private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
    {
        // Seed Admin User

    }
    private static async Task SeedUserAccountAsync(ModelBuilder modelBuilder)
    {
        AppUser user = new AppUser
        {
            ProfileIcon = "\\eb3b",
            ProfileColor = "Primary",
            UserName = "new_user",
            Email = "passw0rd123#"

        };
        modelBuilder.Entity<AppUser>().HasData(user);

    }
}