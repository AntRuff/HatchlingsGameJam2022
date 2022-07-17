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

    // Update is called once per frame
    void Update()
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
}
