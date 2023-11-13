using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keyboard : MonoBehaviour
{
    string word = null;
    public TextMeshProUGUI myName = null;
    // Use this for initialization

    public void alphabetFunction(string alphabet)
    {
        //wordIndex++;
        word = alphabet;
        myName.text = word;

    }
}