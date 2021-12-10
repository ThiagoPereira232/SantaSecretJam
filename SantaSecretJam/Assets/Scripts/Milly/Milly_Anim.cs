using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milly_Anim : MonoBehaviour
{
    private Player player;
    private Milly milly;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        milly = GetComponent<Milly>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }

    #region Movement
        
    void OnMove()
    {
        if(player.Direction.sqrMagnitude > 0 && milly.Agent.remainingDistance > 1.97)
        {
            if (player.Direction.y > 0)
            {
                anim.SetInteger("transition", 2);
            }
            if (player.Direction.y < 0)
            {
                anim.SetInteger("transition", 1);
            }
            if (player.Direction.x > 0)
            {
                anim.SetInteger("transition", 3);
            }
            if (player.Direction.x < 0)
            {
                anim.SetInteger("transition", 4);
            }
        } 
        else
        {
            if (milly.Agent.remainingDistance <= 2)
            {
                anim.SetInteger("transition", 0);
            }
        }
        
    }

    #endregion
}
