using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using System.IO;
using UnityEditor;

namespace com.ksgames.core.abstractions.inventory
{
    [CreateAssetMenu(fileName = "SpriteCollection", menuName = "inventor/SpriteCollection")]
    public class SpriteCollection : ScriptableObject
    {
        public string Id;

        public List<Object> SpriteFolders;

        [Header("Use this to scan specific collections only.")]
        public List<string> CollectionFilter;

        [Header("Use this to ignore collections.")]
        public List<string> CollectionFilterIgnore;

        [Header("Body Parts")] public List<ItemSprite> Body;

        public List<ItemSprite> Head;

        public List<ItemSprite> Ears;

        public List<ItemSprite> Hair;

        public List<ItemSprite> Beard;

        public List<ItemSprite> Eyebrows;

        public List<ItemSprite> Eyes;

        public List<ItemSprite> Mouth;

        [Header("Equipment")] public List<ItemSprite> Armor;

        public List<ItemSprite> Helmet;

        public List<ItemSprite> Cape;

        public List<ItemSprite> Back;

        public List<ItemSprite> MeleeWeapon1H;

        public List<ItemSprite> MeleeWeapon2H;

        public List<ItemSprite> Bow;

        public List<ItemSprite> Firearm1H;

        public List<ItemSprite> Firearm2H;

        public List<ItemSprite> Shield;

        public List<ItemSprite> Supplies;

        [Header("Accessories")] public List<ItemSprite> Makeup;

        public List<ItemSprite> Mask;

        public List<ItemSprite> Glasses;

        public List<ItemSprite> Earrings;

        [Header("Service")] public bool DebugLogging;


        public void ClearAllSprites()
        {
            // Body Parts
            Body?.Clear();
            Head?.Clear();
            Ears?.Clear();
            Hair?.Clear();
            Beard?.Clear();
            Eyebrows?.Clear();
            Eyes?.Clear();
            Mouth?.Clear();

            // Equipment
            Armor?.Clear();
            Helmet?.Clear();
            Cape?.Clear();
            Back?.Clear();
            MeleeWeapon1H?.Clear();
            MeleeWeapon2H?.Clear();
            Bow?.Clear();
            Firearm1H?.Clear();
            Firearm2H?.Clear();
            Shield?.Clear();
            Supplies?.Clear();

            // Accessories
            Makeup?.Clear();
            Mask?.Clear();
            Glasses?.Clear();
            Earrings?.Clear();

#if UNITY_EDITOR
            if (DebugLogging)
            {
                Debug.Log($"All sprite collections cleared for {Id}");
            }

            EditorUtility.SetDirty(this);
#endif
        }

#if UNITY_EDITOR
        public void ScanSpriteFolders()
        {
            if (SpriteFolders == null || SpriteFolders.Count == 0)
            {
                if (DebugLogging)
                    Debug.LogWarning("No sprite folders specified for scanning.");
                return;
            }

            // Clear existing sprites before scanning
            ClearAllSprites();

            foreach (var folder in SpriteFolders)
            {
                if (folder == null) continue;

                var folderPath = AssetDatabase.GetAssetPath(folder);
                if (string.IsNullOrEmpty(folderPath))
                {
                    if (DebugLogging)
                        Debug.LogWarning($"Invalid folder path for: {folder.name}");
                    continue;
                }

                var pngFiles = Directory.GetFiles(folderPath, "*.png", SearchOption.AllDirectories);

                foreach (var filePath in pngFiles)
                {
                    var normalizedPath = filePath.Replace("\\", "/");
                    var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(normalizedPath);

                    if (sprite == null) continue;

                    // Determine sprite type based on folder structure
                    var spriteType = DetermineSpriteType(normalizedPath);

                    if (spriteType == null)
                    {
                        if (DebugLogging)
                            Debug.LogWarning($"Could not determine sprite type for: {normalizedPath}");
                        continue;
                    }

                    // Apply collection filters
                    if (!PassesCollectionFilter(normalizedPath)) continue;

                    // Create ItemSprite instance
                    var itemSprite = CreateItemSprite(sprite, normalizedPath, spriteType);

                    // Add to appropriate list
                    AddSpriteToCollection(itemSprite, spriteType);
                }
            }

            if (DebugLogging)
            {
                var totalSprites = GetAllSprites().Count;
                Debug.Log($"Sprite scanning completed. Total sprites loaded: {totalSprites}");
            }

            EditorUtility.SetDirty(this);
        }

