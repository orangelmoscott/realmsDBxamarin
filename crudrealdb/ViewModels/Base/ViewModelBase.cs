using System;
using System.ComponentModel;

namespace crudrealdb.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
