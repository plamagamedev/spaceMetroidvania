using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHIPSPAWNERFIRST : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject origin;
    public GameObject destination;
    public float speed;
    private Animator animator;
    public GameObject player;
    public FollowPlayer followPlayer;
    public GameObject spwanPoint;
    public Vector2 force;
    private const string fliyinganimation = "FLYING";
    private const string landinganimation = "LANDING";

    void Start()
    {
        animator = GetComponent<Animator>();
        if (Events.shipSpawned)
        {
            transform.position = destination.transform.position;
            animator.Play(landinganimation);
            //TODO make the animation end;
            noSpawn();
        }
        else
        {
            transform.position = origin.transform.position;
        }

    }
    private bool fly = true;
    // Update is called once per frame
    void Update()
    {
        if (fly)
        {
            if (Time.time > 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
                if (transform.position == destination.transform.position)
                {
                    animator.Play(landinganimation);
                    StartCoroutine("spawn");
                    fly = false;
                }
            }
        }

    }
    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(.5f);
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;
        player.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        player.transform.position = spwanPoint.transform.position;
        player.transform.parent = null;
        followPlayer.player = player;
        Events.shipSpawned=true;
        Destroy(this);
    }
    public void noSpawn()
    {
        player.transform.parent = null;
        followPlayer.player = player;
        Destroy(this);
    }
}
