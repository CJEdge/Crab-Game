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
        private GameObject menuMap;

        [SerializeField]
        private GameObject gameMap;

        [SerializeField]
        private Transform[] startingPositions;

        [SerializeField]
        private TMP_Text countdownText;

        [SerializeField]
        private PlayerInputManager playerInput;

        #region Types

        public enum GameState
        {
            MenuState,
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
                case GameState.MenuState:
                    if (!this.IsMenu)
                    {
                        StartCoroutine("HandleMenu");
                        this.IsMenu = true;
                    }
                    //check if all players are on starting platform
                    break;
                case GameState.PreGameState:
                    if (!this.IsPreGame)
                    {
                        StartCoroutine("HandlePreGame");
                        this.IsPreGame = true;
                    }
                    break;
                case GameState.GameState:
                    if (PlayerManager.Instance.PlayersAlive == 1)
                    {
                        gameState = GameState.GameOverState;                
                    }
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

        private IEnumerator HandleMenu()
        {
            gameMap.SetActive(false);
            menuMap.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        private IEnumerator HandlePreGame()
        {
            playerInput.DisableJoining();
            menuMap.SetActive(false);
            gameMap.SetActive(true);
            PlayerManager.Instance.PlayersAlive = PlayerManager.Instance.players.Count;
            for (int i = 0; i < PlayerManager.Instance.players.Count; i++)
            {
                PlayerManager.Instance.players[i].GetComponent<PlayerMovementComponent>().GameStarted = false;
                PlayerManager.Instance.players[i].transform.position = startingPositions[i].position;
            }
            yield return new WaitForSeconds(5);
            countdownText.text = "3";
            yield return new WaitForSeconds(1);
            countdownText.text = "2";
            yield return new WaitForSeconds(1);
            countdownText.text = "1";
            yield return new WaitForSeconds(1);
            countdownText.text = "FIGHT";
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
            gameState = GameState.MenuState;
            gameMap.SetActive(false);
            menuMap.SetActive(true);
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
            countdownText.text = "";
        }
    }
}
