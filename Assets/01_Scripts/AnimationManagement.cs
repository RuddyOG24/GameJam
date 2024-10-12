using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagement : MonoBehaviour
{
    public List<Transform> imagePositions; // Lista de posiciones de las im�genes
    public float timeBetweenImages = 5f;   // Tiempo en segundos entre cada imagen

    private int currentImageIndex = 0;
    private float timer = 0f;
    private bool isTransitioning = false;

    // Este evento se dispara cuando se terminen las im�genes
    public delegate void OnAnimationEnd();
    public event OnAnimationEnd AnimationEnded;

    void Start()
    {
        // Inicializa la c�mara en la posici�n de la primera imagen
        if (imagePositions.Count > 0)
        {
            Camera.main.transform.position = imagePositions[0].position;
        }
    }

    void Update()
    {
        // Contador de tiempo para cambiar de imagen
        timer += Time.deltaTime;

        if (timer >= timeBetweenImages && !isTransitioning)
        {
            currentImageIndex++;
            if (currentImageIndex < imagePositions.Count)
            {
                StartCoroutine(TransitionToNextImage());
                timer = 0f;
            }
            else
            {
                // Si hemos llegado al final de la lista de im�genes, dispara el evento de fin de animaci�n
                if (AnimationEnded != null)
                {
                    AnimationEnded(); // Aseg�rate de invocar el evento
                }
            }
        }
    }

    // Mueve la c�mara suavemente hacia la siguiente imagen
    IEnumerator TransitionToNextImage()
    {
        isTransitioning = true;
        Vector3 targetPosition = imagePositions[currentImageIndex].position;
        float transitionDuration = 1f; // Duraci�n de la transici�n
        float elapsedTime = 0f;

        Vector3 startingPosition = Camera.main.transform.position;

        while (elapsedTime < transitionDuration)
        {
            Camera.main.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = targetPosition;
        isTransitioning = false;
    }
}
