using UnityEngine;
using VehiclePhysics;


public class PlayerVehicleDataProvider
{
    private readonly VehicleBase _vehicle;
    private readonly Transform _vehicleTransform;


    public PlayerVehicleDataProvider(VehicleBase vehicle)
    {
        _vehicle = vehicle;
        _vehicleTransform = vehicle.transform;
    }
    
    public bool TryGetData(out VehicleData data)
    {
        data = default;
        if (_vehicle == null || !_vehicle.isActiveAndEnabled)
            return false;

        data = new VehicleData(_vehicle.data, _vehicleTransform.position);
        return true;
    }
}
