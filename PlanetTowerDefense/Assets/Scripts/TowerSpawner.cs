using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject spawnGhost;

    private void Start()
    {
        Camera cam = Camera.main;
    }

    private void Update()
    {
        spawnAtMousePosition();

    }

    private void spawnAtMousePosition()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Instantiate(tower, hit.point, Quaternion.LookRotation(hit.point, hit.normal));
            }
        }
    }

    private void moveSpawnGhost()
    {
        
    }
}
