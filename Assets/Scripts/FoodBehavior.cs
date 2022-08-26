using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    [Header("Snake Manager")]

    SnakeMovement SM;

    public int foodAmount;

    private void Start()
    {
        SM = GameObject.FindGameObjectWithTag("SnakeManager").GetComponent<SnakeMovement>();

        foodAmount = Random.Range(1, 10);
        transform.GetComponentInChildren<TextMesh>().text = "" + foodAmount;

    }

    private void Update()
    {
        if (SM.transform.childCount > 0 && transform.position.y - SM.transform.GetChild(0).position.y < -10)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}

