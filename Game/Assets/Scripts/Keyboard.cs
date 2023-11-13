using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keyboard : MonoBehaviour
{
    string word = null;
    public TextMeshProUGUI myName = null;
    HangedMan hangedMan; // Reference to the HangedMan script

    void Start()
    {
        // Find and assign the HangedMan script in the scene
        hangedMan = FindObjectOfType<HangedMan>();
    }

    // Use this for initialization
    public void alphabetFunction(string alphabet)
    {
        //wordIndex++;
        word = alphabet;
        myName.text = word;
        hangedMan.CheckLetter(alphabet); // Pass the entered letter to the HangedMan script
    }
}