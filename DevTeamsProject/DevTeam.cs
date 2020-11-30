using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        
        public long Id { get; set; }
        public string TeamName { get;set;}
        private List<Developer> developers = new List<Developer>();


        public DevTeam() { }

        public DevTeam(long id)
        {
            Id = id;
        }

        public DevTeam(long id,string name)
        {
             Id = id;
             TeamName = name;
           
        }

        public List<Developer> GetDevelopers()
        {
            return developers;
        }

        public void AddToTeam(Developer dev)
        {
            developers.Add(dev);
        }

        public bool RemoveFromTeam(Developer dev)
        {
            bool onTeam = FindDeveloperOnTeam(dev);
            if (onTeam)
            {
                developers.Remove(dev);
                return true;
            }
            else
                return false;

        }



        public bool FindDeveloperOnTeam(Developer dev)
        {
            foreach(Developer d in developers)
            {
                if (d.Id == dev.Id)
                {
                    return true;
                }
          
            }

            return false;
        }



        

      

        


        

    }
}
