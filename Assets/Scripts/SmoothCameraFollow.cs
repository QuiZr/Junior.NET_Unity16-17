using UnityEngine;
using System.Collections;

public class SmoothCameraFollow : MonoBehaviour
{
    // Target that camera will follow
    public Transform target;

    // If the target will move less then this value
    // camera will ignore this movement
    public Vector3 cameraDeadZone = Vector3.one;

    [Range(0,1)]
    public float cameraSmoothTime = 0.2f;

    // Bounds within the camera will stay
    public Vector3 minCameraPosition = new Vector3(0, -1000, -1000);
    public Vector3 maxCameraPosition = new Vector3(1000, 1000, 1000);

    private float currentCameraSmoothTime = 0f;
    private Vector3 currentVelocity = Vector3.zero;
    private Vector3 lastLegalTargetPosition;

    void Update()
    {
        // Positon with x and y coordinates from the camera,
        // but z from the target
        Vector3 relativeCameraPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            target.position.z);
        Vector3 deltaPosition = target.position - relativeCameraPosition;

        // If target left the dead zone and is inside
        // bounds make sure to follow his position
        if (!IsInDeadZone(deltaPosition))
            lastLegalTargetPosition = ClampPositionToBounds(target.position);

        // Move the camera
        Vector3 newPosition = Vector3.SmoothDamp(
            relativeCameraPosition,
            lastLegalTargetPosition,
            ref currentVelocity,
            cameraSmoothTime);
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    private bool IsInDeadZone(Vector3 delta)
    {
        if (Mathf.Abs(delta.x) < cameraDeadZone.x)
            return (Mathf.Abs(delta.y) < cameraDeadZone.y);
        return false;
    }

    private Vector3 ClampPositionToBounds(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, minCameraPosition.x, maxCameraPosition.x);
        position.y = Mathf.Clamp(position.y, minCameraPosition.y, maxCameraPosition.y);
        position.z = Mathf.Clamp(position.z, minCameraPosition.z, maxCameraPosition.z);

        return position;
    }
}
