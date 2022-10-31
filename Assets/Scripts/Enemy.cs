using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    Player player;
    Generator generator;
    SpriteRenderer spriteRenderer;
    Randomazer randomazer;

    private bool inactive = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        generator = FindObjectOfType<Generator>();   
        player = FindObjectOfType<Player>();
        randomazer = FindObjectOfType<Randomazer>();    
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (inactive == false)
        {
            if (other.tag == "Hole")
            {
                Destroy(gameObject);
                randomazer.GetSpriteName();
            }

            if (other.gameObject.GetComponent<Player>() != null || other.gameObject.GetComponent<Enemy>() != null)
            {

                speed = 0;
                transform.parent = player.transform;
                StartCoroutine(WaitDisappearance());
            }
            inactive = true;
        }
    }

    private IEnumerator WaitDisappearance()
    { 
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
