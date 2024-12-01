using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerObject : MonoBehaviour
{
    AudioSource playerAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudioAtLocation(AudioClip audioclip, float volume)
    {
        playerAudioSource = gameObject.GetComponent<AudioSource>();
        playerAudioSource.PlayOneShot(audioclip, volume);
        Destroy(gameObject, audioclip.length);
        
    }
}
