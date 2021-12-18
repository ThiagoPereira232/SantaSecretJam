using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Porta : MonoBehaviour
{
    bool playerHitDoor;
    [SerializeField] private float rangeKey;
    public LayerMask playerLayer;

    public GameObject tecladoVirtual;

    [SerializeField] private TextMeshProUGUI campoNome;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHitDoor)
        {
            tecladoVirtual.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Space) && playerHitDoor)
        {
            tecladoVirtual.SetActive(false);
        }
    }

    public void VerificarResposta()
    {
        if(campoNome.text == "Hatshepsut")
        {
            tecladoVirtual.SetActive(false);
            Destroy(this.gameObject);
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
            playerHitDoor = true;
        }
        else
        {
            playerHitDoor = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeKey);
    }
}
