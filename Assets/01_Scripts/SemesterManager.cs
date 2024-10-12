using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SemesterManager : MonoBehaviour
{
    public int doorNumber; // El número de la puerta (1, 2, 3, 4)
    public int requiredSemester; // El semestre requerido para abrir la puerta
    private LogicChangeScene logicChangeScene; // Referencia al script LogicChangeScene

    // Esta variable debe reflejar el semestre actual del jugador
    private int currentSemester = 1; // Esto se puede guardar en otro sistema o script

    void Start()
    {
        // Encontrar el componente LogicChangeScene en la misma escena
        logicChangeScene = FindObjectOfType<LogicChangeScene>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Verificar si el semestre del jugador es suficiente para abrir la puerta
            if (currentSemester >= requiredSemester)
            {
                // Si está habilitada, realizar el cambio de escena usando LogicChangeScene
                if (logicChangeScene != null)
                {
                    logicChangeScene.indexLevel = doorNumber; // Asignar el índice de la escena basado en la puerta
                    logicChangeScene.ChangeScene(doorNumber); // Cambiar de escena
                }
            }
            else
            {
                // Mostrar un mensaje si no cumple con el requisito
                ShowRestrictionMessage();
            }
        }
    }

    private void ShowRestrictionMessage()
    {
        // Aquí puedes mostrar un mensaje en la pantalla usando el sistema de UI de Unity
        Debug.Log("Requisito: Semestre Anterior Completado");
        // Puedes reemplazar Debug.Log con un sistema de UI que muestre este mensaje.
    }
}
