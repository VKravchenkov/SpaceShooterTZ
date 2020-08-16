using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShot : MonoBehaviour, IPolledObject
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed = 100f;

    public void OnObjectSpawn()
    {
        rigidbody.velocity = transform.forward * speed;
    }

}
