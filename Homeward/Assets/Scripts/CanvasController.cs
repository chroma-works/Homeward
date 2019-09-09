using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject[] storyBoard;
    private int storyBoardActiveIndex;

    public string mapName;

    public AudioSource audioPlayer;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        storyBoardActiveIndex = 0;
        changeMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (storyBoardActiveIndex == 9)
            {
                SceneManager.LoadScene(mapName);
                return;
            }
            Debug.Log("storyBoardActiveIndex!" + storyBoardActiveIndex + (storyBoardActiveIndex + 1));
            storyBoard[storyBoardActiveIndex].SetActive(false);
            storyBoardActiveIndex++;
            if (storyBoardActiveIndex == 3)
            {
                audioPlayer.Stop();
            }
            if (storyBoardActiveIndex == 4)
            {
                changeMusic(1);
                audioPlayer.volume = 0.007f;
            }
            if (storyBoardActiveIndex == 7)
            {
                changeMusic(2);
                audioPlayer.volume = 0.055f;
            }
        }
        if (storyBoardActiveIndex == 5)
        {
            if (audioPlayer.volume < 0.4f)
            {
                audioPlayer.volume += 0.005f;
            }
        }
        if (storyBoardActiveIndex == 6)
        {
            if (audioPlayer.volume < 0.6f)
            {
                audioPlayer.volume += 0.005f;
            }
        }
    }

    private void changeMusic(int index)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clips[index];
        audioPlayer.Play();
    }
}
