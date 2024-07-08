using System.Collections;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    private bool moving = false;
    private float movementDuration = 3;
    private FloorSFX sfx;

    void Awake(){
        sfx = GetComponent<FloorSFX>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(float height){
        StartCoroutine(RaiseToHeight(height));
    }

    public IEnumerator RaiseToHeight(float height){
        moving = true;
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;
        Vector3 destination = new Vector3(startPosition.x, height, startPosition.z);

        yield return StartCoroutine(sfx.PlayInitialMovement());

        StartCoroutine(sfx.PlayMovement(movementDuration));

        while(elapsedTime < movementDuration){
            float t = elapsedTime / movementDuration;
            transform.position = Vector3.Lerp(startPosition, destination, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = destination;
        moving = false;

        StartCoroutine(sfx.PlayEndingMovement());
    }
}
