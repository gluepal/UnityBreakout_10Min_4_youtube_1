using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mBall;
    public GameObject mBar;
    public int mBallSpeed;
    public int mBarSpeed;
    public float mBarMinX, mBarMaxX;

    private bool mStarted = false;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            if(mBarMaxX > mBar.transform.position.x)
            {
                mBar.transform.position = mBar.transform.position + new Vector3(1.0f * Time.deltaTime, 0) * mBarSpeed;
            }
            if (mStarted == false)
            {
                mBall.transform.position = new Vector3(mBar.transform.position.x, mBall.transform.position.y, 0);
            }
        }

        if (Input.GetKey("left"))
        {
            if (mBarMinX < mBar.transform.position.x)
            {
                mBar.transform.position = mBar.transform.position + new Vector3(-1.0f * Time.deltaTime, 0) * mBarSpeed;
            }
            if(mStarted == false)
            {
                mBall.transform.position = new Vector3(mBar.transform.position.x, mBall.transform.position.y, 0);
            }
        }

        if (Input.GetKey("space"))
        {
            mBall.GetComponent<Rigidbody2D>().AddForce(new Vector3(1.0f, 1.0f, 0) * mBallSpeed);
            mStarted = true;
        }
    }
}
