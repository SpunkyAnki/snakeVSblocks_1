using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyBar : MonoBehaviour
{
    SnakeMovement SM;

    private void Start()
    {
        SM = GameObject.FindGameObjectWithTag("SnakeManager").GetComponent<SnakeMovement>();
    }

    private void Update()
    {
        if (SM.transform.childCount > 0 && transform.position.y - SM.transform.GetChild(0).position.y < -10)
            Destroy(this.gameObject);
    }
}