        private string DetermineSpriteType(string filePath)
        {
            var pathLower = filePath.ToLowerInvariant();

            // Body Parts
            if (pathLower.Contains("/body/") || pathLower.Contains("\\body\\")) return "Body";
            if (pathLower.Contains("/head/") || pathLower.Contains("\\head\\")) return "Head";
            if (pathLower.Contains("/ears/") || pathLower.Contains("\\ears\\")) return "Ears";
            if (pathLower.Contains("/hair/") || pathLower.Contains("\\hair\\")) return "Hair";
            if (pathLower.Contains("/beard/") || pathLower.Contains("\\beard\\")) return "Beard";
            if (pathLower.Contains("/eyebrows/") || pathLower.Contains("\\eyebrows\\")) return "Eyebrows";
            if (pathLower.Contains("/eyes/") || pathLower.Contains("\\eyes\\")) return "Eyes";
            if (pathLower.Contains("/mouth/") || pathLower.Contains("\\mouth\\")) return "Mouth";

            // Equipment
            if (pathLower.Contains("/armor/") || pathLower.Contains("\\armor\\")) return "Armor";
            if (pathLower.Contains("/helmet/") || pathLower.Contains("\\helmet\\")) return "Helmet";
            if (pathLower.Contains("/cape/") || pathLower.Contains("\\cape\\")) return "Cape";
            if (pathLower.Contains("/back/") || pathLower.Contains("\\back\\")) return "Back";
            if (pathLower.Contains("/meleeweapon1h/") || pathLower.Contains("\\meleeweapon1h\\"))
                return "MeleeWeapon1H";
            if (pathLower.Contains("/meleeweapon2h/") || pathLower.Contains("\\meleeweapon2h\\"))
                return "MeleeWeapon2H";
            if (pathLower.Contains("/bow/") || pathLower.Contains("\\bow\\")) return "Bow";
            if (pathLower.Contains("/firearm1h/") || pathLower.Contains("\\firearm1h\\")) return "Firearm1H";
            if (pathLower.Contains("/firearm2h/") || pathLower.Contains("\\firearm2h\\")) return "Firearm2H";
            if (pathLower.Contains("/shield/") || pathLower.Contains("\\shield\\")) return "Shield";
            if (pathLower.Contains("/supplies/") || pathLower.Contains("\\supplies\\")) return "Supplies";

            // Accessories
            if (pathLower.Contains("/makeup/") || pathLower.Contains("\\makeup\\")) return "Makeup";
            if (pathLower.Contains("/mask/") || pathLower.Contains("\\mask\\")) return "Mask";
            if (pathLower.Contains("/glasses/") || pathLower.Contains("\\glasses\\")) return "Glasses";
            if (pathLower.Contains("/earrings/") || pathLower.Contains("\\earrings\\")) return "Earrings";

            return null;
        }

        private bool PassesCollectionFilter(string filePath)
        {
            // If we have a filter list, check if the path matches any of them
            if (CollectionFilter != null && CollectionFilter.Count > 0)
            {
                var passesFilter = CollectionFilter.Any(filter =>
                    !string.IsNullOrEmpty(filter) && filePath.ToLowerInvariant().Contains(filter.ToLowerInvariant()));

                if (!passesFilter) return false;
            }

            // If we have an ignore list, check if the path should be ignored
            if (CollectionFilterIgnore != null && CollectionFilterIgnore.Count > 0)
            {
                var shouldIgnore = CollectionFilterIgnore.Any(ignore =>
                    !string.IsNullOrEmpty(ignore) && filePath.ToLowerInvariant().Contains(ignore.ToLowerInvariant()));

                if (shouldIgnore) return false;
            }

            return true;
        }

        private ItemSprite CreateItemSprite(Sprite sprite, string filePath, string spriteType)
        {
            
            
            var itemSprites = new List<Sprite>();
    
            // Load all sprites from the texture file
            var allSprites = AssetDatabase.LoadAllAssetsAtPath(filePath).OfType<Sprite>().ToArray();
    
            if (allSprites == null || allSprites.Length == 0)
            {
                if (DebugLogging)
                    Debug.LogWarning($"No sprites found in file: {filePath}");
            }
            
            
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            itemSprites = allSprites.ToList();
            var itemSprite = new ItemSprite(spriteType, fileName,filePath,sprite,itemSprites);

            return itemSprite;
        }

