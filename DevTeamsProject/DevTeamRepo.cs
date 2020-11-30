using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
       
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        

        

        public void CreateNewTeam(long id,string name)
        {
            DevTeam team = new DevTeam(id, name);
            _devTeams.Add(team);
        }

        public int GetUniqueTeamID()
        {
            return _devTeams.Count + 1;
        }


        public void AddNewTeam(DevTeam dev)
        {
            _devTeams.Add(dev);
        }


        public bool AddDeveloperToTeam(long teamid,Developer dev)
        {
            DevTeam team = FindTeamById(teamid);
           
            if (team != null)
            {
                team.AddToTeam(dev);
                return true;
            }
            else
                return false;
        }

        public void AddDevelopersToTeam(long teamid, List<Developer> devs)
        {
            DevTeam team = FindTeamById(teamid);
            if (team != null)
            {
                foreach(Developer d in devs)
                {
                    team.AddToTeam(d);
                }
            }
                
        }



        //DevTeam Read
        public List<DevTeam> GetTeams()
        {
            return _devTeams;
        }


        

        //DevTeam Update
        public bool updateTeam(long id, DevTeam team)
        {
            DevTeam oldTeam = FindTeamById(id);
            if (oldTeam != null)
            {
                oldTeam.TeamName = team.TeamName;
                oldTeam.Id = team.Id;
                return true;
            }
            else
                return false;

        }




        //DevTeam Delete
        public bool DeleteTeam(long id)
        {
            DevTeam team = FindTeamById(id);
            if(team != null)
            {
                _devTeams.Remove(team);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveDeveloperFromTeam(long teamid,Developer dev)
        {
            DevTeam team = FindTeamById(teamid);
            bool devRemoved = false;

            if(team != null)
            {
                devRemoved = team.RemoveFromTeam(dev);
            }

            return devRemoved;

        }


        //DevTeam Helper (Get Team by ID)
        private DevTeam FindTeamById(long id)
        {
            foreach (DevTeam d in _devTeams)
            {
                if (d.Id == id)
                {
                    return d;
                }
            }
            return null;

        }

    }
}
