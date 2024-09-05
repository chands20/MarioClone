using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformOnTouch : MonoBehaviour
{
    private float startLocation;
    private float endLocation;
    private Vector3 direction = Vector3.left;
    [SerializeField] float distance;
    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position.x;

        endLocation = startLocation + distance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x >= endLocation) { direction = Vector3.right; }
        else if (transform.position.x <= startLocation) { direction = Vector3.left; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 2;

        // Make the player a child of the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = 0;

        // Remove as the parent
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
