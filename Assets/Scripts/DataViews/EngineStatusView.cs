using UnityEngine;
using UnityEngine.UI;


public class EngineStatusView : VehicleDataView
{
	[SerializeField] private Color _defaultView = Color.grey;
	[SerializeField] protected Image _view;
		
		
	public override void UpdateView(VehicleData vehicleData)
	{
		_view.color = vehicleData.IsEngineActive 
			? Color.green 
			: Color.red;
	}

	public override void ResetView()
	{
		_view.color = _defaultView;
	}
}