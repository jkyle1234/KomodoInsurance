using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        
        public string First { get; set; }
        public long Id { get; set; }
        public string Last { get; set; }
        public bool HasPluarlsight { get; set; }

        public Developer() { }

        public Developer(string first,string last,long id,bool hasAccess)
        {
            First = first;
            Last = last;
            Id = id;
            HasPluarlsight = hasAccess;
        }

        public string GetFullName(long id)
        {
            return $"{First} {Last}";
        }

        

    }
}
