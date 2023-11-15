using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    public TMP_Text puntuacioAlta;

    // Start is called before the first frame update
    void Start()
    {
        puntuacioAlta.text = "Puntuació més alta: " + score.ToString();

    }

    //// Update is called once per frame
    //void Update()
    //{
    //    puntuacioAlta.text = "Puntuació més alta: " + score.ToString();
    //}
}
