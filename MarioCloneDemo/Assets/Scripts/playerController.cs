using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    public static playerController Instance;

    private Rigidbody2D rb;
    private bool canJump;
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                Jump();
            }
        }
        UIManager.Instance.currentHealth = playerHealth;

    }

    // Player Movement
    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(moveInput * Vector2.right * moveSpeed * Time.deltaTime);
    }

    // Player Jump
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpReset"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyOnPlatform"))
        {
            playerHealth -= 1;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}
