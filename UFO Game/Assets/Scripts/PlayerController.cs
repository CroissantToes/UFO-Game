using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text lifeText;

    private Rigidbody2D rb2d;
    private int count;
    private int life;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        life = 3;
        winText.text = "";
        SetCountText();
        SetLifeText();
    }

    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            life = life - 1;
            SetLifeText();
        }

        if (count == 8)
        {
            transform.position = new Vector2(75f, 0f);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 16)
        {
            winText.text = "You win! Game created by Chris Santos";
        }
    }

    void SetLifeText()
    {
        lifeText.text = "Lives: " + life.ToString();

        if(life <= 0)
        {
            winText.text = "You Lose! Press R to restart";
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
