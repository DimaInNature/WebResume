namespace WR.Consumers.Desktop.Domain.Core.MVVM.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName));
}