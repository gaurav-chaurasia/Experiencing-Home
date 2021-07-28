using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this enum will store diff modes like NONE, TELEPORT, and WALK
/// 
/// </summary>
public enum InputMode
{
    NONE,
    TELEPORT,
    WALK
}

/// <summary>
///  this class is to keep track of current player state
///  this will have only one static Player variable which will be our current player
/// </summary>
public class Player : MonoBehaviour
{
    // static player variable
    // there will be only object of this class 
    // and we can get that object
    public static Player instance;

    // now our current object has a field called activeMode
    // which basically keeps track of which mode we are in 
    // by default we are setting it to NONE
    public InputMode activeMode = InputMode.NONE;

    // [SerializeField] makes private or protected variable visible in the editor
    // and speed variable is to control the speed of the object
    [SerializeField]
    private float playerSpeed = 0.4f;

    public GameObject leftWall;
    public GameObject rightWall;

    public GameObject forwardWall;
    public GameObject backWall;

    public GameObject ceiling;
    public GameObject floor;

    // gets called before any object of any class is created
    void Awake()
    {
        if(instance != null)
        {
            GameObject.Destroy(instance.gameObject);
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryWalk();
    }

    // we will be walking by looking in forward direction
    // it will not be walking using gazeable object
    public void TryWalk()
    {
        // checking mouse is continously pressed down which is basiclly 
        // Input.GetMouseButton(0) and also checking InputMode to be WALK
        if (Input.GetMouseButton(0) && activeMode == InputMode.WALK)
        {
            Vector3 forward = Camera.main.transform.forward;
            
            //Debug.Log(forward);
            // user can walk only on the floor and can not go up or down
            Vector3 newPosition;
            newPosition.x = transform.position.x + forward.x * Time.deltaTime * playerSpeed;
            newPosition.z = transform.position.z + forward.z * Time.deltaTime * playerSpeed;
            newPosition.y = transform.position.y;

            if (newPosition.x < rightWall.transform.position.x && newPosition.x > leftWall.transform.position.x &&
                newPosition.y < ceiling.transform.position.y && newPosition.y > floor.transform.position.y &&
                newPosition.z > backWall.transform.position.z && newPosition.z < forwardWall.transform.position.z)
            {
                transform.position = newPosition;
            }
        }
    }
}
