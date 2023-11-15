using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Pregunta[] preguntes;
    public List<Pregunta> noRespostes;

    // Start is called before the first frame update
    void Start()
    {
        if (noRespostes == null) { }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
