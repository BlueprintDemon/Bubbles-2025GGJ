using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAbleCamera : MonoBehaviour
{
    private Vector2 moveValue;

    [SerializeField]
    private InputActionAsset inputs;

    private InputActionMap playerinputs;

    private InputAction Movement;
    private InputAction Looking;
    Vector3 newvector3;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject PlayerObject;


    private CharacterController characterController;

    [SerializeField]
    float Walkspeed = 120f;
    Vector3 CurrentPos;
    Vector2 lookingValue;
    float viewSensitity = 0.1f;
    float VertialRoataion;
    float gravity = 9.8f;
    float vSpeed = 0;
    public bool OverRideMove = false;


    private void OnEnable()
    {
        playerinputs = inputs.FindActionMap("Player");
        playerinputs.Enable();
        Movement = playerinputs["Move"];
        Looking = playerinputs["Look"];


        Movement.performed += OnMovementStart;
        Movement.canceled += context => moveValue = Vector2.zero;

        Looking.performed += OnMovementMouse;
        Looking.canceled += context => lookingValue = Vector2.zero;

        //TLDR sets values, as well as bindings for actions being performed/cancled
    }

    private void OnMovementStart(InputAction.CallbackContext context)
    {

        moveValue = context.ReadValue<Vector2>();
        // Debug.Log(moveValue);
        //MovementHandling();

    }

    private void OnMovementMouse(InputAction.CallbackContext context)
    {
        lookingValue = context.ReadValue<Vector2>();
        // Debug.Log(lookingValue);
        //LookingHandling();
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = PlayerObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandling();
        LookingHandling();
        if (OverRideMove)
        {

            Movement.performed -= OnMovementStart;
            Movement.performed += context => moveValue = Vector2.zero;
            //updates looking and movement each frame 
            //BAD GAME IDEA - have a game where you can update your view every 5 seconds or so, horror game ?
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, +10, transform.position.z);
        }
    }
    void MovementHandling()
    {
        //InputPos is adding to the currently WorldPos of the playerobject
        Vector3 InputPos = new Vector3(moveValue.x, 0f, moveValue.y);
        Vector3 WorldPos = PlayerObject.transform.TransformDirection(InputPos);
        WorldPos.Normalize();
        CurrentPos.x = WorldPos.x * Walkspeed;
        CurrentPos.z = WorldPos.z * Walkspeed; //Controllable walkspeed by * it
        Vector3 vel = PlayerObject.transform.forward * Input.GetAxis("Vertical") * 5; //No one said i had to program GRAVITY into my 3D world i thought it was already for me. It was not.

        vSpeed -= gravity * Time.deltaTime;
        vel.y = vSpeed;
        CurrentPos.y = vel.y;//Calculating the gravity effect on time, then making that the currentpos
        characterController.Move(CurrentPos * Time.deltaTime);//telling the component that it sucks for not doing this for me, and then giving its needed value to function.


        //TLDR scary maths




    }
    void LookingHandling()
    {
        //Debug.Log("LookingFiring");

        float mouseRotation = lookingValue.x * viewSensitity;
        PlayerObject.transform.Rotate(0, mouseRotation, 0);
        VertialRoataion -= lookingValue.y * viewSensitity; //able to easyily change the speed of the looking 
        VertialRoataion = Mathf.Clamp(VertialRoataion, -80f, 80f); //Not entirely sure HOW it works but i beilive it locks the Variable into a max and a min limit
        cam.transform.localRotation = Quaternion.Euler(VertialRoataion, 0, 0);

    }
}
