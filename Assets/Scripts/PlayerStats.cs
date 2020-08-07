using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static int deaths = 0, points = 0;


    public static int Deaths
    {
        get
        {
            return deaths;
        }
        set
        {
            deaths = value;
        }
    }

    public static void AddDeath()
    {
        deaths += 1;
    }

    public static int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }
}
