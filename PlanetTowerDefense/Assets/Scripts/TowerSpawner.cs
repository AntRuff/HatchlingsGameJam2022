using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject spawnGhost;
    [SerializeField] GameObject spawnObject;
    [SerializeField] GameManager gameManager;

    [SerializeField] int towerPrice;

    private void Start()
    {
        
        Camera cam = Camera.main;
    }

    private void Update()
    {
        spawnAtMousePosition();
        moveSpawnGhost();

    }

    private void spawnAtMousePosition()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            

                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;
                
                
                if (Physics.Raycast(ray, out hit)) 
                {
                    if (!hit.collider.gameObject.CompareTag("Turret"))
                    {
                    if (gameManager.GetComponent<InventoryManager>().GetSilver() >= towerPrice)
                    {
                        Instantiate(tower, hit.point, Quaternion.LookRotation(hit.point, hit.normal));
                        gameManager.GetComponent<InventoryManager>().updateSilver(-towerPrice);

                        Debug.DrawLine(hit.point, hit.normal);
                        Debug.Log(hit.normal);
                    }
                }
                

                }
                
            

        }
    }

    private void moveSpawnGhost()
    {
        if (gameManager.GetComponent<InventoryManager>().GetSilver() >= towerPrice)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            Physics.Raycast(ray, out hit);

            if (hit.collider.gameObject.CompareTag("Turret"))
            {
                spawnGhost.transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                spawnGhost.transform.SetPositionAndRotation(hit.point, Quaternion.LookRotation(hit.point, hit.normal));
            }
        }
        
        
    }

}
