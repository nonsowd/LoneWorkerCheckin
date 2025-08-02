using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandArmVibrationCalculator.Avalonia.Services;

namespace HandArmVibrationCalculator.Avalonia.ViewModels;

public partial class EquipmentSetupPageViewModel : ViewModelBase
{
    private readonly IEquipmentService _equipmentService;

    [ObservableProperty]
    private List<EquipmentTypeViewModel> _availableTypes = new();
    [ObservableProperty]
    private List<EquipmentMakeViewModel> _availableMakes = new();
    [ObservableProperty]
    private List<EquipmentModelViewModel> _availableModels =new();

    [ObservableProperty]
    private EquipmentTypeViewModel _selectedType;
    [ObservableProperty]
    private EquipmentMakeViewModel _selectedMake;
    [ObservableProperty]
    private EquipmentModelViewModel _selectedModel;

    [ObservableProperty]
    private decimal _equipmentExposureLimit;

    [ObservableProperty]
    private decimal _equipmentExposureAction;

    public EquipmentSetupPageViewModel(IEquipmentService equipmentService)
    {
        _equipmentService = equipmentService;
    }

    [RelayCommand]
    private void OnSelectedTypeChanged()
    {

    }

    [RelayCommand]
    private void OnSelectedMakeChanged()
    {

    }

    [RelayCommand]
    private void OnSelectedModelChanged()
    {

    }

    [RelayCommand]
    private void OnPageLoaded()
    {
        var equipmentTypes = _equipmentService.GetAvailableEquipmentType();

        AvailableTypes  = equipmentTypes.Select(equipmentType => new EquipmentTypeViewModel()
        {
            Id = equipmentType.Id,
            Name = equipmentType.Name
        }).ToList();
    }

    [RelayCommand]
    private void Save()
    {

    }
}
