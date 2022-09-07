using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arms : MonoBehaviour
{
    bool spin;
    [SerializeField] private float spinValue;
    public void StartSpinning()
    {
        spin = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(spin)
        transform.Rotate(0,0,spinValue,Space.Self);
    }
}
