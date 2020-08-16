using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAsteroid : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float tumble;

    private void Start()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
