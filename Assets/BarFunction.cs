using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFunction : MonoBehaviour
{
    public GameObject mBall;
    public int mBallSpeed;
    public int mBarSpeed;
    public float mBarMinX, mBarMaxX;

    private bool mStarted = false;

    public AudioClip barColSound = null;
    private AudioSource barColAudio;

    private void Start()
    {
        barColAudio = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            if (mBarMaxX > this.transform.position.x)
            {
                this.transform.position = this.transform.position + new Vector3(1.0f * Time.deltaTime, 0) * mBarSpeed;
            }
            if (mStarted == false)
            {
                mBall.transform.position = new Vector3(this.transform.position.x, mBall.transform.position.y, 0);
            }
        }

        if (Input.GetKey("left"))
        {
            if (mBarMinX < this.transform.position.x)
            {
                this.transform.position = this.transform.position + new Vector3(-1.0f * Time.deltaTime, 0) * mBarSpeed;
            }
            if (mStarted == false)
            {
                mBall.transform.position = new Vector3(this.transform.position.x, mBall.transform.position.y, 0);
            }
        }

        if (Input.GetKey("space"))
        {
            mBall.GetComponent<Rigidbody2D>().AddForce(new Vector3(1.0f, 1.0f, 0) * mBallSpeed);
            mStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        barColAudio.PlayOneShot(barColSound);
    }
}
