using System.Collections;
using UnityEngine;


public class HUD : MonoBehaviour
{
    [SerializeField] private float _updateInterval = 0.04f;
    [SerializeField] private VehicleDataView[] _views;
    
    private PlayerVehicleDataProvider _playerVehicleDataProvider;


    public void Initialize(PlayerVehicleDataProvider vehicleDataProvider, MonoBehaviour routineHandler)
    {
        _playerVehicleDataProvider = vehicleDataProvider;
        routineHandler.StartCoroutine(UpdateCoroutine());
    }
    
    private IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_updateInterval);

            if (_playerVehicleDataProvider.TryGetData(out var data))
                UpdateViews(data);
            else
                ResetViews();
        }
    }

    private void UpdateViews(VehicleData vehicleData)
    {
        foreach (var view in _views)
            view.UpdateView(vehicleData);
    }
    
    private void ResetViews()
    {
        foreach (var view in _views)
            view.ResetView();
    }
}
