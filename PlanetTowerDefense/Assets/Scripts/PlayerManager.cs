using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private Controls controls = null;
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float HorizontalSens = 10.0f;
    
    public Transform[] GroundChecks;

    public float GravityRotationSpeed = 10f;
    public float TurnSpd = 10f;

    public LayerMask GroundLayers;
    private Vector3 GroundDir;
    //[SerializeField] private float VerticalSens = 10.0f;


    void Awake() => controls = new Controls();

    void OnEnable() => controls.Player.Enable();

    void OnDisable() => controls.Player.Disable();

    // Update is called once per frame
    void FixedUpdate(){
        RotateCamera();
        Move();
    }

    //Updates Player position every frame.
    private void Move(){
        float delta = Time.deltaTime;

        var movementInput = controls.Player.Movement.ReadValue<Vector2>();

        var movement = new Vector3{
            x = movementInput.x,
            z = movementInput.y
        }.normalized;

        Vector3 SetGroundDir = FloorAngleCheck();
        GroundDir = Vector3.Lerp(GroundDir, SetGroundDir, delta * GravityRotationSpeed);

        RotateSelf(SetGroundDir, delta, GravityRotationSpeed);
        RotateMesh(delta, transform.forward, TurnSpd);

        transform.Translate(movement * moveSpeed * delta);
    }

    //Updates Camera and player rotation every frame
    private void RotateCamera(){
        var rInput = controls.Player.Rotate.ReadValue<Vector2>();

        float RotationX = HorizontalSens * rInput.x * Time.deltaTime;
        //float RotationY = VerticalSens * rInput.y * Time.deltaTime;

        Vector3 TotalRotation = transform.rotation.eulerAngles;

        TotalRotation.y += RotationX;
        //TotalRotation.x += -RotationY;

        transform.rotation = Quaternion.Euler(TotalRotation);
    }

    //Rotates player's up to match floor
    private void RotateSelf(Vector3 Direction, float d, float GravitySpeed){
        Vector3 LerpDir = Vector3.Lerp(transform.up, Direction, d * GravitySpeed);
        transform.rotation = Quaternion.FromToRotation(transform.up, LerpDir) * transform.rotation;
    }

    //Rotates player's forward to match floor
    private void RotateMesh(float d, Vector3 LookDir, float spd){
        Quaternion SlerpRot = Quaternion.LookRotation(LookDir, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, SlerpRot, spd * d);
    }

    //Find where floor is
    private Vector3 FloorAngleCheck(){
        RaycastHit HitFront;
        RaycastHit HitCenter;
        RaycastHit HitBack;

        Physics.Raycast(GroundChecks[0].position, -GroundChecks[0].transform.up, out HitFront, 10f, GroundLayers);
        Physics.Raycast(GroundChecks[1].position, -GroundChecks[1].transform.up, out HitCenter, 10f, GroundLayers);
        Physics.Raycast(GroundChecks[2].position, -GroundChecks[2].transform.up, out HitBack, 10f, GroundLayers);

        Vector3 HitDir = transform.up;

        if (HitFront.transform != null){ HitDir += HitFront.normal; }
        if (HitCenter.transform != null){ HitDir += HitCenter.normal; }
        if (HitBack.transform != null){ HitDir += HitBack.normal; }

        Debug.DrawLine(transform.position, transform.position + (HitDir.normalized * 5f), Color.red);

        return HitDir.normalized;
    }
}
