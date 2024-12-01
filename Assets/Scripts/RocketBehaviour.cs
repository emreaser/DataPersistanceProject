using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    Rigidbody missileRb;
    float speed = 750;
    [SerializeField] float damage = 50;
    [SerializeField] GameObject explosion;


    private float Xrange = 22;
    private float Yrange = 14;


    // Start is called before the first frame update
    void Start()
    {
        Xrange = 22;
        Yrange = 14;
        missileRb = GetComponent<Rigidbody>();
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    public void Fire()
    {
        missileRb.AddForce(transform.up * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { 
            Instantiate(explosion, transform.position, transform.rotation);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.x > Xrange || transform.position.x < -Xrange || transform.position.y > Yrange || transform.position.y < -Yrange)  
        {
            Destroy(gameObject);
        }        
    }
}
