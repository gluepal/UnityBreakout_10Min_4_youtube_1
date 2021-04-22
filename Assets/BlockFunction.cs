using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFunction : MonoBehaviour
{
    public int blockDurable = 0;

    public AudioClip blockColSound = null;
    private AudioSource blockColAudio;

    GameObject gameManager;

    private void Start()
    {
        blockColAudio = this.gameObject.AddComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(blockDurable != 0)
        {
            blockDurable--;
            if(blockDurable <= 0)
            {
                gameManager.GetComponent<GameManager>().WhenDestroyBlock();
                Destroy(gameObject);
            } else
            {
                blockColAudio.PlayOneShot(blockColSound);
            }
        } else
        {
            blockColAudio.PlayOneShot(blockColSound);
        }
    }
}
