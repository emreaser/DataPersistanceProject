using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] ParticleSystem portalParticle;
    [SerializeField] GameManager gameManager;

    [SerializeField] AudioClip portalFireSfx;
    [SerializeField] AudioClip portalDamageSfx;
    AudioSource portalAudioSource;


    bool powerUpActive;
    public GameObject spriteObject;
    bool firing;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        portalAudioSource = gameObject.GetComponent<AudioSource>();
        powerUpActive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && powerUpActive && !firing && gameManager.isGameActive)
        {
            portalAudioSource.PlayOneShot(portalFireSfx, 0.5f);
            spriteObject.GetComponent<SpriteRenderer>().color = Color.red;
            powerUpActive = false;
            StartCoroutine(PowerUpCountDown());
            StartCoroutine(FireEmp());
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            portalAudioSource.PlayOneShot(portalDamageSfx, 1.0f);
            Destroy(other.gameObject);
            Instantiate(portalParticle, transform.position, transform.rotation);
            gameManager.ReducePortalIntegrity(other.GetComponent<Enemy>().portalDamage);
            gameManager.enemyCount -= 1;
        }
    }
    

    IEnumerator PowerUpCountDown()
    {
        
        yield return new WaitForSeconds(7);
        spriteObject.GetComponent<SpriteRenderer>().color = new Color(150,255,150,255);
        powerUpActive = true;
    }

    IEnumerator FireEmp()
    {
        firing = true;
        float firingTime = Time.time + 0.3f;
        while (Time.time < firingTime)
        {
            spriteObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
            spriteObject.GetComponent<SphereCollider>().radius += 0.05f;
            yield return null;
        }
        
        spriteObject.transform.localScale = new Vector3(2.32f, 2.32f, 2.32f);
        spriteObject.GetComponent<SphereCollider>().radius = 2f;
        firing = false;
    }

    

}
