using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    public void Rotacaojogador(LayerMask MascaraChao)
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction, Color.red);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            Rotacionar(posicaoMiraJogador);
        }
    }
}
