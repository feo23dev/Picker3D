using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private  Vector3 Target_Offset;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Target_Offset, 0.125f);
        
    }
}
