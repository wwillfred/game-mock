using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DialogUI dialogUI; //we need to be able to call the Canvas' dialogUI IsOpen() method so we can disable input if so

    Rigidbody2D body;

    float horizontal; //calling these variables outside the methods so we can keep track of them between the Update() and FixedUpdate() methods
    float vertical;

    public float runSpeed = 20.0f;

    public DialogUI DialogUI => dialogUI; //so the DialogActivator class of some other gameObject can call the DialogObject.ShowDialog() method

    public IInteractable Interactable { get; set; } //NPC's and other game objects must be able to tell the playerController that they are the object the player is interacting with

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (dialogUI.IsOpen) return; //if there's dialog going on, no need to pick up on other player input!

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

        //Debug.Log(vertical);
        //Debug.Log(horizontal);
    }

    //called before each update of the physics engine
    private void FixedUpdate()
    {
        Vector2 position = body.position;
        position.x = position.x + runSpeed * horizontal * Time.deltaTime;
        position.y = position.y + runSpeed * vertical * Time.deltaTime;

        body.MovePosition(position);
    }

    
}
