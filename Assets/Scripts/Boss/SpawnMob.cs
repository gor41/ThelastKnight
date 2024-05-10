using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    public GameObject Boss;
    public AudioSource MusicBoss;

private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Player"))
    {
        MusicBoss.Play();
        Boss.SetActive(true);
        Destroy(gameObject);
    }
}
}
