using AlphDevCode.Managers;
using UnityEngine;

namespace AlphDevCode.UI
{
    public class UIInput : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                gameManager.RetryGame();
            }
        }
    }
}
