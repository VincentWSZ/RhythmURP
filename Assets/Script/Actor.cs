using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ����ɫ�Ƿ��ڵ�����
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // �ƶ�
        float moveInputHorizontal = Input.GetAxis("Horizontal");
        float moveInputVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveInputHorizontal, 0.0f, moveInputVertical);
        Vector3 moveVelocity = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        // ��Ծ
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}
