using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porpoise : Interactable
{
    private int health = 500;
    public static Porpoise Instance;
    [SerializeField]
    private ParticleSystem engine;
    [SerializeField]
    private AudioSource engineRumble;

    private void Awake()
    {
        Instance = this;
    }
    public override IEnumerator Interact()
    {
        FindObjectOfType<CameraManager>().SwapToStrat();
        FindObjectOfType<InteractionManager>().Exhaust();
        yield return null;
    }

    public void TakeDamage()
    {
        health--;

        if(health <= 0)
        {
            //YOU LOse
        }
    }

    public void WinGame()
    {
        CameraManager.Instance.SwapToWin();
        StartCoroutine(BoldlyGo());
        engine.Play();
        engineRumble.Play();
    }

    private IEnumerator BoldlyGo()
    {
        while (true)
        {
            gameObject.transform.Translate(Vector3.up*50*Time.deltaTime);
            yield return null;
        }


    }
}
