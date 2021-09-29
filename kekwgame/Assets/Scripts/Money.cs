using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Money : MonoBehaviour
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
            playerVar.CurrentMoney += 1;
            
            Destroy(this.gameObject);
        }

    }
}
