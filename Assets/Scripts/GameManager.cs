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
            default:
                break;
        }
    }
}
