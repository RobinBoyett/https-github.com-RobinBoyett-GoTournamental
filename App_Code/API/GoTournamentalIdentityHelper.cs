using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity; 
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace GoTournamental.API.Identity 
{

	public class GoTournamentalIdentityHelper 
    {

		#region Users
		public void CreateUser(string userName, string password, string email) 
        {
			ApplicationDbContext context = new ApplicationDbContext(); 
			IdentityResult idUserResult; 
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 
			var appUser = new ApplicationUser() { UserName = userName, Email = email}; 
			idUserResult = userManager.Create(appUser, password); 					
		}
		public void CreateUserWithRole(string userName, string password, string email, string roleName) 
        {
			ApplicationDbContext context = new ApplicationDbContext(); 
			IdentityResult idRoleResult; 			
			IdentityResult idUserResult; 			
			var roleStore = new RoleStore<IdentityRole>(context); 
			var roleManager = new RoleManager<IdentityRole>(roleStore); 			
			if (!roleManager.RoleExists(roleName)) 
            { 
				idRoleResult = roleManager.Create(new IdentityRole(roleName)); 
			} 		
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 
			var appUser = new ApplicationUser() { UserName = userName, Email = email}; 
			idUserResult = userManager.Create(appUser, password); 					
			if (!userManager.IsInRole(userManager.FindByEmail(email).Id, roleName))
            {
				idUserResult = userManager.AddToRole(userManager.FindByEmail(email).Id, roleName);
			}
		}
        public string GetUserName(string userID)
        {
            string ret = ""; 
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = userManager.FindById(userID);
            if (appUser != null) 
            {
                ret = appUser.UserName;
            }
            return ret;
        }
        public string GetUserEmail(string userID) 
        {
            string ret = ""; 
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = userManager.FindById(userID);
            if (appUser != null) 
            {
                ret = appUser.Email;
            }
            return ret;
        }				
		#endregion

		#region Roles
		public void CreateRole(string roleName)
        {
			ApplicationDbContext context = new ApplicationDbContext(); 
			IdentityResult idRoleResult; 			
			var roleStore = new RoleStore<IdentityRole>(context); 
			var roleManager = new RoleManager<IdentityRole>(roleStore); 			
			if (!roleManager.RoleExists(roleName))
            { 
				idRoleResult = roleManager.Create(new IdentityRole(roleName)); 
			} 		
		}
		public void AddRoleForUser(string userID, string roleName) 
        {
			ApplicationDbContext context = new ApplicationDbContext(); 
			IdentityResult idUserResult; 			
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 
			idUserResult = userManager.AddToRole(userID, roleName); 
		}
		public void AddRoleForUser(string userName, string email, string roleName) 
        {
			ApplicationDbContext context = new ApplicationDbContext(); 
			IdentityResult idRoleResult; 
			IdentityResult idUserResult; 			
			var roleStore = new RoleStore<IdentityRole>(context); 
			var roleManager = new RoleManager<IdentityRole>(roleStore); 			
			if (!roleManager.RoleExists(roleName))
            { 
				idRoleResult = roleManager.Create(new IdentityRole(roleName)); 
			} 		
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)); 
			var appUser = new ApplicationUser() { UserName = userName, Email = email}; 
			if (!userManager.IsInRole(userManager.FindByEmail(email).Id, roleName))
            {
				idUserResult = userManager.AddToRole(userManager.FindByEmail(email).Id, roleName);
			}
		}
		public bool RoleExistsForUser(string userID, string roleName) 
        {
			bool ret = false;
			ApplicationDbContext context = new ApplicationDbContext(); 
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var appUser = userManager.FindById(userID);
			var roles = userManager.GetRoles(appUser.Id);
			if (roles.Contains(roleName))
            {
				ret = true;
			}
			return ret;
		}
		#endregion

		#region Claims
		public void AddClaimForUser(string userID, string claimType, string claimValue) 
        {
			ApplicationDbContext context = new ApplicationDbContext(); 
			IdentityResult idUserResult; 			
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			idUserResult = userManager.AddClaim(userID, new Claim(claimType, claimValue));
		}
		public bool ClaimExistsForUser(string userID, string claimType, string claimValue)
        {
			bool ret = false;
			ApplicationDbContext context = new ApplicationDbContext(); 
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var appUser = userManager.FindById(userID);
			if (appUser != null)
            {
				List<Claim> claims = userManager.GetClaims(appUser.Id).ToList();
				Claim claimToValidate = new Claim(claimType, claimValue);
				foreach (Claim claim in claims)
                {
					if (claim.Type == claimToValidate.Type && claim.Value == claimToValidate.Value)
                    {
						ret = true;
					}
				}
			}
			return ret;	
		}
        public bool UserHasCreatedTournament(string userID) 
        {
            bool ret = false;
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = userManager.FindById(userID);
            if (appUser != null) 
            {
                List<Claim> claims = userManager.GetClaims(appUser.Id).ToList();
                foreach (Claim claim in claims)
                {
                    if (claim.Type == "TournamentID") 
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }
        public int TournamentIDCreatedByUser(string userID)
        {
            int ret = 0;
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = userManager.FindById(userID);
            if (appUser != null)
            {
                List<Claim> claims = userManager.GetClaims(appUser.Id).ToList();
                foreach (Claim claim in claims) 
                {
                    if (claim.Type == "TournamentID") 
                    {
                        ret = Int32.Parse(claim.Value);
                    }
                }

            }
            return ret;
        }

		#endregion

	}

}