﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelsComponent : MonoBehaviour
{
    string sceneName;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (sceneName == "Piege facile")
                SceneManager.LoadScene("AIPolice");
            if (sceneName == "Piege moyen")
                SceneManager.LoadScene("Niveau Changement de Tiles");
            if (sceneName == "Piege difficile")
                SceneManager.LoadScene("TESTVAISSEAU");
            if (sceneName == "Niveau Changement de Tiles")
                SceneManager.LoadScene("AIPolice");
            if (sceneName == "AIPolice")
                SceneManager.LoadScene("FinalScene");
        }
    }
}
