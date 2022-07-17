using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float attackRange = 5;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float attackCooldown = 0.75f;
    private float curAttackCooldown = 0;
    [SerializeField]
    AudioSource gunSound;

    // Update is called once per frame
    void Update()
    {
       // if(target == null)
       // {
            target = DayNightManager.Instance.GetTarget(transform);
      //  }
     //   else
      //  {
      if(target != null)
        {
            transform.LookAt(target.transform);
            if (curAttackCooldown <= attackCooldown)
            {
                curAttackCooldown += Time.deltaTime;
            }
            else if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
            {
                var newBullet = Instantiate(bulletPrefab);
                newBullet.transform.position = transform.position;
                newBullet.transform.rotation = transform.rotation;
                curAttackCooldown = 0;
            }
        }

      //  }

    }
}
