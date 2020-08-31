using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    [SerializeField]
    private Rigidbody meuRB;

    [HideInInspector]
    public float forca = 450f;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
