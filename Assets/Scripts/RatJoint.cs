using UnityEngine;

public class RatJoint : MonoBehaviour
{
    [SerializeField] Rigidbody2D baloonRigidbody;
    [SerializeField] Rigidbody2D myRigidbody2D;

    void FixedUpdate()
    {
        if (baloonRigidbody == null) return;

        Vector2 pos = baloonRigidbody.position;
        myRigidbody2D.MovePosition(pos - (Vector2.up * 1F));
    }
}
