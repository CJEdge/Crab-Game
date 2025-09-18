using System.Collections;
using UnityEngine;
using Project.Components;
using TMPro;
using UnityEngine.InputSystem;

namespace Project.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton Behaviour

        public static GameManager Instance
        {
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

        [SerializeField]
        private GameObject gameMap;

        [SerializeField]
        private Transform[] startingPositions;

        [SerializeField]
        private TMP_Text countdownText;

        [SerializeField]
        private PlayerInputManager playerInput;

        [SerializeField]
        private GameObject playerGameObject;

        [SerializeField]
        private int numberOfPlayers;

        #region Types

        public enum GameState
        {
            PreGameState,
            GameState,
            GameOverState
        }

        public GameState gameState;

        #endregion


        #region Properties

        public bool IsMenu
        {
            get;
            set;
        }

        public bool IsPreGame
        {
            get;
            set;
        }
        public bool IsGameOver
        {
            get;
            set;
        }

        #endregion

        private void Update()
        {
            switch (gameState)
            {
                case GameState.PreGameState:
                    if (!this.IsPreGame)
                    {
                        StartCoroutine("HandlePreGame");
                        this.IsPreGame = true;
                    }
                    break;
                case GameState.GameState:
                        break;
                case GameState.GameOverState:
                    if (!this.IsGameOver)
                    {
                        this.StartCoroutine("HandlePlayerWin");
                        IsGameOver = true;
                    }
                    break;
            }
        }

        private IEnumerator HandlePreGame()
        {
            playerInput.DisableJoining();
            gameMap.SetActive(true);
            SpawnPlayers();
            PlayerManager.Instance.PlayersAlive = PlayerManager.Instance.players.Count;
            for (int i = 0; i < PlayerManager.Instance.players.Count; i++)
            {
                PlayerManager.Instance.players[i].GetComponent<PlayerMovementComponent>().GameStarted = false;
                //PlayerManager.Instance.players[i].transform.position = startingPositions[i].position;
            }
            yield return new WaitForSeconds(1);
            //countdownText.text = "3";
            yield return new WaitForSeconds(0);
            //countdownText.text = "2";
            yield return new WaitForSeconds(0);
            //countdownText.text = "1";
            yield return new WaitForSeconds(0);
            //countdownText.text = "FIGHT";
            for (int i = 0; i < PlayerManager.Instance.players.Count; i++)
            {
                PlayerManager.Instance.players[i].GetComponent<PlayerMovementComponent>().GameStarted = true;
            }
            Invoke("DisableFightText",2f);
            gameState = GameState.GameState;
        }

        private IEnumerator HandlePlayerWin()
        {
            Time.timeScale = 0.5f;
            yield return new WaitForSeconds(3);
            //display text saying who won
            //reset relevent variables
            gameMap.SetActive(false);
            Time.timeScale = 1;
            for (int i = 0; i < PlayerManager.Instance.players.Count; i++)
            {
                Destroy(PlayerManager.Instance.players[i]);
            }
            PlayerManager.Instance.PlayersJoined = 0;
            playerInput.EnableJoining();
            //reset menu ui
        }

        private void DisableFightText()
        {
            //countdownText.text = "";
        }

        private void SpawnPlayers() {
            if (playerGameObject == null) {
                return;
            }
            for (int i = 0; i < numberOfPlayers; i++) {
                Instantiate(playerGameObject, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
