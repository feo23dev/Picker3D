using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haberci : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("toplayicisinir"))
        {
            _GameManager.AtBorder();
            Debug.Log("Geldik");
        }
        
    }
}
