using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerificaEstatuas : MonoBehaviour
{
    [Header("Estatuas")]
    public GameObject anubis;
    public GameObject hapi;
    public GameObject ra;
    public GameObject satet;

    private Estatuas estatuas;

    private SpriteRenderer anubisSprite;
    private SpriteRenderer hapiSprite;
    private SpriteRenderer raSprite;
    private SpriteRenderer satetSprite;

    bool anubisPosition;
    bool hapiposition;
    bool raPosition;
    bool satetPosition;

    [Header("Sprites")]
    public Sprite anubisSpriteV;
    public Sprite hapiSpriteV;
    public Sprite raSpriteV;
    public Sprite satetSpriteV;

    [Header("Settings")]
    public GameObject placa;

    // Start is called before the first frame update
    void Start()
    {
        anubisSprite = anubis.GetComponent<SpriteRenderer>();
        hapiSprite = hapi.GetComponent<SpriteRenderer>();
        raSprite = ra.GetComponent<SpriteRenderer>();
        satetSprite = satet.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        VerificaLado();
        VerificaLados();
        Debug.Log("anubis" + anubisPosition);
        Debug.Log("hapi" + hapiposition);
        Debug.Log("ra" + raPosition);
        Debug.Log("satet" + satetPosition);
    }

    void VerificaLado()
    {
        if(anubisSprite.sprite == anubisSpriteV)
        {
            anubisPosition = true;
        }
        else
        {
            anubisPosition = false;
        }

        if(hapiSprite.sprite == hapiSpriteV)
        {
            hapiposition = true;
        }
        else
        {
            hapiposition = false;
        }

        if(raSprite.sprite == raSpriteV)
        {
            raPosition = true;
        }
        else
        {
            raPosition = false;
        }

        if(satetSprite.sprite == satetSpriteV)
        {
            satetPosition = true;
        }
        else
        {
            satetPosition = false;
        }

    }

    void VerificaLados()
    {
        if(anubisPosition && hapiposition && raPosition && satetPosition)
        {
            placa.SetActive(true);
        }
    }
}
