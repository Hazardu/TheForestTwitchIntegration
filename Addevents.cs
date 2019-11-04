using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ModAPITwitchIntegration;
using TheForest.Utils;
using TheForest;
using Bolt;
using System.Text.RegularExpressions;
using System.Reflection;

namespace TheForestTwitchIntegration
{
    public class CheatMod
    {
        public static void Spawnenemy(string mutantName)
        {
            mutantName = mutantName.TrimStart(' ').TrimEnd(' ');
            if (mutantName == "worm")
            {
                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("worm_SPAWNER"), LocalPlayer.Transform.position + new Vector3(0f, 1f, 2f), Quaternion.identity);
                return;
            }
            GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("instantMutantSpawner"), LocalPlayer.Transform.position + new Vector3(0f, 1f, 2f), Quaternion.identity);
            if (mutantName != null)
            {
                global::spawnMutants spawnMutants = UnityEngine.Object.Instantiate<global::spawnMutants>(Resources.Load<global::spawnMutants>("instantMutantSpawnerDC"));
                spawnMutants.transform.position = LocalPlayer.Transform.position;
                if (mutantName == "dynamiteman")
                {
                    mutantName = "fireman";
                    spawnMutants.useDynamiteMan = true;
                }
                if (mutantName == "pale" || mutantName == "skinny_pale")
                {
                    spawnMutants.pale = true;
                }
                else
                {
                    spawnMutants.pale = false;
                }
                FieldInfo field = spawnMutants.GetType().GetField("amount_" + mutantName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                field.SetValue(spawnMutants, 1);
                Debug.Log("$> spawned 1 " + mutantName);
            }

        }



    }
    public static class Addevents
    {
        [ModAPI.Attributes.ExecuteOnGameStart]
        public static void Init()
        {
            TwitchMod.Register("burn", (s) => LocalPlayer.Stats.Burn());
            TwitchMod.Register("hunger", (s) => LocalPlayer.Stats.Fullness = 0);
            TwitchMod.Register("thirst", (s) => LocalPlayer.Stats.Thirst = 1);
            TwitchMod.Register("heal", (s) => LocalPlayer.Stats.Health += 100);
            TwitchMod.Register("getsick", (s) => LocalPlayer.Stats.BloodInfection.GetInfected());
            TwitchMod.Register("getcured", (s) => LocalPlayer.Stats.BloodInfection.Cure());
            TwitchMod.Register("discharge", (s) => LocalPlayer.Stats.Energy = 0);
            TwitchMod.Register("regenenergy", (s) => LocalPlayer.Stats.Energy += 100);
            TwitchMod.Register("jump", (s) => LocalPlayer.Transform.position += Vector3.up*5);
            TwitchMod.Register("sleep", (s) => LocalPlayer.Stats.GoToSleep());
            TwitchMod.Register("shake", (s) => LocalPlayer.HitReactions.enableFootShake(1, 2));
            TwitchMod.Register("birb", (s) => LocalPlayer.HitReactions.doBirdOnHand());
            TwitchMod.Register("removeitem", (s) => RemoveAnyItemCmd(s));
            TwitchMod.Register("equipitem", (s) => EquipAnyItemCmd(s));
            TwitchMod.Register("armsy", (s) => CheatMod.Spawnenemy("armsy"));
            TwitchMod.Register("sausage", (s) => CheatMod.Spawnenemy("worm"));
            TwitchMod.Register("megan", (s) => CheatMod.Spawnenemy("girl"));
            TwitchMod.Register("vags", (s) => CheatMod.Spawnenemy("vags"));
            TwitchMod.Register("fatman", (s) => CheatMod.Spawnenemy("fat"));
            TwitchMod.Register("fireman", (s) => CheatMod.Spawnenemy("fireman"));
            TwitchMod.Register("enemy", (s) => CheatMod.Spawnenemy(s));
            TwitchMod.Register("explosives", (s) => LocalPlayer.Inventory.AddItem(29, 2));
            TwitchMod.Register("additem", (s) => AddAnyItemCmd(s));


        }

        public static void AddAnyItemCmd(string s)
        {
            var x = s.Substring(1).Split('/');
            var item = 0;
            if (int.TryParse(x[0].TrimStart(' ').TrimEnd(' '), out int result))
            {
                item = result;
            }
            else
            {
                item = TheForest.Items.ItemDatabase.ItemIdByName(x[0].TrimStart(' ').TrimEnd(' '));
            }
            if (x.Length>1)
            {
                if (int.TryParse(x[1], out int i))
                {
                    i = Mathf.Clamp(i, -10, 10);
                    LocalPlayer.Inventory.AddItem(item, i);
                }
            }
            else
            {
                LocalPlayer.Inventory.AddItem(item, 1);
            }

        }
        public static void RemoveAnyItemCmd(string s)
        {
            var x = s.Substring(1).Split('/');
            var item = 0;
            if (int.TryParse(x[0].TrimStart(' ').TrimEnd(' '), out int result))
            {
                item = result;
            }
            else
            {
               item = TheForest.Items.ItemDatabase.ItemIdByName(x[0].TrimStart(' ').TrimEnd(' '));
            }
            if (x.Length > 1)
            {
                if (int.TryParse(x[1], out int i))
                {
                    i = Mathf.Clamp(i, -10, 10);
                    LocalPlayer.Inventory.RemoveItem(item, i);
                }
            }
            else
            {
                LocalPlayer.Inventory.RemoveItem(item, 1);
            }

        }

        public static void EquipAnyItemCmd(string s)
        {
            var x = s.Substring(1);
            ModAPI.Console.Write(x);
            var item = 0;
            if (int.TryParse(x.TrimStart(' ').TrimEnd(' '), out int result))
            {
                item = result;
            }
            else
            {
                item = TheForest.Items.ItemDatabase.ItemIdByName(x.TrimStart(' ').TrimEnd(' '));
            }
            ModAPI.Console.Write(item.ToString());

            LocalPlayer.Inventory.Equip(item,false);
               
           
        }

    }


}

