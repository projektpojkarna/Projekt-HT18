using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class CategoryList : List<string>
    {

        

        public void AddCategory(string namn)
        {
            if (this.Contains(namn))
            {
                
            }
            else
            {
                this.Add(namn);
            }
        
        }

        public void RemoveCategory(string namn)
        {
            this.Remove(namn);
        }

        public void ReNameCategory(string namn, string change)
        {
            for (int i = 0; i<this.Count; i++)
            
            {
                if (this[i].Contains(namn))
                {
                    this[i] = change;
                }
            }
        }

    
    }
}

