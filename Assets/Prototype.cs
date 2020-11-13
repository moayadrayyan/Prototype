using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prototype : MonoBehaviour
{
    public string Paragraph = "";
    public AudioSource BeepClip;

    private Queue WordsStack = new Queue();

    IEnumerator Start()
    {
        BeepClip.playOnAwake = false;
        WordsStack = new Queue(Paragraph.Split(' '));
        while (WordsStack.Count > 0)
        {
            yield return new WaitForSeconds(1f);
            PrintWords();
        }
    }

    void PrintWords()
    {
        if (WordsStack.Count > 0)
        {
            gameObject.transform.Find("Panel").transform.Find("WordsArea").GetComponent<Text>().text += " " + WordsStack.Dequeue();
            BeepClip.Play();
        }
    }
}