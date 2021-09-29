using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Entity

{
   [SerializeField] public float speed = 3f;

   [SerializeField] public int positionOfPatrol = 5;
   public Transform point;
   bool moveingRight;

   Transform player;
   [SerializeField] public float stoppingDistance = 10f;

   bool chill = false;
   bool angry = false;
   bool goBack = false;

   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
   }

   void Update()
   {
      if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
      {
         chill = true;
      }

      if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
      {
         angry = true;
         chill = false;
         goBack = false;
      }

      if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
      {
         goBack = true;
         angry = false;

      }


      if (chill == true)
      {
         Chill();
      }
      else if (angry == true)
      {
         Angry();
      }
      else if (goBack == true)
      {
         Goback();
      }
   }

   void Chill()
   {
      if (transform.position.x > point.position.x + positionOfPatrol)
      {
         moveingRight = false;
      }
      else if (transform.position.x < point.position.x - positionOfPatrol)
      {
         moveingRight = true;
      }

      if (moveingRight)
      {
         transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
      }
      else
      {
         transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
      }
   }


   void Angry()
   {
      transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
   }

   void Goback()
   {
      transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
   }
   void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject == Hero.Instance.gameObject)
      {
         Hero.Instance.GetDamage();
      }
   }
}
