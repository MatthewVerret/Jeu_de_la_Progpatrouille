﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForward : MonoBehaviour
{
    private Vector3 playerPosition;
    private Vector3 fanPosition;
    private GameObject player;
    private bool check;

    [SerializeField]
    int power = 2;
    int MEDIUM_POWER = 4;
    int HARD_POWER = 6;

    //[SerializeField]
    private float Intensity;

    [SerializeField]
    float puissanceFan;

    public void AdjustDifficulty()
    {
        if (KeepOverTimeComponent.difficulty == 2)
        {
            power = MEDIUM_POWER;

        }
        if (KeepOverTimeComponent.difficulty == 3)
        {
            power = HARD_POWER;
        }
    }
    public void PousserAvant()
    {
        //joueur.transform.(transform.forward * (Intensity) * 50);
        player.GetComponent<Rigidbody>().velocity = transform.forward * Intensity * power;
    }
    void Start()
    {
        player = GameObject.Find("Voleur");
        AdjustDifficulty();
        //item = GetComponent<PushComponent>();
        //i = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        if (check)
        {
            playerPosition = player.transform.position;
            fanPosition = GetComponentInParent<Transform>().position;
            Intensity = Mathf.Pow(Mathf.Log(TrouverDistanceBanditFan(playerPosition, fanPosition)), -1);
            PousserAvant();
        }
    }
    public float TrouverDistanceBanditFan(Vector3 positionBandit, Vector3 positionFan)
    { 
        return Vector3.Distance(positionBandit, positionFan);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
            check = true;   
    }
    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        check = false;
    }
}
