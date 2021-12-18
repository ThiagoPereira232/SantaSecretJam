using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] DestinationIdentifier destinationPortal;
    [SerializeField] Transform spawnPoint;
    private Player player;
    private Milly milly;

    public Animator transition;
    public float transitionTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        DontDestroyOnLoad(gameObject);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        yield return SceneManager.LoadSceneAsync(sceneName);

        FindObjects();

        var destPortal = FindObjectsOfType<NextScene>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.transform.position = new Vector2(destPortal.spawnPoint.position.x, destPortal.spawnPoint.position.y);
        try
        {
            milly.transform.position = new Vector2(player.transform.position.x + 1f, player.transform.position.y + 1f);
        }
        catch
        {
            Debug.Log("nn deu q pena");
        }

        Destroy(gameObject);
    }

    void FindObjects()
    {
        player = FindObjectOfType<Player>();
        milly = FindObjectOfType<Milly>();
    }
}

public enum DestinationIdentifier {A, B, C, D, E}
