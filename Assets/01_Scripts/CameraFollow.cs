using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El transform del jugador
    public Vector2 minBounds; // Coordenadas m�nimas de los l�mites de la c�mara
    public Vector2 maxBounds; // Coordenadas m�ximas de los l�mites de la c�mara
    public float smoothTime = 0.2f; // Tiempo de suavizado para el movimiento de la c�mara

    private Vector3 velocity = Vector3.zero; // Para el movimiento suavizado

    void Start()
    {

    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Posici�n objetivo basada en la posici�n del jugador
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            // Suaviza el movimiento de la c�mara
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Limita la c�mara dentro de los l�mites establecidos
            float clampedX = Mathf.Clamp(smoothPosition.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(smoothPosition.y, minBounds.y, maxBounds.y);

            // Actualiza la posici�n de la c�mara
            transform.position = new Vector3(clampedX, clampedY, smoothPosition.z);
        }
    }
}
