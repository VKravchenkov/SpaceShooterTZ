using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Boundary boundary;
    [SerializeField] private GameObject prefabShot;
    [SerializeField] private Transform shotSpawnLeft;
    [SerializeField] private Transform shotSpawnRight;

    [SerializeField] private float speed = 50f;
    [SerializeField] private float tilt = 0.5f;

    [SerializeField] private float nextFire;
    [SerializeField] private float fireRate = 0.2f;

    private void Awake()
    {
        EventManager.GameOver += GameOver;
        EventManager.OnFireClick += FireMobileButton;
        EventManager.OnJoystickClick += JoystickMobileClick;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            EventManager.RunSpawnMissile(shotSpawnLeft.position, shotSpawnRight.position);
            EventManager.MissileSound();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);

        rigidbody.velocity = move * speed;

        rigidbody.position = new Vector3
        {
            x = Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            y = 0f,
            z = Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        };

        rigidbody.rotation = Quaternion.Euler(0f, 0f, rigidbody.velocity.x * -tilt);
    }
#endif

    private void OnDisable()
    {
        EventManager.GameOver -= GameOver;
        EventManager.OnFireClick -= FireMobileButton;
        EventManager.OnJoystickClick -= JoystickMobileClick;
    }
    private void FireMobileButton()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            EventManager.RunSpawnMissile(shotSpawnLeft.position, shotSpawnRight.position);
            EventManager.MissileSound();
        }
    }

    private void JoystickMobileClick(float horizontal, float vertical)
    {
        Vector3 move = new Vector3(horizontal, 0, vertical);

        rigidbody.velocity = move * speed / 2;

        rigidbody.position = new Vector3
        {
            x = Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            y = 0f,
            z = Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        };

        rigidbody.rotation = Quaternion.Euler(0f, 0f, rigidbody.velocity.x * -tilt);
    }

    private void GameOver()
    {
        gameObject.SetActive(false);

        EventManager.RunSpawn(false);
        EventManager.SpawnHideAsteroid();

        LoseOverlay.Instance.Show();
    }
}
[Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}
