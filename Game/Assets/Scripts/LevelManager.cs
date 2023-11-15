using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Pregunta[] preguntes;
    public List<Pregunta> noRespostes;
    public Pregunta preguntaActual;

    public GameObject[] targetes;

    bool isFirstTime;

    // Start is called before the first frame update
    void Start()
    {
        isFirstTime = true;
        if (noRespostes.Count == 0) 
        {
            
            for (int i = 0; i < preguntes.Length; i++) 
            {
                //Debug.Log("Numero de pregunta: ");
                preguntes[i].index = i;
                noRespostes.Add(preguntes[i]);
            }
        }
        preguntaActual = noRespostes[0];

        UpdateTargetes();

    }
    void UpdateTargetes()
    {
        if (preguntaActual != null && !isFirstTime && noRespostes[1] != null)
        {
            noRespostes.Remove(preguntaActual);
            preguntaActual = noRespostes[0];
        }

        if(isFirstTime) { isFirstTime = false; }

        for (int i = 0; i < targetes.Length; i++)
        {
            targetes[i].tag = "NoticiaReal";
            if (preguntaActual.noticies[i].esFalsa)
            {
                targetes[i].tag = "NoticiaFalsa";
            }
            GameObject buttonGameObject = targetes[i].gameObject;
            targetes[i].GetComponent<Button>().onClick.AddListener(() => CheckIsFake(buttonGameObject));

            targetes[i].GetComponentInChildren<TMP_Text>().text = preguntaActual.noticies[i].noticia;
        }
        
    }

    void CheckIsFake(GameObject buttonGameObject = null)
    {
        if (buttonGameObject.tag == "NoticiaFalsa")
        {
            preguntaActual.acertat = true;
            WinCondition();
        }
        else
        {
            LooseCondition();
        }
    }

    void WinCondition()
    {
        GameManager.score += 25;
        Debug.Log(GameManager.score);
        if (preguntaActual.acertat && noRespostes.Count == 1)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            UpdateTargetes();
        }

    }
    
    void LooseCondition()
    {
        if (!preguntaActual.acertat && noRespostes.Count == 1)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            UpdateTargetes();
        }
            
    }
}
