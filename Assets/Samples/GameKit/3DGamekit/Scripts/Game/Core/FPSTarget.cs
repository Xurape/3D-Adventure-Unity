using UnityEngine;

namespace Gamekit3D
{
    public class FPSTarget : MonoBehaviour
    {
        public int targetFPS = 120;

        void OnEnable()
        {
            SetTargetFPS(targetFPS);
        }

        public void SetTargetFPS(int fps)
        {
            Application.targetFrameRate = fps;
        }
    }    
}
