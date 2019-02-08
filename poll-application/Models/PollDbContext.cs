using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace poll_application.Models
{
    public class PollDbContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public PollDbContext() : base("Poll Connection")
        {

        }

        public static PollDbContext Create()
        {
            return new PollDbContext();
        }
    }
}