using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballitem : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private string itemtype;
    [SerializeField] private int bonusBallIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("toplayicisinir"))
        {
            if( itemtype =="Palette" )
            {
                _GameManager.ActivatePalettes();
                gameObject.SetActive(false);
            }
            else
            {
                _GameManager.BonusBalls(bonusBallIndex);
                
            }
            
        }
        
    }
}
