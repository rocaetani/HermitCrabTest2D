using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFormatter
{
    public static String Format(int timeInSeconds)
    {
        int seconds = timeInSeconds % 60;
        
        int hour = 0;
        
        int minutes = timeInSeconds / 60;

        if (minutes >= 60)
        {
            hour = minutes / 60;
            minutes %= 60;
        }

        String hourText = hour < 10 ? "0" + hour: "" + hour;
        String minutesText = minutes < 10 ? "0" + minutes: "" + minutes; 
        String secondsText = seconds < 10 ? "0" + seconds: "" + seconds; 
        
        return hourText + ":" + minutesText + ":" + secondsText;
    }

}
