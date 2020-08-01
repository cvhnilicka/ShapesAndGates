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
    [Tooltip("In ms^1")] [SerializeField] float xSpeed = 11f;
    [Tooltip("In ms^1")] [SerializeField] float ySpeed = 9f;
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

        transform.localPosition = new Vector3(Mathf.Clamp(rawX, -5.25f, 5.25f),
            Mathf.Clamp(rawY, -3.25f, 3.25f),
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
    }

    private void ChangeToBlue()
    {
        var childRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        childRenderer.material = blue;
        currColor = Gate.Color.Blue;
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

    private void PrintTriggerResult(Gate expected)
    {
        if (expected.GetColor() == this.currColor &&
            expected.GetGateType().ToString() == this.currMesh.name)
        {
            print("CORRECT");
        }
        else
        {
            print("Expected Type: " + expected.GetGateType() + "Expected Color: " + expected.GetColor());
            print("Got Type: " + this.currMesh.name + "Got Color: " + this.currColor);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision from gate");
    }
}
