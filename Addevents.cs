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

        public static Dictionary<string, int> allowedPrefabs = new Dictionary<string, int>()
        {
{"boar ragdoll",10},
{"crocodile ragdoll",13},
{"deer ragdoll",16},
{"lizard ragdoll base",19},
{"rabbit ragdoll",22},
{"raccoon ragdoll",25},
{"shark ragdoll",27},
{"squirrel ragdoll",30},
{"tortoise",32},
{"tortoise ragdoll",33},
{"turtle",35},
{"turtle ragdoll",36},
{"fat mutant ragdoll",41},
{"vags ragdoll",44},
{"armsy ragdoll",47},
{"baby ragdoll",51},
{"mutant female dummy",53},
{"mutant male dummy",55},
{"headless shark ragdoll",59},
{"shark ragdoll",60},
{"instant dynamite",61},
{"fire bomb",62},
{"crow ragdoll",65},
{"nitrogen bomb",81},
{"fish",86},
{"skinned lizard",87},
{"rabbit corpse",88},
{"bloody table",93},
{"armor mannequin built",96},
{"arrow basket built",97},
{"bed built",98},
{"birdhouse built",99},
{"bone basket built",100},
{"bone chair built",101},
{"bone frame built",102},
{"bon fire built",103},
{"car built",104},
{"ceiling skull light built",109},
{"chair built",111},
{"chandelier built",112},
{"church built",113},
{"coffin built",114},
{"cross built",115},
{"decoration deer skin built",116},
{"decoration ground weapon holder built",117},
{"decoration rabbit skin built",118},
{"decoration skull built",119},
{"decoration wall plant pot built",121},
{"decoration wall weapon holder built",122},
{"dog effigy built",123},
{"drying rack built",124},
{"drying rack built old",125},
{"drying rack lite built",126},
{"effigy big built",127},
{"effigy head",128},
{"effigy rain built",129},
{"effigy small built",130},
{"ex bone fence chunk built",131},
{"ex bridge built",132},
{"ex coaster built",133},
{"ex crane built",134},
{"ex dock built",135},
{"ex effigy built",136},
{"ex floor built",137},
{"ex foundation built",138},
{"ex foundation built mp",139},
{"ex garden built",140},
{"ex garden underground built2",141},
{"ex platform built",142},
{"ex raft built",143},
{"ex raft oar built",144},
{"ex rock fence chunk built",145},
{"ex rock path chunk built",146},
{"ex roof built old",147},
{"ex roof built",148},
{"ex small wall chunk built",149},
{"ex stairs2built",150},
{"ex stairs built",151},
{"ex stick fence chunk built",152},
{"ex wall built",153},
{"ex wall chunk built",154},
{"ex wall chunk built h",155},
{"ex wall defensive chunk built",156},
{"ex wall defensive chunk reinforcement",157},
{"ex wall defensive gate built",158},
{"ex zipline built",159},
{"ex zipline tree built",160},
{"fire built",161},
{"fire built rock pit",162},
{"fireplace built",163},
{"fire stand built",164},
{"fire stand built old",165},
{"food holder large built new",166},
{"food holder small built new",167},
{"garden built",168},
{"gazebo built",169},
{"hang glider built",170},
{"holder explosives built",171},
{"holder snacks built",172},
{"house boat small",173},
{"item stash built",174},
{"large raft built",175},
{"leaf hut built",176},
{"log cabin built",177},
{"log cabin small built",178},
{"log holder built",179},
{"log holder built old",180},
{"log holder large built",181},
{"log sled built",182},
{"medicine cabinet built",183},
{"mom effigy built",184},
{"mom effigy sitting built",185},
{"multi sled built",186},
{"multi thrower built",187},
{"platform built",188},
{"rabbit cage built",189},
{"raft built",190},
{"rock holder built",191},
{"rock holder large built",192},
{"rock side platform built",193},
{"rock thrower built old",194},
{"rope built",195},
{"shelter built",196},
{"skin rack built",197},
{"skin rack built old",198},
{"skull light built",199},
{"small table built",200},
{"sos built",201},
{"spike defense built",202},
{"stair case built",203},
{"stick marker built",204},
{"stick holder built",205},
{"stick holder large built",206},
{"table built",207},
{"target built",208},
{"timmy drawing 00 built",209},
{"timmy drawing 01 built",210},
{"timmy drawing 02 built",211},
{"timmy drawing 03 built",212},
{"timmy drawing 04 built",213},
{"timmy drawing 05 built",214},
{"timmy drawing 06 built",215},
{"timmy drawing 07 built",216},
{"timmy drawing 08 built",217},
{"timmy drawing 09 built",218},
{"timmy drawing 10 built",219},
{"timmy effigy built",220},
{"timmy effigy sitting built",221},
{"tower built",222},
{"trap deadfall built",223},
{"trap fish built",224},
{"trap leaf pile built",225},
{"trap rabbit built",226},
{"trap rope built",227},
{"trap spike wall built",228},
{"trap swinging rock in tree built",229},
{"trap trip wire explosive built",230},
{"trap trip wire molotov built",231},
{"tree house chalet built",232},
{"tree house chalet built anchor",233},
{"tree house chalet built rope",234},
{"tree house built",235},
{"tree house built anchor",236},
{"tree house built rope",237},
{"tree platform built anchor",238},
{"tree platform built rope",239},
{"treesap collector built",240},
{"trophy boar built",241},
{"trophy creepy armsy built",242},
{"trophy creepy baby built",243},
{"trophy creepy fat built",244},
{"trophy creepy vag built",245},
{"trophy crocodile built",246},
{"trophy deer built",247},
{"trophy goose built",248},
{"trophy lizard built",249},
{"trophy rabbit built",250},
{"trophy raccoon built",251},
{"trophy seagull built",252},
{"trophy shark built",253},
{"trophy squirrel built",254},
{"trophy tortoise built",255},
{"tv built",256},
{"walkway straight built",257},
{"wall built",258},
{"wall built defensive",259},
{"wall built doorway",260},
{"wall built window",261},
{"wardrobe built",262},
{"water collector built",263},
{"weapon rack built",264},
{"wood couch built",265},
{"wood frame built",266},
{"work bench built",267},
{"blueprint armor mannequin",273},
{"blueprint arrow basket",274},
{"blueprint bed",275},
{"blueprint birdhouse",276},
{"blueprint bone basket",277},
{"blueprint bone chair",278},
{"blueprint bone frame",279},
{"blueprint bon fire",280},
{"blueprint cage",281},
{"blueprint car",282},
{"blueprint ceiling skull light",283},
{"blueprint ceiling skull light old",284},
{"blueprint chair",285},
{"blueprint chandelier",286},
{"blueprint church",287},
{"blueprint coffin",288},
{"blueprint cross",289},
{"blueprint decoration deer skin",290},
{"blueprint decoration ground weapon holder",291},
{"blueprint decoration rabbit skin",292},
{"blueprint decoration skull",293},
{"blueprint decoration trophy",294},
{"blueprint decoration trophy old",295},
{"blueprint decoration wall plant pot",296},
{"blueprint decoration wall plant pot old",297},
{"blueprint decoration wall weapon holder",298},
{"blueprint decoration wall weapon holder old",299},
{"blueprint defensive spikes",300},
{"blueprint dog",301},
{"blueprint drying rack",302},
{"blueprint drying rack lite",303},
{"blueprint effigy head",304},
{"blueprint effigy large",305},
{"blueprint effigy rain",306},
{"blueprint effigy small",307},
{"blueprint effigy mom",308},
{"blueprint effigy mom sitting",309},
{"blueprint effigy timmy",310},
{"blueprint effigy timmy sitting",311},
{"blueprint explosive holder",312},
{"blueprint ex bone fence chunk",313},
{"blueprint ex bridge",314},
{"blueprint ex coaster",315},
{"blueprint ex crane",316},
{"blueprint ex dock",317},
{"blueprint ex effigy",318},
{"blueprint ex floor",319},
{"blueprint ex foundation",320},
{"blueprint ex foundation mp",321},
{"blueprint ex garden",322},
{"blueprint ex garden underground2",323},
{"blueprint ex platform",324},
{"blueprint ex raft",325},
{"blueprint ex raft oar",326},
{"blueprint ex rock fence chunk",327},
{"blueprint ex rock path chunk",328},
{"blueprint ex roof old",329},
{"blueprint ex roof",330},
{"blueprint ex small wall chunk",331},
{"blueprint ex stairs",332},
{"blueprint ex stairs2",333},
{"blueprint ex stick fence chunk",334},
{"blueprint ex wall chunk",335},
{"blueprint ex wall chunk h",336},
{"blueprint ex wall defensive chunk",337},
{"blueprint ex wall defensive chunk reinforcement",338},
{"blueprint ex wall defensive gate",339},
{"blueprint ex zipline",340},
{"blueprint ex zipline tree",341},
{"blueprint fire",342},
{"blueprint fireplace",343},
{"blueprint fire rock pit",344},
{"blueprint fire rock pit partial",345},
{"blueprint fire stand",346},
{"blueprint fire stand partial",347},
{"blueprint fish trap",348},
{"blueprint food holder large",349},
{"blueprint food holder small",350},
{"blueprint garden",351},
{"blueprint gazebo",352},
{"blueprint hang glider",353},
{"blueprint house boat",354},
{"blueprint item stash",355},
{"blueprint large raft",356},
{"blueprint leaf shelter",357},
{"blueprint log cabin",358},
{"blueprint log cabin medium",359},
{"blueprint log holder",360},
{"blueprint log holder large",361},
{"blueprint log sled",362},
{"blueprint platform",363},
{"blueprint rabbit trap",364},
{"blueprint raft",365},
{"blueprint rock holder",366},
{"blueprint rock holder large",367},
{"blueprint rock side platform",368},
{"blueprint rock thrower",369},
{"blueprint rope",370},
{"blueprint shelter",371},
{"blueprint skin rack",372},
{"blueprint skull light",373},
{"blueprint small table",374},
{"blueprint sos",375},
{"blueprint staircase",376},
{"blueprint stick holder",377},
{"blueprint stick holder large",378},
{"blueprint stick marker",379},
{"blueprint table",380},
{"blueprint target",381},
{"blueprint tower",382},
{"blueprint trap dead fall",383},
{"blueprint trap leaf pile",384},
{"blueprint trap rope",385},
{"blueprint trap spiked wall",386},
{"blueprint trap swinging rock in tree",387},
{"blueprint tree house chatel anchor",388},
{"blueprint tree house chatel rope",389},
{"blueprint tree house anchor",390},
{"blueprint tree house rope",391},
{"blueprint tree platform anchor",392},
{"blueprint tree platform rope",393},
{"blueprint treesap collector",394},
{"blueprint treesap collector old",395},
{"blueprint trip wire explosive",396},
{"blueprint trip wire molotov",397},
{"blueprint tv",398},
{"blueprint walk way",399},
{"blueprint wall",400},
{"blueprint wall defensive",401},
{"blueprint wall door way",402},
{"blueprint wall window",403},
{"blueprint wardrobe",404},
{"blueprint water collector",405},
{"blueprint weapon rack",406},
{"blueprint wood couch",407},
{"blueprint wood frame",408},
{"blueprint work bench old",409},
{"blueprint work bench",410},
{"arm part",411},
{"bone part",412},
{"head part",413},
{"leg part",414},
{"skull part",415},
{"stick part",416},
{"torso part",417},
{"cooked rabbit",418},
{"cooking arm",419},
{"cooking cod",420},
{"cooking generic meat",421},
{"cooking head",422},
{"cooking leg",423},
{"cooking lizard",424},
{"cooking rabbit",425},
{"cooking small generic meat",426},
{"cooking water pot",427},
{"dry arm",428},
{"dry cod",429},
{"dry generic meat",430},
{"dry head",431},
{"dry leg",432},
{"dry lizard",433},
{"dry rabbit",434},
{"stew berry blue berry",435},
{"stew herb aloe",436},
{"stew herb chicory",437},
{"stew herb conflower",438},
{"stew herb marigold",439},
{"stew meat arm",440},
{"stew meat cod",441},
{"stew meat generic meat",442},
{"stew meat head",443},
{"stew meat leg",444},
{"stew meat lizard",445},
{"stew meat oyster",446},
{"stew meat rabbit",447},
{"stew meat small generic meat",448},
{"stew mushroom amanita",449},
{"stew mushroom chanterelle",450},
{"stew mushroom deermush",451},
{"stew mushroom jack",452},
{"stew mushroom libertycap",453},
{"stew mushroom puffmush",454},
{"bomb timed",455},
{"bomb timed pickup",456},
{"bomb timed placed",457},
{"dynamite",458},
{"dynamite placed",459},
{"dynamite unlit placed",460},
{"fire torch lit placed",461},
{"fire torch unlit placed",462},
{"head bomb",463},
{"head bomb pickup",464},
{"molotov",465},
{"molotov doused lit",466},
{"molotov unlit",467},
{"nitrogen tank 01a explode",468},
{"hash position to name",471},
{"air pick up dynamic mp",472},
{"arm",473},
{"arm female",474},
{"arm skinny female",475},
{"arm skinny male",476},
{"arrow",477},
{"arrow bone",478},
{"arrow drop",479},
{"arrow modern",480},
{"artifact ball pick up",481},
{"artifact ball placed",482},
{"artifact ball placed first time pickup",483},
{"axe crafted dynamic mp",484},
{"axe dynamic mp",485},
{"axe plane dynamic mp",486},
{"axe climbing pick up dynamic mp",487},
{"axe rusty dynamic mp",488},
{"batteries pick up",489},
{"bone pick up mp",490},
{"booze smir mp",491},
{"bow dynamic mp",492},
{"cash",493},
{"cboard dynamic mp",494},
{"chainsaw pick up dynamic mp",495},
{"chocolate bar1",496},
{"chocolate bar2",497},
{"chocolate bar3",498},
{"club crafted dynamic mp",499},
{"club dynamic",500},
{"crossbow bolt dynamic",501},
{"cross bow pick up mp",502},
{"deer skin dynamic mp",503},
{"dynamite pick up dynamic mp",504},
{"flare",505},
{"flare gun dynamic mp",506},
{"flare gun empty mp",507},
{"flare spawn",508},
{"flare spawn unlit",509},
{"flare pick up dynamic mp",510},
{"flint lock mp",511},
{"generic meat mp",512},
{"hairspray mp",513},
{"head",514},
{"head female",515},
{"head skinny female",516},
{"head skinny male",517},
{"katana pick up dynamic mp",518},
{"leg",519},
{"leg female",520},
{"leg skinny female 1",521},
{"leg skinny female",522},
{"leg skinny male 1",523},
{"leg skinny male",524},
{"lizard skin dynamic mp",525},
{"log",526},
{"log burnt",527},
{"meds",528},
{"metal tin tray pickup",529},
{"plane booze smir",530},
{"pot 1 pick up dynamic",531},
{"rabbit skin dynamic mp",532},
{"recurve bow pickup mp",533},
{"rock dynamic mp",534},
{"rope pick up dynamic mp",535},
{"skull pick up dynamic mp",536},
{"small generic meat mp",537},
{"small rock dynamic",538},
{"soda can dynamic mp",539},
{"stick dynamic mp",544},
{"tape roll",545},
{"teeth pickup dynamic mp",546},
{"tennis ball dynamic",547},
{"tennis ball high",548},
{"tennis racket pick up dynamic",549},
{"turtle meat",550},
{"turtle shell",551},
{"walkman distraction device",552},
{"watch dynamic coop",553},
{"watch wrappedcoop",554},
{"animal head boar",555},
{"animal head crocodile",556},
{"animal head deer",557},
{"animal head goose",558},
{"animal head lizard",559},
{"animal head rabbit",560},
{"animal head raccoon",561},
{"animal head seagull",562},
{"animal head shark",563},
{"animal head squirrel",564},
{"animal head tortoise",565},
{"creepy head armsy",566},
{"creepy head baby",567},
{"creepy head fat",568},
{"creepy head vag",569},
{"aloe vera high",570},
{"cone flower high",571},
{"dirt pile aloe",572},
{"dirt pile blueberry",573},
{"dirt pile coneflower",574},
{"dirt pile mushroom amanita 2",575},
{"dirt pile mushroom chanterelle 2",576},
{"dirt pile mushroom deer 2",577},
{"dirt pile mushroom jack 2",578},
{"dirt pile mushroom libertycap 2",579},
{"dirt pile mushroom puff 2",580},
{"suit case spawn blue",582},
{"suit case spawn blue floating",583},
{"suit case spawn dark",584},
{"suit case spawn dark floating",585},
{"suit case spawn pink",586},
{"suit case spawn pink floating",587},
{"suit case spawn red",588},
{"suit case spawn red floating",589},
{"suit case spawn spotty",590},
{"suit case spawn spotty floating",591},
{"suit case spawn yellow",592},
{"suit case spawn yellow floating",593},
{"suit case spawn yellow hair spray",594},
{"yellow crate",595},
{"yellow crate arrow",596},
{"clothing outfit",597},
{"clothing suit case",598},
{"clothing suit case bathrobe",599},
{"clothing suit case host",600},
{"clothing suit case oldtimesuit",601},
{"clothing suit case pilot",602},
{"clothing suit case tennis",603},
{"dead tree01 burn",604},
{"dead tree02 burn",605},
{"dead tree03 burn",606},
{"maple mid cut lower chunks",607},
{"mapple3big bare cut lower chunks",608},
{"mapple3big burnt",609},
{"mapple3big cut lower chunks",610},
{"mapple mid burnt",611},
{"pine tree burn",612},
{"pine tree high burnt",613},
{"pine tree high cut lower chunks",614},
{"pine tree moss burnt",615},
{"pine tree moss cut lower chunks",616},
{"pine tree thin burnt",617},
{"pine tree thin cut lower chunks",618},
{"pine tree top heavy burnt",619},
{"pine tree top heavy cut lower chunks",620},
{"winter pine burn",621},
{"winter pine cut lower chunks",622},
{"winter top heavy burnt",623},
{"arrow fire",624},
{"head thrown",626},
{"projectile fire",628},
{"rock thrown",629},
{"weapon fire",630},
{"multi thrower projectile",632}};

        public static void SpawnPrefab(string s)
        {
            s = s.ToLower();
            ModAPI.Console.Write(s);
            if (allowedPrefabs.ContainsKey(s))
            {
               // var t = Camera.main.transform;
                //if (Physics.Raycast(t.position + t.forward, t.forward, out RaycastHit hit, 10))
                //{
                //    BoltNetwork.Instantiate(new PrefabId(allowedPrefabs[s]), hit.point + Vector3.up, Quaternion.identity);
                //}else
                   var v = BoltNetwork.Instantiate(new PrefabId(allowedPrefabs[s]), LocalPlayer.Transform.position + Vector3.up, Quaternion.identity);
                v.transform.position = LocalPlayer.Transform.position + Vector3.up;


            }
        }
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

        public static void BuildGhost(string s)
        {
        var o = (TheForest.Buildings.Creation.BuildingTypes)Enum.Parse(typeof(TheForest.Buildings.Creation.BuildingTypes),s,true);
            LocalPlayer.Create.CreateBuilding(o);
        }
        public static void Push(string s)
        {
            if (float.TryParse(s, out float result))
            {
                result = Mathf.Clamp(result, 1f, 3f) * 1000;
                LocalPlayer.Rigidbody.AddForce(LocalPlayer.Transform.forward * result, ForceMode.VelocityChange);
            }
            else
            {
                LocalPlayer.Rigidbody.AddForce(LocalPlayer.Transform.forward * 1500f,ForceMode.VelocityChange);
            
            }
        }
        public static void SetTime(string s)
        {
            if (float.TryParse(s, out float result))
            {
                result = Mathf.Clamp(result, 1f, 269f);

                TheForest.Utils.Scene.Atmosphere.TimeOfDay = result;
            }
        }


        public static void KillEnemy(string s)
        {
            List<GameObject> list = new List<GameObject>(TheForest.Utils.Scene.MutantControler.activeCannibals);
            foreach (GameObject item in TheForest.Utils.Scene.MutantControler.activeInstantSpawnedCannibals)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            list.RemoveAll((GameObject o) => o == null);
            list.RemoveAll((GameObject o) => o != o.activeSelf);
            if (list.Count > 0)
            {
                int i = 1;
                if (int.TryParse(s, out i))
                    i = Mathf.Clamp(i, 1, 5);
                list.Sort((GameObject c1, GameObject c2) => Vector3.Distance(LocalPlayer.Transform.position, c1.transform.position).CompareTo(Vector3.Distance(LocalPlayer.Transform.position, c2.transform.position)));
                for (int a = 0; a < i && a <list.Count; a++)
                {
                list[a].SendMessage("killThisEnemy", SendMessageOptions.DontRequireReceiver);

                }
            }
        }
    }
    public static class Addevents
    {
        [ModAPI.Attributes.ExecuteOnGameStart]
        public static void Init()
        {
            TwitchMod.Register("burn", (s) => LocalPlayer.Stats.Burn());
            TwitchMod.Register("hunger", (s) => LocalPlayer.Stats.Fullness -= 0.33f);
            TwitchMod.Register("feed", (s) => LocalPlayer.Stats.Fullness += 0.33f);
            TwitchMod.Register("drink", (s) => LocalPlayer.Stats.Thirst -= 0.33f);
            TwitchMod.Register("thirst", (s) => LocalPlayer.Stats.Thirst += 0.33f);
            TwitchMod.Register("heal", (s) => LocalPlayer.Stats.Health += 100);
            TwitchMod.Register("infect", (s) => LocalPlayer.Stats.BloodInfection.GetInfected());
            TwitchMod.Register("cure", (s) => LocalPlayer.Stats.BloodInfection.Cure());
            TwitchMod.Register("tired", (s) => LocalPlayer.Stats.Energy = 0);
            TwitchMod.Register("energy", (s) => LocalPlayer.Stats.Energy += 100);
            TwitchMod.Register("sit", (s) => LocalPlayer.Stats.SitDown());
            TwitchMod.Register("build", (s) => CheatMod.BuildGhost(s));
            TwitchMod.Register("yeet", (s) => CheatMod.Push(s));
            TwitchMod.Register("revive", (s) => LocalPlayer.Stats.HealedMp());
            TwitchMod.Register("jump", (s) => LocalPlayer.Transform.position += Vector3.up*8);
            TwitchMod.Register("sleep", (s) => LocalPlayer.Stats.GoToSleep());
            TwitchMod.Register("settime", (s) => LocalPlayer.Stats.GoToSleep());
            TwitchMod.Register("shake", (s) => LocalPlayer.HitReactions.enableFootShake(1, 10));
            TwitchMod.Register("birb", (s) => LocalPlayer.HitReactions.doBirdOnHand());
            TwitchMod.Register("removeitem", (s) => RemoveAnyItemCmd(s));
            TwitchMod.Register("equipitem", (s) => EquipAnyItemCmd(s));
            TwitchMod.Register("additem", (s) => AddAnyItemCmd(s));
            TwitchMod.Register("createitem", (s) => SpawnAnyItem(s));
            TwitchMod.Register("explosives", (s) => LocalPlayer.Inventory.AddItem(29, 5));
            TwitchMod.Register("armsy", (s) => CheatMod.Spawnenemy("armsy"));
            TwitchMod.Register("sausage", (s) => CheatMod.Spawnenemy("worm"));
            TwitchMod.Register("megan", (s) => CheatMod.Spawnenemy("girl"));
            TwitchMod.Register("vags", (s) => CheatMod.Spawnenemy("vags"));
            TwitchMod.Register("fatman", (s) => CheatMod.Spawnenemy("fat"));
            TwitchMod.Register("fireman", (s) => CheatMod.Spawnenemy("fireman"));
            TwitchMod.Register("enemy", (s) => CheatMod.Spawnenemy(s));
            TwitchMod.Register("killenemy", (s) => CheatMod.KillEnemy(s));
            TwitchMod.Register("prefab", s => CheatMod.SpawnPrefab(s));

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
                    i = Mathf.Clamp(i, 1, 50);
                    LocalPlayer.Inventory.AddItem(item, i);
                }
            }
            else
            {
                LocalPlayer.Inventory.AddItem(item, 1);
            }

        }
        public static void SpawnAnyItem(string s)
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
                    i = Mathf.Clamp(i, 1, 10);
                    for (int a = 0; a < i; a++)
                    {
                    LocalPlayer.Inventory.FakeDrop(item, null);

                    }
                }
            }
            else
            {
                LocalPlayer.Inventory.FakeDrop(item, null);
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
                    i = Mathf.Clamp(i, 1, 100);
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

