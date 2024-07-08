using UnityEngine;

public class JumpOrbController : OrbController //inheritence, polymorphism
{
    [SerializeField] float jumpSpeed = 0.2f;
    [SerializeField] float heightMax = 50;
    [SerializeField] float heightMin = 5;
    float startingHeight;
    bool up = true;

    void OnAwake(){
        startingHeight = transform.position.y;
    }
    public override void Idle()
    {
        if (up){
            transform.position += Vector3.up * jumpSpeed;
            if(transform.position.y >= startingHeight + heightMax){
                up = false;
            }
        } else{
            transform.position += Vector3.down * jumpSpeed;
            if(transform.position.y <= startingHeight + heightMin){
                up = true;
            }
        }
    }

    public override void OrbBonus(GameObject player)
    {
        player.GetComponent<PlayerMovement>().EnableJump();
    }
}
