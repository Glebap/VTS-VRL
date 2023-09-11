using UnityEngine;


public class NearVehicleObserver : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _vehicleLayerMask;
    [SerializeField] private LayerMask _obstacleLayerMask;
    [SerializeField] private int _maxVehicles = 10;
    [SerializeField] private float _maxDistance = 20f;

    private Collider[] _nearVehiclesColliders;
    private Transform _vehicleTransform;
    
    
    public void Initialize(Transform vehicleTransform)
    {
        _nearVehiclesColliders = new Collider[_maxVehicles];
        _vehicleTransform = vehicleTransform;
    }

    public bool TryGetNearVehicleDistance(out float distance)
    {
        distance = float.MaxValue;
        if (!IsAnyVehicleInProximity(out int count))
            return false;

        var nearestVehiclePosition = new Vector3();
        for (var i = 0; i < count; i++)
        {
            var nearVehiclePosition = _nearVehiclesColliders[i].transform.position;
            nearVehiclePosition.y += 1.0f;
            
            var distanceToNearVehicle = GetDistanceToNearVehicle(nearVehiclePosition);
            if (distanceToNearVehicle < distance)
            {
                distance = distanceToNearVehicle;
                nearestVehiclePosition = nearVehiclePosition;
            }
        }

        return distance <= _maxDistance && IsVehicleVisible(nearestVehiclePosition);
    }

    private float GetDistanceToNearVehicle(Vector3 nearVehiclePosition)
    {
        var vehiclePosition = _vehicleTransform.position;
        vehiclePosition.y += 1.0f;
        
        var direction = nearVehiclePosition - vehiclePosition;
        var ray = new Ray(vehiclePosition, direction);
        var lenght = direction.magnitude;
        
        return Physics.Raycast(ray, out var hit, lenght, _vehicleLayerMask) 
            ? Vector3.Distance(vehiclePosition, hit.point) 
            : lenght;
    }

    
    private bool IsAnyVehicleInProximity(out int count)
    {
        count = Physics.OverlapSphereNonAlloc(_vehicleTransform.position, 
            _maxDistance, _nearVehiclesColliders, _vehicleLayerMask);

        return count > 0;
    }

    private bool IsVehicleVisible(Vector3 vehiclePosition)
    {
        return IsVehicleWithinFieldOfView(vehiclePosition) 
               && !HasObstacleInLineOfSight(vehiclePosition);
    }

    private bool HasObstacleInLineOfSight(Vector3 vehiclePosition)
    {
        var cameraPosition = _mainCamera.transform.position;
        var direction = vehiclePosition - cameraPosition;
        var ray = new Ray(cameraPosition, direction);

        return Physics.Raycast(ray, out _, direction.magnitude, _obstacleLayerMask);
    }

    private bool IsVehicleWithinFieldOfView(Vector3 vehiclePosition)
    {
        var cameraTransform = _mainCamera.transform;
        var toTarget = vehiclePosition - cameraTransform.position;
        var horizontalFieldOfView = 2f * Mathf.Atan(Mathf.Tan(_mainCamera.fieldOfView 
            * Mathf.Deg2Rad / 2f) *  _mainCamera.aspect) * Mathf.Rad2Deg;

        return Vector3.Angle(toTarget, cameraTransform.forward) <= horizontalFieldOfView / 2f;
    }

}
