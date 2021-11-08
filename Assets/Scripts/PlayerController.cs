using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Debug.Log(vertical);
        Debug.Log(horizontal);
    }

    private void FixedUpdate()
    {
        Vector2 position = body.position;
        position.x = position.x + runSpeed * horizontal * Time.deltaTime;
        position.y = position.y + runSpeed * vertical * Time.deltaTime;

        body.MovePosition(position);
        //body.MovePosition(body.position + movement * runSpeed * Time.fixedDeltaTime);
    }

    
}
