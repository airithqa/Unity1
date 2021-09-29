using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    Hero playerVar;
    private void OnCollisionEnter2D(Collision2D collision)
   {
       GameObject playerGameObject = GameObject.Find("Hero");
       if (playerGameObject != null)
       {
           playerVar = playerGameObject.GetComponent<Hero>();
       }
       if (collision.gameObject.tag == "Player")
       {
           playerVar.Herolives += 1;
                Debug.Log("Now hero has"+playerVar.Herolives );
                Destroy(this.gameObject);
       }
      
        
   }

    

        



}
