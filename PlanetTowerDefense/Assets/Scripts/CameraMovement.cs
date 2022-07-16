using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 previousPosition;

    private int zoom;

    private void Start()
    {
        zoom = -100;
    }

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            previousPosition = cam.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        }

        if (Mouse.current.rightButton.isPressed)
        {
            Vector3 Direction = previousPosition - cam.ScreenToViewportPoint(Mouse.current.position.ReadValue());

            cam.transform.position = new Vector3();


            cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: Direction.y * 100);
            cam.transform.Rotate(new Vector3(x: 0, y: -1, z: 0), angle: Direction.x * 100, relativeTo: Space.World);
            cam.transform.Translate(new Vector3 (x: 0, y: 0, z: -100));

            


            previousPosition = cam.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        }

        if (Mouse.current.scroll.ReadValue().y < 0)
        {
            zoom = zoom - 1;
            cam.transform.Translate(new Vector3(x: 0, y: 0, z: zoom));
        }

        if (Mouse.current.scroll.ReadValue().y > 0)
        {
            zoom = zoom + 1;
            cam.transform.Translate(new Vector3(x: 0, y: 0, z: zoom));
        }


    }
}