using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HangedMan : MonoBehaviour
{
    // Text -> not sure which type should I use
    string text;
    public TextMeshProUGUI playerTitle;

    // Titles
    public string[] headers;
    string title;
    int numTitle = 0;

    // Score
    int scoreNum = 0;
    public TextMeshProUGUI scoreText = null;

    // Camera
    public Camera cam;

    // Textures
    public GameObject square;
    public SpriteRenderer spriteRenderer;
    Sprite[] spriteArray;
    int sprite;

    // Win and lose
    public Sprite win;
    public Sprite lose;

    // Start is called before the first frame update
    void Start()
    {
        StartGame(numTitle);
    }

    public void CheckLetter(string c)
    {
        print("Checking: " + c);
        if (title.Contains(c))
        {
            print("It is contained!");
            AddLetters(c);
        }
        else
        {
            print("Nope!");
            sprite++;
            ChangeSprite(sprite);
        }
    }

    // Create misterious title
    void StartGame(int numTitle)
    {
        playerTitle.text = null;
        title = headers[numTitle];
        foreach (char c in title)
        {
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

    // Add the letters that are correct
    void AddLetters(string c)
    {
        string t = playerTitle.text;
        for (int i = 0; i < title.Length; i++)
        {
            if (title[i] == c[0] && t[i] == '?')
            {
                t = t.Remove(i, 1);
                t = t.Insert(i, c);
            }
        }
        playerTitle.text = t;
        CheckWord();
    }

    void CheckWord()
    {
        //scoreText = null;
        if (playerTitle.text == title && numTitle < headers.Length)
        {
            scoreNum += 25;
            scoreText.text = scoreNum.ToString();
            numTitle++;
            if (numTitle == headers.Length)
            {
                Win();
            }
            else
            {
                StartGame(numTitle);
            }
        }
    }

    void ChangeSprite(int sprite)
    {
        if (sprite == 7)
        {
            Lose();
        }
        spriteRenderer.sprite = spriteArray[sprite];
        
    }

    void Win()
    {
        print("You have won!");
        square.GetComponent<SpriteRenderer>().sprite = lose;
        square.GetComponent<SpriteRenderer>().sortingLayerName = "Result";
        square.GetComponent<SpriteRenderer>().sortingOrder = 1;
        square.SetActive(true);
    }

    void Lose()
    {
        print("You have lost!");
        square.GetComponent<SpriteRenderer>().sprite = lose;
        square.GetComponent<SpriteRenderer>().sortingLayerName = "Result";
        square.GetComponent<SpriteRenderer>().sortingOrder = 1;
        square.SetActive(true);
    }
}
