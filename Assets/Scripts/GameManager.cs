using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] sounds;

    void Start()
    {
        
    }

    void Update()
    {
        
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
