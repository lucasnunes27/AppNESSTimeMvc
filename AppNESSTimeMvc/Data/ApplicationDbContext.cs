using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AppNESSTimeMvc.Models;

namespace AppNESSTimeMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppNESSTimeMvc.Models.Time> Time { get; set; }
        public DbSet<AppNESSTimeMvc.Models.Jogador> Jogador { get; set; }
    }
}
