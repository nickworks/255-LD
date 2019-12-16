using System.Collections;
using UnityEngine;

namespace Powers
{
    public class CantUseObjectNotify : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(ShowMessage());
        }

        //show message for 3 seconds, and then disable.
        private IEnumerator ShowMessage()
        {
            yield return new WaitForSeconds(3);

            gameObject.SetActive(false);
        }
    }
}

