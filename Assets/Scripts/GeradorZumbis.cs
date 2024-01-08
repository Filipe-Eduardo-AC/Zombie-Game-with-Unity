using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    public GameObject Zumbi;
    private float contadorTempo = 0;
    public float TempoGerarZumbi = 2;
    public float ZumbiRows = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;

        if (contadorTempo >= TempoGerarZumbi)
        {
            ZumbiRows = Random.Range(1, 3);

            while (ZumbiRows > 0)
            {
                Instantiate(Zumbi, transform.position, transform.rotation);

                contadorTempo = 0;
                ZumbiRows--;
            }            
        }               
    }
}
