using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{

    private bool _triggered;
    private void OnTriggerEnter(Collider other)
    {
        //if (_triggered)
        //{
        //    return;
        //}

        //_triggered = true; // bool trigger to avoid multiple triggers


        if (other.tag == "Gate")
        {
            ProcessGateTrigger(other);
        }

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    print("trigger exit");
    //    if (!_triggered)
    //    {
    //        print("TRIGGER OFF");
    //        return;
    //    }
    //    _triggered = false;
    //}

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
            expected.GetGateType().ToString() == GetComponent<Player>().GetMesh().name)
        {
            DestroyProperGate(expected); // todo probs want to change variable name
            //PrintExpected(expected);
        }
        else
        {
            print("INCORRECT");
        }


    }

    private void DestroyProperGate(Gate toDestory)
    {
        Destroy(toDestory.gameObject); 
        // todo may need other cleanup stuff here
    }

    private void PrintExpected(Gate expected)
    {
        print("Expected Type: " + expected.GetGateType() + "Expected Color: " + expected.GetColor());
        print("Got Type: " + GetComponent<Player>().GetMesh().name + "Got Color: " + GetMatColor());
    }
}
