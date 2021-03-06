﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeHeart : MonoBehaviour {

    public static GameObject uiNamePanel, escapeObj, optionBox1, optionBox2, optionBox3, optionBox4, nextButton, groupNameObj;
    public static Text uiSpeech, uiName, uiOption1, uiOption2, uiOption3, uiOption4, nextText, toText;
    public static Image MissLove, MayorMaine;
    public static int optionNum = 0; // for optionbuttons
    public static int next = 0; // increase this for each click, set to zero, when changing character
    public static string saveName;

    void Start() {
        uiSpeech = GameObject.Find("Text_speech").GetComponent<Text>();
        uiName = GameObject.Find("Text_character").GetComponent<Text>();
        uiOption1 = GameObject.Find("TextOption1").GetComponent<Text>();
        uiOption2 = GameObject.Find("TextOption2").GetComponent<Text>();
        uiOption3 = GameObject.Find("TextOption3").GetComponent<Text>();
        uiOption4 = GameObject.Find("TextOption4").GetComponent<Text>();
        nextText = GameObject.Find("TextNext").GetComponent<Text>();
        uiNamePanel = GameObject.Find("Panel_speech-box");
        optionBox1 = GameObject.Find("ButtonOption (1)");
        optionBox2 = GameObject.Find("ButtonOption (2)");
        optionBox3 = GameObject.Find("ButtonOption (3)");
        optionBox4 = GameObject.Find("ButtonOption (4)");
        nextButton = GameObject.Find("ButtonNext");
        escapeObj = GameObject.Find("ButtonEscapeOrgan");
        groupNameObj = GameObject.Find("InputFieldName");
        MissLove = GameObject.Find("ImageMissLove").GetComponent<Image>();
        MayorMaine = GameObject.Find("ImageMayorMaine").GetComponent<Image>();

        if (!Map.doneHeart) {
            ChangeText();
        }
        else {
            optionBox1.SetActive(false);
            optionBox2.SetActive(false);
            optionBox3.SetActive(false);
            optionBox4.SetActive(false);
            nextButton.SetActive(false);
            groupNameObj.SetActive(false);
            uiSpeech.text = "Hey " + saveName + ", the Heart is in a good condition. Travel to the other organs who really need you.";
            uiName.text = "Mayor Maine";
        }
    }

    public void CharacterField(string iFieldString) {
        saveName = iFieldString;
    }

    // Using variable to differentiate between 4 option buttons
    public void selectOption(int optionButton) {
        optionNum = optionButton; 
    }

    // Variable changed when onclick ButtonNext
    public void increaseNext() {
        next++;
        ChangeText();
    }

    public void ChangeText() { // change speech text of characters and options
                               // next button: always plus one (linear conversation)
                               // option buttons 1, 2, 3, 4 (more?), called from ui buttons
        switch (next) {
            case 0:
                uiName.text = "Miss Love";
                uiSpeech.text = "Welcome to the Heart, the big muscle. Before you enter, let me see some ID.";
                nextText.text = "Enter names";
                optionBox1.SetActive(false);
                optionBox2.SetActive(false);
                optionBox3.SetActive(false);
                optionBox4.SetActive(false);
                MayorMaine.enabled = false;
                escapeObj.SetActive(false);
                groupNameObj.SetActive(false);
                break;
            case 1:
                MissLove.enabled = false;
                uiNamePanel.SetActive(false);
                uiSpeech.text = "Your identity is the group name that the people in Anatomy Park will call you. Agree on a good name for your group."; // One group
                // uiSpeech.text = "Your leader identity is the name that the people in Anatomy Park will call you. You will each lead a group."; // different roles
                groupNameObj.SetActive(true);
                nextText.text = "Confirm";
                break;
            case 2:
                groupNameObj.SetActive(false);
                MissLove.enabled = true;
                uiNamePanel.SetActive(true);
                uiSpeech.text = "Thanks Darlings. We have simply increased the security because of the many incidents with intruders, you know, infectious bacteria. Anyway, the mayor has a quest for you guys, he's waiting for you in the Left Chamber.";
                nextText.text = "Go to Left Chamber";
                break;
            case 3:
                nextButton.SetActive(false);
                MissLove.enabled = false;
                uiOption1.text = "How is the health?";
                uiOption2.text = "How do we improve the health?";
                uiOption3.text = "What are our roles?";
                optionBox1.SetActive(true);
                optionBox2.SetActive(true);
                optionBox3.SetActive(true);
                MayorMaine.enabled = true;
                uiName.text = "Mayor Maine";
                uiSpeech.text = "Greetings "+ saveName +". I need your help, all of you. The health of our world is in a terrible condition.";
                break;
            case 4:
            case 5:
            case 6:
                if (optionNum == 1) {
                    optionBox1.SetActive(false);
                    uiSpeech.text = "Right now, the body is weak and likely to get infected with viruses, so we need to improve the health.";
                }
                else if (optionNum == 2) {
                    optionBox2.SetActive(false);
                    uiSpeech.text = "Your job as blood cells is to defeat virsuses, and after a virus attack you transport energy resources to the damaged organs. This way you improve the health of an organ, and the health of the body also gets better.";
                }
                else if (optionNum == 3) {
                    optionBox3.SetActive(false);
                    uiSpeech.text = "Everyone of you are important for this task. The plasma cells transport proteins, and the red blood cells transport oxygen. Both of them are important energy resources. Lastly the white blood cells are the soldiers, who defeat viruses.";
                }

                if (next == 6) {
                    optionBox4.SetActive(true);
                    uiOption4.text = "Heal Heart";
                }
                break;
            case 7:
                optionBox4.SetActive(false);
                uiSpeech.text = "The heart is in an unhealthy state. I suggest, you help it as much as you can. Use your resources and come up with a good solution for curing the Heart.";
                //negotiation stuff here!!!!
                nextButton.SetActive(true);
                nextText.text = "We did it!!";
                break;
            case 8:
                uiSpeech.text = "What a relief, the heart is back to normal, but the body still needs healing.It is time for you to visit the other organs and heal them, just like you did here in the heart.";
                nextText.text = "Where do we go?";
                break;
            case 9:
                Map.doneHeart = true;
                SceneManager.LoadScene(6); // goto map
                break;
        }
    }
}
