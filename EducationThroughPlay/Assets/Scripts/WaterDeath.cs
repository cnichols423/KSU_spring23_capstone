using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterDeath : MonoBehaviour
{

    float timer;

    public float maxTimeInWaterUntilDeath = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            timer = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            timer += Time.deltaTime;

            if(timer > maxTimeInWaterUntilDeath)
            {
                SceneManager.LoadScene("Nav Hub");
            }
            
        }
    }
}
