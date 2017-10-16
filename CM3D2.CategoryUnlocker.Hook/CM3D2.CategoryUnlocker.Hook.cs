using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Inject;



namespace CM3D2.CategoryUnlocker.Hook
{

    public static class catmanager
    {
        //extended array for m_strDefSlotName field
        public static  string[] m_strDefSlotName = new string[]
  {
        "body",
        "_ROOT_",
        "IK",
        "head",
        "Bip01 Head",
        "Jyouhanshin",
        "eye",
        "Bip01 Head",
        "Jyouhanshin",
        "hairF",
        "Bip01 Head",
        "Jyouhanshin",
        "hairR",
        "Bip01 Head",
        "Jyouhanshin",
        "hairS",
        "Bip01 Head",
        "Jyouhanshin",
        "hairT",
        "Bip01 Head",
        "Jyouhanshin",
        "wear",
        "_ROOT_",
        "Uwagi",
        "skirt",
        "_ROOT_",
        "Kahanshin",
        "onepiece",
        "_ROOT_",
        "Kahanshin",
        "mizugi",
        "_ROOT_",
        "Kahanshin",
        "panz",
        "_ROOT_",
        "Kahanshin",
        "bra",
        "_ROOT_",
        "Jyouhanshin",
        "stkg",
        "_ROOT_",
        "Kahanshin",
        "shoes",
        "_ROOT_",
        "Kahanshin",
        "headset",
        "Bip01 Head",
        "Jyouhanshin",
        "glove",
        "_ROOT_",
        "Uwagi",
        "accHead",
        "Bip01 Head",
        "Jyouhanshin",
        "hairAho",
        "Bip01 Head",
        "Jyouhanshin",
        "accHana",
        "_ROOT_",
        "Jyouhanshin",
        "accHa",
        "Bip01 Head",
        "Jyouhanshin",
        "accKami_1_",
        "Bip01 Head",
        "Jyouhanshin",
        "accMiMiR",
        "Bip01 Head",
        "Jyouhanshin",
        "accKamiSubR",
        "Bip01 Head",
        "Jyouhanshin",
        "accNipR",
        "_ROOT_",
        "Uwagi",
        "HandItemR",
        "_IK_handR",
        "Uwagi",
        "accKubi",
        "Bip01 Spine1a",
        "Jyouhanshin",
        "accKubiwa",
        "Bip01 Neck",
        "Jyouhanshin",
        "accHeso",
        "Bip01 Head",
        "Jyouhanshin",
        "accUde",
        "_ROOT_",
        "Uwagi",
        "accAshi",
        "_ROOT_",
        "Uwagi",
        "accSenaka",
        "_ROOT_",
        "Uwagi",
        "accShippo",
        "Bip01 Spine",
        "Uwagi",
        "accAnl",
        "_ROOT_",
        "Uwagi",
        "accVag",
        "_ROOT_",
        "Uwagi",
        "kubiwa",
        "_ROOT_",
        "Uwagi",
        "megane",
        "Bip01 Head",
        "Jyouhanshin",
        "accXXX",
        "_ROOT_",
        "Uwagi",
        "chinko",
        "Bip01 Pelvis",
        "Uwagi",
        "chikubi",
        "_ROOT_",
        "Jyouhanshin",
        "accHat",
        "Bip01 Head",
        "Jyouhanshin",
        "kousoku_upper",
        "_ROOT_",
        "Uwagi",
        "kousoku_lower",
        "_ROOT_",
        "Kahanshin",
        "seieki_naka",
        "_ROOT_",
        "Uwagi",
        "seieki_hara",
        "_ROOT_",
        "Uwagi",
        "seieki_face",
        "_ROOT_",
        "Uwagi",
        "seieki_mune",
        "_ROOT_",
        "Uwagi",
        "seieki_hip",
        "_ROOT_",
        "Uwagi",
        "seieki_ude",
        "_ROOT_",
        "Uwagi",
        "seieki_ashi",
        "_ROOT_",
        "Uwagi",
        "accNipL",
        "_ROOT_",
        "Uwagi",
        "accMiMiL",
        "Bip01 Head",
        "Jyouhanshin",
        "accKamiSubL",
        "Bip01 Head",
        "Jyouhanshin",
        "accKami_2_",
        "Bip01 Head",
        "Jyouhanshin",
        "accKami_3_",
        "Bip01 Head",
        "Jyouhanshin",
        "HandItemL",
        "_IK_handL",
        "Uwagi",
        "underhair",
        "_ROOT_",
        "Kahanshin",
        "moza",
        "_ROOT_",
        "Kahanshin",
        /// start of new modelslots
        "nails",
        "_ROOT_",
        "Jyouhanshin",
        ///modelslot sample
      "toenails",
    "_ROOT_",
    "Jyouhanshin",
     "general1a",
     "_ROOT_",
     "Jyouhanshin",
     "general1b",
     "_ROOT_",
     "Jyouhanshin",
     "general2a",
     "_ROOT_",
     "Jyouhanshin",
     "general2b",
     "_ROOT_",
     "Jyouhanshin",
     "general3a",
     "_ROOT_",
     "Jyouhanshin",
     "general3b",
     "_ROOT_",
     "Jyouhanshin",
     "general4a",
     "_ROOT_",
     "Jyouhanshin",
     "general4b",
     "_ROOT_",
     "Jyouhanshin",
     "general5a",
     "_ROOT_",
     "Jyouhanshin",
     "general5b",
     "_ROOT_",
     "Jyouhanshin",
     "general6a",
     "_ROOT_",
     "Jyouhanshin",
     "general6b",
     "_ROOT_",
     "Jyouhanshin",
     "general7a",
     "_ROOT_",
     "Jyouhanshin",
     "general7b",
     "_ROOT_",
     "Jyouhanshin",

        "end"
  };
        // method for adding new MPN's to scene editinfo. this method requires pre-patched Assembly-Charp.dll to work
        public static void loadcustomcats()
        {

            //head categories

            //folder_2
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.folder_eye2,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 8,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.頭,
                m_ePartsType = SceneEditInfo.EMenuPartsType.folder_eye2,
                m_strBtnPartsTypeName = "EYE2"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.folder_eye2, TBody.MaskMode.None);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

