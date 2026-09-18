using UnityEngine;


        

public class MovimentoNave : MonoBehaviour
    {
        [Header("Configurações de Movimento")]
        public float velocidadeFrenteTras = 20f;   // Velocidade para frente e trás
        public float velocidadeLados = 15f;        // Velocidade para os lados
        public float suavizacao = 5f;              // Quão suave o movimento fica

        private Rigidbody rb;
        private Vector3 movimentoDesejado;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            // Recomendações importantes para nave:
            rb.useGravity = false;
            rb.drag = 1f;           // Arrasto linear (ajuda a parar)
            rb.angularDrag = 2f;    // Arrasto angular
        }

        void Update()
        {
            // Pega os inputs
            float frenteTras = Input.GetAxis("Vertical");   // W/S ou Setas ↑↓
            float lados = Input.GetAxis("Horizontal");      // A/D ou Setas ←→

            // Calcula a direção desejada relativa à orientação da nave
            Vector3 direcao = transform.forward * frenteTras * velocidadeFrenteTras +
                              transform.right * lados * velocidadeLados;

            movimentoDesejado = direcao;
        }

        void FixedUpdate()
        {
            // Aplica o movimento de forma suave usando física
            rb.velocity = Vector3.Lerp(rb.velocity, movimentoDesejado, suavizacao * Time.fixedDeltaTime);
        }
    }


    // Update is called once per frame