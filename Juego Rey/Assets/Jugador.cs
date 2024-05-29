using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public GameManager gameManager;
    public float fuerzaSalto;

    private Rigidbody2D rb;
    private Animator anim;
    private bool enSuelo = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.start)
        {
            if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
            {
                anim.SetBool("estaSaltando", true);
                rb.AddForce(new Vector2(0, fuerzaSalto));
                enSuelo = false; // El personaje ya no está en el suelo después de saltar
            }
        }


        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            anim.SetBool("estaSaltando", false);
            enSuelo = true; // El personaje vuelve a estar en el suelo
        }

        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }

    }
}
