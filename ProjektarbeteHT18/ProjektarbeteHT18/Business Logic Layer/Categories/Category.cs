using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.Categories
{
    public class Category : IListable, ICategory
    {
        public string CategoryName { get; set; }

        public Category(string CategoryName) { this.CategoryName = CategoryName; }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new[] { CategoryName });
        }
    }
}
