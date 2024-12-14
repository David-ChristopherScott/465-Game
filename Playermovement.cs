using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    public Rigidbody2D rb;
    private Animator anim;
    private bool grounded;

    private PlayerCombat playerCombat; // Communicating with the player combat script 

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>(); //Calls player combat 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(-0.55f, 0.55f, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(0.59f, 0.55f, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        anim.SetBool("Run", horizontalInput != 0);

        // Triggers combat 
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (playerCombat != null)
            {
                playerCombat.Attack(); 
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, playerSpeed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
