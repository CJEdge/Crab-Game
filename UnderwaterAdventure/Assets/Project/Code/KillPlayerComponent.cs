using UnityEngine;
using Project.Managers;

namespace Project.Components
{
    public class KillPlayerComponent : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            PlayerManager.Instance.PlayersAlive--;
            Destroy(gameObject);
        }
    }
}
