using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private Controls controls = null;
    
    [SerializeField] private float HorizontalSens = 15.0f;
    [SerializeField] private float VerticalSens = 15.0f;
    [SerializeField] private float RotateSpeed = 10f;

    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float maxSpeed = 30f;

    [SerializeField] private Rigidbody rb;

    private Vector3 curDir = Vector3.zero;
    /*public Transform[] GroundChecks;

    public float GravityRotationSpeed = 10f;
    public float TurnSpd = 10f;

    public LayerMask GroundLayers;
    private Vector3 GroundDir;*/

    [SerializeField]
    private ParticleSystem flame;

    void Awake() => controls = new Controls();

    void OnEnable() => controls.Player.Enable();

    void OnDisable() => controls.Player.Disable();

    // Update is called once per frame
    void FixedUpdate(){
        RotateCamera();
        RotatePlayer();
        Move();
    }

    //Updates Player position every frame.
    private void Move(){
        float delta = Time.deltaTime;

        var movementInput = controls.Player.Movement.ReadValue<Vector3>();
        var movement = Vector3.zero;
        if (Vector3.Distance(movementInput, Vector3.zero) > 0.1f){
            curDir = movement;
        }
        movement = new Vector3{
            x = movementInput.x,
            y = movementInput.y,
            z = movementInput.z
        };
        transform.Translate(movement * Time.deltaTime * moveSpeed);


        /*Vector3 SetGroundDir = FloorAngleCheck();
        GroundDir = Vector3.Lerp(GroundDir, SetGroundDir, delta * GravityRotationSpeed);

        RotateSelf(SetGroundDir, delta, GravityRotationSpeed);
        RotateMesh(delta, transform.forward, TurnSpd);*/

        //transform.Translate(movement.normalized * moveSpeed * delta);

        /*if (moveSpeed == 0) { rb.AddRelativeForce(-movement.normalized * moveSpeed * delta, ForceMode.Acceleration); }
        else { rb.AddRelativeForce(movement.normalized * moveSpeed * delta, ForceMode.Acceleration); }*/
    }

    //Updates Camera and player rotation every frame
    private void RotateCamera(){
        var rInput = controls.Player.RotateCamera.ReadValue<Vector2>();

        float RotationX = HorizontalSens * rInput.x * Time.deltaTime;
        float RotationY = VerticalSens * rInput.y * Time.deltaTime;

        Vector3 TotalRotation = transform.rotation.eulerAngles;

        TotalRotation.y += RotationX;
        TotalRotation.x += -RotationY;

        transform.rotation = Quaternion.Euler(TotalRotation);
    }

    private void RotatePlayer(){
        var rotate = controls.Player.RotatePlayer.ReadValue<float>();

        float RotationZ = RotateSpeed * rotate * Time.deltaTime;

        Vector3 TotalRotation = transform.rotation.eulerAngles;

        TotalRotation.z += RotationZ;

        transform.rotation = Quaternion.Euler(TotalRotation);
    }

    /*//Rotates player's up to match floor
    private void RotateSelf(Vector3 Direction, float d, float GravitySpeed){
        Vector3 LerpDir = Vector3.Lerp(transform.up, Direction, d * GravitySpeed);
        transform.rotation = Quaternion.FromToRotation(transform.up, LerpDir) * transform.rotation;
    }

    //Rotates player's forward to match floor
    private void RotateMesh(float d, Vector3 LookDir, float spd){
        Quaternion SlerpRot = Quaternion.LookRotation(LookDir, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, SlerpRot, spd * d);
    }/*

    //Find where floor is
    /*private Vector3 FloorAngleCheck(){
        RaycastHit HitFront;
        RaycastHit HitCenter;
        RaycastHit HitBack;

        Physics.Raycast(GroundChecks[0].position, -GroundChecks[0].transform.up, out HitFront, 1f, GroundLayers);
        Physics.Raycast(GroundChecks[1].position, -GroundChecks[1].transform.up, out HitCenter, 1f, GroundLayers);
        Physics.Raycast(GroundChecks[2].position, -GroundChecks[2].transform.up, out HitBack, 1f, GroundLayers);

        Vector3 HitDir = transform.up;

        if (HitFront.transform != null){ HitDir += HitFront.normal; }
        if (HitCenter.transform != null){ HitDir += HitCenter.normal; }
        if (HitBack.transform != null){ HitDir += HitBack.normal; }

        Debug.DrawLine(transform.position, transform.position + (HitDir.normalized * 5f), Color.red);

        return HitDir.normalized;
    }*/
}
