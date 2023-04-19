using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] VRPlayer player;
    [SerializeField] List<SearchObject> objectsToFind;
    [SerializeField] List<HidingLocation> hidingLocations;
    [SerializeField] List<TargetLocation> targetLocations;
    [SerializeField] Transform startLocation;
    [SerializeField] StartButton startButton;
    [SerializeField] AudioClip sound;

    public enum GAME_STATE { IDLE, STARTED, FINISHED }
    public GAME_STATE gameState = GAME_STATE.IDLE;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        startButton.buttonPressed += startPressed;
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(resetGame());
    }

    void startPressed(VRHand hand)
    {
        if (gameState == GAME_STATE.IDLE)
        {
            startGame();
        }
        else if (gameState == GAME_STATE.STARTED)
        {

            bool gameFinished = true;
            foreach (TargetLocation t in targetLocations)
            {
                if (!t.isFound)
                {
                    gameFinished = false;
                    break;
                }
            }

            //end game
            if(gameFinished)
            {
                AudioSource.PlayClipAtPoint(sound, this.transform.position);
                Invoke("endGame", 6.0f);
            }
                

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        List<HidingLocation> hidingTemp = new List<HidingLocation>(hidingLocations);
        foreach(SearchObject so in objectsToFind)
        {
            int loc = Random.Range(0, hidingTemp.Count);
            so.transform.position = hidingTemp[loc].transform.position;
            hidingTemp.RemoveAt(loc);
            so.gameObject.SetActive(true);
        }
        gameState = GAME_STATE.STARTED;
    }
    public void endGame()
    {
        SceneManager.LoadScene(0);
        
    }
    public IEnumerator resetGame()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 pos = startLocation.position;
        pos.y = startLocation.position.y - 1.0f;
        startLocation.transform.position = pos;
        player.doTeleport(startLocation.position);
        yield return new WaitForSeconds(1.5f);
    }
}