        private void AddSpriteToCollection(ItemSprite itemSprite, string spriteType)
        {
            switch (spriteType)
            {
                // Body Parts
                case "Body":
                    Body ??= new List<ItemSprite>();
                    Body.Add(itemSprite);
                    break;
                case "Head":
                    Head ??= new List<ItemSprite>();
                    Head.Add(itemSprite);
                    break;
                case "Ears":
                    Ears ??= new List<ItemSprite>();
                    Ears.Add(itemSprite);
                    break;
                case "Hair":
                    Hair ??= new List<ItemSprite>();
                    Hair.Add(itemSprite);
                    break;
                case "Beard":
                    Beard ??= new List<ItemSprite>();
                    Beard.Add(itemSprite);
                    break;
                case "Eyebrows":
                    Eyebrows ??= new List<ItemSprite>();
                    Eyebrows.Add(itemSprite);
                    break;
                case "Eyes":
                    Eyes ??= new List<ItemSprite>();
                    Eyes.Add(itemSprite);
                    break;
                case "Mouth":
                    Mouth ??= new List<ItemSprite>();
                    Mouth.Add(itemSprite);
                    break;

                // Equipment
                case "Armor":
                    Armor ??= new List<ItemSprite>();
                    Armor.Add(itemSprite);
                    break;
                case "Helmet":
                    Helmet ??= new List<ItemSprite>();
                    Helmet.Add(itemSprite);
                    break;
                case "Cape":
                    Cape ??= new List<ItemSprite>();
                    Cape.Add(itemSprite);
                    break;
                case "Back":
                    Back ??= new List<ItemSprite>();
                    Back.Add(itemSprite);
                    break;
                case "MeleeWeapon1H":
                    MeleeWeapon1H ??= new List<ItemSprite>();
                    MeleeWeapon1H.Add(itemSprite);
                    break;
                case "MeleeWeapon2H":
                    MeleeWeapon2H ??= new List<ItemSprite>();
                    MeleeWeapon2H.Add(itemSprite);
                    break;
                case "Bow":
                    Bow ??= new List<ItemSprite>();
                    Bow.Add(itemSprite);
                    break;
                case "Firearm1H":
                    Firearm1H ??= new List<ItemSprite>();
                    Firearm1H.Add(itemSprite);
                    break;
                case "Firearm2H":
                    Firearm2H ??= new List<ItemSprite>();
                    Firearm2H.Add(itemSprite);
                    break;
                case "Shield":
                    Shield ??= new List<ItemSprite>();
                    Shield.Add(itemSprite);
                    break;
                case "Supplies":
                    Supplies ??= new List<ItemSprite>();
                    Supplies.Add(itemSprite);
                    break;

                // Accessories
                case "Makeup":
                    Makeup ??= new List<ItemSprite>();
                    Makeup.Add(itemSprite);
                    break;
                case "Mask":
                    Mask ??= new List<ItemSprite>();
                    Mask.Add(itemSprite);
                    break;
                case "Glasses":
                    Glasses ??= new List<ItemSprite>();
                    Glasses.Add(itemSprite);
                    break;
                case "Earrings":
                    Earrings ??= new List<ItemSprite>();
                    Earrings.Add(itemSprite);
                    break;

                default:
                    if (DebugLogging)
                        Debug.LogWarning($"Unknown sprite type: {spriteType}");
                    break;
            }
        }


        public void Refresh()
        {
            ClearAllSprites();
            ScanSpriteFolders();
            EditorUtility.SetDirty(this);
        }

#endif

        public List<ItemSprite> GetAllSprites()
        {
            return Body.Union(Head).Union(Ears).Union(Hair)
                .Union(Beard)
                .Union(Eyebrows)
                .Union(Eyes)
                .Union(Mouth)
                .Union(Armor)
                .Union(Helmet)
                .Union(Cape)
                .Union(Back)
                .Union(MeleeWeapon1H)
                .Union(MeleeWeapon2H)
                .Union(Bow)
                .Union(Firearm1H)
                .Union(Firearm2H)
                .Union(Shield)
                .Union(Supplies)
                .Union(Makeup)
                .Union(Mask)
                .Union(Glasses)
                .Union(Earrings)
                .ToList();
        }
    }
}