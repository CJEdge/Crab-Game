using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Managers;
using Project.Components;
using TMPro;

public class StartPlatform : MonoBehaviour
{
    
    List<PlayerJoinComponent> playersReady = new List<PlayerJoinComponent>();


    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerJoinComponent player = collision.gameObject.GetComponent<PlayerJoinComponent>();
        if (player.IsReady)
        {
            return;
        }
        player.IsReady = true;
        playersReady.Add(player);
        PlayerReady();
    }

    private void PlayerReady()
    {
        if(playersReady.Count == PlayerManager.Instance.players.Count)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        GameManager.Instance.gameState = GameManager.GameState.PreGameState;
    }
}
