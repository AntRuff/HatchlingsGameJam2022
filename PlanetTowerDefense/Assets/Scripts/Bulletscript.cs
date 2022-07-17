using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    [SerializeField]
    private float decayTime = 5;
    private float decayTimer = 0;
    [SerializeField]
    private float bulletSpeed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        if (decayTimer < decayTime)
        {
            decayTimer += Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
