using UnityEngine;

public class Destroyers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Baloon") Destroy(collision.gameObject);
    }
}
