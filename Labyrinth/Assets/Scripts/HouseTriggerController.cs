using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseTriggerController : MonoBehaviour
{
    public HouseController house;
    public bool oneTimeUse = true;
    private bool active = true;

    void OnTriggerEnter(Collider other){
        if(!active){
            return;
        }

        if (other.gameObject.CompareTag("Player")){
            if(oneTimeUse){
                active = false;
            }
            GetComponent<AudioSource>().Play();
            StartCoroutine(house.ShowFloors());
        }
    }
}
