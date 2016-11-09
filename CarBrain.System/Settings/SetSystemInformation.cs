using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CarBrain.Data;
using CarBrain.System.Models;

namespace CarBrain.System.Settings
{
	public class SetSystemInformation : ISetting
	{
		public void Start ()
		{
			if (!DataBase<UserSettings>.Exsist ("CarBrain")) 
			{
				UserSettings settings = new UserSettings ();

				string pathImages = Path.Combine (Environment.CurrentDirectory, "images");

				settings.Background = File.ReadAllBytes (Path.Combine (pathImages, "background.jpg"));

				settings.Icons = new List<Icon> () {
					new Icon () {
						AppPath = "settings",
						Img = File.ReadAllBytes (Path.Combine (pathImages, "settings.png")),
						Position = new Position (1, 1),
						Text = "Настройки"
					}
				};

				DataBase<UserSettings> db = new DataBase<UserSettings> ("CarBrain", "settings");

				db.Insert (settings);
			}

			DataBase<UserSettings> _db = new DataBase<UserSettings> ("CarBrain", "settings");

			IEnumerable<UserSettings> collection = _db.Get();

			UserSettings _settings = collection.First((usrsetting) => true);

			Global.SystemInformation = new SystemInformation () {
				Screen = new Screen () {
					Background = _settings.Background,
					Icons = _settings.Icons
				}
			};

		}
		public void Kill () 
		{
			
		}
	}
}

