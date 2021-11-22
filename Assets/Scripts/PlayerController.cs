using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DialogUI dialogUI; //not sure why this is here

    Rigidbody2D body;

    float horizontal; //calling these variables outside the methods below so we can keep track of them between the Update() and FixedUpdate() methods
    float vertical;

    public float runSpeed = 20.0f;

    public DialogUI DialogUI => dialogUI; //if another class needs to get its hands on the dialogUI

    public IInteractable Interactable { get; set; }

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

        Debug.Log(vertical);
        Debug.Log(horizontal);
    }

    private void FixedUpdate()
    {
        Vector2 position = body.position;
        position.x = position.x + runSpeed * horizontal * Time.deltaTime;
        position.y = position.y + runSpeed * vertical * Time.deltaTime;

        body.MovePosition(position);
    }

    
}
