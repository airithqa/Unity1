using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
   [SerializeField] private int nextLevelIdex;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         ChangeScene();
      }
   }

   private void ChangeScene()
   {
      SceneManager.LoadScene(nextLevelIdex);
   }

   
}
