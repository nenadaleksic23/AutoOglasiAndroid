using AutoOglasiAndroid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutoOglasiAndroid.ViewModels
{
    class MainPageViewModel
    {
        public ObservableCollection<Test> items { get; set; } = new ObservableCollection<Test>();

        public MainPageViewModel()
        {
            for (int i = 0; i < 5; i++)
            {
                Test t = new Test()
                {
                    Name = i.ToString() + "Ime",
                    Age = (18 + i).ToString()

                };
                items.Add(t);
            }
        }
    }
}
