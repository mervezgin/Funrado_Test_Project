using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator animator;
    Joystick joystick;

    [SerializeField] float moveSpeed = default;
    [SerializeField] float rotationSpeed = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();

        playerRb.freezeRotation = true; //Rigidbody'nin dönüşünü durdurur, bu sayede sadece kodla dönüş sağlayabiliriz. 
    }

    // Update is called once per frame
    void Update()
    {
        JoystickControl();
    }

    public void JoystickControl()
    {
        float moveDirection = joystick.Vertical; // Dikey eksen girdisini alır ve mutlak değer alır.
        float rotateDirection = joystick.Horizontal; // Yatay eksen girdisini alır.
        float angle = Mathf.Atan2(rotateDirection, moveDirection) * Mathf.Rad2Deg;

        Vector3 forwardDirection = transform.forward; // Karakterin önündeki yönü alır.
        Vector3 playerRotation = transform.eulerAngles;

        if (angle < 0)
        {
            angle += 360;
        }

        if (angle - playerRotation[1] != 0)
        {
            if (moveDirection != 0 && rotateDirection != 0)
            {
                transform.Rotate(0, angle - playerRotation[1], 0);
            }
        }
        else
        {
            if (moveDirection != 0 && rotateDirection != 0)
            {
                Vector3 playerMove = forwardDirection * moveSpeed * Time.deltaTime;
                playerRb.MovePosition(playerRb.position + playerMove);
            }
        }

        bool isRunning = moveDirection != 0 || rotateDirection != 0;
        animator.SetBool("isRunning", isRunning);
    }
}
