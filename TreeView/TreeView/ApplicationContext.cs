using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TreeView.Abstractions;
using TreeView.Helpers.MVVM;

namespace TreeView
{
    public class ApplicationContext: PropertyChangedClass
    {
        private IList<ICategoryItem> _Items;
        public IList<ICategoryItem> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                SetValue(ref _Items, value);
            }
        }
    }
}
