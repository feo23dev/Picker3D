using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballitem : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("toplayicisinir"))
        {
            _GameManager.ActivatePalettes();
            gameObject.SetActive(false);
        }
        
    }
}
