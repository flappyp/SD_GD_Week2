using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
        
    public AudioSource tireScreechSource; 
    public AudioClip tireScreechClip;      
    public float tireScreechThreshold = 0.5f;   
    private Rigidbody carRigidbody;            

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        tireScreechSource.clip = tireScreechClip;
        tireScreechSource.loop = true;  
        tireScreechSource.Play();
        tireScreechSource.volume = 0;   
    }

    void Update()
    {
        
        float lateralVelocity = Vector3.Dot(carRigidbody.velocity, transform.right);
        if (Mathf.Abs(lateralVelocity) > tireScreechThreshold)
        {
            
            tireScreechSource.volume = Mathf.Lerp(tireScreechSource.volume, 1, Time.deltaTime * 10f);
        }
        else
        {
            
            tireScreechSource.volume = Mathf.Lerp(tireScreechSource.volume, 0, Time.deltaTime * 10f);
        }
    }
}
