using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using EzAIO.Champions.Ashe;
using SharpDX;
using static EzAIO.Utilities.BaseUlt.Bases;
using static EzAIO.Program;

namespace EzAIO.Utilities.BaseUlt
{
    using static ChampionBases;
    public static class BaseUlt
    {
        public static AIBaseClient Player = GameObjects.Player;

        public static void OnGameLoad()
        {
            if (GameObjects.Player.IsDead)
            {
                return;
            }
            
            R = new Spell(SpellSlot.R);
            if (GameObjects.EnemyHeroes == null)
            {
                return;
            }
            var BasePos = GameObjects.EnemySpawnPoints.FirstOrDefault();
            foreach (var target in GameObjects.EnemyHeroes)
            {
                if (BasePos == null)
                {
                    return;
                }
                var nem = new Bases.BaseChamps(target, BasePos.Position, Teleport.TeleportStatus.Unknown,
                    Teleport.TeleportType.Unknown, 0, 0);
                GetChamps.Add(nem);   
            }

            GameEvent.OnGameTick += OnGameUpdate;
            Teleport.OnTeleport += OnTeleport;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            var notMode = Configs.BaseUltMenu.NotifyModeList.Index;
            if (BaseULTChamps == null || !R.IsReady())
            {
                return;
            }

            
            var i = 1;
            foreach (var target in BaseULTChamps)
            {
                switch (notMode)
                {
                    case 0:
                        MSG("BaseUlt "+target.CharacterName+$" with <font color = '#FF0000'>{target.Health} <font color = '#FFFFFF'> health!");
                        break;
                    case 1:
                        var pos = Player.HPBarPosition;
                        DrawText(TextBold,"BaseUlt "+target.CharacterName,pos.X,pos.Y+20*i,Color.Cyan);
                        break;
                        
                }
            }
        }

        private static void OnTeleport(AIBaseClient sender, Teleport.TeleportEventArgs args)
        {
            var Champ = GetChamps.FirstOrDefault(x => x.NetworkID == sender.NetworkId);
            if (Champ != null)
            {
                Champ.TStatus = args.Status;
                Champ.TType = args.Type;
                Champ.Duration = args.Duration;
                if (args.Status == Teleport.TeleportStatus.Start)
                {
                    Champ.Start = Variables.GameTimeTickCount;
                }
                else
                {
                    Champ.Start = 0;
                }
            }
            else
            {
                if (sender is AIHeroClient)
                {
                    var BasePos = GameObjects.EnemySpawnPoints.FirstOrDefault();
                    var nem = new Bases.BaseChamps((AIHeroClient) sender, BasePos.Position, args.Status, args.Type,
                        args.Duration, args.Start);
                    GetChamps.Add(nem);
                }
            }
        }

        private static void OnGameUpdate(EventArgs args)
        {
            if (Player.IsDead)
            {
                return;
            }
            switch (Player.CharacterName)
            {
                case "Draven":
                    Delay = 500;
                    Speed = 2000;
                    break;
                case "Ezreal":
                    Delay = 1000;
                    Speed = 2000;
                    break;
                case "Ashe":
                    Delay = 250;
                    Speed = 1600;
                    break;

            }

            if (GameObjects.EnemyHeroes == null || !R.IsReady() || !Configs.BaseUltMenu.EnableBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes)
            {
                var panic = Configs.BaseUltMenu.PanicKey.Active;
                if (target == null)
                {
                    return;
                }
                var info = GetChamps.FirstOrDefault(x => x.NetworkID == target.NetworkId);
                if (info == null)
                {
                    return;
                }
                if (info.TType == Teleport.TeleportType.Recall && info.TStatus == Teleport.TeleportStatus.Start)
                {
                    if (Player.CharacterName == "Draven" && R.Name == "DravenRCast")
                    {
                        if (Champions.Draven.Damage.RDamage(target) * 1.5 >= target.Health)
                        {
                            BaseULTChamps.Add(target);
                            if (info.PosBase.DistanceToPlayer() / Speed * 1000 + Delay >=
                                info.Duration - (Variables.GameTimeTickCount - info.Start))
                            {
                                if (panic || Player.CountEnemyHeroesInRange(Configs.BaseUltMenu.EnemyRangeSlider.Value) != 0)
                                {
                                    return;
                                }
                                if (R.Cast(info.PosBase))
                                {
                                    return;
                                }
                            }
                        }
                    }

                    if (Player.CharacterName == "Ezreal")
                    {
                        if (Champions.Ezreal.Damage.RDamage(target) >= target.Health)
                        {
                            BaseULTChamps.Add(target);
                            if (info.PosBase.DistanceToPlayer() / Speed * 1000 + Delay >=
                                info.Duration - (Variables.GameTimeTickCount - info.Start))
                            {
                                if (panic || Player.CountEnemyHeroesInRange(Configs.BaseUltMenu.EnemyRangeSlider.Value) != 0)
                                {
                                    return;
                                }
                                if (R.Cast(info.PosBase))
                                {
                                    return;
                                }
                            }
                        }
                    }
                    if (Player.CharacterName == "Ashe")
                    {
                        if (target.Health <= Champions.Ashe.Damage.RDamage(target))
                        {
                            BaseULTChamps.Add(target);
                            if (info.PosBase.DistanceToPlayer() / Speed * 1000 + Delay >=
                                info.Duration - (Variables.GameTimeTickCount - info.Start))
                            {
                                if (panic ||
                                    Player.CountEnemyHeroesInRange(Configs.BaseUltMenu.EnemyRangeSlider.Value) != 0)
                                {
                                    return;
                                }

                                if (R.Cast(info.PosBase))
                                {
                                    return;
                                }
                            }
                        }
                    }

                    if (Player.CharacterName == "Jinx")
                    {
                        var delayshort = 2000 / 1500 * 1000;
                        var maxspeed = 2200;
                        var delay = 500;
                        if (target.Health <= R.GetDamage(target))
                        {
                            BaseULTChamps.Add(target);
                            if (Player.Distance(info.PosBase) > 2000)
                            {
                                delay = 500 + delayshort;
                                if ((info.PosBase.DistanceToPlayer() - 2000) / maxspeed * 1000 + delay >=
                                    info.Duration - (Variables.GameTimeTickCount - info.Start))
                                {
                                    if (R.Cast(info.PosBase))
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (info.PosBase.DistanceToPlayer() / 1500 * 1000 + delay >=
                                    info.Duration - (Variables.GameTimeTickCount - info.Start))
                                {
                                    if (R.Cast(info.PosBase))
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    
                }
                else
                {
                    BaseULTChamps.Remove(target);
                    continue;
                }
            }
            BaseULTChamps.Clear();
        }
    }
}