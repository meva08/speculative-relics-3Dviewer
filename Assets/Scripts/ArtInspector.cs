using UnityEngine;

public class ArtworkInspector : MonoBehaviour
{
    [Header("References")]
    public Camera viewingCamera;

    [Header("Rotation")]
    public float rotationSpeed = 4f;

    private bool isDragging = false;

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        if (viewingCamera == null)
            viewingCamera = Camera.main;

        // Remember the artwork's original position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = viewingCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform ||
                    hit.transform.IsChildOf(transform))
                {
                    isDragging = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.Rotate(
                Vector3.up,
                -mouseX * rotationSpeed,
                Space.World
            );

            transform.Rotate(
                viewingCamera.transform.right,
                mouseY * rotationSpeed,
                Space.World
            );
        }
    }

    public void ResetArtwork()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}