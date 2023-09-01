using VehiclePhysics;


public class PlayerVehicleDataProvider
{
    private readonly VehicleBase _vehicle;


    public PlayerVehicleDataProvider(VehicleBase vehicle)
    {
        _vehicle = vehicle;
    }
    
    public bool TryGetData(out VehicleData data)
    {
        data = default;
        if (_vehicle == null || !_vehicle.isActiveAndEnabled)
            return false;

        data = new VehicleData(_vehicle.data);
        return true;
    }
}
