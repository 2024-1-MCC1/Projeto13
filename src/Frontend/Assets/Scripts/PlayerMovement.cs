using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isGrounded;

    [SerializeField]
    private float moveSpeed = 3f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalMovement, 0, verticalMovement).normalized;

        // Transforma a dire��o do movimento para a dire��o do jogador
        moveDirection = transform.TransformDirection(moveDirection);

        // Aplica a for�a de movimento na dire��o para onde o jogador est� olhando
        rb.AddForce(moveDirection * moveSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}

