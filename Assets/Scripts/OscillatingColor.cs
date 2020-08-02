using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingColor : MonoBehaviour
{
    [SerializeField] Material blue;
    [SerializeField] Material pink;

    [SerializeField] float timedelay = 3f;

    private int numChildren;
    private int currIndex;

    // Start is called before the first frame update
    void Start()
    {
        numChildren = transform.childCount;
        currIndex = 1;
        InvokeRepeating("GetSubChildren", 1.0f, timedelay);

    }


    private void GetSubChildren()
    {
        bool toChange = true;
        int i = 1;
        foreach (Transform child in transform)
        {

            MeshRenderer childRenderer = child.GetComponentInChildren<MeshRenderer>();
            if (i == currIndex && toChange)
            {
                childRenderer.material = blue;
                if (currIndex == numChildren)
                {
                    currIndex = 1;
                }
                else
                {
                    currIndex += 1;
                }
                toChange = false;
                
            }
            else
            {
                childRenderer.material = pink;
            }
            i += 1;

        }
    }
    
}
