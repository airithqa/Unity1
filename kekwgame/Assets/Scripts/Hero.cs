using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
   

[SerializeField] private float speed = 100f;
[SerializeField] private float jumpForce = 5f;
private bool isGrounded=false;
[SerializeField] private Rigidbody2D phys;
[SerializeField] private SpriteRenderer sprite;
private bool isFacingRight = true;
[SerializeField] private Animator animation;



private void FixedUpdate()
{
CheckGround();
float move = Input.GetAxis("Horizontal");
if (move > 0 && !isFacingRight)
    Flip();
else if (move < 0 && isFacingRight)
    Flip();
}
private void Flip()
{

isFacingRight = !isFacingRight;

Vector3 theScale = transform.localScale;

theScale.x *= -1;

transform.localScale = theScale;
}
private void Run()
{

Vector3 dir = transform.right * Input.GetAxis("Horizontal");
if (isGrounded) { State = States.run; }
transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

}
private void Jump()
{
phys.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
}
private void CheckGround()
{
Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
isGrounded = collider.Length > 1;
if (!isGrounded) State = States.jump;
}
private void Update()
{
if (isGrounded) State = States.idle;
if (Input.GetButton("Horizontal"))
{
    Run();
}

if (isGrounded && Input.GetButtonDown("Jump"))
    Jump();

}
private States State
{
get { return (States)animation.GetInteger("state"); }
set { animation.SetInteger("state", (int)value); }
}
public enum States
{
idle,
run,
jump
}


}




