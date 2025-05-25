using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDelAvion : MonoBehaviour
{
    public float velocidadActual = 20f;
    public float velocidadMinima = 20f;
    public float aceleracion = 30f;
    public float desaceleracion = 20f;

    public float sensibilidadBase = 2f; // sensibilidad reducida para mouse
    public float suavizado = 7f;
    public float maxRollAngle = 60f;
    public float rollSuavizado = 0.9f;

    // Control de marchas
    private int marchaActual = 1;
    private int marchasMaximas = 4;
    private float[] velocidadPorMarcha = { 30f, 60f, 90f, 120f };

    private Vector2 rotacionMouse;
    private Vector2 rotacionActual;
    private float rollActual = 0f;

    // Rotación por teclado
    public float rotacionTeclaGradosPorSegundo = 15f; // más alto que mouse

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        float velocidadMaximaActual = velocidadPorMarcha[marchaActual - 1];

        // Aceleración/desaceleración
        if (Input.GetKey(KeyCode.W))
        {
            velocidadActual += aceleracion * Time.deltaTime;
        }
        
        else
        {
            velocidadActual -= desaceleracion * Time.deltaTime;
        }

        velocidadActual = Mathf.Clamp(velocidadActual, velocidadMinima, velocidadMaximaActual);
        transform.position += transform.forward * velocidadActual * Time.deltaTime;

        // Marchas
        if (Input.GetKeyDown(KeyCode.Q) && marchaActual < marchasMaximas)
        {
            marchaActual++;
        }
        if (Input.GetKeyDown(KeyCode.E) && marchaActual > 1)
        {
            marchaActual--;
        }

        // ⇨ Movimiento de mouse
        float sensibilidadVelocidad = Mathf.Lerp(sensibilidadBase, sensibilidadBase * 0.2f, velocidadActual /120f);
        
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadVelocidad;

        
        rotacionMouse.y -= mouseY;
        rotacionMouse.y = Mathf.Clamp(rotacionMouse.y, -80f, 80f);

        // ⇨ Movimiento por teclas (más fuerte que mouse)
        if (Input.GetKey(KeyCode.D))
        {
            rotacionMouse.x += rotacionTeclaGradosPorSegundo * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotacionMouse.x -= rotacionTeclaGradosPorSegundo * Time.deltaTime;
        }

        // Lerp para suavizado
        rotacionActual = Vector2.Lerp(rotacionActual, rotacionMouse, Time.deltaTime * suavizado);

        // Roll automático
        float objetivoRoll = Mathf.Clamp(-((Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0)) * maxRollAngle, -maxRollAngle, maxRollAngle);
        rollActual = Mathf.Lerp(rollActual, objetivoRoll, Time.deltaTime * rollSuavizado);

        // Aplicar rotación
        transform.rotation = Quaternion.Euler(rotacionActual.y, rotacionActual.x, rollActual);
    }


}
