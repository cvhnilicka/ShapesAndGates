using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivotor : MonoBehaviour
{
    [SerializeField] Vector3 rotationVector;

    float rotationFactor;

    [SerializeField] float period = 4f; // amount of time for 'animation' to take place

    [SerializeField] float degrees = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        PivotObject();
    }

    private void PivotObject()
    {
        float cycles = Time.time / period; // grows continually from 0
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        rotationFactor = rawSinWave / 2f;
        Vector3 rotationV = new Vector3(0, 0, 1) * Time.deltaTime * rotationFactor * degrees;
        transform.Rotate(rotationV);
    }
}
