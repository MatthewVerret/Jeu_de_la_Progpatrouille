﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleted : MonoBehaviour
{
    GameObject destructibleWall;
    RandomButton Simon;
    private void Start()
    {
        destructibleWall = GameObject.FindGameObjectWithTag("DestructibleWall");
        
    }

    
    void Update()
    {
        if(FinishedGame.JeuRéussi == true /*&&*/)
        {
            
            Destroy(destructibleWall);
        }
    }
}
