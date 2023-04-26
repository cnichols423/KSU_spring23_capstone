using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeText : MonoBehaviour
{

    DialogueBox db;

    int msgCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        db = GetComponent<DialogueBox>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(msgCount == 0 && !db.hasDialogue())
        {
            db.sendMessage("Hi! Welcome to the Navigation Hub.");
            msgCount++;

        } else if(msgCount == 1 && !db.hasDialogue())
        {
            db.sendMessage("Use WASD keys to move. Press Space to jump. Use mouse to look around!");
            msgCount++;
        } else if (msgCount == 2 && !db.hasDialogue())
        {
            db.sendMessage("Walk over to a lesson jump pad.");
            msgCount++;
        }
    }
}
