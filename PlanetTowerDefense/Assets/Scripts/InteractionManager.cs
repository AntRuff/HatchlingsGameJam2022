using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public Collider interactionRange;
    [SerializeField] private float interactionTimer = 1f;
    public Text interactText;
    private bool canInteract = false;
    private Interactable action = null;
    public AudioSource mining;


    private void Start() {
        interactText.enabled = false;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Interactable>()){
            canInteract = true;
            action = other.gameObject.GetComponent<Interactable>();
            interactText.enabled = true;
            interactText.text = action.interactText;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Interactable>()){
            canInteract = false;
            action = null;
            interactText.enabled = false;
            interactText.text = "";
        }
    }

    public void Exhaust()
    {
        action = null;
        interactText.text = "";
    }

    public void Refresh()
    {
        canInteract = true;
        interactText.enabled = true;
    }

    public void Mine(){
        mining.Play();
    }

    public void StopMine(){
        mining.Stop();
    }

    public void CallInteract(){
        if (!canInteract){
            return;
        }
        if (action){
            canInteract = false;
            interactText.enabled = false;
            StartCoroutine(action.Interact());
        }
    }
}
