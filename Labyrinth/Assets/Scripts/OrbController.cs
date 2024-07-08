using UnityEngine;

public abstract class OrbController : MonoBehaviour //abstraction
{

    void Update(){
        Idle();
    }

    public abstract void Idle();

    public abstract void OrbBonus(GameObject player);

}
