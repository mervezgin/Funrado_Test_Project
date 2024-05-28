using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator animator;

    [SerializeField] float moveSpeed = default;
    [SerializeField]float rotationSpeed = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        playerRb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControl();
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

}
