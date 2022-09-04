using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField ] private  GameObject collector;
    [SerializeField] private bool collectorMove;
    [SerializeField] private float collectorSpeed;
    
    
    // Start is called before the first frame update
    private void Awake() 
    {
        
        
        
    }
    void Start()
    {
        collectorMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collectorMove)
        {
             collector.transform.position += transform.forward * Time.deltaTime * collectorSpeed; 
            
            if(Time.timeScale !=0)
            {
                if(Input.GetKey(KeyCode.LeftArrow))
                {
                    collector.transform.position = Vector3.Lerp(collector.transform.position, new Vector3(collector.transform.position.x -.1f, collector.transform.position.y, collector.transform.position.z),0.05f);
                }
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    collector.transform.position = Vector3.Lerp(collector.transform.position, new Vector3(collector.transform.position.x +.1f, collector.transform.position.y, collector.transform.position.z),0.05f);
                }

                
            }

            
    
        }
        
    }
}
