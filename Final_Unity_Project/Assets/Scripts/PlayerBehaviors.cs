using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBehaviors : MonoBehaviour
{
    public Rigidbody2D rb;
    private int degree;

    private static PlayerBehaviors _instance;
    public static PlayerBehaviors Instance { get { return _instance; } }
    [SerializeField] private Text gameOverText;

    // Singleton
    void Awake()
    {
        if (_instance != null && !_instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        degree = 1;
    }

    public void OnEnable()
    {
        StartCoroutine(RotateSpongebob());
    }

    public void OnDisable()
    {
        StopCoroutine(RotateSpongebob());
    }

    //Coroutine
    public IEnumerator RotateSpongebob()
    {
        while (true)
        {
            yield return new WaitForSeconds((float)0.1);

            if (Input.GetKey("left"))
            {
                degree += 15;
                transform.eulerAngles = Vector3.forward * degree;
            }
            if (Input.GetKey("right"))
            {
                degree -= 15;
                transform.eulerAngles = Vector3.forward * degree;
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "planktonfreejpg")
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
}
