using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private AudioClip orbSFX;
    private AudioSource[] speakers;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3;
    private Vector3 velocity;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = .4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;
    private bool canJump;
    private int numOrbs;

    

    void Awake(){
        controller = GetComponent<CharacterController>();
        speakers = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        controller.Move(speed * Time.deltaTime * move);

        if(Input.GetButtonDown("Jump") && isGrounded && canJump){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    // encapsulation using getters and setters    
    public void SetSpeed(float speed){
        this.speed = speed;
    }

    public float GetSpeed(){
        return speed;
    }

    public void EnableJump(){
        canJump = true;
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        } else if(other.gameObject.CompareTag("Orb")){
            other.GetComponent<OrbController>().OrbBonus(gameObject);
            Destroy(other.gameObject);
            speakers[1].clip = orbSFX;
            speakers[1].Play();
            numOrbs++;
        }
    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}
