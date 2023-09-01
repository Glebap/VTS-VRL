using TMPro;
using UnityEngine;


public class NearVehicleView : VehicleDataView
{
	[SerializeField] private NearVehicleObserver _nearVehicleObserver;
	[SerializeField] private string _defaultView = "-";
	[SerializeField] private TMP_Text _view;
			
		
	public override void UpdateView(VehicleData vehicleData)
	{
		var distance = _nearVehicleObserver.GetNearVehicleDistance(vehicleData.Position);
			
		_view.text = distance.HasValue 
			? distance.Value.ToString("F2") + "m" 
			: _defaultView;
	}

	public override void ResetView()
	{
		_view.text = _defaultView;
	}
}