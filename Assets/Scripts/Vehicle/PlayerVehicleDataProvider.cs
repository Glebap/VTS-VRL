using VehiclePhysics;


public class PlayerVehicleDataProvider
{
    private readonly VehicleBase _vehicle;
    private readonly NearVehicleObserver _nearVehicleObserver;
    
    
    public PlayerVehicleDataProvider(VehicleBase vehicle, NearVehicleObserver nearVehicleObserver)
    {
        _vehicle = vehicle;
        _nearVehicleObserver = nearVehicleObserver;
        
        nearVehicleObserver.Initialize(_vehicle.transform);
    }
    
    public bool TryGetData(out VehicleData data)
    {
        data = default;
        if (_vehicle == null || !_vehicle.isActiveAndEnabled)
            return false;

        data = _nearVehicleObserver.TryGetNearVehicleDistance(out var distance) 
            ? new VehicleData(_vehicle.data, distance) 
            : new VehicleData(_vehicle.data);
            
        return true;
    }
}
