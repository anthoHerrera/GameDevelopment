﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvilPick : MonoBehaviour
{
    private bool picked = false;
    public Text puntaje;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        picked = !picked;
        this.gameObject.SetActive(false);
        int x = 0;
        int.TryParse(puntaje.text, out x);
        x -= 50;
        puntaje.text = x.ToString();
    }
}