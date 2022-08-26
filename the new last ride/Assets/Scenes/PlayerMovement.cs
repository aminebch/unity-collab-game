using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    private object body;
    private bool facingRightDirction;
    private object vector3;
    public Animator anim;
    
    public bool APressed { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        FlipPlayer(movement);

        Debug.Log(movement);

        if (movement > 0 || movement < 0)
            anim.SetBool("isMove", true);
        else
            anim.SetBool("isMove", false);


        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (_rigidbody.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
        }
        if (_rigidbody.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }
        if (_rigidbody.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
        }


    }

    private void FlipPlayer(float horizontal)
    {
        if(horizontal > 0 && !facingRightDirction || horizontal < 0 && facingRightDirction)
        {
            facingRightDirction = !facingRightDirction;

            Vector3 TheCurrentScale = transform.localScale;

            TheCurrentScale.x *= -1;
            transform.localScale = TheCurrentScale;
        }
    }

}