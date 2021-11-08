using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public bool pauseGame;
   
   private void Awake()
   {
      instance = this;
   }
   
   
   
}
