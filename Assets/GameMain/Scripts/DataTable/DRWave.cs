﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2020-07-12 13:00:24.338
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Flower
{
    /// <summary>
    /// 敌人波次配置表。
    /// </summary>
    public class DRWave : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取波次编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取波次结束等待时间。
        /// </summary>
        public float FinishWaitTIme
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取敌人波次元素ID范围。
        /// </summary>
        public int[] WaveElements
        {
            get;
            private set;
        }

        public override bool ParseDataRow(GameFrameworkDataSegment dataRowSegment, object dataTableUserData)
        {
            Type dataType = dataRowSegment.DataType;
            if (dataType == typeof(string))
            {
                string[] columnTexts = ((string)dataRowSegment.Data).Substring(dataRowSegment.Offset, dataRowSegment.Length).Split(DataTableExtension.DataSplitSeparators);
                for (int i = 0; i < columnTexts.Length; i++)
                {
                    columnTexts[i] = columnTexts[i].Trim(DataTableExtension.DataTrimSeparators);
                }

                int index = 0;
                index++;
                m_Id = int.Parse(columnTexts[index++]);
                index++;
                FinishWaitTIme = float.Parse(columnTexts[index++]);
                WaveElements = DataTableExtension.ParseInt32Array(columnTexts[index++]);
            }
            else if (dataType == typeof(byte[]))
            {
                string[] strings = (string[])dataTableUserData;
                using (MemoryStream memoryStream = new MemoryStream((byte[])dataRowSegment.Data, dataRowSegment.Offset, dataRowSegment.Length, false))
                {
                    using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                    {
                        m_Id = binaryReader.Read7BitEncodedInt32();
                        FinishWaitTIme = binaryReader.ReadSingle();
                        WaveElements = binaryReader.ReadInt32Array();
                    }
                }
            }
            else
            {
                Log.Warning("Can not parse data row which type '{0}' is invalid.", dataType.FullName);
                return false;
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
