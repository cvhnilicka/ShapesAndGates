using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    int count = 0;
    Text deathCount;



    // Start is called before the first frame update
    void Start()
    {
        deathCount = GetComponent<Text>();
        deathCount.text = count.ToString();
    }

    public void AddDeath()
    {
        count += 1;
        deathCount.text = count.ToString();
    }
}
