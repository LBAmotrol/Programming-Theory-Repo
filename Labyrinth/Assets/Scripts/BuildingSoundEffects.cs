using UnityEngine;

public class BuildingSoundEffects : MonoBehaviour
{
    public AudioClip initialMovement;
    private AudioSource speaker;

    void Awake(){
        speaker = GetComponent<AudioSource>();
        speaker.clip = initialMovement;
    }

    // Update is called once per frame
    public void PlayInitialMovement(){
        speaker.Play();
    }
}
