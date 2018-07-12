using BaseBackend.API.Models;
using System;
using System.Linq;

namespace BaseBackend.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Teams.Any())
            {
                return;   // DB has been seeded
            }

            var teams = new Team[]
            {
              new Team{Group="A",Name="Russia"},
              new Team{Group="A",Name="Saudi Arabia"},
              new Team{Group="A",Name="Egypt"},
              new Team{Group="A",Name="Uruguay"},
              new Team{Group="B",Name="Portugal"},
              new Team{Group="B",Name="Spain"},
              new Team{Group="B",Name="Morocco"},
              new Team{Group="B",Name="Iran"},
              new Team{Group="C",Name="France"},
              new Team{Group="C",Name="Australia"},
              new Team{Group="C",Name="Peru"},
              new Team{Group="C",Name="Denmark"},
              new Team{Group="D",Name="Argentina"},
              new Team{Group="D",Name="Iceland"},
              new Team{Group="D",Name="Croatia"},
              new Team{Group="D",Name="Nigeria"},
              new Team{Group="E",Name="Brazil"},
              new Team{Group="E",Name="Switzerland"},
              new Team{Group="E",Name="Costa Rica"},
              new Team{Group="E",Name="Serbia"},
              new Team{Group="F",Name="Germany"},
              new Team{Group="F",Name="Mexico"},
              new Team{Group="F",Name="Sweden"},
              new Team{Group="F",Name="South Korea"},
              new Team{Group="G",Name="Belgium"},
              new Team{Group="G",Name="Panama"},
              new Team{Group="G",Name="Tunisia"},
              new Team{Group="G",Name="England"},
              new Team{Group="H",Name="Poland"},
              new Team{Group="H",Name="Senegal"},
              new Team{Group="H",Name="Colombia"},
              new Team{Group="H",Name="Japan"},
            };
            foreach (Team team in teams)
            {
                context.Teams.Add(team);
            }
            context.SaveChanges();
        }
    }
}