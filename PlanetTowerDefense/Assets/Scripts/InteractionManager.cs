using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Collider interactionRange;
    [SerializeField] private float interactionTimer = 1f;
    private bool canInteract = false;
    private Interactable action = null;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Interactable>()){
            canInteract = true;
            action = other.gameObject.GetComponent<Interactable>();
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.GetComponent<Interactable>()){
            canInteract = false;
            action = null;
        }
    }

    public void CallInteract(){
        if (!canInteract){
            return;
        }
        if (action){
            StartCoroutine(action.Interact());
            Debug.Log("Finished Interaction");
            StartCoroutine(InteractionCooldown());
            Debug.Log("Can Interact again");
        }
    }

    private IEnumerator InteractionCooldown(){
        canInteract = false;
        yield return new WaitForSeconds(interactionTimer);
        canInteract = true;
    }
}
