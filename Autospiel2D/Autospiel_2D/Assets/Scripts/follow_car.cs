using UnityEngine;

public class follow_car : MonoBehaviour
{
    public Transform car;

    [Header("Camera Follow")]
    public float followSpeed = 4f;
    public float maxFollowSpeed = 15f;
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("FOV")]
    public float normalFov = 60f;
    public float drivingFov = 75f;
    public float fovSmooth = 3f;

    Camera cam;
    Rigidbody2D carRb;

    void Start()
    {
        cam = GetComponent<Camera>();
        carRb = car.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        // Zielposition
        Vector3 target = car.position + offset;

        // Abstand zum Auto
        Vector3 difference = target - transform.position;

        // Kamera wird "gezogen"
        Vector3 cameraVelocity = difference * followSpeed;

        // Maximale Geschwindigkeit der Kamera
        cameraVelocity = Vector3.ClampMagnitude(
            cameraVelocity,
            maxFollowSpeed
        );

        transform.position += cameraVelocity * Time.deltaTime;

        // FOV
        float speed = carRb.linearVelocity.magnitude;

        float targetFov = speed > 0.1f
            ? drivingFov
            : normalFov;

        cam.fieldOfView = Mathf.Lerp(
            cam.fieldOfView,
            targetFov,
            fovSmooth * Time.deltaTime
        );
    }
}