using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Speeds")]
    // Panning, scrolling, and rotation speeds.
    public float PanSpeed = 30f;

    public float ScrollSpeed = 5f;
    public float RotationSpeed = 5f;

    [Header("Camera positions")]
    // Camera position boundaries.
    public float MinX = -5f, MaxX = 75f;

    public float MinY = 10f, MaxY = 80f;

    public float MinZ = -5f, MaxZ = 75f;

    // Camera default position.
    public float DefaultX = 37.5f, DefaultY = 70f, DefaultZ = 37.5f;
    public float DefaultRotationX = 90f, DefaultRotationY, DefaultRotationZ;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(DefaultX, DefaultY, DefaultZ);
            transform.rotation = Quaternion.Euler(DefaultRotationX, DefaultRotationY, DefaultRotationZ);
        }

        // Vertical movement.
        if (transform.position.z <= MaxZ && Input.GetKey("e"))
        {
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.z >= MinZ && Input.GetKey("d"))
        {
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }

        // Horizontal movement.
        if (transform.position.x >= MinX && Input.GetKey("s"))
        {
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.x <= MaxX && Input.GetKey("f"))
        {
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }

        // Zoom in and out.
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        var position = transform.position;
        position.y -= 1000 * scroll * ScrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, MinY, MaxY);
        transform.position = position;

        // Rotation.
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(
                -RotationSpeed * Input.GetAxis("Mouse Y"),
                0,
                0
            );
        }
    }
}