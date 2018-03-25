using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool _doMovement = true;

    public float PanSpeed = 30f;
    public float PanBorderThickness = 10f;
    public float ScrollSpeed = 5f;
    public float MinX = -5, MaxX = 75;
    public float MinY = 10, MaxY = 80;
    public float MinZ = -5, MaxZ = 75;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _doMovement = !_doMovement;

        if (!_doMovement)
            return;

        Debug.Log(transform.position.x);
        if (transform.position.z <= MaxZ &&
            (Input.GetKey("e") || Input.mousePosition.y >= Screen.height - PanBorderThickness))
        {
            transform.Translate(Vector3.forward * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.z >= MinZ && Input.GetKey("d") || Input.mousePosition.y <= PanBorderThickness)
        {
            transform.Translate(Vector3.back * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.x >= MinX && Input.GetKey("s") || Input.mousePosition.x <= PanBorderThickness)
        {
            transform.Translate(Vector3.left * PanSpeed * Time.deltaTime, Space.World);
        }

        if (transform.position.x <= MaxX &&
            (Input.GetKey("f") || Input.mousePosition.x >= Screen.width - PanBorderThickness))
        {
            transform.Translate(Vector3.right * PanSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        var position = transform.position;
        position.y -= 1000 * scroll * ScrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, MinY, MaxY);
        transform.position = position;
    }
}