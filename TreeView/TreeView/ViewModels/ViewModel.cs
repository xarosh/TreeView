using System;
using System.Collections.Generic;
using System.Linq;
using TreeView.Helpers.MVVM;
using System.Windows.Input;
using System.Collections.ObjectModel;
using TreeView.Abstractions;
using TreeView.Model;

namespace TreeView.ViewModels
{

    public class ViewModel : PropertyChangedClass
    {
        private readonly Random rnd;

        public string Filter { get; set; } = string.Empty;

        public ViewModel()
        {
            rnd = new Random();
            LoadCommand = new RelayCommand(Load);
            Categories = new ObservableCollection<ICategory>();
            PropertyChanged += ViewModel_PropertyChanged;
        }
        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Filter))
                foreach (var category in Categories)
                    (category as IFiltering).Filter(Filter);
        }

        public ICategoryItem SelectedItem { get; set; }
        public IList<ICategory> Categories { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICategory category { get; set; }
        private void Load()
        {
            var startPosition = Categories.Count == 0 ? 0 : Categories.Count;
            for (int i = startPosition; i < startPosition + 25; i++)
            {
             //   var category = CategoryBase;
                category.Name = $"Category{i + 1}";
                var itemsCount = rnd.Next(1, 11);
                for (int j = 0; j < itemsCount; j++)
                {
                    var itemNumber = rnd.Next(1, 31);
                    var name = $"Item{itemNumber}";
                    var isExist = category.Items.Any(item => item.Name == name);
                    while (isExist)
                    {
                        itemNumber = rnd.Next(1, 31);
                        name = $"Item{itemNumber}";
                        isExist = category.Items.Any(item => item.Name == name);
                    }
                    SelectedItem.Name = name;
                    category.Items.Add(SelectedItem);
                }
                Categories.Add(category);
            }
        }

    }
}

