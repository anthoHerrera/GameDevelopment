using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    private bool eaten = false;
    public Text puntaje;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !eaten)
        {
            eaten = !eaten;
            this.gameObject.SetActive(false);
            int x = 0;
            int.TryParse(puntaje.text, out x);
            x += 200;
            puntaje.text = x.ToString();

        }
    }
}
