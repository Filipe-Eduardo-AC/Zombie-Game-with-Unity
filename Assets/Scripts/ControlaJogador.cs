using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    private Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;

    public void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs do Jogador - Guardando teclas apertadas
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        //Animações do Jogador
        if (direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Movendo", true);
        }
        else
        {
            animatorJogador.SetBool("Movendo", false);
        }

        if (Vivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    void FixedUpdate()
    {
        //Movimentação do Jogador por segundo
        rigidbodyJogador.MovePosition
            (rigidbodyJogador.position +
            (direcao * Velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}