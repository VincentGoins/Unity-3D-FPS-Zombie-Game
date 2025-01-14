using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Unity.FPS.UI
{
public class LoadMenu : MonoBehaviour
{
    void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject
                && Input.GetButtonDown(GameConstants.k_ButtonNameSubmit))
            {
                LoadTargetScene();
            }
        }

        public void LoadTargetScene()
        {
            SceneManager.LoadScene(/*SceneName*/ "Round1");
        }
    }
}
