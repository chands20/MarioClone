using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingPlatform : MonoBehaviour
{

    private float startLocation;
    private float endLocation;
    private Vector3 direction = Vector3.right;
    [SerializeField] float distance;
    [SerializeField] float speed;

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

        if (transform.position.x >= endLocation) { direction = Vector3.left; }
        else if(transform.position.x <= startLocation) { direction = Vector3.right; }
    }
}
