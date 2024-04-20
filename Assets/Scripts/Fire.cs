using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject lazerPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] GameManager gm;// The time between each fire

    private float nextFireTime; // The time when the next fire can happen

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireLazer();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireLazer()
    {
        Instantiate(lazerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    //if cube falls to tag Death, reset game
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            gm.RestartGame();
        }
    }
}
