using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddToDirectory(Developer d)
        {
            _developerDirectory.Add(d);
        }

        public void AddDevelopersToDirectory(List<Developer> devs)
        {
            foreach(Developer d in devs)
            {
                AddToDirectory(d);
            }
        }

        //Developer Read
        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }

        public Developer GetDeveloper(long id)
        {
            Developer d = FindDeveloperById(id);
            return d;
        }

        public int GetNextDeveloperID()
        {
            return _developerDirectory.Count + 1;
        }


        //Developer Update
        public bool UpdateDeveloper(long id, Developer d)
        {
            Developer olddev = FindDeveloperById(id);
            if (olddev != null)
            {
                olddev.First = d.First;
                olddev.Last = d.Last;
                olddev.Id = d.Id;
                olddev.HasPluarlsight = d.HasPluarlsight;
                return true;
            }
            else
                return false;
        }



        //Developer Delete
        public bool RemoveDeveloper(long id)
        {
            Developer d = FindDeveloperById(id);
            if (d != null)
            {
                _developerDirectory.Remove(d);
                return true;
            }
            else
                return false;
        }


        public int GetCountOfNeededPluarlSight()
        {
            int count = 0;
            foreach(Developer d in _developerDirectory)
            {
                if (d.HasPluarlsight == false)
                    count++;
            }

            return count;
        }





        //Developer Helper (Get Developer by ID)
        private Developer FindDeveloperById(long id)
        {
            foreach (Developer d in _developerDirectory)
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
