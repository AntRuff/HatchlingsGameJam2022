using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{

    public Camera playerCam;
    public Camera stratCam;
    public GameObject player;
    public Transform rest;
    public Transform spawn;
    public Canvas button;

    // Start is called before the first frame update
    void Start()
    {
        playerCam.enabled = true;
        stratCam.enabled = false;
    }

    public void SwapToStrat()
    {
        stratCam.enabled = true;
        playerCam.enabled = false;
        player.transform.position = rest.position;
        button.gameObject.SetActive(true);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player.GetComponent<PlayerManager>().enabled = false;
    }

    public void SwapToPlayer()
    {
        playerCam.enabled = true;
        button.gameObject.SetActive(false);
        player.transform.position = spawn.position;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<PlayerManager>().enabled = true;
        stratCam.enabled = false;
    }
}
