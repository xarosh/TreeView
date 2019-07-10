using TreeView.ViewModels;
using TreeView.Abstractions;

using TreeView.Helpers.MVVM;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TreeView.Model
{
    public abstract class CategoryBase: PropertyChangedClass,ICategory, IFiltering
    {
        public IList<ICategoryItem> Items { get ; set ; }
        public string Name { get ; set; }
        public bool IsShown { get; set; } = true;


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
