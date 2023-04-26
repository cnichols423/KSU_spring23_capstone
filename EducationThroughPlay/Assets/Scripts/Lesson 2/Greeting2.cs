using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting2 : MonoBehaviour
{
    DialogueBox db;

    int msgCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        db = GameObject.Find("Dialogue Box").GetComponentInChildren<DialogueBox>();


    }

    // Update is called once per frame
    void Update()
    {
        if (msgCount == 0 && !db.hasDialogue())
        {
            db.sendMessage("Lesson 2: Materials and Lighting");
            msgCount++;

        }
        else if (msgCount == 1 && !db.hasDialogue())
        {
            db.sendMessage("Press E on buttons you find to alter the environment..");
            msgCount++;
        }

    }
}
