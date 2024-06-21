using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public FloorController[] floors;
    public bool startHidden = false;
    private float[] floorHeights;
    private float hiddenHeight = -20;
    private BuildingSoundEffects sfx;
    
    void Awake()
    {
        sfx = GetComponent<BuildingSoundEffects>();

        SetFloorData();

        if(startHidden){
            HideHouse();
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ShowFloors());
    }

    public void SetFloorData(){
        floorHeights = new float[floors.Length];
        for(int i = 0; i < floors.Length; i++){
            floorHeights[i] = floors[i].transform.position.y;
        }

        Array.Sort(floorHeights, floors);
    }

    public void HideHouse(){
        foreach(FloorController floor in floors){
            Vector3 floorStart = floor.transform.position;
            floor.transform.position = new Vector3(floorStart.x, hiddenHeight, floorStart.z);
        }
    }

    public IEnumerator ShowFloors(){
        sfx.PlayInitialMovement();

        for(int i = 0; i < floors.Length; i++){
           yield return floors[i].RaiseToHeight(floorHeights[i]);
        }
    }

    public IEnumerator HideFloors(){
        sfx.PlayInitialMovement();
        
        foreach(FloorController floor in floors){
            yield return floor.RaiseToHeight(hiddenHeight);
        }
    }

    
}
