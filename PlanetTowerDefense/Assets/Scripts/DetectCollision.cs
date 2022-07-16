using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public float bottomOffset;
    public float frontOffset;
    public float collisionRadius;
    public LayerMask GroundLayer;

    private void Start() {
        Physics.IgnoreLayerCollision(0,7);
    }

    public bool CheckGround(Vector3 Direction) {
        Vector3 Pos = transform.position + (Direction * bottomOffset);
        Collider[] hitColliders = Physics.OverlapSphere(Pos, collisionRadius, GroundLayer);
        if (hitColliders.Length > 0){
            return true;
        }
        return false;
    }
}
