using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Playables;

public class Gate : MonoBehaviour
{
    public enum Color { Blue, Green };
    public enum GateType {  Sphere, Cube, Capsule }


    [Header("General")]
    [SerializeField] Color currColor;
    [SerializeField] GateType type;

    [Header("FX")]
    [SerializeField] GameObject successFX;
    //[SerializeField] GameObject successFX;

    // Start is called before the first frame update
    void Start()
    {
        SetChildrenTags();
    }
    // reloads the children to active
    public void ReloadGameObject()
    {
        SetChildrenActive(true);
    }

    private void AddMeshCollider()
    {
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
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

    public void StartDeathSequence(bool success)
    {
        if (success)
        {
            GameObject newFx = Instantiate(successFX, this.transform.position, Quaternion.identity);
        }
        else
        {
            // death fx here if i want them
        }
        SetChildrenActive(false);
        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }
    

    private void SetChildrenActive(bool isActive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }

}
