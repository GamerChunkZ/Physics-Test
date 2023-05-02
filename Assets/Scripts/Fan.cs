using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] float maxForce = 20F;
    [SerializeField] float range = 2;

    [SerializeField] float fanSpeed = 3F;
    [SerializeField] Animator animator;

    Transform myTransform;

    float force;
    bool isHeld = false;
    Rigidbody2D baloon = null;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // increasing force overtime to a max of 1
        if (force < 1)
        {
            force += Time.deltaTime;
            force = Mathf.Clamp01(force);
        }

        // increase fanspeed as force increase
        animator.SetFloat("Speed", force * fanSpeed);

        // If the baloon is in range apply force
        if (baloon)
        {
            Vector2 pos = myTransform.position;
            Vector2 direction = baloon.position - pos;
            float distance = direction.magnitude;
            float magnitude = Mathf.Clamp01(distance / range);

            direction.Normalize();
            baloon.AddForce(direction * force * maxForce * magnitude);
        }

        // Click detection
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!isHeld)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPos = myTransform.position;
                if ((pos - myPos).magnitude < 0.75) isHeld = true;
            }
        }
        else isHeld = false;

        // if held move with the mouse
        if (isHeld)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myTransform.position = pos;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Baloon")
        {
            baloon = collision.attachedRigidbody;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Baloon")
        {
            baloon = null;
        }
    }

    // killing baloon if it collide with the fan
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Baloon") Destroy(collision.gameObject);        
    }
}
