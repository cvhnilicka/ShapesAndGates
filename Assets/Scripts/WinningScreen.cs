using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningScreen : MonoBehaviour
{
    Text deathCount;
    // Start is called before the first frame update
    void Start()
    {
        deathCount = GetComponent<Text>();
        int count = PlayerStats.Deaths;
        deathCount.text = count.ToString();
    }
}
