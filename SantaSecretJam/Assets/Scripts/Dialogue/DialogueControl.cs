using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        eng,
        pt
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed; 

   
    private bool isShowing;
    private int index;
    private string[] sentences; 
    Sprite[] sprites;
    string[] actorName; 

    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerable TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {

        }
    }
}
