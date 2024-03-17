using System.Collections;
using UnityEngine;
using TMPro;

namespace Domain.Interactions.Active
{
    public class ElectricModificator : MonoBehaviour
    {
        [SerializeField] private int _cooldown = 4;
        [SerializeField] private GameObject _lightningDischarge;
        [SerializeField] private GameObject _fixedWall;
        [SerializeField] private TMP_Text _text;

        private void Start()
        {
            HideDischarge();

            StartCoroutine(GeneratePulseOccasionally());
        }

        public IEnumerator GeneratePulseOccasionally()
        {
            if (_cooldown <= 0)
                throw new System.ArgumentException("Cooldown must be a positive value.");

            for (; ; )
            {
                for (int i = _cooldown; i >= 0; i--)
                {
                    yield return new WaitForSeconds(1f);
                    _text.text = i.ToString();
                }
                yield return ShowPulse();
            }
        }

        protected IEnumerator ShowPulse()
        {
            if (_lightningDischarge == null)
                throw new System.NullReferenceException("Can't find a lightning discharge object.");

            ShowDischarge();

            yield return new WaitForSeconds(0.5f);

            HideDischarge();
        }

        private void ShowDischarge()
        {
            _fixedWall.SetActive(false);
            _lightningDischarge.SetActive(true);
        }

        private void HideDischarge()
        {
            _fixedWall.SetActive(true);
            _lightningDischarge.SetActive(false);
        }

        public void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}