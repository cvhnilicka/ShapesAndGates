using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    // Variables n stuff
    [Header("General")]
    [Tooltip("In ms^1")] [SerializeField] float xSpeed = 35f;
    [Tooltip("In ms^1")] [SerializeField] float ySpeed = 30f;
    [SerializeField] GameObject[] lazers;


    [Header("Screen Position Dependant")]
    [SerializeField] float positionPitchFactor = -7f;
    [SerializeField] float positionYawFactor = 7f;


    [Header("Control Throw Dependant")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlRollFactor = -25f;


    private float horizontalThrow;
    private float verticalThrow;

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

    private bool _triggered;



    // Start is called before the first frame update
    void Start()
    {
        currMesh = cube;
        ChangeToGreen();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessShape();
        ProcessColor();
    }

    private void ProcessTranslation()
    {
        // X Axis Calculations
        horizontalThrow = Input.GetAxis("Horizontal");
        float xFrameOffset = horizontalThrow * xSpeed * Time.deltaTime; // offset this frame
        float rawX = transform.localPosition.x + xFrameOffset;

        // Y Axis calculations
        verticalThrow = Input.GetAxis("Vertical");
        float yFrameOffset = verticalThrow * ySpeed * Time.deltaTime;
        float rawY = transform.localPosition.y + yFrameOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawX, -30f, 30f),
            Mathf.Clamp(rawY, -15f, 15f),
            transform.localPosition.z);
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



    private void OnTriggerEnter(Collider other)
    {
        if (_triggered)
        {
            return;
        }

        _triggered = true; // bool trigger to avoid multiple triggers


        if (other.tag == "Gate")
        {
            ProcessGateTrigger(other);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!_triggered)
        {
            return; 
        }
        _triggered = false;
    }

    private void ProcessGateTrigger(Collider gateTrigger)
    {
        Gate parGate = gateTrigger.GetComponentInParent<Gate>();
        switch (parGate.GetGateType())
        {
            case Gate.GateType.Capsule:
            case Gate.GateType.Sphere:
            case Gate.GateType.Cube:
            default:
                PrintTriggerResult(parGate);
                break;
        }
    }

    private Color GetMatColor()
    {
        return this.gameObject.GetComponentInChildren<MeshRenderer>().material.color;
    }

    private void PrintTriggerResult(Gate expected)
    {
        if (expected.GetMatColor() == GetMatColor() &&
            expected.GetGateType().ToString() == this.currMesh.name)
        {
            print("CORRECT");
            //PrintExpected(expected);
        }
        else
        {
            print("INCORRECT");
        }

       
    }

    private void PrintExpected(Gate expected)
    {
        print("Expected Type: " + expected.GetGateType() + "Expected Color: " + expected.GetColor());
        print("Got Type: " + this.currMesh.name + "Got Color: " + this.currColor);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision from gate");
    }
}
