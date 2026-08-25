using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private float interactDistance = 5f;
    [SerializeField] private Camera playerCamera;

    private void Update()
    {
        HandleInteract();

        DrawRay();
    }

    private void HandleInteract()
    {
        if (!GameInput.Instance.isInteractPressed())
        {
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.GetComponentInParent<Elephant>() is Elephant elephant)
            {
                elephant.Found();
            }
        }
    }

    private void DrawRay()
    {
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactDistance, Color.red);
    }
}
