using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    public Rigidbody2D rb;
    private int degree;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        degree = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEnable()
    {
        StartCoroutine(RotateSpongebob());
    }

    public void OnDisable()
    {
        StopCoroutine(RotateSpongebob());
    }

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
}
