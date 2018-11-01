using ProjektarbeteHT18.Business_Logic_Layer.Categories;
using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class CategoryList<T> : CustomList<Category>
    {
        public CategoryList() : base() {}

        public override bool Add(Category category)
        {
            var alreadyInList = Contains(category);
            if (!alreadyInList) {
                InnerList.Add(category);
            }
            return alreadyInList;
        }
        public Category Get(string categoryName)
        {
            return InnerList.Single((c) => c.CategoryName == categoryName);
        }

        public void Remove(string categoryName)
        {
            var catToRemove = Get(categoryName);
            InnerList.Remove(catToRemove);
        }

        public void Rename(string category, string newName)
        {
            Get(category).CategoryName = newName;
        }

        public override bool Contains(Category category)
        {
            return InnerList.Any((c) => c.CategoryName == category.CategoryName);
        }
    }


}
