using UnityEngine;

public class FolderOpenClose : MonoBehaviour
{
    [Header("Hinge")]
    public Transform frontHinge;

    [Header("Opening")]
    public Vector3 openRotationOffset = new Vector3(0f, -120f, 0f);
    public float animationSpeed = 4f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool isOpen = false;

    void Start()
    {
        if (frontHinge == null)
            return;

        closedRotation = frontHinge.localRotation;

        openRotation =
            closedRotation *
            Quaternion.Euler(openRotationOffset);
    }

    void Update()
    {
        if (frontHinge == null)
            return;

        Quaternion targetRotation =
            isOpen ? openRotation : closedRotation;

        frontHinge.localRotation = Quaternion.Slerp(
            frontHinge.localRotation,
            targetRotation,
            Time.deltaTime * animationSpeed
        );
    }

    public void ToggleFolder()
    {
        isOpen = !isOpen;
    }

    public void OpenFolder()
    {
        isOpen = true;
    }

    public void CloseFolder()
    {
        isOpen = false;
    }
}