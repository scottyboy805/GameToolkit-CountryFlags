using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameToolkit.CountryFlags
{
    public abstract class CountryFlagBehaviour : MonoBehaviour
    {
        // Protected
        protected const string ComponentMenuRoot = "Country Flags/";

        // Private
        [SerializeField]
        private CountryFlagsAsset countryFlagsAsset;
        [SerializeField]
        private string defaultCounterFlagCode = "gb";

        // Properties
        public CountryFlagsAsset Asset => countryFlagsAsset;

        // Methods
        public abstract void UpdateCountryCode(string countryFlagCode);

        public void UpdateDefaultCountryCode()
        {            
            if (string.IsNullOrEmpty(defaultCounterFlagCode) == false)
                UpdateCountryCode(defaultCounterFlagCode);
        }

        protected virtual void Start()
        {
            UpdateDefaultCountryCode();
        }

        protected virtual void Reset()
        {
#if UNITY_EDITOR
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(CountryFlagsAsset).FullName);

            // Check for any
            if(guids.Length > 0)
            {
                // Get the path
                string path = AssetDatabase.GUIDToAssetPath(guids[0]);

                // Load the asset
                countryFlagsAsset = AssetDatabase.LoadAssetAtPath<CountryFlagsAsset>(path);

                // Mark as dirty
                EditorUtility.SetDirty(countryFlagsAsset);
            }
#endif

            // Update default
            UpdateDefaultCountryCode();
        }
    }
}
