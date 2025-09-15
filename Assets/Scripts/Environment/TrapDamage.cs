using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public int damage = 10;
    public float damageRate = 1f; 

    private float nextDamageTime;

    void OnTriggerStay(Collider other)
    {
        if (Time.time >= nextDamageTime)
        {
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage, transform.position);
                nextDamageTime = Time.time + damageRate;
            }
        }
    }
}
