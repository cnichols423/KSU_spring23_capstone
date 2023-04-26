using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlights : MonoBehaviour
{
    public float lightDelay;
    public float lightTimerIncrement;
    int lightsCount = 8;
    int index;

    float timer;

    bool turnOnLights;

    DialogueBox db;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < lightsCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        db = GameObject.Find("Dialogue Box").GetComponentInChildren<DialogueBox>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (!turnOnLights && timer > lightDelay)
        {
            turnOnLights = true;
            timer = 0.0f;
            db.sendMessage("Lesson 3: Rigidbodies, collliders, and triggers. Try to find a way to the exit!");
        }

        if(turnOnLights && timer > lightTimerIncrement && index < lightsCount)
        {
            transform.GetChild(index++).gameObject.SetActive(true);
            timer = 0.0f;
        }

    }
}
