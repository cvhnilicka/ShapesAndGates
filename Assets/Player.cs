using System.Collections;
using System.Collections.Generic;
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

    private Mesh currMesh;



    // Start is called before the first frame update
    void Start()
    {
        currMesh = cube;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessShape();
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

    private void ProcessShape()
    {
        if (Input.GetButtonDown("Fire"))
        {
            if (currMesh == cube)
            {
                ChangeToSphere();
            }
            else
            {
                ChangeToCube();
            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        print("Player Collided with something");
        print(collision.collider.gameObject.tag);

        switch(collision.collider.gameObject.tag)
        {
            case "SquareGate": if (currMesh == cube)
                {
                    print("yay!");
                    //print(collision.collider.)
                } 
                else
                {
                    print("Should be a cube");
                }
                break;
            case "SphereGate": if (currMesh == sphere)
                {
                    print("sphere!!!!");
                }
            else
                {
                    print(" dont be a square!");
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var parGate = other.GetComponentInParent<Gate>();
        print(parGate.currColor);

        switch (other.gameObject.tag)
        {
            case "SquareGate":
                if (currMesh == cube)
                {
                    print("yay!");
                    //print(collision.collider.)
                }
                else
                {
                    print("Should be a cube");
                }
                break;
            case "SphereGate":
                if (currMesh == sphere)
                {
                    print("sphere!!!!");
                }
                else
                {
                    print(" dont be a square!");
                }
                break;
        }
    }
}
