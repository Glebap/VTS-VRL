using UnityEngine;
using VehiclePhysics;


public class VehicleSpawner : MonoBehaviour
{
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private Vehicle _vehiclePrefab;
	[SerializeField] private PlayerVehicle _pLayerVehiclePrefab;

	
	public VehicleBase SpawnPlayerVehicle()
	{
		return Instantiate(_pLayerVehiclePrefab, _spawnPoint.position, _spawnPoint.rotation, transform).Base;
	}
}