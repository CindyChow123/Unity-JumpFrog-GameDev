using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banana : MonoBehaviour
{
    public GameObject player;
    public PlayerBullet playerBullet;
    private int bananas = 0;
    private Collider2D lastTriggerEntered;

    [SerializeField] private Text ScoreText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        playerBullet = player.GetComponent<PlayerBullet>();
    }

    private void Update()
    {
        if (lastTriggerEntered != null && Input.GetKeyDown(KeyCode.R))
        {
            CollectBanana(lastTriggerEntered);
            lastTriggerEntered = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            lastTriggerEntered = collision;
        }
    }

    private void CollectBanana(Collider2D collision)
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        playerBullet.AddAmmo(1);
        bananas++;
        ScoreText.text = "Score: " + bananas;
    }
}