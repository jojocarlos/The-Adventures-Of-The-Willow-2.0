using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //same KeyID;
    public string keyID;

    private bool isFollowing;

    public float followSpeed;

    public Transform followTarget;
    public Animator Anim;
    public bool keyDoorOpened;

    void Start()
    {
        Anim.SetBool("PlayerFollow", false);
    }

    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
        if (keyDoorOpened)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isFollowing)
            {
                KeyFollow thePlayer = FindObjectOfType<KeyFollow>();
                Anim.SetTrigger("PlayerFollow");
                followTarget = thePlayer.KeyFollowPoint;
                isFollowing = true;
                thePlayer.AddKey(this);
            }
        }
    }
}
