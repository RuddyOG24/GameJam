using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AnimationManagement;

public class LogicChangeScene : MonoBehaviour
{
    public bool passLevel;
    public int indexLevel;
    private AnimationManagement animationManager;

    void Start()
    {
        // Encontrar el componente AnimationManagement en la misma escena
        animationManager = FindObjectOfType<AnimationManagement>();

        if (animationManager != null)
        {
            // Suscribirse al evento de fin de animaci�n
            animationManager.AnimationEnded += OnAnimationEnd;
        }
    }
    // Este m�todo se llama cuando la animaci�n de im�genes ha terminado
    void OnAnimationEnd()
    {
        ChangeScene(indexLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    void OnDestroy()
    {
        if (animationManager != null)
        {
            // Desuscribirse del evento al destruir este objeto
            animationManager.AnimationEnded -= OnAnimationEnd;
        }
    }
}
