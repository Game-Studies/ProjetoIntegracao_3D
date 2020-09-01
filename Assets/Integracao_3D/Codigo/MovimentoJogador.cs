using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    [SerializeField]
    private Rigidbody meuRB;
    private Transform meuTransform;

    [SerializeField, Tooltip("controle da força aplicada ao movimento")]
    private float forca = 450f;
    [SerializeField, Tooltip("velocidade maxima em m/s")]
    private float velocidadeMaxima = 5f;

    private float vertical;
    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        if (meuRB == null)
        {
            meuRB = GetComponent<Rigidbody>();
            if (meuRB == null)
            {
                Debug.LogError("Deu ruim " + gameObject.name);
            }
        }

        meuTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical") * forca;
        horizontal = Input.GetAxis("Horizontal") * forca;

        
    }

    private void FixedUpdate()
    {
        Vector3 frente = Vector3.forward * vertical;
        Vector3 direita = Vector3.right * horizontal;
        Vector3 forcaResultante = (frente + direita).normalized * Time.fixedDeltaTime * 100;

        meuRB.AddForce(forcaResultante, ForceMode.VelocityChange);

        //meuTransform.Translate(forcaResultante);

        // Controla limite de velocidade total (inclui gravidade)   
        meuRB.velocity = Vector3.ClampMagnitude(meuRB.velocity, velocidadeMaxima);
    }

}
