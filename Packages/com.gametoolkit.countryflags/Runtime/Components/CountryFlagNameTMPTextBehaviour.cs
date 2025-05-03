using TMPro;
using UnityEngine;

namespace GameToolkit.CountryFlags
{
    [AddComponentMenu(ComponentMenuRoot + "Country Flag Text")]
    public class CountryFlagNameTMPTextBehaviour : CountryFlagBehaviour
    {
        // Private
        [SerializeField]
        private TMP_Text textMeshPro;

        // Methods
        public override void UpdateCountryCode(string countryFlagCode)
        {
            // Check for null
            if (textMeshPro == null || Asset == null)
                return;

            // Update name
            textMeshPro.text = Asset.GetCountryFlagName(countryFlagCode);
        }

        protected override void Reset()
        {
            // Get tmp
            textMeshPro = GetComponent<TMP_Text>();

            base.Reset();
        }
    }
}
