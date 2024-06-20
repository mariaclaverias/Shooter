using UnityEngine;

public class ConsoleCheck : MonoBehaviour
{
    void Start()
    {
        CheckConsoleType();
    }

    void CheckConsoleType()
    {
#if UNITY_EDITOR
        // Verificar en el editor de Unity
        UnityEditor.BuildTarget buildTarget = UnityEditor.EditorUserBuildSettings.activeBuildTarget;
        if (buildTarget == UnityEditor.BuildTarget.XboxOne)
        {
            Debug.Log("El juego est� corriendo en una consola Xbox (en el editor de Unity).");
        }
        else if (buildTarget == UnityEditor.BuildTarget.StandaloneWindows ||
                 buildTarget == UnityEditor.BuildTarget.StandaloneWindows64)
        {
            Debug.Log("El juego est� corriendo en PC (en el editor de Unity).");
        }
        else
        {
            Debug.Log("El juego est� corriendo en otra plataforma (en el editor de Unity).");
        }
#else
        // Verificar en tiempo de ejecuci�n
        if (Application.platform == RuntimePlatform.XboxOne)
        {
            Debug.Log("El juego est� corriendo en una consola Xbox.");
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || 
                 Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("El juego est� corriendo en PC.");
        }
        else
        {
            Debug.Log("El juego est� corriendo en otra plataforma.");
        }
#endif
    }
}
