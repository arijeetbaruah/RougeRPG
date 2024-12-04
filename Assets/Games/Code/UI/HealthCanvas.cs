using UnityEngine;
using UnityEngine.UI;

namespace RougeRPG
{
    public class HealthCanvas : MonoBehaviour
    {
        [SerializeField] protected Image healthBar;

        public void SetHeathBar(Health character, float damage)
        {
            float val = (float)character.CurrentHealth/(float)character.MaxHealth;
            healthBar.fillAmount = val;
        }
    }
}
