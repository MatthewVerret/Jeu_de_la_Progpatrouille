﻿/// Permet de faire une certaine action dans le script Action, lorsque toutes les tiles sont identique
/// 
/// 
/// ATTENTION, CHANGER LA FONCTION START!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

using System.Collections;
using System.Timers;

using System.Collections.Generic;
using UnityEngine;

public class OpenDoorComponents : MonoBehaviour
{
    public TileComponents[] ListTiles;
    public bool LevelComleted = false;
    bool Explosé = false;
    private static System.Timers.Timer aTimer;
    int cnt = 0;
    float timeToWait = 3;
    float timer = 0;
    float currCountdownValue;
    [SerializeField]
    private GameObject ModèleExplosion;

    [SerializeField]
    GameObject LeftDoor;
        [SerializeField]
    GameObject floor;
    //  [SerializeField]
    Camera cam1;
    Camera cam2;
    bool EasyDifficulty;
    EasyLevelComponent Difficulté;
    bool MediumMode;
    void Start()
    {
        var Difficulty = "medium";
        if (Difficulty == "medium")
        {
            MediumMode = true;
        }
        LevelComleted = false;
        StartCoroutine(StartCountdown());
        
    }
    void Update()
    {
        EasyDifficulty = FindObjectOfType<DifficultyScript>().EasyDifficulty;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (TileComponents Floor in ListTiles)
            {
                Floor.gameObject.GetComponent<MeshRenderer>().material.color = ListTiles[0].gameObject.GetComponent<MeshRenderer>().material.color;
            }

        }
            timer += Time.deltaTime;
        if (cnt==0 &&(timeToWait - timer) <= 0.01)
        {
            cnt = 1;
            timer = timer - timer;
        }
        if (timer > 2.901f) cnt = 0;
        Test();
      
    }

    void Test()                            // regarde si les tiles sont identique.
    {
        ListTiles = FindObjectsOfType<TileComponents>(); //Voir façon plus rapide
        int cnt = 0;
        foreach (TileComponents Floor in ListTiles)
        {
            if(!Explosé)            // test si le niveau est fini
            if (Floor.gameObject.GetComponent<MeshRenderer>().material.color != ListTiles[0].gameObject.GetComponent<MeshRenderer>().material.color)
            {
                LevelComleted = false;
                
                break;
            }
            cnt++;
        }
        if (cnt == ListTiles.Length && !Explosé)      // action lorsque les tuiles sont tous de la mm couleur
        { 
            
            GameObject Explosion = Instantiate(ModèleExplosion, transform.position, ModèleExplosion.transform.rotation);
                Destroy(Explosion, 3);
           
           foreach (TileComponents Floor in ListTiles)
           {
               Destroy(Floor.gameObject);
               Destroy(floor);
           }
            LevelComleted = true;
            Explosé = true;           

        }

    }
   
    // Update is called once per frame
    private void OnMouseDown()                          // fonction qui permet de call le start par clicker sur un items.
    {
        if (gameObject.layer == 9)
        {
            Test();
        }
    }

    private void ChangeOneTile()
    {
        timer = 0;
        TileComponents[] List = FindObjectsOfType<TileComponents>();
        var value = Random.Range(0, List.Length);
        if (List[value].gameObject.GetComponent<MeshRenderer>().material.color == List[1].BlackMaterial.color && !LevelComleted)
            List[value].gameObject.GetComponent<MeshRenderer>().material = List[1].WhiteMaterial;
        else
        {
            List[value].gameObject.GetComponent<MeshRenderer>().material = List[1].BlackMaterial;
        }
    }
    public IEnumerator StartCountdown(float countdownValue = 3) // code inspiré d'internet
    {
        if (!LevelComleted)
        {
            Test();
            yield return new WaitForSeconds(5f);
            if (!Explosé && !EasyDifficulty)
            ChangeOneTile();
            StartCoroutine(StartCountdown());
        }
    }
}
