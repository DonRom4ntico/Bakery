using CarlBakerzShop.Models;
using Microsoft.AspNetCore.Identity;

namespace CarlBakerzShop.Services
{
	public class DatabaseInitializer
	{
		public static async Task SeedDataAsync(UserManager<ApplicationUser>? userManager,
			RoleManager<IdentityRole>? roleManager)

		{
			if (userManager == null || roleManager == null)
			{
				Console.WriteLine("userManager or roleManager is null => exit");
				return;
			}

			//awon nato kung naa tay admin or wala
			var exists = await roleManager.RoleExistsAsync("admin");
			if (!exists)
			{
				Console.WriteLine("Admin role is not defined and will be created");
				await roleManager.CreateAsync(new IdentityRole("admin"));
			}


			//awon nato kung naa tay seller or wala
			exists = await roleManager.RoleExistsAsync("seller");
			if (!exists)
			{
				Console.WriteLine("Seller role is not defined and will be created");
				await roleManager.CreateAsync(new IdentityRole("seller"));
			}


			//awon nato kung naa tay client or wala
			exists = await roleManager.RoleExistsAsync("client");
			if (!exists)
			{
				Console.WriteLine("Client role is not defined and will be created");
				await roleManager.CreateAsync(new IdentityRole("client"));
			}

			//awon nato kung naa bata admin maskig isa or wala
			var adminUsers = await userManager.GetUsersInRoleAsync("admin");
			if (adminUsers.Any())
			{
				Console.WriteLine("Admin user already exists => exit");
				return;
			}

			//create tag admin gois
			var user = new ApplicationUser()
			{
				FirstName = "Admin",
				LastName = "Admin",
				UserName = "admin@admin.com", //ang username pang authenticate sa user
				Email = "admin@admin.com",
				CreatedAt = DateTime.Now,
			};

			string initialPassword = "admin123";

			var result = await userManager.CreateAsync(user, initialPassword);
			if (result.Succeeded)
			{
				//mag set sa user role
				await userManager.AddToRoleAsync(user, "admin");
				Console.WriteLine("Admin user created successfully! Please update the initial password!");
				Console.WriteLine("Email: " + user.Email);
				Console.WriteLine("Initial Password: " + initialPassword);









			}
		}
	}
}
