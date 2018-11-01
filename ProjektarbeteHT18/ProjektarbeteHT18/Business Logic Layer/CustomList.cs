using Newtonsoft.Json;
using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public abstract class CustomList<T> where T : IListable
    {
        [JsonProperty] protected List<T> InnerList { set; get; }

        public CustomList()
        {
            InnerList = new List<T>();
        }

        public virtual List<T> GetAll()
        {
            return InnerList;
        }

        public virtual bool Add(T obj)
        {
            var alreadyInList = InnerList.Contains(obj);
            if (!Contains(obj))
            {
                InnerList.Add(obj);
            }
            return alreadyInList;
        }

        public virtual void Remove(T obj)
        {
            InnerList.Remove(obj);
        }

        public virtual T Get(T obj)
        {
            return InnerList.Single((o) => o.Equals(obj));
        }

        public virtual bool Contains(T obj)
        {
            return InnerList.Contains(obj);
        }

        public ListViewItem[] ToListViewItems()
        {
            var list = new List<ListViewItem>();
            foreach(T obj in InnerList)
            {
                list.Add(obj.ToListViewItem());
            }
            return list.ToArray();
        }
    }
}
