﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TreeView.Abstractions;
using TreeView.Helpers.MVVM;
using TreeView.Model;

namespace TreeView.ViewModels
{
  

    public class ViewModel : PropertyChangedClass
    {
       
        private readonly Random rnd;
        private string _Filter;


        public string Filter
        {
            get
            {
                return _Filter;
            }
            set
            {
                SetValue(ref _Filter, value);
            }
        }

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

        public ICommand LoadCommand { get; set; }
        public IList<ICategory> Categories { get; set; }
        public ICategoryItem SelectedCategoryItem { get; set; }

        private void Load()
        {
            var startPosition = Categories.Count == 0 ? 0 : Categories.Count;
            for (int i = startPosition; i < startPosition + 25; i++)
            {
                CategoryBase category = new CategoryBase();
                category.Name = $"Category{i + 1}";
                var itemsCount = rnd.Next(1, 11);
                for (int j = 0; j < itemsCount; j++)
                {
                    CategoryItemBase items = new CategoryItemBase();
                    var itemNumber = rnd.Next(1, 31);
                    var name = $"Item{itemNumber}";
                    var isExist = category.Items.Any(item => item.Name == name);
                    while (isExist)
                    {
                        itemNumber = rnd.Next(1, 31);
                        name = $"Item{itemNumber}";
                        isExist = category.Items.Any(item => item.Name == name);
                    }
                    items.Name = name;
                    category.Items.Add(items);
                }
                Categories.Add(category);
            }
        }
       


    }
}



