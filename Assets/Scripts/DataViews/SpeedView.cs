using TMPro;
using UnityEngine;


public class SpeedView : VehicleDataView
{
	[SerializeField] private string _defaultView = "-";
	[SerializeField] private TMP_Text _view;
    
	
	public override void UpdateView(VehicleData vehicleData)
	{
		_view.text = vehicleData.Speed.ToString("0") + "km/h";
	}

	public override void ResetView()
	{
		_view.text = _defaultView;
	}
}
