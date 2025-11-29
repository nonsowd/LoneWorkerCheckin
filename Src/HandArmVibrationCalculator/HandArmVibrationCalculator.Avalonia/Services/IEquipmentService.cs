using HandArmVibrationCalculator.Avalonia.DomainModel;

namespace HandArmVibrationCalculator.Avalonia.Services;

public interface IEquipmentService
{
    List<EquipmentType>  GetAvailableEquipmentType();
}
