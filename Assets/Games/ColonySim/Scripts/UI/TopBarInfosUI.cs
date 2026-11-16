using TMPro;
using UnityEngine;

namespace CS
{
    public class TopBarInfos : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyValueText;
        
        private void Start()
        {
            _currencyValueText.text = "0";
        }
        
        public void SetCurrencyValue(string currencyValue)
        {
            _currencyValueText.text = currencyValue;
        }
    }
}
