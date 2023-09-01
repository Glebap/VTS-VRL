using UnityEngine;
using VehiclePhysics;


public class NearVehicleObserver : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private int _maxVehicles = 10;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private LayerMask vehicleLayer;

    private VPCameraController _cameraController;

    private Collider[] _nearColliders;
    
    
    private void Awake()
    {
        _nearColliders = new Collider[_maxVehicles];
    }

    public float? GetNearVehicleDistance(Vector3 vehiclePosition)
    {
        var size = Physics.OverlapSphereNonAlloc(vehiclePosition, 
            _maxDistance, _nearColliders, vehicleLayer);

        if (size <= 0)
            return null;

        float nearestDistance = float.MaxValue;
        for (var i = 0; i < size; i++)
        {
            var nearVehiclePosition = _nearColliders[i].transform.position;
            if (HasObstacleBetweenPlayerAndCar(vehiclePosition, nearVehiclePosition) 
                || !IsInFieldOfView(nearVehiclePosition)) continue;
            
            float distance = Vector3.Distance(vehiclePosition, nearVehiclePosition);
            
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
            }
        }

        return nearestDistance > _maxDistance ? null : nearestDistance;
    }

    private bool HasObstacleBetweenPlayerAndCar(Vector3 vehiclePosition, Vector3 nearVehiclePosition)
    {
        Vector3 direction = nearVehiclePosition - vehiclePosition;
        
        return Physics.Raycast(new Ray(vehiclePosition, direction), out RaycastHit hit, _maxDistance) 
               && hit.collider.gameObject.layer != vehicleLayer;
    }

    private bool IsInFieldOfView(Vector3 targetPosition)
    {
        var cameraTransform = _mainCamera.transform;
        Vector3 toTarget = targetPosition - cameraTransform.position;
        float angle = Vector3.Angle(toTarget, cameraTransform.forward);

        float fieldOfView = _mainCamera.fieldOfView;

        return angle <= fieldOfView / 2f;
    }
}
