using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : Interactable {
    public override IEnumerator Interact(){
        Debug.Log("Mining Silver");
        yield return new WaitForSeconds(1f);
    }
}