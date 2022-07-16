using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private Controls controls = null;
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float HorizontalSens = 10.0f;
    [SerializeField] private float VerticalSens = 10.0f;

    public Camera camera;


    void Awake() => controls = new Controls();

    void OnEnable() => controls.Player.Enable();

    void OnDisable() => controls.Player.Disable();

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    private void Move(){
        var movementInput = controls.Player.Movement.ReadValue<Vector2>();

        var movement = new Vector3{
            x = movementInput.x,
            z = movementInput.y
        }.normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void Rotate(){
        var rInput = controls.Player.Rotate.ReadValue<Vector2>();

        float RotationX = HorizontalSens * rInput.x * Time.deltaTime;
        float RotationY = VerticalSens * rInput.y * Time.deltaTime;

        Vector3 TotalRotation = camera.transform.rotation.eulerAngles;

        TotalRotation.y += RotationX;
        TotalRotation.x += -RotationY;

        camera.transform.rotation = Quaternion.Euler(TotalRotation);
    }
}
