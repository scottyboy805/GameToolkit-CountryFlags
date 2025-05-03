using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameToolkit.CountryFlags
{
    [Serializable]
    public class CountryFlagsMetadata
    {
        // Type
        [Serializable]
        public struct CountryFlagEntry
        {
            // Internal
            [SerializeField]
            internal string code;
            [SerializeField]
            internal string name;
            [SerializeField]
            internal string nameRU;
            [SerializeField]
            internal Sprite flag;

            // Properties
            public string Code => code;
            public string Name => name;
            public string NameRU => nameRU;
            public Sprite Flag => flag;
        }

        // Private
        [SerializeField]
        private List<CountryFlagEntry> Items = new();

        // Properties
        public IReadOnlyList<CountryFlagEntry> CountryFlags => Items;

        // Methods
        internal void UpdateMetadata()
        {
            for (int i = 0; i < CountryFlags.Count; i++)
            {
                CountryFlagEntry item = Items[i];

                // Update the metadata
                item.code = item.code.ToLower();
                Items[i] = item;
            }
        }

        internal void UpdateSprites(Sprite[] flagSprites)
        {
            if (flagSprites.Length != Items.Count)
                throw new Exception("Flag sprites are not compatible with the associated metadata! Ensure that the same number of flag sprites are provided and that the order matches the metadata order");

            for(int i = 0; i < Items.Count; i++) 
            {
                CountryFlagEntry item = Items[i];

                // Update the sprite
                item.flag = flagSprites[i];
                Items[i] = item;
            }
        }

        public static CountryFlagsMetadata ParseJson(string flagsJson)
        {
            // Deserialize the json
            return JsonUtility.FromJson<CountryFlagsMetadata>(flagsJson);
        }
    }
}
