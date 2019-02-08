namespace poll_application.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using poll_application.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<poll_application.Models.PollDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(poll_application.Models.PollDbContext context)
        {
            context.Polls.AddOrUpdate(p => p.Id,
              new Poll() { Id = 1, Name = "Android vs iOS", Date = DateTime.Now, MultiVote = false, Private = false, Votes = 0 },
              new Poll() { Id = 2, Name = "Which rpg game is the best?", Date = DateTime.Now, MultiVote = false, Private = false, Votes = 0 },
              new Poll() { Id = 3, Name = "Coffe vs Tea", Date = DateTime.Now, MultiVote = false, Private = false, Votes = 0 },
              new Poll() { Id = 4, Name = "Windows or Linux?", Date = DateTime.Now, MultiVote = false, Private = false, Votes = 0 },
              new Poll() { Id = 5, Name = "The best programming language", Date = DateTime.Now, MultiVote = false, Private = false, Votes = 0 }
            );

            context.PollOptions.AddOrUpdate(p => p.Id,
              new PollOption() { Name = "Android", PollId = 1, Votes = 0 },
              new PollOption() { Name = "iOS", PollId = 1, Votes = 0 },

              new PollOption() { Name = "The Witcher", PollId = 2, Votes = 0 },
              new PollOption() { Name = "Gothic", PollId = 2, Votes = 0 },
              new PollOption() { Name = "Fallout", PollId = 2, Votes = 0 },
              new PollOption() { Name = "Pillars of Eternity", PollId = 2, Votes = 0 },

              new PollOption() { Name = "Coffe", PollId = 3, Votes = 0 },
              new PollOption() { Name = "Tea", PollId = 3, Votes = 0 },

              new PollOption() { Name = "Windows", PollId = 4, Votes = 0 },
              new PollOption() { Name = "Linux", PollId = 4, Votes = 0 },

              new PollOption() { Name = "C#", PollId = 5, Votes = 0 },
              new PollOption() { Name = "Java", PollId = 5, Votes = 0 },
              new PollOption() { Name = "C", PollId = 5, Votes = 0 },
              new PollOption() { Name = "C++", PollId = 5, Votes = 0 },
              new PollOption() { Name = "Python", PollId = 5, Votes = 0 },
              new PollOption() { Name = "PHP", PollId = 5, Votes = 0 },
              new PollOption() { Name = "JavaScript", PollId = 5, Votes = 0 }
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
