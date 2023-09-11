using TMPro;
using UnityEngine;


public class GearModeView : VehicleDataView
{
    [SerializeField] private string _defaultView = "-";
    [SerializeField] private TMP_Text _view;
    
    
    public override void UpdateView(VehicleData vehicleData)
    {
        _view.text = vehicleData.GearMode == 0 ? "Automatic" : "Manual";
    }

    public override void ResetView()
    {
        _view.text = _defaultView;
    }
}
