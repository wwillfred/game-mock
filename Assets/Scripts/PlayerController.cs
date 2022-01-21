using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DialogUI dialogUI; //we need to be able to call the Canvas' dialogUI IsOpen() method so we can disable input if true

    Rigidbody2D body;

    Vector2 movement;

    public float runSpeed = 20.0f;

    public DialogUI DialogUI => dialogUI; //so the DialogActivator class of some other gameObject can call the DialogObject.ShowDialog() method

    public IInteractable Interactable { get; set; } //NPC's and other game objects must be able to tell the playerController that they are the object the player is interacting with

    //inventory variables
    /*public bool hasHatchet = false;*/ //hatchet is needed for clearing the bush
    public bool hasQuarryGateKey = false; //gate key for scene 4 is obtained by opening toolbox in scene 3
    public bool hasSpokenToQuarryWorkerB = false; //quarry worker A needs to know

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (dialogUI.IsOpen) return; //if there's dialog going on, no need to pick up on other player input!

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

        //Debug.Log(movement);
    }

    //called before each update of the physics engine
    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * runSpeed * Time.fixedUnscaledDeltaTime);
        body.velocity = new Vector2(movement.x, movement.y);

        //Vector2 position = body.position;
        //position.x = position.x + runSpeed * horizontal * Time.deltaTime;
        //position.y = position.y + runSpeed * vertical * Time.deltaTime;

        //body.MovePosition(position);
    }
    
}
