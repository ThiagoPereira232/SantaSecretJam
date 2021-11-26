using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();
    List<Sprite> spr = new List<Sprite>();
    List<string> actorName = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) )
        {
            DialogueControl.instance.Speech(sentences.ToArray(), spr.ToArray(), actorName.ToArray());
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch(DialogueControl.instance.language)
            {
                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
            }
            spr.Add(dialogue.dialogues[i].profile);
            actorName.Add(dialogue.dialogues[i].actorName);
        }
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null)
        {
            playerHit = true;
        } else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
