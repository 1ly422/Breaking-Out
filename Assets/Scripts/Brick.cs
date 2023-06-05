using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int health { get; private set; }

    public bool unbreakable;

    public int points = 100;

    public Color[] colors =
    {
        new Color(231, 105, 93, 255), 
        new Color(231, 144, 93, 255), 
        new Color(231, 229, 93, 255), 
        new Color(93, 231, 122, 255),
        new Color(93, 157, 231, 255),
    };

    void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (!this.unbreakable)
        {
            this.health = this.colors.Length;
            this.spriteRenderer.color = this.colors[this.health - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Hit();
        }
    }

    private void Hit()
    {
        if (this.unbreakable) return;

        if (--this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.spriteRenderer.color = this.colors[this.health - 1];
        }


        FindObjectOfType<GameManager>().Hit(this);
    }
}
