using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }

    public float speed = 500f;

    private bool isInit = false;

    private void Awake()
    {
        this.rigidbody = (Rigidbody2D)GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        this.transform.position = new Vector3(0f, -2f);
        this.rigidbody.velocity = Vector3.zero;
        this.isInit = false;
        //Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        if (!isInit)
        {

            Vector2 force = Vector2.zero;
            force.x = Random.Range(-1f, 1f);
            force.y = -1f;

            this.rigidbody.AddForce(force.normalized * this.speed);
            this.isInit = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.rigidbody.velocity == Vector2.zero)
            {
                SetRandomTrajectory();
            }
        }
    }
}
