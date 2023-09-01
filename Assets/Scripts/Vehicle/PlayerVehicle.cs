using UnityEngine;
using VehiclePhysics;

[RequireComponent(typeof(VPVehicleController))]
[RequireComponent(typeof(VPStandardInput))]
[RequireComponent(typeof(VPCameraTarget))]
[RequireComponent(typeof(VPTelemetry))]
[RequireComponent(typeof(VPVisualEffects))]
[RequireComponent(typeof(VPResetVehicle))]
public class PlayerVehicle : MonoBehaviour
{
	public VehicleBase Base { get; private set; }

	public void Awake()
	{
		Base = GetComponent<VehicleBase>();
	}
}