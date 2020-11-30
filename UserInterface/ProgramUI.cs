using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    class ProgramUI
    {
        private bool keepRunning = true;
        private DeveloperRepo devRepo = new DeveloperRepo();
        private DevTeamRepo devTeamRepo = new DevTeamRepo();
        

        public void Run()
        {
            CreateInitialListOfDevelopers();
            CreateIntialTeams();
            Menu();
           
        }

        

        public void Menu()
        {

            while (keepRunning)
            {
                
                //Display options to user
                DisplayOptions();

                DisplayDevelperlist();

                DisplayTeamList();

                Console.WriteLine("Please enter an option 1-7: ");

                //Get the users input
                int input = GetMenuOption();

                //evaluate user input and act on it
                EvaluateInput(input);
                
            }

        }

        private void EvaluateInput(int input)
        {
            switch (input)
            {
                case 1:
                    CreateNewDeveloper();
                    break;
                case 2:
                    CreateNewTeam();
                    break;
                case 3:
                    AddDeveloperToTeam();
                    break;
                case 4:
                    AddDevelopersToTeam();
                    break;
                case 5:
                    RemoveDevFromTeam();
                    break;
                case 6:
                    GetNumberOfLicensesNeeded();
                    break;
                case 7:
                    keepRunning = false;
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Please enter a valid number 1-7.");
                    break;

            }

            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }

        private void GetNumberOfLicensesNeeded()
        {
            Console.Clear();
            Console.WriteLine($"The number licenses needed are {devRepo.GetCountOfNeededPluarlSight()}.");
        }

        private void RemoveDevFromTeam()
        {
            Console.Clear();
            DisplayDevelperlist();
            DisplayTeamList();
            Console.WriteLine("Please enter the teamid: ");
            long teamid = GetValidID();
            Console.WriteLine("Please enter the id of the developer to remove from team: ");
            long devid = GetValidID();
            Developer d = devRepo.GetDeveloper(devid);
            bool removed = devTeamRepo.RemoveDeveloperFromTeam(teamid, d);
            if(removed)
            {
                Console.WriteLine("Developer removed");
            }
        }

        private void AddDevelopersToTeam()
        {
            Console.Clear();
            DisplayDevelperlist();
            DisplayTeamList();
            bool done = false;
            Console.WriteLine("Add developers to team type 0 to quit");
            Console.WriteLine("Please enter the teamid: ");
            long teamid = GetValidID();
            if (teamid == 0)
                done = true; 
            while (!done)
            {
                string team = "Please enter the id of the developer to add to team: " + teamid.ToString() + " type 0 to exit";
                Console.WriteLine(team);
                long devid = GetValidID();
                if (devid == 0)
                    break;
                Developer d = devRepo.GetDeveloper(devid);
                bool added = devTeamRepo.AddDeveloperToTeam(teamid, d);
                if (added)
                {
                    Console.Clear();
                    DisplayDevelperlist();
                    DisplayTeamList();
                }
                else
                {
                    Console.WriteLine("Please enter a valid developer id");
                    done = true;
                }
                
            }
        }




        private void AddDeveloperToTeam()
        {
            Console.Clear();
            DisplayDevelperlist();
            DisplayTeamList();
            Console.WriteLine("Please enter the teamid: ");
            long teamid = GetValidID();
            Console.WriteLine("Please enter the id of the developer to add to team: ");
            long devid = GetValidID();
            Developer d = devRepo.GetDeveloper(devid);
            bool added = devTeamRepo.AddDeveloperToTeam(teamid, d);
            if(added)
            {
                Console.WriteLine("Developer added to team " + teamid.ToString());
            }
            else
            {
                Console.WriteLine("Developer not added invalid id");
            }

        }

        private void CreateNewTeam()
        {
            Console.Clear();
            Console.WriteLine("Please enter team name: ");
            string name = Console.ReadLine();
            long id = devTeamRepo.GetUniqueTeamID();
            devTeamRepo.CreateNewTeam(id, name);

        }

        private void CreateIntialTeams()
        {
            DevTeam a = new DevTeam(1, "Blue");
            DevTeam b = new DevTeam(2, "Red");
            devTeamRepo.AddNewTeam(a);
            devTeamRepo.AddNewTeam(b);

        }

        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer d = new Developer();
            Console.WriteLine("Enter developers first name: ");
            d.First = Console.ReadLine();
            Console.WriteLine("Enter developers last name: ");
            d.Last = Console.ReadLine();
            Console.WriteLine("Has a pluarlsight license y/n");
            string lic = Console.ReadLine();
            if (lic == "y")
            {
                d.HasPluarlsight = true;
            }
            else
                d.HasPluarlsight = false;

            
            d.Id = devRepo.GetNextDeveloperID();
            devRepo.AddToDirectory(d);
        }

        private void CreateInitialListOfDevelopers()
        {
            //Load the intial list of developers
            List<Developer> devs = new List<Developer>()
            {
                new Developer("Bob","Brown",1,true),
                new Developer("Sam","Smith",2,false),
                new Developer("Cala","Sutton",3,true),
                new Developer("Jason","Kyle",4,false),
                new Developer("Jane","Doe",5,true),
                new Developer("Burt","Backarack",6,false)
            };

            devRepo.AddDevelopersToDirectory(devs);
        }

           
    

        private void DisplayDevelperlist()
        {
            Console.WriteLine("\nList of available developers");
            Console.WriteLine("---------------------------------------");
            foreach(Developer d in devRepo.GetDevelopers())
            {
                Console.WriteLine($"Id {d.Id} {d.First} {d.Last} has PluarlSightLicence {d.HasPluarlsight}");
            }
            Console.WriteLine();
           
        }

        private void DisplayTeamList()
        {
            Console.WriteLine("\nList of teams and developers on team");
            Console.WriteLine("---------------------------------------");
            foreach (DevTeam t in devTeamRepo.GetTeams())
            {
                Console.WriteLine($"Id {t.Id} {t.TeamName}");
                foreach(Developer d in t.GetDevelopers())
                {
                    Console.WriteLine($"\t {d.First} {d.Last} {d.HasPluarlsight}");
                }
            }
            Console.WriteLine();
        }

        private void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Select an option");
            Console.WriteLine("1. Create New Developer");
            Console.WriteLine("2. Create New Team");
            Console.WriteLine("3. Add Developer To Team");
            Console.WriteLine("4. Add Multiple Developers To Team");
            Console.WriteLine("5. Remove Developer From Team");
            Console.WriteLine("6. Get Numver Of Pluarlsight Licenses Needed");
            Console.WriteLine("7. Exit");
            
        }


        private int GetMenuOption()
        {
            string input = Console.ReadLine();
            int num = 0;
            bool proper = false;
            proper = int.TryParse(input, out num);
            while (input is null || input == "" || !proper)
            {
                Console.WriteLine("Please enter a valid integer resposne:");
                input = Console.ReadLine();
                proper = int.TryParse(input, out num);
            }

            return num;

        }

        private long GetValidID()
        {
            string input = Console.ReadLine();
            long num = 0;
            bool proper = false;
            proper = long.TryParse(input, out num);
            while (input is null || input == "" || !proper)
            {
                Console.WriteLine("Please enter a valid ID:");
                input = Console.ReadLine();
                proper = long.TryParse(input, out num);
            }
            return num;
        }
    }
}
