using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour
{
    private float damage = 50.0f;

    private void Start()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    }
}
