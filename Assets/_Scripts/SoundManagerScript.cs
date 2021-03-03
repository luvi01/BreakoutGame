using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip deathSound, hitSound, slamSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        deathSound = Resources.Load<AudioClip>("Death");
        hitSound = Resources.Load<AudioClip>("Hit");
        slamSound = Resources.Load<AudioClip>("Slam");


        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "death":
                audioSource.PlayOneShot(deathSound);
                break;
            case "hit":
                audioSource.PlayOneShot(hitSound);
                break;
            case "slam":
                audioSource.PlayOneShot(slamSound);
                break;
        }
    }
}
