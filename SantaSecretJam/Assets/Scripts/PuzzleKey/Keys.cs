using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    bool playerHitKey;

    GameController gameCont;

    [SerializeField] private float rangeKey;
    public LayerMask playerLayer;

    public GameObject oldKey;
    public GameObject newKey;
    public GameObject portas;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Altar");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        gameCont = GameController.instanceGame;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(oldKey.activeSelf);

        if (Input.GetKeyDown(KeyCode.Alpha2) && playerHitKey)
        {
            if(gameCont.newKey && gameCont.oldKey)
            {
                if (!oldKey.activeSelf && gameCont.oldKey)
                {
                    oldKey.SetActive(true);
                    gameCont.oldKey = false;
                }
            }
            else
            {
                if (!oldKey.activeSelf)
                {
                    if (!newKey.activeSelf && gameCont.newKey)
                    {
                        newKey.SetActive(true);
                        gameCont.newKey = false;
                    }
                }
                
            }          
        }
        if(!oldKey.activeSelf && !newKey.activeSelf)
        {
            portas.SetActive(true);
        }
        else
        {
            portas.SetActive(false);
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
