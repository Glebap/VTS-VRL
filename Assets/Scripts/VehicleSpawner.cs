using UnityEngine;
using VehiclePhysics;


public class VehicleSpawner : MonoBehaviour
{
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private Vehicle _vehiclePrefab;

	
	public VehicleBase SpawnPlayerVehicle()
	{
		return Instantiate(_vehiclePrefab, _spawnPoint.position, _spawnPoint.rotation, transform).Base;
	}
}