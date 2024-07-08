using UnityEngine;

public class MapOrbController : OrbController //inheritence, polymorphism
{
    [SerializeField] Camera mazeMap;
    public override void Idle()
    {
        
    }

    public override void OrbBonus(GameObject player)
    {
        mazeMap.gameObject.SetActive(true);
    }
}
