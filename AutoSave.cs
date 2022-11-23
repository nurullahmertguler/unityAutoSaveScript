#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
[ExecuteInEditMode]
public class AutoSave : MonoBehaviour
{

    // Static constructor that gets called when unity fires up.
    static AutoSave()
    {

        EditorApplication.playModeStateChanged += (PlayModeStateChange state) => {
            // If we're about to run the scene...
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
            {
                // Save the scene and the assets.
                Debug.Log("Auto-saving all open scenes... " + state);
                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
        };
    }

    public float saveTimeMin=5;
    float time;
    private void Update()
    {
        time += Time.deltaTime;

        if (time > saveTimeMin * 60 && EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
        {
            Debug.Log("Auto-saving all open scenes... ");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();

            time = 0;
        }
    }

}

#endif

