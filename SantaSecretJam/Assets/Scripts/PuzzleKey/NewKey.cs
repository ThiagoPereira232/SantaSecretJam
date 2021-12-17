using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKey : MonoBehaviour
{
    bool playerHitKey;

    GameController gameCont;

    [SerializeField] private float rangeKey;
    public LayerMask playerLayer;

    private void Start()
    {
        gameCont = GameController.instanceGame;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHitKey)
        {
            gameCont.newKey = true;
            gameObject.SetActive(false);
        }
        
    }

    private void FixedUpdate()
    {
        isKey();
    }

    private void isKey()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeKey, playerLayer);
        if (hit != null)
        {
            playerHitKey = true;
        }
        else
        {
            playerHitKey = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeKey);
    }
}
