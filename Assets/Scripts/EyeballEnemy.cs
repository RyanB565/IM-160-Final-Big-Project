/*****************************************************************************
 // File Name      : EyeballEnemy.cs
 // Author         : Ryan Blanco
 // Creation Date  : April 14, 2026
 //
 // Brief Description : Eyeball enemy that chases the player when close enough
 //                     and can be damaged by the player's lightning ability.
 *****************************************************************************/



using UnityEngine;

public class EyeballEnemy : MonoBehaviour
{

    [SerializeField] private Transform player;

    // How fast the eyeball moves
    [SerializeField] private float moveSpeed = 2f;

    // How close the player must be before chasing
    [SerializeField] private float chaseDistance = 10f;

    // Eyeball health
    [SerializeField] private int health = 3;

    private float distanceToPlayer;

    private Rigidbody rb;



    /// <summary>
    /// start
    /// </summary>

    // gets the rigibody
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// chaseplayer
    /// </summary>
    //eyeball chases player
    private void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

        transform.LookAt(player);
    }
    /// <summary>
    /// update 
    /// </summary>
    // checks and sees if player is close enough to chase
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            ChasePlayer();
        }
    }

    /// <summary>
    /// TakeDamage
    /// </summary>
    // Eyeballenemy takes damage and if health is destoys it 

    public void TakeDamage(int amount)
    {
        health = health - amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }

    /// <summary>
    /// kills player
    /// </summary>
    // kills player 
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLife life = other.gameObject.GetComponent<PlayerLife>();

            if (life != null)
            {
                life.KillPlayer();
            }
        }
    }
  
}
