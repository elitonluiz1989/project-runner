using ProjectRunner.WPF.Mapping;
using System;
using System.ComponentModel;

namespace ProjectRunner.WPF.ViewModels
{
    public class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }

        public TType CastTo<TType>()
        {
            return AppMapper.Map<TType>(this);
        }

        public static TViewModel CreateFrom<TType, TViewModel>(TType obj)
        {
            return AppMapper.Map<TViewModel>(obj);
        }
    }
}
