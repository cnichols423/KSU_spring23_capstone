using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLight : MonoBehaviour
{
    public float intensityMin, intensityMax, duration;
    float intensity, timer;

    bool direction;

    Light exitLight;

    // Start is called before the first frame update
    void Start()
    {
        exitLight = GetComponent<Light>();
        intensity = intensityMin;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        exitLight.intensity = intensity;

        if(timer < duration && !direction)
        {
            intensity = Mathf.Lerp(intensityMin, intensityMax, timer / duration);

        } else if(timer > duration && !direction) {
            direction = true;
            timer = 0.0f;
        }

        if (timer < duration && direction)
        {
            intensity = Mathf.Lerp(intensityMax,intensityMin , timer / duration);

        }
        else if (timer > duration && direction)
        {
            direction = false;
            timer = 0.0f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            SceneManager.LoadScene("Nav Hub");
        }
    }
}
