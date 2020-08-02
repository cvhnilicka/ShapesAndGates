using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public enum Color { Blue, Green };
    public enum GateType {  Sphere, Cube, Capsule }


    [Header("General")]
    [SerializeField] Color currColor;
    [SerializeField] GateType type;

    [Header("Particle FX")]
    [SerializeField] GameObject successFX;

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

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger on gate script");   
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

    public string GetMaterialName()
    {
        return this.gameObject.GetComponentInChildren<MeshRenderer>().material.name;
    }

    public UnityEngine.Color GetMatColor()
    {
        return this.gameObject.GetComponentInChildren<MeshRenderer>().material.color;
    }

    private void OnDestroy()
    {
        print("Gate : " + this.gameObject.name + " has been called to destroy");
        // TODO Here can go the cleanup and animation calling for destroying the gate
        GameObject newFx = Instantiate(successFX, this.transform.position, Quaternion.identity);
        newFx.transform.parent = transform.parent;
    }
}
