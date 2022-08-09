namespace WR.Consumers.Desktop.Presentation.Connectors;

internal static class ViewModelConnector
{
    public static TViewModel? Connect<TViewModel>(string? viewModelName = default)
        where TViewModel : BaseViewModel
    {
        TViewModel? viewModel = (ThisApplication.Current as App)?
            .ServiceProvider?.GetService<TViewModel>();

        ViewModelNotFoundException.ThrowIfNotFound(
            model: viewModel,
            message: viewModelName ?? typeof(TViewModel).Name);

        return viewModel;
    }
}