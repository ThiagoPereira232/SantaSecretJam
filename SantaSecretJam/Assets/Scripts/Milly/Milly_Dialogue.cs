using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milly_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    bool playerHitMilly;
    DialogueControl dialCont;

    private List<string> sentences = new List<string>();
    List<Sprite> spr = new List<Sprite>();
    List<string> actorName = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        GetNPCInfo();
        dialCont = DialogueControl.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerHitMilly)
        {
            dialCont.Speech(sentences.ToArray(), spr.ToArray(), actorName.ToArray());
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
            switch (DialogueControl.instance.language)
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
        if (hit != null)
        {
            playerHitMilly = true;
        }
        else
        {
            playerHitMilly = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
