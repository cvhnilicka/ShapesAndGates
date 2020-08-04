using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFx;

    private float levelLoadDelay = 1.0f;

    private bool _triggered;

    DeathCounter deathCounter;

    [SerializeField] PlayableDirector timeline;

    private Vector3 originalPos;
    private Quaternion origRotation;


    private void Start()
    {
        deathCounter = FindObjectOfType<DeathCounter>();
        originalPos = transform.position;
        origRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Gate")
        {
            ProcessGateTrigger(other);
        } 


    }

    private void OnCollisionEnter(Collision collision)
    {
        // used for non gate collisions
        StartDeathSequence();
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
                bool r = GetTriggerResult(parGate);
                ProcessTriggerResult(r, parGate);
                break;
        }
    }

    private void ProcessTriggerResult(bool success, Gate gate)
    {
        if (success)
        {
            DestroyProperGate(gate); // todo probs want to change variable name
        }
        else
        {
            // destory self
            StartDeathSequence();
        }
    }

    private void StartDeathSequence()
    {
        GameObject death = Instantiate(deathFx, this.transform.position, Quaternion.identity);
        deathCounter.AddDeath();
        // TODO NEED TO SOMEHOW RESET THE TRANSFORM TO ORIGINAL HERE
        gameObject.SetActive(false);
        gameObject.transform.SetPositionAndRotation(originalPos, origRotation);
        Invoke("ReloadTimeline", .99f);
        
        //Destroy(gameObject);
        
    }

    private Color GetMatColor()
    {
        return this.gameObject.GetComponentInChildren<MeshRenderer>().material.color;
    }

    private bool GetTriggerResult(Gate expected)
    {
        if (expected.GetMatColor() == GetMatColor() &&
            expected.GetGateType().ToString() == GetComponent<Player>().GetMesh().name)
        {    
            return true;
        }
        else
        {
            print(expected.GetMatColor() == GetMatColor());
            print(expected.GetGateType().ToString() == GetComponent<Player>().GetMesh().name);

            return false;
        }

    }

    private void DestroyProperGate(Gate toDestory)
    {
        toDestory.StartDeathSequence(true); 
        // todo may need other cleanup stuff here
    }

    private void PrintExpected(Gate expected)
    {
        print("Expected Type: " + expected.GetGateType() + "Expected Color: " + expected.GetColor());
        print("Got Type: " + GetComponent<Player>().GetMesh().name + "Got Color: " + GetMatColor());
    }

    private void ReloadTimeline()
    {
        timeline.time = 0;
        timeline.Stop();
        timeline.Evaluate();
        gameObject.SetActive(true);
        timeline.Play();

        Gate[] gates = FindObjectsOfType<Gate>();
        foreach (Gate g in gates)
        {
            g.ReloadGameObject();
        }
    }
}
