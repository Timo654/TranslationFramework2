using System.Collections.Generic;
using System.Drawing;
using TF.Core.Entities;
using TF.Core.Files;

namespace TFGame.YakuzaIshin
{
    public class Game : YakuzaGame.Game
    {

        public override string Id => "c3a0df5a-a3af-49bf-b604-c1161b5736bc";
        public override string Name => "Ryū ga Gotoku Ishin!";
        public override string Description => "BLJM61149";
        public override Image Icon => Resources.Icon; // https://en.wikipedia.org/wiki/Yakuza_Ishin
        public override int Version => 6;
        public override System.Text.Encoding FileEncoding => new Encoding();

        private GameFileContainer GetBootpar()
        {
            var tableSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern =
                        "ability.bin;caption.bin;complete_haruka.bin;complete_heat.bin;complete_shisho.bin;dictionary.bin;dictionary_ignore.bin;explanation_main_scenario.bin;explanation_sub_story.bin;item.bin;kiyaku.bin;otazunemono.bin;restaurant_menu.bin;tips_tutorial.bin",

                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.Table.File)
                };

            var bootpar = new GameFileContainer
            {
                Path = @"data\bootpar\boot.par",
                Type = ContainerType.CompressedFile
            };

            bootpar.FileSearches.Add(tableSearch);
            return bootpar;
        }

        private GameFileContainer GetAlife()
        {
            var tableSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "alife_cooking_*.bin",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.Table.File)
                };

            var bootpar = new GameFileContainer
            {
                Path = @"data\alife\cooking",
                Type = ContainerType.Folder
            };

            bootpar.FileSearches.Add(tableSearch);
            return bootpar;
        }

        private IList<GameFileContainer> GetPause()
        {
            var dds1Search =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "2d_mn_syotitle_??.dds",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(DDS2File),
                };

            var chapter = new GameFileContainer
            {
                Path = @"data\pausepar\chapter.par",
                Type = ContainerType.CompressedFile
            };

            chapter.FileSearches.Add(dds1Search);

            var tableSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "*.bin",
                    IsWildcard = false,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.Table.File)
                };

            var dds2Search =
                new GameFileSearch
                {
                    RelativePath = @"picture\",
                    SearchPattern = "2d_mn_rom_continue.dds;2d_*.dds;head_pic_*.dds;kan_?.dds;ifc_jimaku_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(DDS2File)
                };

            var pause = new GameFileContainer
            {
                Path = @"data\pausepar\pause.par",
                Type = ContainerType.CompressedFile
            };

            pause.FileSearches.Add(tableSearch);
            pause.FileSearches.Add(dds2Search);

            var dds3Search =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "2d_jm_gp_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(DDS2File)
                };

            var tougijyo = new GameFileContainer
            {
                Path = @"data\pausepar\tougijyo.par",
                Type = ContainerType.CompressedFile
            };

            tougijyo.FileSearches.Add(dds3Search);

            var dds4Search =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "staffroll_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(DDS2File)
                };

            var staffroll = new GameFileContainer
            {
                Path = @"data\pausepar\staffroll.par",
                Type = ContainerType.CompressedFile
            };

            staffroll.FileSearches.Add(dds4Search);

            var dds5Search =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "rule_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(DDS2File)
                };

            var minigame = new GameFileContainer
            {
                Path = @"data\pausepar\minigame.par",
                Type = ContainerType.CompressedFile
            };

            minigame.FileSearches.Add(dds5Search);

            var dds6Search =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "2d_yk_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(DDS2File)
                };

            var equip_param = new GameFileContainer
            {
                Path = @"data\pausepar\equip_param.par",
                Type = ContainerType.CompressedFile
            };

            equip_param.FileSearches.Add(dds6Search);

            var result = new List<GameFileContainer>();
            result.Add(chapter);
            result.Add(pause);
            result.Add(tougijyo);
            result.Add(staffroll);
            result.Add(minigame);
            result.Add(equip_param);
            return result;
        }

        private GameFileContainer GetScenario()
        {

            var mailSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "mail.bin",
                    IsWildcard = false,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.Mail.File)
                };

            var search =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "scenario2.bin",
                    IsWildcard = false,
                    RecursiveSearch = false,
                    FileType = typeof(Files.Scenario.File)
                };

            var container = new GameFileContainer
            {
                Path = @"data\scenario",
                Type = ContainerType.Folder
            };

            container.FileSearches.Add(search);
            container.FileSearches.Add(mailSearch);
            return container;
        }

        private GameFileContainer GetStage()
        {
            var streetNameSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "street_name.dat",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.StreetName.File)
                };

            var stage = new GameFileContainer
            {
                Path = @"data\stage\ps3\flag_data",
                Type = ContainerType.Folder
            };

            stage.FileSearches.Add(streetNameSearch);
            return stage;
        }

        private GameFileContainer GetStaypar()
        {
            var tableSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "activity_list.bin;colosseum_participant.bin;commerce_*.bin;complete_haruka.bin;controller_explain.bin;correlation_*.bin;encount_loser_popup.bin;encounter_*.bin;explanation_soldier_mission.bin;farm_vegetable_list.bin;kyoukei_bird_param.bin;otazunemono.bin;pet_*.bin;response_chase.bin;response_roulette.bin;roulette_npc.bin;soldier_card_list.bin;soldier_leader_skill_list.bin;soldier_normal_skill_list.bin;soldier_training_mission.bin;tenkei_blog.bin;treasure_random_item.bin;tutorial.bin;ultimate.bin;virtue_shop_*.bin",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.Table.File)
                };

            var enemyNameSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "enemy_name_all.bin",
                    IsWildcard = false,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.EnemyName.File)
                };

            var par = new GameFileContainer
            {
                Path = @"data\staypar\stay.par",
                Type = ContainerType.CompressedFile
            };

            par.FileSearches.Add(tableSearch);
            par.FileSearches.Add(enemyNameSearch);
            return par;
        }

        private IList<GameFileContainer> Get2dpar(string path)
        {
            var result = new List<GameFileContainer>();

            var dds1Search =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "2d_cf_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(DDS2File),
                };

            var sprite = new GameFileContainer
            {
                Path = @"data\2dpar\sprite.par",
                Type = ContainerType.CompressedFile,
            };
            sprite.FileSearches.Add(dds1Search);

            result.Add(sprite);

            var dds2Search =
                new GameFileSearch
                {
                    RelativePath = "",
                    SearchPattern = "*.dds",
                    IsWildcard = false,
                    RecursiveSearch = true,
                    FileType = typeof(DDS2File),
                };

            var ui = new GameFileContainer
            {
                Path = @"data\2dpar\ui.par",
                Type = ContainerType.CompressedFile,
            };

            ui.FileSearches.Add(dds2Search);

            result.Add(ui);

            return result;
        }

        private GameFileContainer GetFontpar()
        {
            var ddsSearch =
                new GameFileSearch
                {
                    RelativePath = @".",
                    SearchPattern = "*_hankaku.dds",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(DDS2File),
                    Exclusions =
                    {
                        "item_hankaku.dds",
                        "ranking_hankaku.dds"
                    }
                };

            var fontpar = new GameFileContainer
            {
                Path = @"data\fontpar\font.par",
                Type = ContainerType.CompressedFile
            };
            fontpar.FileSearches.Add(ddsSearch);
            return fontpar;
        }

        private IList<GameFileContainer> GetMappar(string path)
        {
            var result = new List<GameFileContainer>();

            var imbSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "*.imb;*.dds",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(YakuzaGame.Files.Imb.File)
                };

            var map_par_containers = new GameFileContainerSearch
            {
                RelativePath = @"data\map_par",
                TypeSearch = ContainerType.CompressedFile,
                RecursiveSearch = false,
                SearchPattern = "map_cmn.par;st_gion.par;st_kyoto.par;st_mibudera.par;st_mibudera_soto.par;st_ryoma_ie.par;st_tosa.par"
            };
            map_par_containers.FileSearches.Add(imbSearch);

            result.AddRange(map_par_containers.GetContainers(path));
            return result;
        }

        private IList<GameFileContainer> GetMinigame()
        {
            var tableSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "fishing_battle.bin;fishing_dispose.bin;fishing_fish_info.bin;fishing_sao_info.bin;minigame_chohan_bakuto.bin;computer_*.bin",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(YakuzaGame.Files.Table.File)
                };

            var minigame = new GameFileContainer
            {
                Path = @"data\minigame",
                Type = ContainerType.Folder
            };

            minigame.FileSearches.Add(tableSearch);

            var ddsSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "2d_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(DDS2File)
                };

            var karaoke = new GameFileContainer
            {
                Path = @"data\minigame\karaoke.par",
                Type = ContainerType.CompressedFile
            };

            karaoke.FileSearches.Add(ddsSearch);

            var result = new List<GameFileContainer>();
            result.Add(minigame);
            result.Add(karaoke);
            return result;
        }

        private IList<GameFileContainer> GetAuth(string path)
        {
            var result = new List<GameFileContainer>();

            var cmnSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "cmn.bin",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(YakuzaGame.Files.CmnBin.JpnFile)
                };

            var ddsSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "ycap_*.dds",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(DDS2File)
                };

            var auth_containers = new GameFileContainerSearch
            {
                RelativePath = @"data\auth",
                TypeSearch = ContainerType.CompressedFile,
                RecursiveSearch = false,
                SearchPattern = "*.par"
            };
            auth_containers.FileSearches.Add(cmnSearch);
            auth_containers.FileSearches.Add(ddsSearch);

            result.AddRange(auth_containers.GetContainers(path));

            return result;
        }

        private GameFileContainer GetHact()
        {
            var cmnSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "cmn.bin",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(YakuzaGame.Files.CmnBin.JpnFile),
                };

            var hact = new GameFileContainer
            {
                Path = @"data\hact.par",
                Type = ContainerType.CompressedFile
            };

            hact.FileSearches.Add(cmnSearch);

            return hact;
        }

        private IList<GameFileContainer> GetWdrCommon()
        {
            var result = new List<GameFileContainer>();

            var aiPopupSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "ai_popup.bin",
                    IsWildcard = false,
                    RecursiveSearch = false,
                    FileType = typeof(Files.AiPopup.File)
                };

            var common_blacksmithSearch =
                new GameFileSearch
                {
                    RelativePath = "shop",
                    SearchPattern = "blacksmith.bin",
                    IsWildcard = false,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.Blacksmith.File)
                };

            var common_presentSearch =
                new GameFileSearch
                {
                    RelativePath = "shop",
                    SearchPattern = "present.bin;send.bin;throw.bin",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.PresentSendThrow.File)
                };

            var common_saleSearch =
                new GameFileSearch
                {
                    RelativePath = "shop",
                    SearchPattern = "sale????.bin",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.Sale.File)
                };

            var wdr_par_c_common = new GameFileContainer
            {
                Path = @"data\wdr_par\common.par",
                Type = ContainerType.CompressedFile
            };
            wdr_par_c_common.FileSearches.Add(aiPopupSearch);
            wdr_par_c_common.FileSearches.Add(common_blacksmithSearch);
            wdr_par_c_common.FileSearches.Add(common_presentSearch);
            wdr_par_c_common.FileSearches.Add(common_saleSearch);

            result.Add(wdr_par_c_common);

            return result;
        }

        private IList<GameFileContainer> GetWdr()
        {
            var result = new List<GameFileContainer>();

            var wdr_restaurantSearch =
                new GameFileSearch
                {
                    RelativePath = "shop",
                    SearchPattern = "restaurant????.bin;ex_shop????.bin;shop????.bin",
                    IsWildcard = true,
                    RecursiveSearch = false,
                    FileType = typeof(Files.Restaurant.File)
                };

            /*var disposeStringSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "dispose_string.bin",
                    IsWildcard = false,
                    RecursiveSearch = false,
                    FileType = typeof(YakuzaGame.Files.DisposeString.File)
                };

            var wdr_msgSearch =
                new GameFileSearch
                {
                    RelativePath = ".",
                    SearchPattern = "*.msg",
                    IsWildcard = true,
                    RecursiveSearch = true,
                    FileType = typeof(YakuzaGame.Files.Msg.File)
                };*/

            var wdr_par = new GameFileContainer
            {
                Path = @"data\wdr_par\wdr.par",
                Type = ContainerType.CompressedFile
            };

            //wdr_par.FileSearches.Add(disposeStringSearch);
            wdr_par.FileSearches.Add(wdr_restaurantSearch);
            //wdr_par.FileSearches.Add(wdr_msgSearch);

            result.Add(wdr_par);

            return result;
        }

        public override GameFileContainer[] GetContainers(string path)
        {
            var result = new List<GameFileContainer>();

            result.AddRange(Get2dpar(path));
            result.Add(GetAlife());
            /*result.Add(GetFontpar());*/
            result.Add(GetHact());
            result.AddRange(GetMappar(path));
            result.AddRange(GetMinigame());
            result.AddRange(GetAuth(path));
            result.Add(GetBootpar());
            result.AddRange(GetPause());
            result.Add(GetScenario());
            result.Add(GetStage());
            result.Add(GetStaypar());
            result.AddRange(GetWdrCommon());
            result.AddRange(GetWdr());

            result.Sort();
            return result.ToArray();
        }
    }
}

