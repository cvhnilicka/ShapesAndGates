using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingColor : MonoBehaviour
{
    [SerializeField] Material blue;
    [SerializeField] Material pink;

    private int numChildren;
    private int currIndex;
    // Start is called before the first frame update
    void Start()
    {
        numChildren = transform.childCount;
        print("num children: " + numChildren);
        currIndex = 1;
        InvokeRepeating("GetSubChildren", 1.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        // every second i want to change which child is blue

    }

    private void GetSubChildren()
    {
        int i = 1;
        foreach (Transform child in transform)
        {

            MeshRenderer childRenderer = child.GetComponentInChildren<MeshRenderer>();
            if (i == currIndex)
            {
                print("Curr index" + currIndex);
                childRenderer.material = blue;
                if (currIndex == numChildren)
                {
                    currIndex = 1;
                }
                else
                {
                    currIndex += 1;
                }
                return;
                
            }
            else
            {
                childRenderer.material = pink;
            }
            i += 1;

        }
    }
    
}
