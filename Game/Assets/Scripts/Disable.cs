using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    public Button yourbutton;
    void Start()
    {
        yourbutton.interactable = false;
    }
}