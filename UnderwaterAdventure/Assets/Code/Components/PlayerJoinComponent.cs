using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Managers;

namespace Project.Components
{
    public class PlayerJoinComponent : MonoBehaviour
    {

        [SerializeField]
        private GameObject[] hats;

        public bool IsReady
        {
            get;
            set;
        }

        public void Start()
        {
            this.IsReady = false;
            PlayerManager.Instance.PlayerJoined(this);

            for (int i = 0; i < hats.Length; i++)
            {
                hats[i].SetActive(false);
                hats[PlayerManager.Instance.PlayersJoined - 1].SetActive(true);
            }
        }

    }
}
