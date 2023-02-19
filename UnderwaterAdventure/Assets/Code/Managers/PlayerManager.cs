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

        [SerializeField]
        private GameObject[] playerTextGameObjects;

        [SerializeField]
        private GameObject[] frogHeadUi;

        [SerializeField]
        private TMP_Text[] playerReadyText;

        [SerializeField]
        private TMP_Text[] playerTexts;

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
            StartCoroutine("PlayerJoinedText");
        }

        #endregion


        #region Coroutines

        IEnumerator PlayerJoinedText()
        {
            int value = this.PlayersJoined - 1;
            playerTextGameObjects[value].SetActive(true);
            playerTexts[value].text = "Player " + (value + 1) + " " + "joined";
            yield return new WaitForSeconds(1f);
            playerTextGameObjects[value].SetActive(false);
            yield return new WaitForSeconds(0.3f);
            frogHeadUi[value].SetActive(true);
            playerReadyText[value].text = "Not Ready";
        }

        #endregion

    }
}
