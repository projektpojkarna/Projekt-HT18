using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class CategoryList : List<string>
    {
        //TODO: en metod för att lägga till som kontrollerar att kategori-namnet inte finns

        public void AddCategory(string name)
        {
            if (this.Contains(name))
            {
                throw new Exception();
            }
            else
            {
                this.Add(name);
            }



        }
    }
}

