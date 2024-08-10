using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RacerScript : MonoBehaviour
{
    public float laptime = 0;
    public float besttime = 0;
    private bool startTimer = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;

    public UnityEngine.UI.Text Ltime;
    public UnityEngine.UI.Text Btime;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        Ltime.text = "TIME: " + laptime.ToString("F2");
       
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (startTimer == true)
        {

            laptime = laptime + Time.deltaTime;

        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name == "StartFinish")
        {
            if (startTimer == false)
            {
                startTimer = true;
                laptime = 0;
                checkpoint1 = false;
                checkpoint2 = false;
            }

            if (checkpoint1 == true && checkpoint2 == true)
            {
                startTimer = false;

                if (besttime == 0)
                {
                    besttime = laptime;
                }
                if (laptime < besttime)
                {
                    besttime = laptime;
                }

                Btime.text = "BEST: " + besttime.ToString("F2");
            
           
                laptime = 0;
                startTimer = true;
                checkpoint1 = false;
                checkpoint2 = false;    
            }
        }
           

        if(other.gameObject.name == "checkpoint1")
        {
            checkpoint1 = true;
        }
        if(other.gameObject.name == "checkpoint2")
        {
            checkpoint2 = true;
        }
    }
}
