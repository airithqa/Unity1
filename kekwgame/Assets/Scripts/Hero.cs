using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{ 
    [SerializeField] private float speed = 100f;
[SerializeField] private float jumpForce = 5f;
[SerializeField] private Rigidbody2D phys;
[SerializeField] private SpriteRenderer sprite;
[SerializeField] private string start_run;
[SerializeField] private string _jump_anim;

[Header (("Animation"))]
[SerializeField] private Animator animation;
public int Herolives = 6;
public int HeroMana = 6;
public int CurrentMoney = 0;

public Text moneyDisplay;
private float direction;
public bool checkGround = true;
private bool canJump = true;
private bool isFacingRight = true;
public string groundTag = "Ground";
public GameObject panel;
public int currentHealth;
public HealthBar healthBar;
public ManaBar ManaBar;
public int currentmana;

private void Start()
{
    currentHealth = Herolives;
    healthBar.SetMaxHealth(Herolives);
    currentmana = HeroMana;
    ManaBar.SetMaxMana(HeroMana);
}

private void Update()
{
  
   
    moneyDisplay.text = CurrentMoney.ToString();
    if (Input.GetMouseButton(0))
    {
        if(animation) {
            animation.SetTrigger("Attack");
        }
    }
    if (Herolives <= 0)
    {
        panel.SetActive(true);
        Destroy(gameObject);
    }

    direction = Input.GetAxisRaw("Horizontal");
    animation.SetFloat(start_run, Mathf.Abs(direction));
    
    
    if (Input.GetButton("Horizontal"))
    {
        Run();
    }

    if(canJump && Input.GetKeyDown(KeyCode.Space))
    {
        
        phys.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        canJump = !checkGround;
    }

    
   
}
private void FixedUpdate()
{

animation.SetBool(_jump_anim,!canJump);
float move = Input.GetAxis("Horizontal");
if (move > 0 && !isFacingRight)
    Flip();
else if (move < 0 && isFacingRight)
    Flip();
}

    private void Awake()
    {
        Instance = this;
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

transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

}

private void OnCollisionEnter2D(Collision2D collisionData)
{
    if(checkGround
       && collisionData.gameObject.CompareTag(groundTag))
    {
        canJump = true;
    }
}

    public static Hero Instance { get; set; }

    public void GetDamage()
    {

        Herolives--;
        Debug.Log("Hero has : " + Herolives);
         if(animation) {
               animation.SetTrigger("Hurt");
         }
         healthBar.SetHealth(Herolives);
           
    }
    

}




