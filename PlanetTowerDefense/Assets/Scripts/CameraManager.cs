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
    public Camera winCam;
    public static CameraManager Instance;
    public CameraMovement move;

    private GameManager game;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCam.enabled = true;
        stratCam.enabled = false;
        winCam.enabled = false;
        move.enabled = false;
    }

    public void SwapToStrat()
    {
        stratCam.enabled = true;
        playerCam.enabled = false;
        move.enabled = true;
        player.transform.position = rest.position;
        button.gameObject.SetActive(true);
        /*player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player.GetComponent<PlayerManager>().enabled = false;*/
        //player.SetActive(false);
        player.GetComponent<PlayerManager>().movementEnabled = false;
        gameObject.GetComponent<TowerSpawner>().enabled = true;
        Debug.Log(gameObject.GetComponent<TowerSpawner>().enabled);
        //player.GetComponent<PlayerManager>().DisablePlayerControls();
    }

    public void SwapToPlayer()
    {
        playerCam.enabled = true;
        button.gameObject.SetActive(false);
        player.transform.position = spawn.position;
        move.enabled = false;
        /*player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<PlayerManager>().enabled = true;*/
        //player.SetActive(true);
        player.GetComponent<PlayerManager>().movementEnabled = true;
        stratCam.enabled = false;
        gameObject.GetComponent<TowerSpawner>().enabled = false;
        //player.GetComponent <PlayerManager>().EnablePlayerControls();
    }

    public void SwapToWin()
    {
        playerCam.enabled = false;
        stratCam.enabled = false;
        winCam.enabled = true;
        player.transform.parent = rest;
        player.transform.position = rest.position;
        player.transform.rotation = rest.rotation;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player.GetComponent<PlayerManager>().enabled = false;
    }
}
