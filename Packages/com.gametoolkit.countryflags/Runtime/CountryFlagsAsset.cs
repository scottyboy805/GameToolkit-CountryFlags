using System;
using System.Linq;
using UnityEngine;

namespace GameToolkit.CountryFlags
{
    [CreateAssetMenu]
    public sealed class CountryFlagsAsset : ScriptableObject
    {
        // Private
        [SerializeField]
        private TextAsset jsonMetadata;
        [SerializeField]
        private Sprite[] flagSprites;
        [SerializeField]
        private CountryFlagsMetadata metadata = new();

        // Methods
        public Sprite GetCountryFlagCode(string countryCode)
        {
            // Check for invalid
            if (string.IsNullOrEmpty(countryCode) == true)
                return null;

            // Get as lower
            countryCode = countryCode.ToLower();

            // Select code
            return metadata.CountryFlags
                .Where(f => f.code == countryCode)
                .Select(f => f.flag)
                .FirstOrDefault();
        }

        public string GetCountryFlagName(string countryCode)
        {
            // Check for invalid
            if (string.IsNullOrEmpty(countryCode) == true)
                return null;

            // Get as lower
            countryCode = countryCode.ToLower();

            // Select name
            return metadata.CountryFlags
                .Where(f => f.code == countryCode)
                .Select(f => f.name)
                .FirstOrDefault();
        }

#if UNITY_EDITOR
        [ContextMenu("Load From Metadata")]
        internal void LoadFromMetadata()
        {
            // Check for no file
            if (jsonMetadata == null)
                throw new Exception("Json metadata is missing!");

            // Check for flags sprites
            if (flagSprites == null || flagSprites.Length == 0)
                throw new Exception("Flag sprites are missing!");

            // Parse the metadata
            metadata = CountryFlagsMetadata.ParseJson(jsonMetadata.text);

            // Update metadata
            metadata.UpdateMetadata();

            // Update sprites
            metadata.UpdateSprites(flagSprites);
        }
#endif
    }
}
