using UnityEngine;

public class DestruirAlColisionar : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Puedes agregar condiciones si quieres que se destruya solo con ciertos objetos
        // if (collision.gameObject.CompareTag("Enemigo")) { ... }

        //Destroy(gameObject);
    }
}