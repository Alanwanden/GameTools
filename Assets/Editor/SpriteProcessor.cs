using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class SpriteProcessor : AssetPostprocessor
{
    private void OnPostprocessTexture(Texture2D texture)
    {
        string lowerCaseAssetPath = assetPath.ToLower();
        bool is›nSpritesDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;
        if (is›nSpritesDirectory)
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
        }
    }
}
