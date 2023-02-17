
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public PlayerMovement movement;
    [SerializeField] private AudioSource crashSFX;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") {

            crashSFX.enabled = true;
            movement.enabled = false;
            FindObjectOfType<GameManager>().endGame();
            
        }

    }
}
