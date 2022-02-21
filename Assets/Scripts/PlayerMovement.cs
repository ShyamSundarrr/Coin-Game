using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float Jumpforce;
    Rigidbody2D rb;
    float dirx;

    [SerializeField]
    Text CoinCounter;

    [SerializeField]
    GameObject CoinMagnet;

    int CoinsNumber;
    public GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal") * Speed;
        CoinCounter.text = CoinsNumber.ToString();
        CoinMagnet.transform.position = new Vector2(transform.position.x, transform.position.y);
        if(Input.GetButtonDown("Jump")&& rb.velocity.y == 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1f) * Jumpforce, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Coin"))
        {
           
            Destroy(other.gameObject);
            CoinsNumber += 1;
        }
        if(other.tag == "Spike")
        {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        


    }



}
