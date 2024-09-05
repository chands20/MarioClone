using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnPlatform : MonoBehaviour
{

    private Vector3 direction = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * 2 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyWall"))
        {
            if (direction == Vector3.right) { direction = Vector3.left; }
            else if (direction == Vector3.left) { direction = Vector3.right; }
        }
    }
}
