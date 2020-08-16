using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;

        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            EventManager.HitPlayer();
        }

        if (other.tag == "Missile")
        {
            EventManager.RunSpawnExplosion(transform.position);
            EventManager.EplosionAsteroidSound();
            EventManager.ChangeScore(1);

            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }

    }
}
