using TMPro;
using UnityEngine;


public class RpmView : VehicleDataView
{
    [SerializeField] private string _defaultView = "0";
    [SerializeField] private TMP_Text _view;
    
    
    public override void UpdateView(VehicleData vehicleData)
    {
        _view.text = vehicleData.EngineRotations.ToString("0") + "Tr/min";
    }

    public override void ResetView()
    {
        _view.text = _defaultView;
    }
}
