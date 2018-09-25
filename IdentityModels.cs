﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace UniversityManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<UniversityManagementSystem.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystem.Models.Classroom> Classrooms { get; set; }
    }
}