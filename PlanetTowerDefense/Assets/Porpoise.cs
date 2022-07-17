using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porpoise : Interactable
{
    public override IEnumerator Interact()
    {
        FindObjectOfType<CameraManager>().SwapToStrat();
        FindObjectOfType<InteractionManager>().Exhaust();
        yield return null;
    }

}
