using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IMatavel
{
    public GameObject Jogador;
    private Rigidbody rigidbodyInimigo;
    private MovimentoPersonagem movimentoInimigo;
    private AnimacaoPersonagem animacaoInimigo;
    private Status statusInimigo;
    public AudioClip SomDeMorte;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        rigidbodyInimigo = GetComponent<Rigidbody>();
        animacaoInimigo = GetComponent<AnimacaoPersonagem>(); 
        movimentoInimigo = GetComponent<MovimentoPersonagem>();
        statusInimigo = GetComponent<Status>();
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;

        movimentoInimigo.Rotacionar(direcao);

        if (distancia > 2.5)
        {
            movimentoInimigo.Movimentar(direcao, statusInimigo.Velocidade);

            animacaoInimigo.Atacar(false);
        }
        else
        {
            animacaoInimigo.Atacar(true);
        }
    }

    void AtacaJogador()
    {
        int dano = Random.Range(20, 31);

        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
    }

    public void TomarDano(int dano)
    {
        statusInimigo.Vida -= dano;
        if (statusInimigo.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        Destroy(gameObject);
        ControlaAudio.instancia.PlayOneShot(SomDeMorte);
    }
}
