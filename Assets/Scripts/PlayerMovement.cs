using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; //referencia Rigidbody
    public float forwardforce = 2000f;
    public float sidewaysForce = 500;
    public float upwardsForce = 200;
    //jump
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool TouchingGround;
    [SerializeField] private AudioSource jumpSFX;

    // Update is called once per frame
    void FixedUpdate()
    {
        TouchingGround = Physics.CheckSphere(groundCheck.position,groundCheckRadius,groundLayer);
        rb.AddForce(0, 0, forwardforce * Time.deltaTime); //Mueve el objeto constantemente hacia delante por la gravedad
        
        if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("space") && TouchingGround || Input.GetKey(KeyCode.UpArrow) && TouchingGround || Input.GetKey("w") && TouchingGround)
        {   
            jumpSFX.Play();
            rb.AddForce(0, upwardsForce * Time.deltaTime, 0, ForceMode.Impulse);
        }
        if (rb.position.y < -1f) 
        {
            FindObjectOfType<GameManager>().endGame();
        }
    }
}
