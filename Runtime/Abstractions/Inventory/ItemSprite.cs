using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.ksgames.core.abstractions.inventory
{

	[Serializable]
	public class ItemSprite
	{
		public string Name;

		// public string Collection;

		// public string Edition;

		public string Id;

		public string Path;

		public Sprite Sprite;

		public List<Sprite> Sprites;

		public bool Multiple;

		public string Hash;

		public List<string> Tags = new List<string>();

		public ItemSprite(string type, string name, string path, Sprite sprite,
			List<Sprite> sprites)
		{
			
			Id = "id"+"."+ type +"." + name;
			if (sprites == null || sprites.Count == 0)
			{
				throw new Exception("No sprites found");
			}

			Name = name;
			// Collection = collection;
			// Edition = edition;
			Path = path;
			Sprite = sprite;
			Sprites = sprites.OrderBy(x => x.name).ToList();
			Multiple = true;
			Hash = ((object)((Texture)sprite.texture).imageContentsHash /*cast due to .constrained prefix*/).ToString();
		}

		public Sprite GetSprite(string name)
		{
			return Sprites.Single(x => x.name == name);
		}
	}
}
