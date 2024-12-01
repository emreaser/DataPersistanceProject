using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float totalHealth;
    GameObject portal;
    GameObject player;
    [SerializeField] float speed;
    GameManager gameManager;
    [SerializeField] GameObject explosion;
    [SerializeField] float score;
    public int portalDamage;
    [SerializeField] float sfxVolume;
    [SerializeField] AudioClip explosionSfx;
    [SerializeField] GameObject audioPlayerObject;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        portal = GameObject.Find("Portal");
        player = GameObject.Find("Player");
        RotateToPortal();
    }

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive) 
        { 
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        }
    }

    public void TakeDamage(float damageamount)
    {
        totalHealth -= damageamount;
        if (totalHealth <= 0)
        {
            audioPlayerObject = Instantiate(audioPlayerObject, transform.position, transform.rotation);
            audioPlayerObject.GetComponent<AudioPlayerObject>().PlayAudioAtLocation(explosionSfx, sfxVolume);
            gameManager.AddScore(score);
            gameManager.enemyCount -= 1;
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
                        
        }
    }
    void RotateToPortal()
    {
        Quaternion newRotation = Quaternion.LookRotation((transform.position - portal.transform.position), Vector3.forward);
        newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, newRotation.z, newRotation.w);
        transform.rotation = newRotation;

    }

   
    
}
