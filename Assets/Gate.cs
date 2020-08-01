using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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
        //AddMeshCollider();
        SetChildrenTags();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddMeshCollider()
    {
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
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

    private void SetChildrenTags()
    {
        foreach (Transform child in transform)
        {
            child.tag = gameObject.tag;
        }
    }
}
