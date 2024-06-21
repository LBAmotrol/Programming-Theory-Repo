using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSFX : MonoBehaviour
{
    public AudioClip initialMovement;
    public AudioClip movement;
    public AudioClip endingMovement;
    
    private AudioSource[] audioSources;

    void Awake(){
        audioSources = GetComponents<AudioSource>();
    }

    public IEnumerator PlayInitialMovement(){
        audioSources[0].clip = initialMovement;

        audioSources[0].Play();

        yield return new WaitForSeconds(0.5f);
        
    }

    public IEnumerator PlayMovement(float duration){
        audioSources[1].clip = movement;
        audioSources[1].loop = true;

        float elapsedTime = 0;

        while(elapsedTime < duration){
            if(!audioSources[1].isPlaying){
                audioSources[1].Play();
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        audioSources[1].Stop();
        audioSources[1].loop = false;
    }

    public IEnumerator PlayEndingMovement(){
        audioSources[0].clip = endingMovement;

        audioSources[0].Play();

        yield return new WaitForSeconds(0.5f);
    }

}
