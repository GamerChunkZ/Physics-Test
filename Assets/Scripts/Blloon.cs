using UnityEngine;

public class Blloon : MonoBehaviour
{
    [SerializeField] float upwardForce = 20F;

    Rigidbody2D rigidbodyComponent;

    private void Start()
    {
        if(rigidbodyComponent == null) { rigidbodyComponent = GetComponent<Rigidbody2D>(); }
    }
    private void FixedUpdate()
    {
        rigidbodyComponent.AddForce(Vector2.up * upwardForce);   
    }
}
