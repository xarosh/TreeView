using System.Collections.Generic;

namespace TreeView.Abstractions
{
    public interface ICategory
    {
        IList<ICategoryItem> Items { get; set; }
        string Name { get; set; }
    }
}
