using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.Interface
{
    public interface IListable
    {
        ListViewItem ToListViewItem();
    }
}
