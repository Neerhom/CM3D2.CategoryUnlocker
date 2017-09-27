using System;
using System.Collections.Generic;
using UnityEngine;

namespace CM3D2.CategoryUnlocker.Hook
{

    public static class catmanager
    {

        public static void loadcustomcats()
        {
            //add seieki_ashi
            SceneEditInfo.m_dicPartsTypePair.Add
            (

               MPN.seieki_ashi,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 16,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.head_brow,

               m_strBtnPartsTypeName = "S_Ashi"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.seieki_ashi,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.seieki_ashi,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }


                );

            //seieki_face
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.seieki_face,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 17,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.head_eye,

               m_strBtnPartsTypeName = "S_Face"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.seieki_face,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.seieki_face,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );



            //seieki_hara
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.seieki_hara,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 18,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.head_eye_hi,

               m_strBtnPartsTypeName = "S_Hara"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.seieki_hara,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.seieki_hara,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );



            //seieki_hip
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.seieki_hip,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 19,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.head_head_slider,

               m_strBtnPartsTypeName = "S_Hip"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.seieki_hip,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.seieki_hip,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );



            //seieki_mune
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.seieki_mune,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 20,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.body_all_slider,

               m_strBtnPartsTypeName = "S_Mune"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.seieki_mune,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.seieki_mune,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );

            //seieki_naka
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.seieki_naka,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 21,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.head_lip,

               m_strBtnPartsTypeName = "S_Naka"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.seieki_naka,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.seieki_naka,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );


            //seieki_ude
            SceneEditInfo.m_dicPartsTypePair.Add
                (

               MPN.seieki_ude,
           new SceneEditInfo.CCateNameType
           {
               m_nIdx = 22,
               m_eType = SceneEditInfo.CCateNameType.EType.Item,
               m_eMenuCate = SceneEditInfo.EMenuCategory.服装,
               m_ePartsType = SceneEditInfo.EMenuPartsType.head_mole,

               m_strBtnPartsTypeName = "S_Ude"
           }
           );

            SceneEditInfo.m_dicPartsTypeWearMode.Add(MPN.seieki_ude,
            TBody.MaskMode.None);


            SceneEditInfo.m_dicPartsTypeCamera.Add
            (

                MPN.seieki_ude,
                new SceneEditInfo.CamToBone
                {
                    bone = string.Empty,
                    angle = new Vector2(-180f, 9.3f),
                    distance = 2.89f
                }

                );


        }

    

    public static void delmenuadder()
    {
            CM3.dicDelItem[MPN.seieki_ashi] = "_I_seieki_ashi_del.menu";
            CM3.dicDelItem[MPN.seieki_face] = "_I_seieki_face_del.menu";
            CM3.dicDelItem[MPN.seieki_hara] = "_I_seieki_hara_del.menu";
            CM3.dicDelItem[MPN.seieki_hip] = "_I_seieki_hip_del.menu";
            CM3.dicDelItem[MPN.seieki_mune] = "_I_seieki_mune_del.menu";
            CM3.dicDelItem[MPN.seieki_naka] = "_I_seieki_naka_del.menu";
            CM3.dicDelItem[MPN.seieki_ude] = "_I_seieki_ude_del.menu";
        }

public static void ExtSet (global::Maid f_maid, global::CharacterMgr.Preset f_prest)
        {
            global::MaidProp[] array;
            
            if (f_prest.ePreType == global::CharacterMgr.PresetType.Wear || f_prest.ePreType == global::CharacterMgr.PresetType.All)
            {
                array = (from mp in f_prest.listMprop
                         where 81 <= mp.idx && mp.idx <= 87
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

}
}

