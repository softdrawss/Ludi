using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HangedMan : MonoBehaviour
{
    // Text -> not sure which type should I use
    Keyboard keys;
    string text;
    public TextMeshProUGUI letter;

    // Header
    public string[] headers;
    string title;
    public TextMeshProUGUI playerTitle;

    // Sprites
    //int i = 0;
    //public Sprite[] spriteArray;
    //public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        startGame(0);
        //StartCoroutine(NewHeading());
    }

    // Update is called once per frame
    void Update()
    {
        // error here, it does not detect the letters
        text = letter.text;
        if (isContained(text))
        {
            print("It is contained!");
            addLetters(text);
        }
        else
        {
            print("Nope!");
            //i++;
            //ChangeSprite(i);
        }
    }

    // Create misterious title
    void startGame(int t)
    {
        playerTitle.text = null;
        title = headers[0];
        foreach (char c in title)
        {
            // White spaces must be ' ', if they are written like " " it detects it as a string
            if (!c.Equals(' '))
            {
                playerTitle.text = playerTitle.text + "?";
            }
            else
            {
                playerTitle.text = playerTitle.text + " ";
            }
        }

    }

    // Check if the letter is inside the title
    bool isContained(string c)
    {
        print("Checking...");
        if (title.Contains(c)) return true;
        else return false;
    }

    // Add the letters that are correct
    void addLetters(string c)
    {
        string t = "";
        foreach (char i in title)
        {
            if (i.Equals(c))
            {
                print(c);
                t = t + c;
            }
            else if (c.Equals('?'))
            {
                t = t + "?";
            }
            else if (c.Equals(' '))
            {
                t = t + " ";
            }
        }
        print(t);
        playerTitle.text = t;
    }

    // Change the sprite of the hanged man if it is not correct
    //void ChangeSprite(int i)
    //{
    //    spriteRenderer.sprite = spriteArray[i];
    //}

    //IEnumerator NewHeading()
    //{
    //
    //}

}
