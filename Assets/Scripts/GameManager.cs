using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    public TextMeshPro totalEntriesTxt;
=======
>>>>>>> 67b2a03f216ce2d7ffa73454036d430a51277b08
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
<<<<<<< HEAD
=======

    public TextMeshPro totalEntriesTxt;
>>>>>>> 67b2a03f216ce2d7ffa73454036d430a51277b08

    public void CollectingEntry(int totalEntries)
    {
        //play collection noise

        //play ConfusedJosh
        CueAudio(8);
        totalEntriesTxt.text = $"Entries Collected: {totalEntries} / 5";
        OpenEntry(totalEntries);
    }

    public void OpenEntry(int totalEntries)
    {

        CueAudio(29 + totalEntries);
    }

    public void EnemyAudio()
    {
        int soundIndex = Random.Range(14, 28);
        CueAudio(soundIndex);
    }

    public void CueAudio(int soundIndex)
    {
        switch (soundIndex)
        {
            case 0:
                AudioManager.Instance.Play("MenuSong");
                break;
            case 1:
                AudioManager.Instance.Play("WASDJosh");
                break;
            case 2:
                AudioManager.Instance.Play("JumpJosh");
                break;
            case 3:
                AudioManager.Instance.Play("RunJosh");
                break;
            case 4:
                AudioManager.Instance.Play("SpellJosh");
                break;
            case 5:
                AudioManager.Instance.Play("HurtJosh");
                break;
            case 6:
                AudioManager.Instance.Play("ThrowingJosh");
                break;
            case 7:
                AudioManager.Instance.Play("JumpingJosh");
                break;
            case 8:
                AudioManager.Instance.Play("ConfusedJosh");
                break;
            case 9:
                AudioManager.Instance.Play("WhereIsJosh");
                break;
            case 10:
                AudioManager.Instance.Play("NeedToGetHomeJosh");
                break;
            case 11:
                AudioManager.Instance.Play("FixItJosh");
                break;
            case 12:
                AudioManager.Instance.Play("WhoIsThatJosh");
                break;
            case 13:
                AudioManager.Instance.Play("ColorlessJosh");
                break;
            case 14:
                AudioManager.Instance.Play("Enemy1");
                break;
            case 15:
                AudioManager.Instance.Play("Enemy2");
                break;
            case 16:
                AudioManager.Instance.Play("Enemy3");
                break;
            case 17:
                AudioManager.Instance.Play("Enemy4");
                break;
            case 18:
                AudioManager.Instance.Play("Enemy5");
                break;
            case 19:
                AudioManager.Instance.Play("Enemy6");
                break;
            case 20:
                AudioManager.Instance.Play("Enemy7");
                break;
            case 21:
                AudioManager.Instance.Play("Enemy8");
                break;
            case 22:
                AudioManager.Instance.Play("Enemy9");
                break;
            case 23:
                AudioManager.Instance.Play("EnemyHigh1");
                break;
            case 24:
                AudioManager.Instance.Play("EnemyHigh2");
                break;
            case 25:
                AudioManager.Instance.Play("EnemyHigh3");
                break;
            case 26:
                AudioManager.Instance.Play("EnemyLong1");
                break;
            case 27:
                AudioManager.Instance.Play("EnemyLong2");
                break;
            case 28:
                AudioManager.Instance.Play("EnemyLong3");
                break;
            default:
                break;
        }
    }
}
