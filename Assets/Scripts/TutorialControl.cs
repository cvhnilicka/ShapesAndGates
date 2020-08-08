using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TutorialControl : MonoBehaviour
{
    [Header("Control Tracks")]
    [SerializeField] ControlTrack colorInstruction;
    [SerializeField] ControlTrack sphereInstruction;
    [SerializeField] ControlTrack capsuleInstruction;
    [SerializeField] ControlTrack cubeInstruction;

    [SerializeField] PlayableDirector timeline;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
