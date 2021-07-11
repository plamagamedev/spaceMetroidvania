using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject player;
    public static dir destinationdirection;
    public static int destinationid;
    public string sceneName;
    public dir direction;
    public int destid;
    public int ownid;
    public void Start(){
        if (destinationid!=0){
            if (destinationid==ownid){
                switch (destinationdirection){
                    case dir.left:
                    player.transform.position=transform.position+new Vector3(1,0,0);
                    break;
                    case dir.right:
                    player.transform.position=transform.position+new Vector3(-1,0,0);
                    break;
                    default:
                    player.transform.position=transform.position+new Vector3(0,0,0);
                    break;
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer==Layer.playerLayer){
            destinationdirection=direction;
            destinationid=destid;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
    public enum dir
    {
        up, down, left, right
    }
}
