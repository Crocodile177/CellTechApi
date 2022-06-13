using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellTechApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CellTechApi.DbContexts
{
    public class CellPhoneContext : DbContext
    {
        public CellPhoneContext(DbContextOptions<CellPhoneContext> options) : base(options)
        {
        }

        public DbSet<CellPhone> CellPhones { get; set; }
    }
}
