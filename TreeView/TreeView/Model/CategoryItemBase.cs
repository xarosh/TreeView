using TreeView.Helpers.MVVM;
using TreeView.Abstractions;

namespace TreeView.Model
{
    public class CategoryItemBase : PropertyChangedClass, ICategoryItem,IFiltering
    {
        public string Name { get; set; }
        public bool IsShown { get; set; } = true;
       
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
