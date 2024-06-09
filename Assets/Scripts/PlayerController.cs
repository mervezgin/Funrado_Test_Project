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
        //KeyboardControl();
        JoystickControl();
    }

    public void KeyboardControl()
    {
        float moveDirection = Input.GetAxis("Vertical"); // W, S ya da yukarı ok tuşu, aşağı ok tuşu ile ileri geri hareket girdisi
        float rotateDirection = Input.GetAxis("Horizontal"); // A, D ya da sağ ok tuşu, sol ok tuşu ile sağa sola hareket girdisi

        Vector3 playerMove = transform.forward * moveDirection * moveSpeed * Time.deltaTime; // Hareket vektörünü hesaplar.
        playerRb.MovePosition(playerRb.position + playerMove); //Rigidbody'yi yeni pozisyona hareket ettirir.

        float rotation = rotateDirection * rotationSpeed * Time.deltaTime; // Dönüş açısını hesaplar.
        transform.Rotate(0, rotation, 0); //Karakteri döndürür.

        bool isRunning = moveDirection != 0 || rotateDirection != 0; //Karakterin hareket edip etmediğini kontrol eder.
        animator.SetBool("isRunning", isRunning); //Animasyon parametresini günceller.
    }
    public void JoystickControl()
    {
        /*
        float moveDirection = joystick.Vertical; //Joystick dikey eksen girdisi
        float rotateDirection = joystick.Horizontal; //Joystick yatay eksen girdisi

        Vector3 playerMove = transform.forward * moveDirection * moveSpeed * Time.deltaTime; // Hareket vektörünü hesaplar.
        playerRb.MovePosition(playerRb.position + playerMove); //Rigidbody'yi yeni pozisyona hareket ettirir.

        float rotation = rotateDirection * rotationSpeed * Time.deltaTime;// Dönüş açısını hesaplar.         
        transform.Rotate(0, rotation, 0); //Karakteri döndürür.

        bool isRunning = moveDirection != 0 || rotateDirection != 0; //Karakterin hareket edip etmediğini kontrol eder.
        animator.SetBool("isRunning", isRunning); //Animasyon parametresini günceller.
        */
        /*
        float moveDirection = joystick.Vertical; // Joystick'in dikey ekseni (ileri/geri hareket)
        float rotateDirection = joystick.Horizontal; // Joystick'in yatay ekseni (dönüş)

        // Dönüş
        transform.Rotate(0, rotateDirection * rotationSpeed * Time.deltaTime, 0);

        // Hareket
        Vector3 moveDirectionVector = transform.forward * moveDirection * moveSpeed * Time.deltaTime;
        playerRb.MovePosition(playerRb.position + moveDirectionVector);

        // Karakterin hareket ettiğini kontrol etmek için animasyon parametresini güncelle
        bool isRunning = moveDirection != 0 || rotateDirection != 0;
        animator.SetBool("isRunning", isRunning);
        */
        float moveDirection = Mathf.Abs(joystick.Vertical); // Dikey eksen girdisini alır ve mutlak değer alır.
        float rotateDirection = joystick.Horizontal; // Yatay eksen girdisini alır.

        Vector3 forwardDirection = transform.forward; // Karakterin önündeki yönü alır.

        // Eğer ters yöne bakılıyorsa, karakterin yönünü tersine çevirir.
        if (rotateDirection < 0)
        {
            forwardDirection *= -1f;
        }

        // Karakterin hareket vektörünü hesaplar.
        Vector3 playerMove = forwardDirection * moveDirection * moveSpeed * Time.deltaTime;
        // Rigidbody ile karakteri yeni pozisyona hareket ettirir.
        playerRb.MovePosition(playerRb.position + playerMove);

        // Karakterin dönüş açısını hesaplar.
        float rotation = rotateDirection * rotationSpeed * Time.deltaTime;
        // Karakteri yatay eksende döndürür.
        transform.Rotate(0, rotation, 0);

        // Karakterin hareket halinde olup olmadığını kontrol eder ve buna göre animasyonu günceller.
        bool isRunning = moveDirection != 0 || rotateDirection != 0;
        animator.SetBool("isRunning", isRunning);
    }
}
