using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusLifeController : MonoBehaviour
{
    [SerializeField] private List<ItemHead> itemHeads;

    public int CurrentCountHead { get; private set; }

    private void OnEnable()
    {
        EventManager.OnHitPlayer += HitPlayer;
        EventManager.OnStartGame += FullHead;

        EventManager.OnReplayLevel += FullHead;
        EventManager.OnCurrentLevel += (levelData) => FullHead();
    }

    private void OnDisable()
    {
        EventManager.OnHitPlayer -= HitPlayer;
        EventManager.OnStartGame -= FullHead;

        EventManager.OnReplayLevel -= FullHead;
        EventManager.OnCurrentLevel -= (levelData) => FullHead();
    }

    private void HitPlayer()
    {
        CurrentCountHead--;

        if (CurrentCountHead == 0)
        {
            itemHeads[CurrentCountHead].DeActive();

            EventManager.ExplosionSpaceShipSound();

            EventManager.EndGame();
            return;
        }

        itemHeads[CurrentCountHead].DeActive();
    }

    private void FullHead()
    {
        CurrentCountHead = itemHeads.Count;
        itemHeads.ForEach(item => item.Active());
    }
}

