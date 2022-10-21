using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerRotation : MonoBehaviour
    {
        public void LookAtOnlyInYAxis(Vector3 pointToLook)
        {
            transform.LookAt(pointToLook);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}