using UnityEngine;
using UnityEngine.UI;

namespace GameToolkit.CountryFlags
{
    [AddComponentMenu(ComponentMenuRoot + "Country Flag Image")]
    public class CountryFlagImageBehaviour : CountryFlagBehaviour
    {
        // Private
        [SerializeField]
        private Image image;

        // Methods
        public override void UpdateCountryCode(string countryFlagCode)
        {
            // Check for null
            if (image == null || Asset == null)
                return;

            // Get the flag sprite
            image.sprite = Asset.GetCountryFlagCode(countryFlagCode);
        }

        protected override void Reset()
        {
            // Get image
            image = GetComponent<Image>();

            base.Reset();
        }
    }
}
