using UnityEngine;

namespace AlphDevCode.Tools
{
    public class SpawnBoundary
    {
        private const float ZScreenEdge = 10f;
        private const float XScreenEdge = 17f;
        private const float SafeDistance = 5f;
        private const float OffScreenDistance = 5f;

        public Vector2 GetRandomSpawnPoint()
        {
            var point = Vector2.zero;
            while (CheckIfInsideSafeArea(point))
            {
                var xPos = Random.Range(-XScreenEdge, XScreenEdge);
                var zPos = Random.Range(-ZScreenEdge, ZScreenEdge);
                point = new Vector2(xPos, zPos);
            }
            return point;
        }
        
        public bool CheckIfInsideSafeArea(Vector2 point)
        {
            Rect rect = Rect.MinMaxRect(-SafeDistance,-SafeDistance,SafeDistance,SafeDistance);
            return rect.Contains(new Vector2(point.x, point.y));
        }
    }
}