using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

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
}
