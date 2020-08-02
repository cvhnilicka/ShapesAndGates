using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
   

    [Header("Meshes")]
    [SerializeField] Mesh sphere;
    [SerializeField] Mesh cube;
    [SerializeField] Mesh capsule;

    [Header("Materials")]
    [SerializeField] Material blue;
    [SerializeField] Material green;

    private Mesh currMesh;
    private Gate.Color currColor;

    private string colorString;





    // Start is called before the first frame update
    void Start()
    {
        currMesh = cube;
        ChangeToGreen();
    }

    // Update is called once per frame
    void Update()
    {

        ProcessShape();
        ProcessColor();
    }



    private void ChangeToSphere()
    {
        var childMesh = gameObject.GetComponentInChildren<MeshFilter>();
        childMesh.mesh = sphere;
        currMesh = sphere;
    }

    private void ChangeToCube()
    {
        var childMesh = gameObject.GetComponentInChildren<MeshFilter>();
        childMesh.mesh = cube;
        currMesh = cube;
        
    }


    private void ChangeToCapsule()
    {
        var childMesh = gameObject.GetComponentInChildren<MeshFilter>();
        childMesh.mesh = capsule;
        currMesh = capsule;
    }

    private void ProcessShape()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeToSphere();
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeToCube();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeToCapsule();
        }
    }

    private void ProcessColor()
    {
        if (Input.GetButtonDown("Fire"))
        {
            ChangeToGreen();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            ChangeToBlue();
        }
    }

    private void ChangeToGreen()
    {
        var childRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        childRenderer.material = green;
        currColor = Gate.Color.Green;
        colorString = green.name;
    }

    private void ChangeToBlue()
    {
        var childRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        childRenderer.material = blue;
        currColor = Gate.Color.Blue;
        colorString = blue.name;
    }

    public Mesh GetMesh()
    {
        return this.currMesh;
    }
}
