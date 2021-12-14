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

    private void Start()
    {
    }
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
        yield return SceneManager.LoadSceneAsync(sceneName);
        player = FindObjectOfType<Player>();
        var destPortal = FindObjectsOfType<NextScene>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.transform.position = new Vector2(destPortal.spawnPoint.position.x, destPortal.spawnPoint.position.y);
        Destroy(gameObject);
    }
}

public enum DestinationIdentifier {A, B, C, D, E}
