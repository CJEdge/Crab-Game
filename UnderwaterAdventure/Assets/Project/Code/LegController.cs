using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{

    [SerializeField]
    private Transform origin;

    [SerializeField]
    private float legLength;

    [SerializeField]
    private int maxLegAngle;

    [SerializeField]
    private float stepThreshold;

    [SerializeField]
    private float stepSpeed;

    [SerializeReference]
    private Transform footTransform;

    [SerializeField]
    private GameObject leg;

    float timeCount = 0;


    Vector2 direction;

    void FixedUpdate() {

        direction = new Vector2(Mathf.Cos(maxLegAngle * Mathf.Deg2Rad), Mathf.Sin(maxLegAngle * Mathf.Deg2Rad)).normalized ;

        Ray2D ray = new Ray2D((Vector2)origin.position, direction);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction, legLength);

        Debug.DrawRay(ray.origin,ray.direction *legLength, Color.green);

        if (hit) {
            Debug.Log(hit.collider.gameObject.name);
        }

        float dist = Vector2.Distance(hit.point, footTransform.position);


        if(dist > stepThreshold) {
            ResetLegPosition();
        }

        Debug.Log(dist);
    }


    private void ResetLegPosition() {
        leg.transform.rotation = Quaternion.Lerp(leg.transform.rotation, Quaternion.Euler(0, 0, Mathf.Deg2Rad * maxLegAngle), Time.deltaTime * stepSpeed);
    }

}
