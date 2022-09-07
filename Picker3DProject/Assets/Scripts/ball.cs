using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ballcounter"))
        {
            _GameManager.CountTheBalls();
        }
        
    } 
    
}