                MPN.folder_eye2,
            new SceneEditInfo.CamToBone
            {
                bone = "Bip01 Head",
                angle = new Vector2(-180f, 4.7f),
                distance = 1f
            }
            );
            // eye2
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.eye2,
			new SceneEditInfo.CCateNameType
            {
                m_nIdx = 0,
                m_eType = SceneEditInfo.CCateNameType.EType.Color,
                m_eMenuCate = SceneEditInfo.EMenuCategory.頭,
                m_ePartsType = SceneEditInfo.EMenuPartsType.eye2,
                m_strBtnPartsTypeName = "EYE2"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.eye2, TBody.MaskMode.None);
            SceneEditInfo.m_dicPartsTypeCamera.Add(
        
                MPN.eye2, 
            new SceneEditInfo.CamToBone
            {
                bone = "Bip01 Head",
                angle = new Vector2(-180f, 4.7f),
                distance = 1f
            }
            );

            // makeup 1
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.makeup1,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 9,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.頭,
                m_ePartsType = SceneEditInfo.EMenuPartsType.makeup1,
                m_strBtnPartsTypeName = "MAKEUP1"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.makeup1, TBody.MaskMode.None);
            SceneEditInfo.m_dicPartsTypeCamera.Add(
               
                MPN.makeup1,
            new SceneEditInfo.CamToBone
            {
                bone = "Bip01 Head",
                angle = new Vector2(-180f, 4.7f),
                distance = 1f
            }        
            );


            // makeup 2
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.makeup2,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 10,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.頭,
                m_ePartsType = SceneEditInfo.EMenuPartsType.makeup2,
                m_strBtnPartsTypeName = "MAKEUP2"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.makeup2, TBody.MaskMode.None);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

                MPN.makeup2,
            new SceneEditInfo.CamToBone
            {
                bone = "Bip01 Head",
                angle = new Vector2(-180f, 4.7f),
                distance = 1f
            }
            );

            // body categories

            // tattoo2 
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.acctatoo2,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 25,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.身体,
                m_ePartsType = SceneEditInfo.EMenuPartsType.acctatoo2,
                m_strBtnPartsTypeName = "TATTOO2"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.acctatoo2, TBody.MaskMode.Nude);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

            MPN.acctatoo2,
            new SceneEditInfo.CamToBone
            {
                bone = string.Empty,
                angle = new Vector2(-180f, 9.3f),
                distance = 2.89f
            }
            );

            // tattoo3 
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.acctatoo3,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 26,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.身体,
                m_ePartsType = SceneEditInfo.EMenuPartsType.acctatoo3,
                m_strBtnPartsTypeName = "TATTOO3"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.acctatoo3, TBody.MaskMode.Nude);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

            MPN.acctatoo3,
            new SceneEditInfo.CamToBone
            {
                bone = string.Empty,
                angle = new Vector2(-180f, 9.3f),
                distance = 2.89f
            }
            );

            //nails
            
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.nails,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 27,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.身体,
                m_ePartsType = SceneEditInfo.EMenuPartsType.nails,
                m_strBtnPartsTypeName = "NAILS"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.nails, TBody.MaskMode.None);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

            MPN.nails,
            new SceneEditInfo.CamToBone
            {
                bone = "Bip01 L Hand",
                angle = new Vector2(-180f, 5.6f),
                distance = 1.5f
            }
            );

            //toenails

            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.toenails,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 28,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.身体,
                m_ePartsType = SceneEditInfo.EMenuPartsType.toenails,
                m_strBtnPartsTypeName = "TOENAILS"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.toenails, TBody.MaskMode.Nude);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

            MPN.toenails,
            new SceneEditInfo.CamToBone
            {
                bone = "Bip01 R Foot",
                angle = new Vector2(-180f, 27.7f),
                distance = 2.2f
            }
            );

            //skintoon
            SceneEditInfo.m_dicPartsTypePair.Add(
                MPN.skintoon,
            new SceneEditInfo.CCateNameType
            {
                m_nIdx = 29,
                m_eType = SceneEditInfo.CCateNameType.EType.Item,
                m_eMenuCate = SceneEditInfo.EMenuCategory.身体,
                m_ePartsType = SceneEditInfo.EMenuPartsType.skintoon,
                m_strBtnPartsTypeName = "SKINTOON"
            }
            );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.skintoon, TBody.MaskMode.Nude);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

            MPN.skintoon,
            new SceneEditInfo.CamToBone
            {
                bone = string.Empty,
                angle = new Vector2(-180f, 9.3f),
                distance = 2.89f
            }
            );

            //body
            SceneEditInfo.m_dicPartsTypePair.Add(
                 MPN.body,
             new SceneEditInfo.CCateNameType
             {
                 m_nIdx = 30,
                 m_eType = SceneEditInfo.CCateNameType.EType.Item,
                 m_eMenuCate = SceneEditInfo.EMenuCategory.身体,
                 m_ePartsType = SceneEditInfo.EMenuPartsType.body,
                 m_strBtnPartsTypeName = "BODY"
             }
             );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.body, TBody.MaskMode.Nude);
            SceneEditInfo.m_dicPartsTypeCamera.Add(

            MPN.body,
            new SceneEditInfo.CamToBone
            {
                bone = string.Empty,
                angle = new Vector2(-180f, 9.3f),
                distance = 2.89f
            }
            );


            //general categories 
            //add general1
            SceneEditInfo.m_dicPartsTypePair.Add
            (

               MPN.general1,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 16,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.general1,

               m_strBtnPartsTypeName = "GENERAL1"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.general1,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.general1,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }


                );

            //general 2
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.general2,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 17,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.general2,

               m_strBtnPartsTypeName = "GENERAL2"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.general2,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.general2,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );



            //general1 3
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.general3,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 18,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.general3,

               m_strBtnPartsTypeName = "GENERAL3"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.general3,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.general3,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );

            
            // general 4
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.general4,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 19,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.general4,

               m_strBtnPartsTypeName = "GENERAL4"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.general4,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.general4,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );



            // general 5
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.general5,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 20,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.general5,

               m_strBtnPartsTypeName = "GENERAL5"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.general5,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.general5,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );

            // general 6
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.general6,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 21,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.general6,

               m_strBtnPartsTypeName = "GENERAL6"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.general6,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.general6,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );


            // general 7
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.general7,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 22,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.general7,

               m_strBtnPartsTypeName = "GENERAL7"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.general7,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.general7,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );


        }


        //register del menu in CM3 class
        public static void delmenuadder()
        {
            CM3.dicDelItem[MPN.general1] = "_I_general1_del.menu";
            CM3.dicDelItem[MPN.general2] = "_I_general2_del.menu";
            CM3.dicDelItem[MPN.general3] = "_i_general3_del.menu";
            CM3.dicDelItem[MPN.general4] = "_I_general4_del.menu";
            CM3.dicDelItem[MPN.general5] = "_I_general5_del.menu";
            CM3.dicDelItem[MPN.general6] = "_I_general6_del.menu";
            CM3.dicDelItem[MPN.general7] = "_I_general7_del.menu";

            CM3.dicDelItem[MPN.makeup1] = "_i_makeup1_del.menu";
            CM3.dicDelItem[MPN.makeup2] = "_i_makeup2_del.menu";
            CM3.dicDelItem[MPN.nails] = "_I_nails_del.menu";
            CM3.dicDelItem[MPN.toenails] = "_I_toenails_del.menu";
            CM3.dicDelItem[MPN.acctatoo2] = "_i_acctatoo2_del.menu";
            CM3.dicDelItem[MPN.acctatoo3] = "_i_acctatoo3_del.menu";
            CM3.dicDelItem[MPN.folder_eye2] = "_I_folder_eye2_del.menu";
            CM3.dicDelItem[MPN.body] = "body001_i_.menu";

        }

        // add more MPN's to preset set method
        public static void ExtSet(Maid f_maid, CharacterMgr.Preset f_prest)
        {
            global::MaidProp[] array;

            if (f_prest.ePreType == global::CharacterMgr.PresetType.Body || f_prest.ePreType == global::CharacterMgr.PresetType.All)
            {
                array = (from mp in f_prest.listMprop
                         where 88 <= mp.idx && mp.idx <= 96
                         select mp).ToArray<global::MaidProp>();
            }
          else  if (f_prest.ePreType == global::CharacterMgr.PresetType.Wear || f_prest.ePreType == global::CharacterMgr.PresetType.All)
            {
                array = (from mp in f_prest.listMprop
                         where 97 <= mp.idx && mp.idx <= 103
                         select mp).ToArray<global::MaidProp>();
            }

            else
            { array = null; }

            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    global::MaidProp maidProp = array[i];
                    if (maidProp.idx != 23)
                    {
                        f_maid.SetProp((global::MPN)maidProp.idx, maidProp.value, false);
                        if (string.IsNullOrEmpty(maidProp.strFileName))
                        {
                            string strFileName = maidProp.strFileName;
                            if (global::CM3.dicDelItem.TryGetValue((global::MPN)maidProp.idx, out strFileName))
                            {
                                maidProp.strFileName = strFileName;
                            }
                        }
                        f_maid.SetProp((global::MPN)maidProp.idx, maidProp.strFileName, 0, false);
                        if (global::CharacterMgr.EditModeLookHaveItem && !global::GameMain.Instance.CharacterMgr.GetPlayerParam().status.IsHaveItem(maidProp.strFileName))
                        {
                            f_maid.DelProp((global::MPN)maidProp.idx, false);
                        }
                    }
                }
            }

            
        }

        // method for modifying m_strDefSlotName filed. this method requires pre-patched Assembly-Charp.dll
        // that has this field witout IsInitOnly attribute
        public static void slotext()
        {

            TBody.m_strDefSlotName = m_strDefSlotName;
        }


        // extend CreateInitMaidPropList  so game won't go derp when new MPN field is added.
        //this method requires pre-patched Assembly-Charp.dll to work
        public static bool  maidpropext( out List<MaidProp> result )
        {
            result = new  List <MaidProp> 
        {
            Maid.CreateProp(0, 2147483647, 0, MPN.null_mpn, 0),
            Maid.CreateProp(0, 130, 10, MPN.MuneL, 1),
            Maid.CreateProp(0, 130, 10, MPN.MuneTare, 1),
            Maid.CreateProp(0, 100, 40, MPN.RegFat, 1),
            Maid.CreateProp(0, 100, 20, MPN.ArmL, 1),
            Maid.CreateProp(0, 100, 20, MPN.Hara, 1),
            Maid.CreateProp(0, 100, 40, MPN.RegMeet, 1),
            Maid.CreateProp(20, 80, 50, MPN.KubiScl, 2),
            Maid.CreateProp(0, 100, 50, MPN.UdeScl, 2),
            Maid.CreateProp(0, 100, 50, MPN.EyeScl, 2),
            Maid.CreateProp(0, 100, 50, MPN.EyeSclX, 2),
            Maid.CreateProp(0, 100, 50, MPN.EyeSclY, 2),
            Maid.CreateProp(0, 100, 50, MPN.EyePosX, 2),
            Maid.CreateProp(0, 100, 50, MPN.EyePosY, 2),
            Maid.CreateProp(0, 100, 50, MPN.HeadX, 2),
            Maid.CreateProp(0, 100, 50, MPN.HeadY, 2),
            Maid.CreateProp(20, 80, 50, MPN.DouPer, 2),
            Maid.CreateProp(20, 80, 50, MPN.sintyou, 2),
            Maid.CreateProp(0, 100, 50, MPN.koshi, 2),
            Maid.CreateProp(0, 100, 50, MPN.kata, 2),
            Maid.CreateProp(0, 100, 50, MPN.west, 2),
            Maid.CreateProp(0, 100, 10, MPN.MuneUpDown, 2),
            Maid.CreateProp(0, 100, 40, MPN.MuneYori, 2),
            Maid.CreateProp(string.Empty, MPN.body, 3),
            Maid.CreateProp(string.Empty, MPN.head, 3),
            Maid.CreateProp(string.Empty, MPN.hairf, 3),
            Maid.CreateProp(string.Empty, MPN.hairr, 3),
            Maid.CreateProp(string.Empty, MPN.hairt, 3),
            Maid.CreateProp(string.Empty, MPN.hairs, 3),
            Maid.CreateProp(string.Empty, MPN.wear, 3),
            Maid.CreateProp(string.Empty, MPN.skirt, 3),
            Maid.CreateProp(string.Empty, MPN.mizugi, 3),
            Maid.CreateProp(string.Empty, MPN.bra, 3),
            Maid.CreateProp(string.Empty, MPN.panz, 3),
            Maid.CreateProp(string.Empty, MPN.stkg, 3),
            Maid.CreateProp(string.Empty, MPN.shoes, 3),
            Maid.CreateProp(string.Empty, MPN.headset, 3),
            Maid.CreateProp(string.Empty, MPN.glove, 3),
            Maid.CreateProp(string.Empty, MPN.acchead, 3),
            Maid.CreateProp(string.Empty, MPN.hairaho, 3),
            Maid.CreateProp(string.Empty, MPN.accha, 3),
            Maid.CreateProp(string.Empty, MPN.acchana, 3),
            Maid.CreateProp(string.Empty, MPN.acckamisub, 3),
            Maid.CreateProp(string.Empty, MPN.acckami, 3),
            Maid.CreateProp(string.Empty, MPN.accmimi, 3),
            Maid.CreateProp(string.Empty, MPN.accnip, 3),
            Maid.CreateProp(string.Empty, MPN.acckubi, 3),
            Maid.CreateProp(string.Empty, MPN.acckubiwa, 3),
            Maid.CreateProp(string.Empty, MPN.accheso, 3),
            Maid.CreateProp(string.Empty, MPN.accude, 3),
            Maid.CreateProp(string.Empty, MPN.accashi, 3),
            Maid.CreateProp(string.Empty, MPN.accsenaka, 3),
            Maid.CreateProp(string.Empty, MPN.accshippo, 3),
            Maid.CreateProp(string.Empty, MPN.accanl, 3),
            Maid.CreateProp(string.Empty, MPN.accvag, 3),
            Maid.CreateProp(string.Empty, MPN.megane, 3),
            Maid.CreateProp(string.Empty, MPN.accxxx, 3),
            Maid.CreateProp(string.Empty, MPN.handitem, 3),
            Maid.CreateProp(string.Empty, MPN.acchat, 3),
            Maid.CreateProp(string.Empty, MPN.haircolor, 3),
            Maid.CreateProp(string.Empty, MPN.skin, 3),
            Maid.CreateProp(string.Empty, MPN.acctatoo, 3),
            Maid.CreateProp(string.Empty, MPN.underhair, 3),
            Maid.CreateProp(string.Empty, MPN.hokuro, 3),
            Maid.CreateProp(string.Empty, MPN.mayu, 3),
            Maid.CreateProp(string.Empty, MPN.lip, 3),
            Maid.CreateProp(string.Empty, MPN.eye, 3),
            Maid.CreateProp(string.Empty, MPN.eye_hi, 3),
            Maid.CreateProp(string.Empty, MPN.chikubi, 3),
            Maid.CreateProp(string.Empty, MPN.chikubicolor, 3),
            Maid.CreateProp(string.Empty, MPN.moza, 3),
            Maid.CreateProp(string.Empty, MPN.onepiece, 3),
            Maid.CreateProp(string.Empty, MPN.set_maidwear, 3),
            Maid.CreateProp(string.Empty, MPN.set_mywear, 3),
            Maid.CreateProp(string.Empty, MPN.set_underwear, 3),
            Maid.CreateProp(string.Empty, MPN.folder_eye, 3),
            Maid.CreateProp(string.Empty, MPN.folder_mayu, 3),
            Maid.CreateProp(string.Empty, MPN.folder_underhair, 3),
            Maid.CreateProp(string.Empty, MPN.folder_skin, 3),
            Maid.CreateProp(string.Empty, MPN.kousoku_upper, 3),
            Maid.CreateProp(string.Empty, MPN.kousoku_lower, 3),
            Maid.CreateProp(string.Empty, MPN.seieki_naka, 3),
            Maid.CreateProp(string.Empty, MPN.seieki_hara, 3),
            Maid.CreateProp(string.Empty, MPN.seieki_face, 3),
            Maid.CreateProp(string.Empty, MPN.seieki_mune, 3),
            Maid.CreateProp(string.Empty, MPN.seieki_hip, 3),
            Maid.CreateProp(string.Empty, MPN.seieki_ude, 3),
            Maid.CreateProp(string.Empty, MPN.seieki_ashi, 3),
            Maid.CreateProp(string.Empty, MPN.folder_eye2, 3),
            Maid.CreateProp(string.Empty, MPN.eye2, 3),
            Maid.CreateProp(string.Empty, MPN.makeup1, 3),
            Maid.CreateProp(string.Empty, MPN.makeup2, 3),
            Maid.CreateProp(string.Empty, MPN.acctatoo2, 3),
            Maid.CreateProp(string.Empty, MPN.acctatoo3, 3),
            Maid.CreateProp(string.Empty, MPN.nails, 3),
            Maid.CreateProp(string.Empty, MPN.toenails, 3),
            Maid.CreateProp(string.Empty, MPN.skintoon, 3),
            Maid.CreateProp(string.Empty, MPN.general1, 3),
            Maid.CreateProp(string.Empty, MPN.general2, 3),
            Maid.CreateProp(string.Empty, MPN.general3, 3),
            Maid.CreateProp(string.Empty, MPN.general4, 3),
            Maid.CreateProp(string.Empty, MPN.general5, 3),
            Maid.CreateProp(string.Empty, MPN.general6, 3),
            Maid.CreateProp(string.Empty, MPN.general7, 3),

        };
            return result != null;
        }


        // method for injecting MPN's to Maid.AllProcProp and Maid.AllPropcPropSeq
        public static void allprocext(Maid maid, ref MaidProp maidProp)
        {
        if    (maidProp.type == 3 )  {
                if (maidProp.idx == 25)
                {
                    maid.GetProp(MPN.eye2).boDut = true;

                }
                else if (maidProp.idx == 31)
                {

                    maid.GetProp(MPN.makeup1).boDut = true;
                    maid.GetProp(MPN.makeup2).boDut = true;
                    maid.GetProp(MPN.acctatoo2).boDut = true;
                    maid.GetProp(MPN.acctatoo3).boDut = true;
                    maid.GetProp(MPN.acctatoo2).boDut = true;
                    maid.GetProp(MPN.skintoon).boDut = true;

                }
                else if (maidProp.idx == 23)
                {
                    maid.GetProp(MPN.head).boDut = true;
                    maid.GetProp(MPN.hairf).boDut = true;
                    maid.GetProp(MPN.hairr).boDut = true;
                    maid.GetProp(MPN.hairt).boDut = true;
                    maid.GetProp(MPN.hairs).boDut = true;
                    maid.GetProp(MPN.wear).boDut = true;
                    maid.GetProp(MPN.skirt).boDut = true;
                    maid.GetProp(MPN.mizugi).boDut = true;
                    maid.GetProp(MPN.bra).boDut = true;
                    maid.GetProp(MPN.panz).boDut = true;
                    maid.GetProp(MPN.stkg).boDut = true;
                    maid.GetProp(MPN.shoes).boDut = true;
                    maid.GetProp(MPN.headset).boDut = true;
                    maid.GetProp(MPN.glove).boDut = true;
                    maid.GetProp(MPN.acchead).boDut = true;
                    maid.GetProp(MPN.hairaho).boDut = true;
                    maid.GetProp(MPN.accha).boDut = true;
                    maid.GetProp(MPN.acchana).boDut = true;
                    maid.GetProp(MPN.acckamisub).boDut = true;
                    maid.GetProp(MPN.acckami).boDut = true;
                    maid.GetProp(MPN.accmimi).boDut = true;
                    maid.GetProp(MPN.accnip).boDut = true;
                    maid.GetProp(MPN.acckubi).boDut = true;
                    maid.GetProp(MPN.acckubiwa).boDut = true;
                    maid.GetProp(MPN.accheso).boDut = true;
                    maid.GetProp(MPN.accude).boDut = true;
                    maid.GetProp(MPN.accashi).boDut = true;
                    maid.GetProp(MPN.accsenaka).boDut = true;
                    maid.GetProp(MPN.accshippo).boDut = true;
                    maid.GetProp(MPN.accanl).boDut = true;
                    maid.GetProp(MPN.accvag).boDut = true;
                    maid.GetProp(MPN.megane).boDut = true;
                    maid.GetProp(MPN.accxxx).boDut = true;
                    maid.GetProp(MPN.handitem).boDut = true;
                    maid.GetProp(MPN.acchat).boDut = true;
                    maid.GetProp(MPN.underhair).boDut = true;
                    maid.GetProp(MPN.chikubi).boDut = true;
                    maid.GetProp(MPN.chikubicolor).boDut = true;
                    maid.GetProp(MPN.moza).boDut = true;
                    maid.GetProp(MPN.onepiece).boDut = true;
                    maid.GetProp(MPN.folder_underhair).boDut = true;
                    maid.GetProp(MPN.eye2).boDut = true;
                    maid.GetProp(MPN.nails).boDut = true;
                    maid.GetProp(MPN.toenails).boDut = true;
                    maid.GetProp(MPN.skintoon).boDut = true;
                    maid.GetProp(MPN.general1).boDut = true;
                    maid.GetProp(MPN.general2).boDut = true;
                    maid.GetProp(MPN.general3).boDut = true;
                    maid.GetProp(MPN.general4).boDut = true;
                    maid.GetProp(MPN.general5).boDut = true;
                    maid.GetProp(MPN.general6).boDut = true;
                    maid.GetProp(MPN.general7).boDut = true;
                }

           }
        }


    }
}

