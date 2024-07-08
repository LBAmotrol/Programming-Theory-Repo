using UnityEngine;

public class LightOrbController : OrbController //inheritence, polymorphism
{
    [SerializeField] float lightChangeSpeed = 0.2f;
    [SerializeField] float lightMax = 50;
    [SerializeField] float lightMin = 5;
    [SerializeField] Light lightComponent;
    private bool brighter = true;

    void OnAwake(){
        lightComponent = GetComponent<Light>();
    }
    
    public override void Idle(){
        if (brighter){
            lightComponent.range += lightChangeSpeed;
            if(lightComponent.range >= lightMax){
                brighter = false;
            }
        } else{
            lightComponent.range -= lightChangeSpeed;
            if(lightComponent.range <= lightMin){
                brighter = true;
            }
        }
        
    }

    public override void OrbBonus(GameObject player){
        GameObject.Find("Flashlight").GetComponent<Light>().enabled = true;
    }

    
    
}
