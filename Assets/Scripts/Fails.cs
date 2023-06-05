using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fails : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            FindObjectOfType<GameManager>().Fail();
        }
    }
}
