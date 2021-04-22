using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData
{
    public int number;
    public int[] stage;
}

[System.Serializable]
public class StagesData
{
    public StageData[] stages;
}

public class GameManager : MonoBehaviour
{
    // For Stage
    public int stageNumber = 0;

    public TextAsset stageJson;
    private StagesData mStages;

    public GameObject[] mBlocks;

    public AudioClip blockDestSound = null;
    private AudioSource blockDestAudio;

    public void Start()
    {
        blockDestAudio = this.gameObject.AddComponent<AudioSource>();

        LoadStage();

    }

    private void LoadStage()
    {
        mStages = JsonUtility.FromJson<StagesData>(stageJson.ToString());

        for (int i = 0; i < mStages.stages[stageNumber - 1].stage.Length; i++)
        {
            GameObject cloneBlock;
            switch (mStages.stages[stageNumber - 1].stage[i])
            {
                case 1:
                    cloneBlock = Instantiate(mBlocks[0]);
                    cloneBlock.transform.position = new Vector3(-2.2f + ((0.365f) * (i % 13)), (4.6f - ((0.25f * (i / 13)))));
                    break;

                case 2:
                    cloneBlock = Instantiate(mBlocks[1]);
                    cloneBlock.transform.position = new Vector3(-2.2f + ((0.365f) * (i % 13)), (4.6f - ((0.25f * (i / 13)))));
                    break;

                case 3:
                    cloneBlock = Instantiate(mBlocks[2]);
                    cloneBlock.transform.position = new Vector3(-2.2f + ((0.365f) * (i % 13)), (4.6f - ((0.25f * (i / 13)))));
                    break;

                case 4:
                    cloneBlock = Instantiate(mBlocks[3]);
                    cloneBlock.transform.position = new Vector3(-2.2f + ((0.365f) * (i % 13)), (4.6f - ((0.25f * (i / 13)))));
                    break;

                case 5:
                    cloneBlock = Instantiate(mBlocks[4]);
                    cloneBlock.transform.position = new Vector3(-2.2f + ((0.365f) * (i % 13)), (4.6f - ((0.25f * (i / 13)))));
                    break;

                case 9:
                    cloneBlock = Instantiate(mBlocks[8]);
                    cloneBlock.transform.position = new Vector3(-2.2f + ((0.365f) * (i % 13)), (4.6f - ((0.25f * (i / 13)))));
                    break;

                default:
                    break;
            }
        }
    }

    public void WhenDestroyBlock()
    {
        blockDestAudio.PlayOneShot(blockDestSound);
    }
}
