using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private EmotionalState state;
    public PlayerData data;
    public Boss boss;
    public PlayerController player;
    public LevelLoader levelLoader;

    [SerializeField] private PlayAreaMov playAreaMov;

    public bool checkWin;
    bool hasAwarded = false;

    [SerializeField] private GameObject WonImage, LostImage;


    private void Update()
    {
        if (player.Health <= 0 && !hasAwarded)
        {

            switch (state)
            {
                case EmotionalState.Depression:
                    data.personalities.Add(Personality.Obsession);
                    break;
                case EmotionalState.Disappointment:
                    data.personalities.Add(Personality.Denial);
                    break;
                case EmotionalState.Resentment:
                    data.personalities.Add(Personality.Anger);
                    break;

                default: break;
            }
            LostImage.SetActive(true);

            checkWin = false;
            // AudioManager.instance.StopWithFadeOut();
            // AudioManager.instance.PlayMusic("mainloop");
            // levelLoader.LoadNextLevel("NarrativeExample");

            try
            {
                playAreaMov.isMoveActive = false;
            }
            catch (System.Exception)
            {

            }

            hasAwarded = true;
        }
        else if (boss.Health <= 0 && !hasAwarded)
        {
            switch (state)
            {
                case EmotionalState.Depression:

                    data.personalities.Add(Personality.Freedom);
                    break;
                case EmotionalState.Disappointment:

                    data.personalities.Add(Personality.Acceptance);
                    break;
                case EmotionalState.Resentment:

                    data.personalities.Add(Personality.Forgiveness);
                    break;

                default: break;
            }
            WonImage.SetActive(true);

            checkWin = true;
            //   AudioManager.instance.StopWithFadeOut();
            // AudioManager.instance.PlayMusic("mainloop");
            // levelLoader.LoadNextLevel("NarrativeExample");
            hasAwarded = true;
            try
            {
                playAreaMov.isMoveActive = false;
            }
            catch (System.Exception)
            {

            }
        }

        if (hasAwarded && Input.GetKeyDown(KeyCode.Backspace))
        {
            AudioManager.instance.StopWithFadeOut();
            AudioManager.instance.PlayMusic("mainloop");
            levelLoader.LoadNextLevel("NarrativeExample");
        }



    }


}
