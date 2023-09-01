using UnityEngine;


public abstract class VehicleDataView : MonoBehaviour
{
	public abstract void UpdateView(VehicleData vehicleData);

	public abstract void ResetView();
}