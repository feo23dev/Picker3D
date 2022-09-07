using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[Serializable]

public class BallAreaTech
{
    public Animator BallAreaElevator;
    public TextMeshProUGUI ballNumberText;
    public int ballRequired;
    public GameObject[] Balls;







}

public class GameManager : MonoBehaviour
{
    [SerializeField ] private  GameObject collector;
    [SerializeField ] private  GameObject[] Pallets;
    bool palettesVisible;
    [SerializeField ] private  GameObject ballControlObj;
    [SerializeField] public bool collectorMove;
    [SerializeField] private float collectorSpeed;
    int ballCollected;
    int totalCheckPoints;
    int currentCheckPoint;

    [SerializeField] private List<BallAreaTech> _BallAreaTech = new List<BallAreaTech>();
    
    
    // Start is called before the first frame update
    
    void Start()
    {
        collectorMove = true;
        
        totalCheckPoints =_BallAreaTech.Count-1;
        for( int i=0; i < _BallAreaTech.Count; i++)
        {
            _BallAreaTech[i].ballNumberText.text= ballCollected + "/" + _BallAreaTech[i].ballRequired;

        }

        
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

    public void AtBorder()
    {
        if(palettesVisible)
        {
            Pallets[0].SetActive(false);
            Pallets[1].SetActive(false);
        }
        collectorMove = false;

        Collider[] HitCollider = Physics.OverlapBox(ballControlObj.transform.position, ballControlObj.transform.localScale / 2,Quaternion.identity);
        Invoke("Check",2f);

        int i= 0;
        while( i< HitCollider.Length)
        {
            HitCollider[i].GetComponent<Rigidbody>().AddForce( new Vector3(0f,0f,0.8f),ForceMode.Impulse);
            i++;
        }

    }


    
    /* private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(ballControlObj.transform.position,ballControlObj.transform.localScale);
    }
    */

    public void CountTheBalls()
    {
        ballCollected++;
        _BallAreaTech[currentCheckPoint].ballNumberText.text= ballCollected + "/" + _BallAreaTech[currentCheckPoint].ballRequired;

    }

    void Check()
    {
        if(ballCollected >= _BallAreaTech[currentCheckPoint].ballRequired)
        {
            Debug.Log("Kazandin");
            // atilan top sayisini sifirlamamiz lazim;

            _BallAreaTech[currentCheckPoint].BallAreaElevator.Play("asansör");
            foreach(var item in _BallAreaTech[currentCheckPoint].Balls)
            {
                item.SetActive(false);
            }
            if( currentCheckPoint == totalCheckPoints)
            {
                Time.timeScale = 0;
                Debug.Log(" Oyun Bitti");
                // P A N E L  Y A P 
            }
            
            else
            {
                currentCheckPoint++;
                ballCollected = 0;

                if(palettesVisible)
                {
                    Pallets[0].SetActive(true);
                    Pallets[1].SetActive(true);

                }
            }
            
        }
        else
        {
            Debug.Log("Kaybettin");
            // P A N  E L  Y A P 
        }
    }

    public void ActivatePalettes()
    {
        palettesVisible = true;
        Pallets[0].SetActive(true);
        Pallets[1].SetActive(true);


    }
    

}
