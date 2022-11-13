using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Data.Context
{
    public class ShoppingCartAppContext : DbContext
    {
        public ShoppingCartAppContext(DbContextOptions<ShoppingCartAppContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {            
        }
    }
}
