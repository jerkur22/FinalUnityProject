using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    private bool fired;
    [SerializeField] private GameObject happyObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && !fired)
        {
            transform.position = player.transform.position;
            transform.eulerAngles = player.transform.eulerAngles;
            fired = true;
        }
        if (fired)
        {
            rb.velocity = transform.up * 4;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plankton")
        {
            Debug.Log("plank");
            happyObject.transform.position = new Vector2(0, -4);
        }
    }
}
