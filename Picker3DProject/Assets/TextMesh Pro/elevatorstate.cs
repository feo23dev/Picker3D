using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorstate : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private Animator BarrierArea;
    public void RemoveTheBarrier()
    {
        BarrierArea.Play("removethebarrier");
    }

    public void End()
    {
        _GameManager.collectorMove = true;
    } 

}
