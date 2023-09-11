using UnityEngine;
using VehiclePhysics;


public struct VehicleData
{
	private const float _minSpeed = 0.0f;
	private const float _minEngineRpm = 0.0f;
	
	public readonly float Speed;
	public readonly float EngineRotations;
	public readonly bool IsEngineActive;
	public readonly int GearPosition;
	public readonly bool IsSwitchingGear;
	public readonly int GearMode;

	public readonly float? NearestVehicleDistance;


	public VehicleData(DataBus dataBus)
	{
		var vehicleData = dataBus.Get(Channel.Vehicle);

		Speed = Mathf.Max(vehicleData[VehiclePhysics.VehicleData.Speed] / 1000.0f * 3.6f, _minSpeed);
		EngineRotations= Mathf.Max(vehicleData[VehiclePhysics.VehicleData.EngineRpm] / 1000.0f, _minEngineRpm);
		IsEngineActive = vehicleData[VehiclePhysics.VehicleData.EngineWorking] == 1;
		GearPosition = vehicleData[VehiclePhysics.VehicleData.GearboxGear];
		IsSwitchingGear = vehicleData[VehiclePhysics.VehicleData.GearboxShifting] != 0;
		GearMode = vehicleData[VehiclePhysics.VehicleData.GearboxMode];
		NearestVehicleDistance = null;
	}
	
	public VehicleData(DataBus dataBus, float nearestVehicleDistance) : this(dataBus) 
	{
		NearestVehicleDistance = nearestVehicleDistance;
	}
}