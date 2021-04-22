using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunction : MonoBehaviour
{
    public int blockDurable = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(blockDurable != 0)
        {
            blockDurable--;
            if(blockDurable <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
