using UnityEngine;

namespace Project.Components
{
    public class PhysicsBodyComponent : MonoBehaviour
    {

        #region Properties

        [field : SerializeField]
        public Rigidbody2D rb
        {
            get;
            set;
        }

        #endregion


        #region Mono Behaviours

        public void Start()
        {
            if(rb == null)
            {
                rb = GetComponentInParent<Rigidbody2D>();
            }
        }

        #endregion

    }
}