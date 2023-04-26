using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//DIALOGUE BOX SCRIPT BY JASON ABOUNADER

public class DialogueBox : MonoBehaviour
{
    Image panel;
    string text;
    Queue<char> inMessage;
    TMP_Text textObject;

    float timer;
    public float fadeDuration = 0.5f;
    public float nextletterSpeed = 0.01f;
    public float lingerDuration = 0.5f;

    bool isDialogue, intro, outro;

    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<Image>();
        panel.color = Color.clear;

        textObject = GetComponentInChildren<TMP_Text>();
        textObject.text = "";

        inMessage = new Queue<char>();

        //EXAMPLE USAGE
        //sendMessage("Hi Jason, Welcome to Game Island!");

        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDialogue)
        {
            timer += Time.deltaTime;

            //if panel is fading in
            if(intro)
            {
                panel.color = new Color(0, 0, 0, Mathf.Lerp(0.0f, 1.0f, timer / fadeDuration));

                if(timer > fadeDuration)
                {
                    timer = 0.0f;
                    intro = false;
                }

            //while panel is visible
            } else if(!intro && !outro)
            {
                if(timer > nextletterSpeed && inMessage.Count != 0)
                {
                    timer = 0.0f;
                    textObject.text += inMessage.Dequeue();

                } else if(inMessage.Count == 0)
                {
                    timer = 0.0f;
                    outro = true;
                }

               

            //panel fading out
            }else if (outro)
            {
                if(timer > lingerDuration)
                {
                    textObject.text = "";
                    panel.color = new Color(0, 0, 0, Mathf.Lerp(1.0f, 0.0f, timer - lingerDuration / fadeDuration));
                }

                if(panel.color.a <= 0.0f)
                {
                    isDialogue = false;
                    outro = false;
                }
            }

        }
    }

    //send text to screen
    public void sendMessage(string m)
    {
        isDialogue = true;
        intro = true;
        timer = 0.0f;
        foreach(char c in m)
        {
            inMessage.Enqueue(c);
        }
    }

    //return if there is text on the screen
    public bool hasDialogue()
    {
        return isDialogue;
    }
    

}
