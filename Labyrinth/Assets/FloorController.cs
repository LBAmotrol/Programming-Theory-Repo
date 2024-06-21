using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    private bool moving = false;
    private float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
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

        while(elapsedTime < moveSpeed){
            float t = elapsedTime / moveSpeed;
            transform.position = Vector3.Lerp(startPosition, destination, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = destination;
        moving = false;
    }
}
