using UnityEngine;
using Project.Components;

public class BubbleBlower : MonoBehaviour
{

    #region Serialized Fields

    [SerializeField]
    private float power;

    #endregion


    #region Properties

    public Rigidbody2D rb
    {
        get;
        private set;
    }

    #endregion


    #region Collision Checks

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<PhysicsBodyComponent>()?.rb;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (rb != null)
        {
            rb.AddForce(new Vector2(0, power));
        }
    }

    #endregion


}
