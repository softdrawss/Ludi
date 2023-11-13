using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro.EditorUtilities;
using TMPro;
using System.Globalization;

public class LevelManager : MonoBehaviour
{
    public TMP_Text monthYearText;
    public Button prevMonthButton;
    public Button nextMonthButton;
    public GameObject dayButtonPrefab;
    public Transform calendarGrid;

    private int currentMonth;
    private int currentYear;
    private int currentDay;
    private int daysInCurrentMonth;

    //Dictionary<string, int> monthDays = new Dictionary<string, int>
    //{
    //    {"January", 31},
    //    {"February", leapYear ? 29 : 28},
    //    {"March", 31},
    //    {"April", 30},
    //    {"May", 31},
    //    {"June", 30},
    //    {"July", 31},
    //    {"August", 31},
    //    {"September", 30},
    //    {"October", 31},
    //    {"November", 30},
    //    {"December", 31}
    //};

    // Start is called before the first frame update
    void Start()
    {
        System.DateTime currentDate = System.DateTime.Now;
        currentMonth = currentDate.Month;
        currentYear = currentDate.Year;
        currentDay = currentDate.Day;
        daysInCurrentMonth = DateTime.DaysInMonth(currentYear, currentMonth);

        // Update calendar display
        UpdateCalendar();

        // Attach click events to month navigation buttons
        prevMonthButton.onClick.AddListener(PreviousMonth);
        nextMonthButton.onClick.AddListener(NextMonth);

    }

    // Update is called once per frame
    void Update()
    {
        //switch (currentMonth) 
        //{
        //    case 1:
        //    break;
        //    case 2:
        //    break;
        //    case 3:
        //    break;
        //    case 4:
        //    break;
        //    case 5:
        //    break;
        //    case 6:
        //    break;
        //    case 7:
        //    break;
        //    case 8:
        //    break;
        //    case 9:
        //    break;
        //    case 10:
        //    break;
        //    case 11:
        //    break;
        //    case 12:
        //    break;
        //}
    }

    void UpdateCalendar()
    {
        // Update month and year display "ca-ES"
        CultureInfo ci = new CultureInfo("ca-ES");
        monthYearText.text = ci.DateTimeFormat.GetMonthName(currentMonth).ToUpper() + " " + currentYear;

        // Clear existing buttons
        foreach (Transform child in calendarGrid)
        {
            Destroy(child.gameObject);
        }

        // Get the number of days in the current month
        int daysInMonth = System.DateTime.DaysInMonth(currentYear, currentMonth);
        int daysInWeek = 7;
        int totalWeeks = Mathf.CeilToInt((float)daysInMonth / daysInWeek);

        for (int week = 0; week < totalWeeks; week++) 
        {
            Transform weekTransform = Instantiate(new GameObject("Week" + (week + 1)).transform, calendarGrid);
            GridLayoutGroup gridLayout = weekTransform.gameObject.AddComponent<GridLayoutGroup>();
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayout.constraintCount = daysInWeek;
        }

        // Create buttons for each day
        for (int weekDays = 0; weekDays <= daysInWeek; weekDays++)
        {
            //GameObject dayButton = Instantiate(dayButtonPrefab, calendarGrid);
            //dayButton.GetComponentInChildren<TMP_Text>().text = day.ToString();

            //// Add click event to the day button
            //int currentDay = day; // Create a local variable to avoid closure-related issues
            //if (this.currentDay >= currentDay) 
            //{ 
            //    dayButton.GetComponent<Button>().onClick.AddListener(() => OnDayButtonClick(currentYear, currentMonth, currentDay)); 
            //}
            
        }
    }

    void PreviousMonth()
    {
        currentMonth--;
        if (currentMonth < 1)
        {
            currentMonth = 12;
            currentYear--;
        }
        UpdateCalendar();
    }

    void NextMonth()
    {
        currentMonth++;
        if (currentMonth > 12)
        {
            currentMonth = 1;
            currentYear++;
        }
        UpdateCalendar();
    }

    void OnDayButtonClick(int year, int month, int day)
    {
        // Customize this method based on what you want to happen when a day button is clicked
        if (day == 30) 
        {
            SceneManager.LoadScene("Menu");
        }
        
        Debug.Log("Clicked on: " + year + "-" + month + "-" + day);
    }
}


