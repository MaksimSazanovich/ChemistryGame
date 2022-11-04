using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToDissappeaar;

    private Player player;
    private Generator generator;
    private Randomazer randomazer;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D circleCollider;
    
    private bool inactive = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        // polygonCollider = GetComponent<PolygonCollider2D>();

        generator = FindObjectOfType<Generator>();
        player = FindObjectOfType<Player>();
        randomazer = FindObjectOfType<Randomazer>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        circleCollider.enabled = true;
        circleCollider.isTrigger = true;
        //polygonCollider.enabled = false;

        gameObject.layer = LayerMask.NameToLayer("Ghost");
        gameObject.tag = "Untagged";
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (inactive == false)
        {
            if (other.gameObject.GetComponent<Hole>())
            {
                
            }

            if (other.gameObject.GetComponent<Player>() || other.gameObject.GetComponent<Enemy>())
            {
                speed = 0;
                transform.parent = player.transform;
                StartCoroutine(WaitDisappearance());
            }
            inactive = true;
        }
        if (other.gameObject.GetComponent<Centre>())
        {
            randomazer.GetSpriteName();
            gameObject.layer = LayerMask.NameToLayer("Default");
            speed = 0;
            rb.bodyType = RigidbodyType2D.Dynamic;
            circleCollider.isTrigger = false;
            //if (gameObject.GetComponent<Enemy>())
            //{
            //generator.CheckAtomToDestroy();
            //}
        }
    }

    private IEnumerator WaitDisappearance()
    {       
        yield return new WaitForSeconds(timeToDissappeaar);
        Destroy(gameObject);
    }

    //public void DestroyAtom()
    //{
    //    gameObject.tag = "Destruction";
    //    Debug.Log("destruction tag");
    //    //Destroy(gameObject);
    //}
}
