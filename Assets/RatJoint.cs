using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatJoint : MonoBehaviour
{
    [SerializeField] Rigidbody2D baloonTransform;
    [SerializeField] Rigidbody2D rbody2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (baloonTransform == null) return;

        Vector2 pos = baloonTransform.position;
        rbody2D.MovePosition(pos - (Vector2.up * 1F));
    }
}
