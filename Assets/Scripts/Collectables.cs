using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Collectables : MonoBehaviour
{
    [SerializeField] int banana;
    [SerializeField] TextMeshProUGUI bananaText;
    [SerializeField] AudioSource collectSound;



    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Banana")) {
            banana += 1;
            bananaText.text = "BANANAS: " + banana.ToString();
            Destroy(collider.gameObject);
            collectSound.Play();
        }
    }
}
