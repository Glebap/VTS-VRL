using System.Collections;
using UnityEngine;


public class HUD : MonoBehaviour
{
    [SerializeField] private float _updateInterval = 0.04f;
    [SerializeField] private VehicleDataView[] _views;
    
    private PlayerVehicleDataProvider _playerVehicleDataProvider;
    private MonoBehaviour _routineHandler;
    private Coroutine _updateCoroutine; 


    public void Initialize(PlayerVehicleDataProvider vehicleDataProvider, MonoBehaviour routineHandler)
    {
        _playerVehicleDataProvider = vehicleDataProvider;
        _routineHandler = routineHandler;
    }

    public void Enable()
    {
        _updateCoroutine ??= _routineHandler.StartCoroutine(UpdateCoroutine());
    }
    
    private void Disable()
    {
        if (_updateCoroutine == null) return;
        
        StopCoroutine(_updateCoroutine);
        _updateCoroutine = null;
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
