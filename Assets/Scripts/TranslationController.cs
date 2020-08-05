using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationController : MonoBehaviour
{

    // Variables n stuff
    [Header("General")]
    [Tooltip("In ms^1")] [SerializeField] float xSpeed = 30f;
    [Tooltip("In ms^1")] [SerializeField] float ySpeed = 30f;


    [Header("Screen Position Dependant")]
    [SerializeField] float positionPitchFactor = -7f;
    [SerializeField] float positionYawFactor = 7f;


    [Header("Control Throw Dependant")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlRollFactor = -25f;

    [Header("World Screen Bounds")]
    [SerializeField] float xPosClamp;
    [SerializeField] float xNegClamp;
    [SerializeField] float yPosClamp;
    [SerializeField] float yNegClamp;



    private float horizontalThrow;
    private float verticalThrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
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

        transform.localPosition = new Vector3(Mathf.Clamp(rawX, xNegClamp, xPosClamp),
            Mathf.Clamp(rawY, yNegClamp, yPosClamp),
            transform.localPosition.z);
    }
}
