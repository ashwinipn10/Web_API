using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {

        }

        //Table name should be same as Back End table
        public DbSet<UserMaster> tb_UserMaster { get; set; }

        public DbSet<RestDetails> tb_RestDetails { get; set; }

    }
}
