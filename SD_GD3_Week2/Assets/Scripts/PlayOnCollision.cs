using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Barrier")
        {
          
            audioSource.PlayOneShot(clip);
            Debug.Log("hit");
        }

    }

}  
