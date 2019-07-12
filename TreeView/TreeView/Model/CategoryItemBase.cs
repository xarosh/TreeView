using TreeView.Helpers.MVVM;
using TreeView.Abstractions;

namespace TreeView.Model
{
    public class CategoryItemBase : PropertyChangedClass, ICategoryItem, IFiltering
    {
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
        private bool _IsShown = true;
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
       
        public void Filter (string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                IsShown = true;
            }
            else if (Name.ToLowerInvariant().Contains(query.ToLowerInvariant()))
            {
                IsShown = true;
            }
            else
            {
                IsShown = false;
            }
        }

    }
}
