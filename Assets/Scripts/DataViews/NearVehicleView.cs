using TMPro;
using UnityEngine;


public class NearVehicleView : VehicleDataView
{
	[SerializeField] private string _defaultView = "-";
	[SerializeField] private TMP_Text _view;
			
		
	public override void UpdateView(VehicleData vehicleData)
	{
		if (vehicleData.NearestVehicleDistance.HasValue)
			_view.text = vehicleData.NearestVehicleDistance.Value.ToString("F2") + "m";
		else
			ResetView();
	}

	public override void ResetView()
	{
		_view.text = _defaultView;
	}
}