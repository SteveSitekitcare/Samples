using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeaderIssue
{
    public class ViewModel: ObservableObject
    {
        public ObservableCollection<Model> MyModel { get; set; } 

        public ViewModel() 
        { 
            MyModel = new ObservableCollection<Model>();
        }
    }
}
