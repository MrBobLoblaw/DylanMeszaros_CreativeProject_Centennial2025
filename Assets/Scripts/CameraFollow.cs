using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Properties")]
    public Transform target;
    public float posSmoothTime = 0.3f;
    public float rotSmoothTime = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    private Quaternion targetRotation;

    [Header("Settings")]
    public bool transitionCamera;
    public Vector3 rotationOffset = Vector3.zero; // Example: (0, 90, 0) for right-facing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target != null)
        {
            targetRotation = transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // position presets
            Vector3 targetPosition = target.position + offset;

            // rotation presets
            Vector3 targetDirection = target.position - transform.position;
            targetRotation = Quaternion.LookRotation(targetDirection) * Quaternion.Euler(rotationOffset);

            if (transitionCamera)
            {
                // Translation
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, posSmoothTime);
                // Rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSmoothTime);
            }
            else
            {
                // Translation
                transform.position = targetPosition;
                // Rotation & preset refresh
                targetDirection = target.position - transform.position;
                targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100f);
            }
        }
    }
}
