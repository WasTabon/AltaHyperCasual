using System.Collections;
using AltaHyperCasual.Data;
using UnityEngine;

namespace AltaHyperCasual.Code.Infectable
{
    public class InfectController : MonoBehaviour, IInfectable
    {
        private Coroutine _rotateCoroutine;
        
        public void Infect()
        {
            Invoke(nameof(Destroy), Constants.TREE_FALL_DURATION);
        }

        private void Destroy()
        {
            GetComponent<Collider>().enabled = false;
            _rotateCoroutine = StartCoroutine(RotateAndDeactivate());
        }
        
        private IEnumerator RotateAndDeactivate()
        {
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(90f, startRotation.eulerAngles.y, Random.Range(0f, 360f));

            float duartion = Constants.TREE_BURN_DURATION;
            float elapsed = 0f;

            while (elapsed < duartion)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duartion;
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
                yield return null;
            }

            transform.rotation = targetRotation;
            
            Invoke(nameof(SetInactive), Constants.TREE_INACTIVE_DURATION);
        }

        private void SetInactive()
        {
            StopCoroutine(_rotateCoroutine);
            gameObject.SetActive(false);
        }
    }
}
