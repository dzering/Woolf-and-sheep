using UnityEngine;

namespace SheepsWolf
{
    public class CameraController
    {
        private Transform target;
        private Camera camera;

        private int interpolationFrameCount = 45;
        private float lineFrame = 0;

        private Vector3 offset;

        public CameraController(Transform target)
        {
            this.target = target;
            camera = Camera.main;
            offset = camera.transform.position - target.position;
        }

        public void Update()
        {
            float interpolationRatio = (float)lineFrame / interpolationFrameCount;
            camera.transform.position = Vector3.Lerp(camera.transform.position, target.position + offset, Time.deltaTime);
            
            lineFrame = Time.deltaTime ;
        }
    }
}
