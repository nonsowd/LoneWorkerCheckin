using HandArmVibrationCalculator.Avalonia.DomainModel;

namespace HandArmVibrationCalculator.Avalonia.Services;

public class EquipmentService : IEquipmentService
{
    public List<EquipmentType> GetAvailableEquipmentType()
    {
        return new()
        {
            new EquipmentType()
            {
                Id = Guid.NewGuid(),
                Name = "Test1"
            },
            new EquipmentType()
            {
                Id = Guid.NewGuid(),
                Name = "Test2"
            },
            new EquipmentType()
            {
                Id = Guid.NewGuid(),
                Name = "Test3"
            },
            new EquipmentType()
            {
                Id = Guid.NewGuid(),
                Name = "Test4"
            },
        };
    }
}
