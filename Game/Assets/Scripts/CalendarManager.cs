using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using TMPro.EditorUtilities;
using TMPro;
using System.Globalization;

public class CalendarManager : MonoBehaviour
{
    public TMP_Text monthYearText;
    public Button prevMonthButton;
    public Button nextMonthButton;
    public GameObject dayButtonPrefab;
    public GameObject weekGridPrefab;
    public Transform calendarGrid;

    private int currentMonth;
    private int currentYear;
    private int currentDay;
    private int daysInCurrentMonth;

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
        int daysCount = 1;

        for (int week = 0; week < totalWeeks; week++) 
        {
            Transform weekTransform = Instantiate(weekGridPrefab.transform, calendarGrid);
            
            // Create buttons for each day
            for (int weekDays = 0; weekDays < daysInWeek; weekDays++)
            {
                
                if (daysCount <= daysInMonth)
                {
                    GameObject dayButton = Instantiate(dayButtonPrefab, weekTransform);
                    dayButton.GetComponentInChildren<TMP_Text>().text = daysCount.ToString();

                    // Add click event to the day button
                    int currentDay = daysCount; // Create a local variable to avoid closure-related issues
                    if (this.currentDay >= currentDay)
                    {
                        dayButton.GetComponent<Image>().color = Color.red;
                        dayButton.GetComponent<Button>().onClick.AddListener(() => OnDayButtonClick(currentYear, currentMonth, currentDay));
                    }
                    daysCount++;
                }
            }

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
        if (day == currentDay) 
        {
            SceneManager.LoadScene("Menu");
        }
        
        Debug.Log("Clicked on: " + year + "-" + month + "-" + day);
    }
}


