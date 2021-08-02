using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalUI : MonoBehaviour
{
    #region Singleton
    private static JournalUI _instance;

    public static JournalUI Instance { get { return _instance; } }

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

    public GameObject journalPanel;
    public TMP_Text journalEntryTxt;
    public TMP_Text totalEntriesTxt;

    string[] journalEntries =
    {
        " I have no clue where I am or what happened to me. " +
            "I was back home and then just... appeared here. " +
            "I don't know what happened. " +
            "I just want my family back. " +
            "I need to get rid of this curse.",
        " I think that defeating the mannequins will help me find out how to stop this stupid curse.",
        "I've killed several mannequins and nothing is changing. " +
            "I think that I need to figure something else out, " +
            "though I'm not sure what that something else would be.",
        "I think my best bet is just giving up. " +
            "There is nothing for me here but stupid mannequins and these blank journals. " +
            "That old house is empty and the truck hasn't been touched in ages.",
        "I don't think I'll ever leave this stupid place or fix my vision. " +
            "If anyone ever finds this, best of luck, " +
            "hopefully you can find a way out of this hell."
    };

    public void CollectingEntry(int totalEntries)
    {
        //play collection noise
        GameManager.Instance.CueAudio(34);
        //play ConfusedJosh
        GameManager.Instance.CueAudio(8);
        totalEntriesTxt.text = $"Entries Collected: {totalEntries + 1} / 5";
        OpenEntry(totalEntries);
    }

    public void OpenEntry(int totalEntries)
    {
        GameManager.Instance.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        journalPanel.SetActive(true);
        journalEntryTxt.text = journalEntries[totalEntries];
        GameManager.Instance.CueAudio(29 + totalEntries);
    }

    public void CloseEntry()
    {
        GameManager.Instance.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        journalPanel.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>().disabled = false;
    }
}
