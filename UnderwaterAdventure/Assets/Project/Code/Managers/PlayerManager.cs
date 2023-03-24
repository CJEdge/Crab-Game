using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Project.Components;
using TMPro;

namespace Project.Managers
{
    public class PlayerManager : MonoBehaviour
    {

        #region Singleton Behaviour

        public static PlayerManager Instance { 
            get; 
            private set; 
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void Start()
        {

        }
        #endregion


        #region Serialized Fields


        #endregion


        #region Non Serialized Fields

        public List<GameObject> players = new List<GameObject>();

        #endregion


        #region Properties

        public int PlayersJoined
        {
            get;
            set;
        } = 0;

        public int PlayersAlive
        {
            get;
            set;
        }

        #endregion

        #region Mono Behaviours


        #endregion


        #region Public Methods

        public void PlayerJoined(PlayerJoinComponent player)
        {
            players.Add(player.gameObject);
            this.PlayersJoined++;
            this.PlayersAlive++;
        }

        #endregion


        #region Coroutines


        #endregion

    }
}
