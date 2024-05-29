using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator animator;
    Joystick joystick;
    

    [SerializeField] float moveSpeed = default;
    [SerializeField]float rotationSpeed = default;

    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();

        playerRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
/*#if UNITY_EDITOR
        KeyboardControl();
#else*/
        JoystickControl();
/*#endif*/
    }

    public void KeyboardControl()
    {
        float moveDirection = Input.GetAxis("Vertical");
        float rotateDirection = Input.GetAxis("Horizontal");

        Vector3 playerMove = transform.forward * moveDirection * moveSpeed * Time.deltaTime;
        playerRb.MovePosition(playerRb.position + playerMove);
       
        float rotation = rotateDirection * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        bool isRunning = moveDirection != 0 || rotateDirection != 0;
        animator.SetBool("isRunning", isRunning);
    }

    public void JoystickControl()
    {
        float moveDirection = joystick.Vertical;
        float rotateDirection = joystick.Horizontal;

        Vector3 playerMove = transform.forward * moveDirection * moveSpeed * Time.deltaTime;
        playerRb.MovePosition(playerRb.position + playerMove);

        float rotation = rotateDirection * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        bool isRunning = moveDirection != 0 || rotateDirection != 0;
        animator.SetBool("isRunning", isRunning);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueKey") || other.gameObject.CompareTag("RedKey") || other.gameObject.CompareTag("Upgrader"))
        {
            hasKey = true;
            Destroy(other.gameObject);
            if (other.gameObject.CompareTag("BlueKey"))
            {
                Debug.Log("you can open blue door bro");
                //open the blue door with oscillation
            }
            else if (other.gameObject.CompareTag("RedKey"))
            {
                Debug.Log("you can open red door bro");
                //open the red door with oscillation
            }
            else if (other.gameObject.CompareTag("Upgrader"))
            {
                Debug.Log("you got the upgrader");
                //player ın leveli artsın
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with the " + collision.gameObject.name);
            //attack code
        }
    }


}
