using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Controls controls;

    private Vector3 previousPosition;

    [SerializeField]
    private int zoom;

    void Awake() => controls = new Controls();

    void OnEnable() => controls.Player.Enable();

    void OnDisable() => controls.Player.Disable();

    private void Start()
    {

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

        if(Mouse.current.scroll.ReadValue().y > 0)
        {
            Debug.Log("mouse up");
        }

        if (Mouse.current.scroll.ReadValue().y > 0)
        {
            Debug.Log("mouse down");
        }

        move();

    }

    public void move()
    {
        var movementInput = controls.StrategyControl.Camera.ReadValue<Vector2>();
        var movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        }.normalized;

        cam.transform.Translate (movement * 10f * Time.deltaTime);
    }
}
