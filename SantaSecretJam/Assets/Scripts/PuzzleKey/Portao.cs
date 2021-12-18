using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{
    GameController gameCont;

    bool playerHitPort;

    [SerializeField] private float rangePort;
    public LayerMask playerLayer;

    private void Start()
    {
        gameCont = GameController.instanceGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerHitPort)
        {
            if (gameCont.newKey)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        isKey();
    }

    private void isKey()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, rangePort, playerLayer);
        if (hit != null)
        {
            playerHitPort = true;
        }
        else
        {
            playerHitPort = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangePort);
    }
}
