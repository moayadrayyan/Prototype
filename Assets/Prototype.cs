using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prototype : MonoBehaviour
{
    //this paragraph input, to be inserted via inspector
    public string Paragraph = "";

    //the sound clip to be played upon writing each word to UI
    public AudioSource BeepClip;

    //Queue will hold the words, to be printed on screen one by one and in correct order.
    private Queue WordsStack = new Queue();
        
    IEnumerator Start()
    {
        //avoid the sound being auto played.
        BeepClip.playOnAwake = false;

        //split the paragraph by a space, and convert it into a queue so we can fetch word by word in correct order.
        WordsStack = new Queue(Paragraph.Split(' '));

        //while still we have words not being removed from the queue
        while (WordsStack.Count > 0)
        {
            //a delay of 1 sec before hitting the printWords function, that will delay the words by 1 sec.
            yield return new WaitForSeconds(1f);

            //print single word to the UI.
            PrintWords();
        }
    }


    /// <summary>
    ///    Print words to the UI one by one, using the Global Queue WordsStack
    /// </summary>
    void PrintWords()
    {
        //Double check that we have words in the Queue to be printed, so we can fetch one.
        if (WordsStack.Count > 0)
        {
            //find the Panel to find the WordsArea which is the Text field object, append the text with the new word being retrieved from the queue.
            gameObject.transform.Find("Panel").transform.Find("WordsArea").GetComponent<Text>().text += " " + WordsStack.Dequeue();

            //play the sound clip upon writing a word to the UI.
            BeepClip.Play();
        }
    }
}