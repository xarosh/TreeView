using TreeView.Abstractions;
using TreeView.Helpers.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TreeView.Model
{
    public class CategoryBase : PropertyChangedClass, ICategory, IFiltering
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
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetValue(ref _Name, value);
            }
        }
        private bool _IsShown=true;
        public bool IsShown 
        {
            get
            {
                return _IsShown;
            }
            set
            {
                SetValue(ref _IsShown, value);
            }
        } 


        public CategoryBase()
        {
            Items = new ObservableCollection<ICategoryItem>();
        }

        public void Filter(string query)
        {
            if (string.IsNullOrEmpty(query))
                IsShown = false;
            else if (Name.ToLowerInvariant().Contains(query.ToLowerInvariant()))
                IsShown = true;
            else
                IsShown = false;
            foreach (var item in Items)
                (item as IFiltering).Filter(query);
        }
    }
}
