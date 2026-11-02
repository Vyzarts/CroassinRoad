using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configuración del Personaje")]
    public float fuerzaSaltoY = 30f;
    public float fuerzaSaltoXZ = 50f;
    public float Gravedad = 1f;


    private Rigidbody rb;

    void Start()
    {
        // Enlaza la variable 'rb' con la pieza física de Unity
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        //detectar el suelo
        bool TocarPiso = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        

        //DETECTAR EL SALTO Y EL SUELO 
        if (Input.GetKeyDown(KeyCode.A) && TocarPiso) 
        {
            SaltoIZQ();
            RotIZQ();
        } else if (Input.GetKeyDown(KeyCode.D) && TocarPiso) 
        {
            SaltoDER();
            RotDER();
        } else if (Input.GetKeyDown(KeyCode.W) && TocarPiso) 
        {
            SaltoENF();
            RotENF();
        } else if (Input.GetKeyDown(KeyCode.S) && TocarPiso) 
        {
            SaltoATR();
            RotATR();
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * Gravedad);
    }

    private void RotIZQ(){
        //grados
        Vector3 RotIZQu = new Vector3(0f, -90f, 0f);
        //confertidor de grador a quaternion
        transform.rotation = Quaternion.Euler(RotIZQu);
    }

        private void RotDER(){
        //grados
        Vector3 RotDERe = new Vector3(0f, 90f, 0f);
        //confertidor de grador a quaternion
        transform.rotation = Quaternion.Euler(RotDERe);
    }
        private void RotATR(){
        //grados
        Vector3 RotATRAS = new Vector3(0f, 180f, 0f);
        //confertidor de grador a quaternion
        transform.rotation = Quaternion.Euler(RotATRAS);
    }
        private void RotENF(){
        //grados
        Vector3 RotENFr = new Vector3(0f, 0f, 0f);
        //confertidor de grador a quaternion
        transform.rotation = Quaternion.Euler(RotENFr);
    }
    // Usar métodos separados mantiene el código limpio (Principio de Responsabilidad Única)
    private void SaltoIZQ()
    {
        // Reseteamos la velocidad Y a 0 antes de saltar para que el salto sea siempre igual
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        Vector3 SaltoIZQ = new Vector3(fuerzaSaltoXZ, fuerzaSaltoY, 0f);
        // Aplicamos la fuerza de impulso hacia arriba
        rb.AddForce(SaltoIZQ, ForceMode.Impulse);
    }

    private void SaltoDER()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        Vector3 SaltoDER = new Vector3(fuerzaSaltoXZ * -1 ,fuerzaSaltoY, 0f);
        rb.AddForce(SaltoDER, ForceMode.Impulse);
    }
    private void SaltoENF()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        Vector3 SaltoENF = new Vector3(0f ,fuerzaSaltoY, fuerzaSaltoXZ * -1);
        rb.AddForce(SaltoENF, ForceMode.Impulse);
    }
    private void SaltoATR()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        Vector3 SaltoATR = new Vector3(0f ,fuerzaSaltoY, fuerzaSaltoXZ);
        rb.AddForce(SaltoATR, ForceMode.Impulse);
    }

 
}

