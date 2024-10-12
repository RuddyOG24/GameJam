using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El transform del jugador
    public Vector2 minBounds; // Coordenadas mínimas de los límites de la cámara
    public Vector2 maxBounds; // Coordenadas máximas de los límites de la cámara
    public float smoothTime = 0.2f; // Tiempo de suavizado para el movimiento de la cámara

    private Vector3 velocity = Vector3.zero; // Para el movimiento suavizado

    void Start()
    {

    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Posición objetivo basada en la posición del jugador
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            // Suaviza el movimiento de la cámara
            Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Limita la cámara dentro de los límites establecidos
            float clampedX = Mathf.Clamp(smoothPosition.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(smoothPosition.y, minBounds.y, maxBounds.y);

            // Actualiza la posición de la cámara
            transform.position = new Vector3(clampedX, clampedY, smoothPosition.z);
        }
    }
}
