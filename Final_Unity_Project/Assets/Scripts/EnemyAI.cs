using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private System.Random rand;
    [SerializeField] private GameObject planktonPrefab;
    public GameObject player;
    int n;
    float step;
    private BoxCollider2D spongeCollider;
    private BoxCollider2D me;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();

        n = rand.Next(0, 4);

        if (n == 0)
        {
            transform.position = new Vector3((float)-8.5, rand.Next(-6, 6), 0);
        }
        if (n == 1)
        {
            transform.position = new Vector3((float)8.5, rand.Next(-6, 6), 0);
        }
        if (n == 2)
        {
            transform.position = new Vector3(rand.Next(-9, 9), (float)-5.5, 0);
        }
        if (n == 3)
        {
            transform.position = new Vector3(rand.Next(-9, 9), (float)5.5, 0);
        }

        spongeCollider = player.GetComponent<BoxCollider2D>();
        me = GetComponent<BoxCollider2D>();

        int step = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) < 1.55 && Mathf.Abs(transform.position.y) < 1.55)
        {
            OnDisable();
            Destroy(this);
        }
    }

    public void OnEnable()
    {
        StartCoroutine(MovePlankton());
    }

    public void OnDisable()
    {
        StopCoroutine(MovePlankton());
    }

    // Coroutine
    public IEnumerator MovePlankton()
    {
        while (true)
        {
            yield return new WaitForSeconds((float)1);

            transform.position = Vector3.MoveTowards(transform.position, (new Vector3(0, 0, 0)), 1);
        }

    }
}
