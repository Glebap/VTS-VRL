using TMPro;
using UnityEngine;


public class GearStateView : VehicleDataView
{
    [SerializeField] private string _defaultView = "-";
    [SerializeField] private TMP_Text _view;
    
    
    public override void UpdateView(VehicleData vehicleData)
    {
        int gearId = vehicleData.GearPosition;
        int gearMode = vehicleData.GearMode;
        bool switchingGear = vehicleData.IsSwitchingGear;

        string gearLabelValue;
        if (gearMode == 0) // Manual
        {
            if (gearId == 0)
                gearLabelValue = switchingGear ? _defaultView : "N";
            else
                gearLabelValue = gearId > 0 ? gearId.ToString() : (gearId == -1 ? "R" : "R" + (-gearId));
        }
        else // Automatic
        {
            gearLabelValue = gearMode switch
            {
                1 => "P",
                2 => gearId < -1 ? "R" + (-gearId) : "R",
                3 => "N",
                4 => gearId > 0 ? "D" + gearId : "D",
                5 => gearId > 0 ? "L" + gearId : "L",
                _ => _defaultView
            };
        }

        _view.text = gearLabelValue;
    }

    public override void ResetView()
    {
        _view.text = _defaultView;
    }
}
