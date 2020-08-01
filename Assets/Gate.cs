using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public enum Color { Blue, Green };
    public enum GateType {  Sphere, Cube, Capsule }



    [SerializeField] Color currColor;
    [SerializeField] GateType type;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision from gate");
    }

    public Color GetColor()
    {
        return this.currColor;
    }

    public GateType GetGateType()
    {
        return this.type;
    }
}
