using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    bool canFire = true;
    AudioSource playerAuidoSource;
    [SerializeField] AudioClip fireAudio;
    GameManager gameManager;

    [SerializeField] GameObject missile;

    private void Awake()
    {
        
        mainCamera = Camera.main;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAuidoSource = gameObject.GetComponent<AudioSource>();

        if (MainManager.Instance.shipSprite != null)
        {
            SetShipSprite(MainManager.Instance.shipSprite);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) 
        { 
        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        Quaternion newRotation = Quaternion.LookRotation((transform.position - mousePos), Vector3.forward);
        transform.rotation = new Quaternion (transform.rotation.x, transform.rotation.y, newRotation.z, newRotation.w);

        if (Input.GetMouseButton(0) && canFire)
        {
                StartCoroutine(Shoot());            
        } else { StopCoroutine(Shoot()); }
        }

    }

    IEnumerator Shoot()
    {
        canFire = false;
        yield return new WaitForSeconds(0.2f);
        playerAuidoSource.PlayOneShot(fireAudio, 0.35f);
        Instantiate(missile, (transform.position + (transform.up * 2)), transform.rotation);
        canFire = true;
    }

    void SetShipSprite(Sprite sprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
 
}
