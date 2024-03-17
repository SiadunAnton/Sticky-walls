using UnityEngine;

namespace Domain.Interactions.Triggered
{
    public class CoinCollectTrigger : ReactiveComponent
    {
        public override void OnEnter(GameObject anObject)
        {
            Collect();
            SelfDestroy();
        }

        private void Collect()
        {
            int coins = PlayerPrefs.GetInt("coins");

            PlayerPrefs.SetInt("coins", coins + 1);
        }

        private void SelfDestroy()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
