using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CustomSkillsTextFormatter
{
    public static float GetText(string name, int formatterIndex)
    {
        switch (name)
        {
            case "SkilledTree_1Perc":
                return Math.Min(4, Skills.Instance.SkilledTree_1Perc_Universal + 1);
            default:
                return -10101010101010101;//error handler
        }
    }
}
