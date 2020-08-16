using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 startPosition;

    private void Awake()
    {
        EventManager.OnStartGame += () => player.SetActive(true);
        EventManager.OnReplayLevel += () =>
        {
            player.transform.position = startPosition;
            player.SetActive(true);

            EventManager.RunSpawn(true);
        };
    }

    private void Start()
    {
        startPosition = player.transform.position;
        EventManager.RunBackgroundMusic();
    }

    private void OnDisable()
    {
        EventManager.OnStartGame -= () => player.SetActive(true);
        EventManager.OnReplayLevel -= () =>
        {
            player.transform.position = startPosition;
            player.SetActive(true);
        };
    }

}
