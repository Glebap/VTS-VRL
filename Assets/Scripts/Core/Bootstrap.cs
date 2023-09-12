using UnityEngine;
using VehiclePhysics;
using VehiclePhysics.UI;


public class Bootstrap : MonoBehaviour
{
	[SerializeField] private MenuOverlay _menuOverlay;
	[SerializeField] private VehicleSpawner _vehicleSpawner;
	[SerializeField] private VPCameraController _cameraController;
	[SerializeField] private NearVehicleObserver _playerNearVehicleObserver;
	[SerializeField] private HUD _hud;


	private void Start()
	{
		var playerVehicleBase = _vehicleSpawner.SpawnPlayerVehicle();
		var playerVehicleDataProvider = new PlayerVehicleDataProvider(playerVehicleBase, _playerNearVehicleObserver);
		
		_hud.Initialize(playerVehicleDataProvider, this);
		_cameraController.target = playerVehicleBase.transform;
		_menuOverlay.vehicle = playerVehicleBase;
		
		_hud.Enable();
	}
}