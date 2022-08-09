﻿namespace WR.Consumers.Desktop.Domain.Core.MVVM.ViewModels;

public abstract class BaseUpdateViewModel<TGeneralType, TAggregatedType>
    : BaseReadViewModel<TGeneralType>
{
    #region Properties

    public ICommand? UpdateCommand { get; protected set; }

    public List<TAggregatedType> AggregatedDataList
    {
        get => _aggregatedDataList ?? new();
        set
        {
            _aggregatedDataList = value;

            OnPropertyChanged(nameof(AggregatedDataList));
        }
    }

    public TAggregatedType? SelectedAggregatedValue
    {
        get => _selectedAggregatedValue;
        set
        {
            _selectedAggregatedValue = value;

            OnPropertyChanged(nameof(SelectedAggregatedValue));
        }
    }

    public int? SelectedAggredatedValueIndex
    {
        get => _selectedAggregatedValueIndex;
        set
        {
            _selectedAggregatedValueIndex = value;

            OnPropertyChanged(nameof(SelectedAggredatedValueIndex));
        }
    }

    private List<TAggregatedType> _aggregatedDataList = new();

    private TAggregatedType? _selectedAggregatedValue;

    private int? _selectedAggregatedValueIndex;

    #endregion

    protected abstract bool CanExecuteUpdateCommand(object obj);

    protected abstract void ExecuteUpdateCommand(object obj);

    protected virtual void Clear()
    {
        SelectedGeneralValue = default;

        SelectedAggregatedValue = default;

        SelectedAggredatedValueIndex = default;
    }
}

public abstract class BaseUpdateViewModel<TGeneralType>
    : BaseReadViewModel<TGeneralType>
{
    public ICommand? UpdateCommand { get; protected set; }

    protected abstract bool CanExecuteUpdateCommand(object obj);

    protected abstract void ExecuteUpdateCommand(object obj);

    protected virtual void Clear() =>  SelectedGeneralValue = default;
}