using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estatuas : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Sprite front_back;
    [SerializeField] private Sprite left_right;
    [SerializeField] private SpriteRenderer spriteRenderer;


    [Header("Settings")]
    bool playerHitEstatua;

    [SerializeField] private float rangeEst;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TradeSprite();
    }

    void TradeSprite()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHitEstatua)
        {
            if (spriteRenderer.sprite == left_right)
            {
                spriteRenderer.sprite = front_back;
            }
            else
            {
                spriteRenderer.sprite = left_right;
            }
        }
    }

    private void FixedUpdate()
    {
        isKey();
    }

    private void isKey()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, rangeEst, playerLayer);
        if (hit != null)
        {
            playerHitEstatua = true;
        }
        else
        {
            playerHitEstatua = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeEst);
    }
}
