#region Copyright (c) 2014-2015 aaaCcchaj All Rights Reserved
/*********************************************************************************************
*文件名：	CommonXMLTools.cs
*创建日期：2014-09-05
*作者：	aaaCcchaj
*版本：	1.0
*说明：	通用的XML文件加载类
*----------------------------------------------------------------------------------------------
*修改记录：
*日期			版本	修改人	修改内容

********************************************************************************************/
#endregion Copyright (c) 2014-2015 aaaCcchaj All Rights Reserved
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Common.Tools;

namespace Common.Tools
{
    /// <summary>
    /// 通用的XML文件加载类
    /// </summary>
    public class CommonXMLTools
    {

        /// <summary>
        ///从XML文件中创建对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static bool CreateFromXML<T>(string filePath, out T reader) where T : class,ILinqXmlReadSerializable, new()
        {
            reader = new T();
            if (!File.Exists(filePath))
            {
                throw new Exception(string.Format("要加载的文件{0}不存在", filePath));
                return false;
            }

            try
            {
                XDocument doc = XDocument.Load(filePath);
                Debug.Assert(doc != null);
                Debug.Assert(doc.Root != null);
                XElement root = doc.Root;
                reader.ReadXml(root);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("读取XML文件错误:{0}", e.Message));
            }
            return false;
        }

        /// <summary>
        /// 读取指定XML文件的配置信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static bool ReadFromXML(string filePath, ILinqXmlReadSerializable reader)
        {
            if (reader == null)
                return false;
            if (!File.Exists(filePath))
            {
                throw new Exception(string.Format("要加载的文件{0}不存在", filePath));
                return false;
            }

            try
            {
                XDocument doc = XDocument.Load(filePath);
                Debug.Assert(doc != null);
                Debug.Assert(doc.Root != null);
                XElement root = doc.Root;
                reader.ReadXml(root);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("读取XML文件错误:{0}", e.Message));
            }
            return false;
        }

 

        /// <summary>
        /// 读取指定XML文件的配置信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static bool WriteToXML(string filePath, ILinqXmlWriteSerializable writer)
        {
            if (writer == null)
                return false;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {
                XDocument doc = new XDocument();
                if (doc.Root == null)
                {
                    doc.Add(new XElement("Root"));
                }
                XElement root = doc.Root;
                writer.WriteXml(root);
                doc.Save(filePath);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("写入XML文件错误:{0}", e.Message));
            }
            return false;
        }

    }
}

