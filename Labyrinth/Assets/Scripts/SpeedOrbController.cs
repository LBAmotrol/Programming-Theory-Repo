using UnityEngine;

public class SpeedOrbController : OrbController
{
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float badMultiplier = 0.5f;
    private EnemyAI aiScript;

    void Start(){
        aiScript = GetComponent<EnemyAI>();
    }
    public override void Idle()
    {
        if (aiScript.IsHunting()){
            speedMultiplier = badMultiplier;
        }
    }

    public override void OrbBonus(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.SetSpeed(playerMovement.GetSpeed() * speedMultiplier);
    }
}
