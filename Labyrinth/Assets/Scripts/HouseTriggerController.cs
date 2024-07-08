using UnityEngine;

public class HouseTriggerController : MonoBehaviour
{
    [SerializeField] HouseController house;
    [SerializeField] bool oneTimeUse = true;
    [SerializeField] EnemyAI[] Enemies;
    private bool active = true;

    void OnTriggerEnter(Collider other){
        if(!active){
            return;
        }

        if (other.gameObject.CompareTag("Player")){
            foreach(EnemyAI enemy in Enemies){
                enemy.HuntPlayer();
            }
            
            if(oneTimeUse){
                active = false;
            }
            foreach(AudioSource audio in GetComponents<AudioSource>()){
                audio.Play();
                Debug.Log("played audio");
            }

            StartCoroutine(house.ShowFloors());
        }
    }
}
