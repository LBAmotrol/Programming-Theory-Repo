using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseTriggerController : MonoBehaviour
{
    public HouseController house;

    void OnTriggerEnter(Collider other){
        Debug.Log("Trigger detected");
        if (other.gameObject.CompareTag("Player")){
            StartCoroutine(house.ShowFloors());
        }
    }
}
