﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour  
{
    public Material colorMaterial;
    public Material whiteMaterial;
    Renderer zeRenderer;
    float PressedHeight = 0.1f; 
    Vector3 buttonPosition;

    public int numberPosition;
    public RandomButton random;

    public delegate void PressedEvent(int number);

    public event PressedEvent OnClick;
    void Awake()
    {
        zeRenderer = GetComponent<Renderer>();
        buttonPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (random.player)
        {
            transform.position = new Vector3(buttonPosition.x, -PressedHeight, buttonPosition.z);
            SelectedColor();
            OnClick.Invoke(numberPosition);
        }
    }

    void OnMouseUp()
    {
        UnSelectedColor();
        transform.position = new Vector3(buttonPosition.x, buttonPosition.y, buttonPosition.z);
    }

    public void SelectedColor()
    {
        zeRenderer.sharedMaterial = whiteMaterial;
    }

    public void UnSelectedColor()
    {
        zeRenderer.sharedMaterial = colorMaterial;
    }

}
