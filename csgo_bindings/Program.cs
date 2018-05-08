using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgo_bindings
{
     class Program
     {
		  static string app_name = "csgo bindings";
		  static string app_version = "0.1 alpha";
		  static string init_cfg = "init.cfg";
		  static string config_cfg = "config.cfg";
		  static string default_ini = "default.ini";
		  static string db_ini = "db.ini";
		  static string _backup = ".backup";
		  static string csgo_path;
		  static string profile_path;
		  static string current_profile;
		  static Dictionary<string, string> db_keys;

		  static void Main(string[] args)
          {
               /*
					create "init.cfg" to initialize this app's commands
               */
               

			   Console.WriteLine("Welcome to the cs:go cfg editor!");
			   Console.WriteLine("The following commands are available: ");

			   /* PROFILE PART */
					Console.WriteLine("profile list");
					Console.WriteLine("lists all profiles.");
					Console.WriteLine("example: profile list");
					Console.WriteLine("now you can see all the profiles. Note: located in: <this app's folder>/profiles.\n\n");

					Console.WriteLine("profile create <profile name>");
					Console.WriteLine("creates a profile.");
					Console.WriteLine("example: profile create ninja_smurf");
					Console.WriteLine("now the profile has been saved to the database.\n\n");

					Console.WriteLine("profile load <profile name>");
					Console.WriteLine("loads in the specified profile with all the settings.");
					Console.WriteLine("example: profile load ninja_smurf");
					Console.WriteLine("now all the settings that belongs to that profile are loaded.\n\n");

					Console.WriteLine("profile save");
					Console.WriteLine("saves the profile.");
					Console.WriteLine("example: profile save");
					Console.WriteLine("as that simple. although the application saves automatically, you can trigger the save function with this command.\n\n");

					Console.WriteLine("profile delete <profile name>");
					Console.WriteLine("deletes the specified profile.");
					Console.WriteLine("example: profile delete ninja_smurf");
					Console.WriteLine("now the specified profile has beed deleted. Note: all settings to that profile are going to be destroyed.\n\n");
			   /* PROFILE PART END */



			   /* BINDINGS AND MAIN FUNCTIONALITY */
					/*Console.WriteLine("make");
					Console.WriteLine("creates the cfg-s to the folder");
					Console.WriteLine(@"example: make");
					Console.WriteLine("as that simple. Note: this app won't put any cfg-s to the destination folder, unless you trigger it, with this command.\n\n");*/

					Console.WriteLine("set path <your cs:go profile>");
					Console.WriteLine("sets the path to the cfg-s.");
					Console.WriteLine(@"Example: set path c:\Program Files (x86)\Steam\userdata\<steamid>\730\local\cfg\");
					Console.WriteLine("now the path has been set to that location. you only have to set this only once for a certain profile.\n\n");

					Console.WriteLine("bind override <old key>, <new key>");
					Console.WriteLine("replaces the old key to the new one.");
					Console.WriteLine("example: bind override f, e");
					Console.WriteLine("now all keys 'f' in the directory that has the extension '.cfg' has been reconfigured to 'e'. Note: you can set the destination folder with the command 'set path'.\n\n");

					Console.WriteLine("db new <key>, <description>");
					Console.WriteLine("creates a description to a key, so you can keep track of your current settings.");
					Console.WriteLine("example: db new f, Használ gomb");
					Console.WriteLine("now you have a key in the database with description: Használ gomb.\n\n");

					Console.WriteLine("db edit <key>, <description>");
					Console.WriteLine("edits a key's description.");
					Console.WriteLine("example: db edit f, Nézegeti a szép kését");
					Console.WriteLine("now you have edited the key's description to: Nézegeti a szép kését.\n\n");

					Console.WriteLine("db del <key>");
					Console.WriteLine("deletes a description with the key from the database.");
					Console.WriteLine("example: db del f");
					Console.WriteLine("now key 'f' doesn't exist in the key database.\n\n");

					Console.WriteLine("buy");
					Console.WriteLine("calls the buy function");
					Console.WriteLine("example: buy");
					Console.WriteLine("here you can set a key to buy certain stuffs.\n\n");

					Console.WriteLine("cross");
					Console.WriteLine("triggers the crosshair creator function.");
					Console.WriteLine("example: cross");
					Console.WriteLine("now you just have to give all the values you want.\n\n");

					Console.WriteLine("alias <alias name>, <command(s)>");
					Console.WriteLine("sets an alias with the specified command(s).");
					Console.WriteLine("example: alias afk, normalsound; +back; +left");
					Console.WriteLine("now you have an alias 'afk' with commands 'normalsound; +back; +left'.\n Note: you have to add a semicolon after every single specified command and a space for the following command.\n\n");

			   /* BINDINGS AND MAIN FUNCTIONALITY END */


			   /* OTHER BINDINGS */
					Console.WriteLine("set fps <number>");
					Console.WriteLine("sets the value of the fps limiter.");
					Console.WriteLine("example: fps");
					Console.WriteLine("now you just have to give all the values you want.\n\n");

					Console.WriteLine("bind net <key>");
					Console.WriteLine("sets the net graph and fps to the specified key, so you can see your ping and fps and other stuff.");
					Console.WriteLine("example: net f11");
					Console.WriteLine("now you can see on the bottom right corner your fps and ping and other stuff.\n\n");

					Console.WriteLine("bind defuse <key>");
					Console.WriteLine("sets the specified key, so when you use that key, the defusing proccess going to be automated.\n Note: you have to start defusing and while you do that, use the specific key so the proccess can continue. Also, you can't look around, so you have to re-use this key combination.");
					Console.WriteLine("example: defuse +attack2");
					Console.WriteLine("now you can defuse with the right click easily.\n\n");

					Console.WriteLine("bind stay <key>");
					Console.WriteLine("says in the radio to stay in the position. can be useful if you have a bot. Note: doesn't work with russians.");
					Console.WriteLine("example: stay alt+1");
					Console.WriteLine("now your bots will stay in position. or not. they are assholes. Note: complex bindings' components require to be set in the key database or the components could be overwritten. \nExample: you want to bind alt+1 and you have a bind on key '1'. if it is not set in the key database, then it will malfunction. same with alt.\n\n");

					Console.WriteLine("bind sound <key>");
					Console.WriteLine("sets the sound control to the specified key, so you can change the volume with the key + the scrollwheels. awesome.");
					Console.WriteLine("example: sound n");
					Console.WriteLine("now you can set the game's sound in the game by using the n+scroll_up and n+scroll_down.\n Note: this also sets the caster volume.\n\n");
			   /* OTHER BINDINGS END */
			   /* Console.WriteLine("radio <key>");
				Console.WriteLine("sets the voice chat's volume to the specified key, so you can change the volume with the key + the scrollwheels. awesome");
				Console.WriteLine("example: sound n");
				Console.WriteLine("now you can set the game's sound in the game by using the n+scroll_up and n+scroll_down.\n");
				*/


			   /* MISC */
					Console.WriteLine("--other commands (aliases) to make gaming more comfortable:--");

					Console.WriteLine("editviewmodel");
					Console.WriteLine("model view can be edited quickly. instructions can be found there.\n\n");

					Console.WriteLine("init");
					Console.WriteLine("loads the entire config set by this app.\n\n");

					Console.WriteLine("sa");
					Console.WriteLine("saves an reloads the configs.\n\n");

					Console.WriteLine("killchat");
					Console.WriteLine("disables chat.\n\n");

					Console.WriteLine("test");
					Console.WriteLine("loads in a test enviroment.\n\n");

					Console.WriteLine("surf");
					Console.WriteLine("loads in a surf enviroment.\n\n");

					Console.WriteLine("afk");
					Console.WriteLine("keeps you spinnin'.\n\n");

					Console.WriteLine("re");
					Console.WriteLine("stops you spinnin'.\n\n");

					Console.WriteLine("music commands: flamenco, opera, melody, techno");
					Console.WriteLine("so you can choose the right song to your rush B rounds.\n\n");
			   /* MISC END */

			   /* Blah-BLah */
					Console.WriteLine("\n\n--Credits and other stuff--\n");
					Console.WriteLine("Created by: Kukac\n");
					Console.WriteLine("this app comes absolutely with no warranty. if it formats your computer and sets it on fire, then it's your problem.\n\nHuge thanks to Ninja, for most of the cfg scripts.\n");
			   /* Blah-BLah END */


			    /* string[] files = Directory.GetFiles(@"c:\Program Files (x86)\Steam\userdata\67629867\730\local\cfg\", "*.cfg");
			  foreach (string file in files)
				{
					 string alltext = System.IO.File.ReadAllText(file);

					 string betu = "lala";
					 alltext.Replace("bind s", "bind " + betu);
				}*/



			   while (true)
               {
					/*Set Prompt*/
					if (current_profile == default(string)) //if string is null
					{
						 Console.WriteLine(current_profile + "@" + app_name + "> ");
					}
					else
					{
						 Console.WriteLine(app_name + "> ");
					}


					string read_line = Console.ReadLine();
					string[] cmd_split = read_line.Split(' ');

					switch(cmd_split[0]) //get first command
					{
						 case "profile":
							  {
								   profile(cmd_split);
								   break;
							  }

						 case "set":
							  {
								   set(cmd_split);
								   break;
							  }

						 case "bind":
							  {
								   if (!(current_profile == default(string)))
								   {
										bind(cmd_split);
								   }
								   else
								   {
										Console.WriteLine("Error: you didn't load in a profile");
								   }
								   break;
							  }

						 case "db":
							  {
								   if (!(current_profile == default(string)))
								   {
										db(cmd_split);
								   }
								   else
								   {
										Console.WriteLine("Error: you didn't load in a profile");
								   }
								   break;
							  }

						 case "buy":
							  {
								   if (!(current_profile == default(string)))
								   {
										buy(cmd_split);
								   }
								   else
								   {
										Console.WriteLine("Error: you didn't load in a profile");
								   }
								   break;
							  }


						 case "cross":
							  {
								   if (!(current_profile == default(string)))
								   {
										cross(cmd_split);
								   }
								   else
								   {
										Console.WriteLine("Error: you didn't load in a profile");
								   }
								   break;
							  }


						 case "alias":
							  {
								   if (!(current_profile == default(string)))
								   {
										alias(cmd_split);
								   }
								   else
								   {
										Console.WriteLine("Error: you didn't load in a profile");
								   }
								   break;
							  }


						 default:
							  {
								   Console.WriteLine("you have entered a wrong command. please try again.");
								   break;
							  }
					}
			   }
          }

		  static void profile(string[] command)
		  {
			   switch(command[1])
			   {
					/*Profil listázó parancs*/
					case "list":
						 {
							  /*Get all directory that contains default.ini and add it to "existing_profiles" list*/
							  string[] profiles = Directory.GetDirectories("\\profiles\\");
							  List<string> existing_profiles = new List<string>();
							  foreach(string profile in profiles)
							  {
								   if (File.Exists("\\profiles\\" + profile + "\\" + default_ini))
								   {
										existing_profiles.Add(profile);
								   }
							  }

							  /*Cout all existing profiles*/
							  Console.WriteLine("Existing profiles:");
							  foreach(string existing_profile in existing_profiles)
							  {
								   Console.WriteLine("\t" + existing_profile);
							  }
							  Console.WriteLine("\n");

							  break;
						 }

						 /*Profil készítő parancs*/
					case "create":
						 {
							  bool create_it = false;
							  string profilename = command[2];
							  if (Directory.Exists(@"\profiles\" + profilename + @"\")) //if theres a profile folder
							  {
								   if (File.Exists(@"\profiles\" + profilename + @"\" + default_ini)) //and it contains the default.ini file
								   {
										Console.WriteLine("this profile already exist."); //then the profile (probably) exists
								   }
								   else
								   {
										create_it = true;
								   }
							  }
							  else
							  {
								   try
								   {
										Directory.CreateDirectory(@"\profiles\" + profilename + @"\");
								   }
								   catch (Exception e)
								   {
										Console.WriteLine(e);
										break;
								   }
								   create_it = true; //amúgy igen
							  }

							  if(create_it) /*Initiate profile to deafult*/
							  {
								   File.Create(@"\profiles\" + profilename + @"\" + default_ini);
								   using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + profilename + @"\" + default_ini))
								   {
										file.WriteLine(profilename);
								   }

								   File.Copy(csgo_path + @"\" + config_cfg, @"\profiles\" + profilename);
								   using (System.IO.StreamWriter file = File.AppendText(@"\profiles\" + profilename + @"\" + config_cfg))
								   {
										file.WriteLine("exec \"init\"");
								   }

								   File.Create(@"\profiles\" + profilename + @"\" + init_cfg);
								   using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + profilename + @"\" + init_cfg))
								   {
										file.WriteLine("//generated by " + app_name + " v. " + app_version);
										file.WriteLine("//Note: don't use double enters in the config file otherwise it won't work");
										file.WriteLine("//ALIASES");
										file.WriteLine("alias wc \"host_writeconfig config\"");
										file.WriteLine("alias killchat \"toggle tv_nochat\"");
										file.WriteLine("alias test \"mp_roundtime 60; mp_roundtime_defuse 60; mp_roundtime_hostage 60; mp_warmuptime 999999999999; mp_restartgame 1; sv_cheats 1; sv_grenade_trajectory 1; sv_infinite_ammo 2\"");
										file.WriteLine("alias surf \"sv_accelerate 10; sv_airaccelerate 800; cl_showpos 1\"");
										file.WriteLine("alias afk \"normalsound; +back; +left\"");
										file.WriteLine("alias re \"normalsound; -back; -left\"");
										file.WriteLine("alias viewmodel \"exec editviewmodel\"");
										file.WriteLine("alias +dev \"developer 1\"");
										file.WriteLine("alias -dev \"developer 0\"");
										file.WriteLine("alias wc \"host_writeconfig config\"");
										file.WriteLine("alias ae \"exec init\"");
										file.WriteLine("alias sa \"wc; ae;\"");
										file.WriteLine("alias dc \"disconnect\"");

										file.WriteLine("//MUSIC");
										file.WriteLine("alias flamenco \"play \\ambient\\flamenco.wav\"");
										file.WriteLine("alias opera \"play \\ambient\\opera.wav\"");
										file.WriteLine("alias melody \"play \\ambient\\de_train_radio.wav\"");
										file.Write("alias techno \"play \\ambient\\misc\\techno_overpass.wav\"");
								   }

								   File.Create(@"\profiles\" + profilename + @"\" + db_ini);
								   //List<string> db_keys = new List<string>();
								   using (System.IO.StreamReader file = new System.IO.StreamReader(@"\profiles\" + profilename + @"\" + config_cfg))
								   {
										string line;
										line = file.ReadLine();
										if (line.Contains("bind"))
										{
											 string[] splitted = line.Split(' ');
											 db_keys.Add(splitted[1], splitted[2]);
										}
								   }

								   using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + profilename + @"\" + db_ini))
								   {
										foreach(KeyValuePair<string, string> db_key in db_keys)
										{
											 file.WriteLine(db_key.Key + " " + db_key.Value);
										}
								   }
								   Console.WriteLine("profile has been created.");
							  }
							  break;
						 }

					case "load":
						 {
							  string profilename = command[2];
							  if (Directory.Exists(@"\profiles\" + profilename + @"\")) //if profile exists
							  {
								   if (File.Exists(@"\profiles\" + profilename + @"\" + default_ini)) //and contains default.ini
								   {
										profile_path = @"\profiles\" + profilename + @"\" + default_ini;
										current_profile = profilename;
								   }
								   else
								   {
										Console.WriteLine("Error: couldn't load profile. profile folder doesn't exists.");
								   }
							  }
							  else
							  {
								   Console.WriteLine("Error: couldn't load profile. default.ini doesn't exists.");
							  }


							  break;
						 }

					case "save":
						 {
							  checkIf_backupFolder();

							  //Now Create all of the directories
							  foreach (string dirPath in Directory.GetDirectories(@"\profiles\" + current_profile + @"\", "*", SearchOption.AllDirectories))
								   Directory.CreateDirectory(dirPath.Replace(@"\profiles\" + current_profile + @"\", csgo_path));

							  //Copy all the files & Replaces any files with the same name
							  foreach (string newPath in Directory.GetFiles(@"\profiles\" + current_profile + @"\", "*.*", SearchOption.AllDirectories))
								   File.Copy(newPath, newPath.Replace(@"\profiles\" + current_profile + @"\", csgo_path), true);

							 // if (command[2] == "all")
							   

							  Console.WriteLine("All cfgs have been saved to: \"" + csgo_path + "\"");

							  break;
						 }

					case "delete":
						 {
							  string profilename = command[2];
							  string read;
							  Console.WriteLine("are you sure, you want to delete this profile? (\"" + profilename + "\") (y/n) \nNote: all saved cfg-s that belongs to this profile (folder) will be permanently deleted.");
							  read = Console.ReadLine();

							  if (read == "y")
							  {

								   checkIf_backupFolder();
								   copyFilesAndFolders(@"\profiles\" + profilename + @"\", @"\" + _backup + @"\");

								   //and lets delete
								   Directory.Delete(@"\profiles\" + profilename + @"\", true);
							  }
							  else
							  {
								   Console.WriteLine("operation canceled.");
							  }
							  break;
						 }
					default:
						 {
							  Console.WriteLine("you have entered a wrong command. please try again.");
							  break;
						 }
			   }
		  }

		  static void set(string[] command)
		  {
			   switch(command[1])
			   {
					case "path":
						 {
							  string read_console;
							  Console.Write("setting the csgo cfg folder: ");
							  read_console = Console.ReadLine();

							  csgo_path = read_console;
							  Console.WriteLine("the path has been set.");
							  break;
						 }

					case "fps":
						 {
							  if (!(current_profile == default(string)))
							  {
								   string read_console;
								   Console.Write("setting fps: ");
								   read_console = Console.ReadLine();

								   using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + current_profile + @"\" + init_cfg))
								   {
										file.Write("fps_max \"" + read_console + "\" //set max_fps");
								   }
								   Console.WriteLine("fps has been set.");
							  }
							  else
							  {
								   Console.WriteLine("Error: you didn't load in a profile");
							  }
							  break;
						 }

					default:
						 {
							  break;
						 }
			   }
		  }

		  static void bind(string[] command)
		  {
			   switch (command[1])
			   {
					case "override":
						 {
							  break;
						 }

					case "net":
						 {
							  string read_console;
							  Console.Write("setting net graph's binding: ");
							  read_console = Console.ReadLine();

							  File.Create(@"\profiles\" + current_profile + @"\fps.cfg");
							  using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + current_profile + @"\fps.cfg"))
							  {
								   file.WriteLine("//generated by csgo bindings beta");
								   file.WriteLine("//Note: don't use double enters in the config file otherwise it won't work");
								   file.WriteLine("//FPS_METER");
								   /*file.WriteLine("alias + fps \"bind mwheelup fpsup; bind mwheeldown fpsdown; bind mouse3 normalfps; ng; developer 1; play \\ui\\menu_focus.wav\"");
								   file.WriteLine("alias - fps \"bind mwheelup slot7; bind mwheeldown slot8; bind mouse3 slot6; developer 0\"");
								   file.WriteLine("alias ng \"toggle net_graph\"");*/
								   file.WriteLine("bind " + read_console + " \"toggle net_graph\"");
							  }
							  break;
						 }

					case "defuse":
						 {
							  string read_console;
							  Console.Write("setting lazy defuse's binding: ");
							  read_console = Console.ReadLine();

							  File.Create(@"\profiles\" + current_profile + @"\defuse.cfg");
							  using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + current_profile + @"\defuse.cfg"))
							  {
								   file.WriteLine("//generated by csgo bindings beta");
								   file.WriteLine("//Note: don't use double enters in the config file otherwise it won't work");
								   file.WriteLine("//AUTO_USE");

								   file.WriteLine("alias +autouse \" + use; bind mouse2 holduse\"");
								   file.WriteLine("alias -autouse \" - use; bind mouse2 +attack2\"");
								   file.WriteLine("alias holduse \" + use; exec boxhair; unbind e; sensitivity 0; bind mouse2 releaseuse; play \\common\\wpn_select.wav\"");
								   file.WriteLine("alias releaseuse \" - use; bind mouse2 +attack2; currentcrosshair; sensitivity .86; bind e +autouse; play \\common\\wpn_moveselect.wav\"");
								   file.WriteLine("bind e +autouse");
							  }
							  break;
						 }

					case "stay":
						 {
							  string read_console;
							  Console.Write("setting hold position's binding: ");
							  read_console = Console.ReadLine();

							  File.Create(@"\profiles\" + current_profile + @"\h_pos.cfg");
							  using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + current_profile + @"\h_pos.cfg"))
							  {
								   file.WriteLine("//generated by csgo bindings beta");
								   file.WriteLine("//Note: don't use double enters in the config file otherwise it won't work");
								   file.WriteLine("//HOLD_POSITION");

								   file.WriteLine("bind " + read_console + " holdpos;");
							  }
							  break;
						 }

					case "sound":
						 {
							  string read_console;
							  string read_console1;
							  string read_console2;
							  string read_console3;
							  Console.WriteLine("setting quick sound modifier's binding");

							  Console.Write("enter volume up bind: ");
							  read_console = Console.ReadLine();

							  Console.Write("enter volume down bind: ");
							  read_console1 = Console.ReadLine();

							  Console.Write("enter volume default bind: ");
							  read_console2 = Console.ReadLine();

							  Console.Write("enter volume default value (between 0.0 and 1.0): ");
							  read_console3 = Console.ReadLine();

							  File.Create(@"\profiles\" + current_profile + @"\sound.cfg");
							  using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + current_profile + @"\sound.cfg"))
							  {
								   file.WriteLine("//generated by csgo bindings beta");
								   file.WriteLine("//Note: don't use double enters in the config file otherwise it won't work");
								   file.WriteLine("//SOUND_MODIFIER");

								   file.WriteLine("alias +sound \"bind " + read_console + " soundup; bind " + read_console1 + " sounddown; bind " + read_console2 + " normalsound; developer 1\"");
								   file.WriteLine("alias -sound \"bind " + read_console + " slot7; bind " + read_console1 + " slot8; bind " + read_console2 + " slot6; developer 0\"");
								   file.WriteLine("alias soundup \"incrementvar volume - 1 2 0.05; play \\ui\\xp_remaining.wav; volume\"");
								   file.WriteLine("alias sounddown \"incrementvar volume - 1 2 - 0.05; play \\ui\\xp_remaining.wav; volume\"");
								   file.WriteLine("alias normalsound \"incrementvar volume 0 " + read_console3 + " " + read_console3 + "; play \\ui\\menu_focus.wav; volume\"");
							  }
							  break;
						 }

					default:
						 {
							  break;
						 }
			   }
		  }

		  static void db(string[] command)
		  {
			   switch (command[1])
			   {
					case "new":
						 {
							  string read_console;
							  string read_console1;
							  Console.WriteLine("adding new key binding to the db.");

							  Console.Write("enter key binding: ");
							  read_console = Console.ReadLine();

							  Console.Write("enter command: ");
							  read_console1 = Console.ReadLine();

							  using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\profiles\" + current_profile + @"\" + db_ini))
							  {
									file.WriteLine(read_console + " " + read_console1);
							  }

							  db_keys.Add(read_console, read_console1);
							  break;
						 }

					case "edit":
						 {
							  string read_console;
							  string old_keypair;
							  Console.WriteLine("editing key binding in the db.");

							  Console.Write("enter key binding: ");
							  read_console = Console.ReadLine();

							  foreach (KeyValuePair<string, string> db_key in db_keys)
							  {
								   if (db_key.Key == read_console)
								   {
										old_keypair = db_key.Key + " " + db_key.Value;
										break;
								   }
							  }

							  string text = File.ReadAllText(@"\profiles\" + current_profile + @"\" + db_ini);
							  text = text.Replace(old_keypair, "new value");
							  File.WriteAllText("test.txt", text);

							  db_keys.Add(read_console, read_console1);
							  break;
						 }

					case "del":
						 {
							  break;
						 }

					default:
						 {
							  break;
						 }
			   }
		  }

		  static void buy(string[] command)
		  {
			   
		  }

		  static void cross(string[] command)
		  {
			   
		  }

		  static void alias(string[] command)
		  {

		  }


		  static void copyFilesAndFolders(string from, string to)
		  {
			   //Now Create all of the directories
			   foreach (string dirPath in Directory.GetDirectories(from, "*", SearchOption.AllDirectories)) //@"\profiles\" + profilename + @"\" @"\" + _backup + @"\"
					Directory.CreateDirectory(dirPath.Replace(from, to)); //@"\" + _backup + @"\"

			   //Copy all the files & Replaces any files with the same name
			   foreach (string newPath in Directory.GetFiles(from, "*.*", SearchOption.AllDirectories))
					File.Copy(newPath, newPath.Replace(from, to), true);

		  }

		  static void checkIf_backupFolder()
		  {
			   if (!Directory.Exists(_backup))
			   {
					DirectoryInfo di = Directory.CreateDirectory(_backup);
					di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

					if (!Directory.Exists(_backup + "//remote"))
					{
						 Directory.CreateDirectory(_backup + "//remote");
					}

					if (!Directory.Exists(_backup + "//local"))
					{
						 Directory.CreateDirectory(_backup + "//local");
					}
			   }
		  }
	 }
}
