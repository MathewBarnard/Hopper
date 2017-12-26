using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Assets.Source.Overworld.Map;
using Assets.Source.Overworld.Map.MapEditor;

public class HexGridGenerator : MonoBehaviour {

    public static void GenerateFromFile(HexGrid grid, string filename) {

        List<HexMapCsv> file = HexMapFileSaver.ReadFile(filename);

        // Create a throwaway tile so that we can get the dimensions of it.
        Vector2 spriteSize = GetTileSize();

        foreach (HexMapCsv row in file) {

            int x = row.X;
            int z = row.Z;

            float mod = z % 2;

            Vector2 position = new Vector2((x * spriteSize.x) + ((spriteSize.x * 0.5f) * mod), (z * spriteSize.y) * 0.75f);

            grid.Tiles.Add(HexTile.Create(grid, row.TileType, position, new Vector2(x, z)));
        }
    }

    public static void GenerateDefault(HexGrid grid, int width, int height) {

        // Create a throwaway tile so that we can get the dimensions of it.
        Vector2 spriteSize = GetTileSize();

        // Z
        for (int z = 0; z < width; z++) {

            // X
            for (int x = 0; x < height; x++) {

                float mod = z % 2;

                Vector2 position = new Vector2((x * spriteSize.x) + ((spriteSize.x * 0.5f) * mod), (z * spriteSize.y) * 0.75f);

                grid.Tiles.Add(HexTile.Create(grid, TileType.BaseTile, position, new Vector2(x, z)));
            }
        }
    }

    private static Vector2 GetTileSize() {
        // Create a throwaway tile so that we can get the dimensions of it.
        GameObject tile = Instantiate((GameObject)Resources.Load("Prefabs/Overworld/BaseTile"), Vector2.zero, Quaternion.identity);
        SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
        Vector2 spriteSize = renderer.sprite.bounds.size;
        Vector2 scale = tile.transform.localScale;
        Destroy(tile);
        return new Vector2(spriteSize.x * scale.x, spriteSize.y * scale.y);
    }

}