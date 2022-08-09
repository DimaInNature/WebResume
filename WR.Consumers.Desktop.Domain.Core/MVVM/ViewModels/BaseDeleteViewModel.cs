namespace WR.Consumers.Desktop.Domain.Core.MVVM.ViewModels;

public abstract class BaseDeleteViewModel<TGeneralType>
    : BaseReadViewModel<TGeneralType>
{
    public ICommand? DeleteCommand { get; protected set; }

    protected abstract bool CanExecuteDeleteCommand(object obj);

    protected abstract void ExecuteDeleteCommand(object obj);

    protected virtual void Clear()
    {
        SelectedGeneralValue = default;
    }
}