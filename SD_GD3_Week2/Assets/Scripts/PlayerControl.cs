using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{ 
    public float moveSpeed,turnSpeed, reverseSpeed;
    Rigidbody rb;
    public float horizontalInput, verticalInput;
    public AudioSource audioSource;
    public AudioClip clip;

  

    Animator anime;


    // Start is called before the first frame update
    void Start()
    {
        anime = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //give values to any private varibles
    }

    void FixedUpdate() {
        rb.AddForce(transform.forward * moveSpeed * verticalInput);
    }


    // Update is called once per frame
    void Update()
    {
       
        // highscoreText.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore")




        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

       // rb.AddForce(transform.forward * moveSpeed * verticalInput);//
        //rb.AddTorque(transform.up * turnSpeed * horizontalInput);

        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        anime.SetFloat("Horizontal Input",horizontalInput);
        if (Mathf.Abs(horizontalInput)>0)anime.SetBool("isTurning",true);
        else anime.SetBool("isTurning", false);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Barrier")
        {

            audioSource.PlayOneShot(clip);
            
        }

    }

    

}
