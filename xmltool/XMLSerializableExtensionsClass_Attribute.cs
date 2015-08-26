#region Copyright (c) 2014-2014 aaaCcchaj All Rights Reserved
/*********************************************************************************************
*文件名：	XMLSerializableExtensionsClass.cs
*创建日期：2014-09-04
*作者：	aaaCcchaj
*版本：	1.0
*说明：	 扩展微软的数据类
             为其添加XML属性的保存、加载方法
*----------------------------------------------------------------------------------------------
*修改记录：
*日期			版本	修改人	修改内容

********************************************************************************************/
#endregion Copyright (c) 2014-2014 aaaCcchaj All Rights Reserved

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace Common.Tools
{
    /// <summary>
    /// 扩展微软的数据类
    /// 为其添加XML的保存、加载方法
    /// </summary>
    public static class XMLSerializableExtensionsAttributeClass
    {
        static XMLSerializableExtensionsAttributeClass()
        {
        }


        /// <summary>
        /// 写泛型(基本类型)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="recname"></param>
        /// <param name="strval"></param>
        public static void Write<T>(this  XElement node, string recname, T strval) where T : IComparable<T>, IConvertible, IComparable, IEquatable<T>
        {
            node.SetAttributeValue(recname, strval);
        }

        /// <summary>
        /// 读取泛型(基本类型)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="recname"></param>
        /// <param name="strval"></param>
        /// <returns></returns>
        public static T Read<T>(this  XElement node, string recname, T strval) where T : IComparable<T>, IConvertible, IComparable, IEquatable<T>
        {
            var xElement = node.Attribute(recname);
            return xElement != null ? (T)Convert.ChangeType(xElement.Value, typeof(T)) : strval;
        }

        #region .....Guid.....
        /// <summary>
        /// 将对象转换为XML表示形式。
        /// </summary>
        /// <param name="guid">需要转化为Xml的对象.</param>
        /// <param name="node">XML节点。</param>
        /// <param name="strAtt">XML节点的属性名称。</param>
        public static void WriteAttr(this XElement node, string strAtt, Guid guid)
        {
            node.SetAttributeValue(strAtt, guid);
        }
        /// <summary>
        /// 将对象转换为XML表示形式。
        /// </summary>
        /// <param name="node">XML节点。</param>
        /// <param name="strAtt">XML节点的属性名称。</param>
        public static Guid ReadGuid(this XElement node, string strAtt)
        {
            var nodeatt = node.Attribute(strAtt);
            if (nodeatt != null)
            {
                string st = nodeatt.Value;
                var obj = new Guid(st);
                return obj;
            }

            return Guid.Empty;
        }
        #endregion .....Guid.....

        #region .....Version.....
        /// <summary>
        /// 将对象转换为XML表示形式。
        /// </summary>
        /// <param name="obj">需要转化为Xml的对象</param>
        /// <param name="node">XML节点</param>
        /// <param name="strAtt">XML节点的属性名称。</param>
        public static void WriteAttr(this XElement node, string strAtt, Version obj)
        {
            node.SetAttributeValue(strAtt, obj);
        }

        /// <summary>
        /// 将对象转换为XML表示形式。
        /// </summary>
        /// <param name="node">XML节点。</param>
        /// <param name="strAtt">XML节点的属性名称。</param>
        public static Version ReadVersion(this XElement node, string strAtt)
        {
            var nodeatt = node.Attribute(strAtt);
            if (nodeatt != null)
            {
                string st = nodeatt.Value;
                var obj = new Version(st);
                return obj;
            }

            return new Version();
        }
        #endregion .....Version.....

        #region .....string.....
        /// <summary>
        /// 从XML元素node中读取xName指定的string值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ReadStringAttr(this XElement node, string xName, string defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? xElement.Value : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="strval">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, string strval)
        {
            node.SetAttributeValue(recname, strval);
        }
        #endregion .....string.....

        #region .....Enum.....
        /// <summary>
        /// 读取枚举
        /// </summary>
        /// <typeparam name="T">枚举的类型</typeparam>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ReadEnumAttr<T>(this XElement node, string xName, T defaultValue)
        {
            string str = node.ReadStringAttr(xName, defaultValue.ToString());
            return (T)Enum.Parse(typeof(T), str);
        }
        /// <summary>
        /// 把枚举值表示的字符串设置为xName对应的属性
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        public static void WriteEnumAttr(this XElement node, string xName, Enum defaultValue)
        {
            node.Write(xName, defaultValue.ToString());
        }
        #endregion .....Enum.....

        #region .....Int.....
        /// <summary>
        /// 从XML元素node中读取xName指定的int值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ReadInt32Attr(this XElement node, string xName, int defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToInt32(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="inum">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, int inum)
        {
            node.SetAttributeValue(recname, inum);
        }
        #endregion .....Int.....

        #region .....Float.....
        /// <summary>
        /// 从XML元素node中读取xName指定的float值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float ReadFloatAttr(this XElement node, string xName, float defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToSingle(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="inum">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, float inum)
        {
            node.SetAttributeValue(recname, inum);
        }
        #endregion .....Float.....

        #region .....Double.....
        /// <summary>
        /// 从XML元素node中读取xName指定的float值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ReadDoubleAttr(this XElement node, string xName, Double defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToDouble(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="inum">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, double inum)
        {
            node.SetAttributeValue(recname, inum);

        }
        #endregion .....Double.....

        #region .....Byte.....
        /// <summary>
        /// 从XML元素node中读取xName指定的byte值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static byte ReadByteAttr(this XElement node, string xName, byte defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToByte(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="varbite">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, byte varbite)
        {

            node.SetAttributeValue(recname, varbite);

        }
        #endregion .....Byte.....

        #region .....Byte[].....
        /// <summary>
        /// 从XML元素node中读取xName指定的byte值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xname"></param>
        /// <returns></returns>
        public static byte[] ReadBytesAttr(this XElement node, string xname)
        {
            int byteCount = node.ReadInt32Attr(xname + "Sum", 0);
            byte[] bytes = new byte[byteCount];
            for (int i = 0; i < bytes.Length; i++)
            {
                string strname = xname + i;
                bytes[i] = node.ReadByteAttr(strname, new byte());
            }

            return bytes;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="varbite">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, byte[] varbite)
        {
            int iNum = 0;

            int ibytetount = varbite.Length;
            node.Write(recname + "Sum", ibytetount);
            foreach (var pinf in varbite)
            {
                string strname = recname + iNum;
                node.Write(strname, pinf);
                iNum += 1;
            }
        }
        #endregion .....Byte[].....

        #region .....Bool.....
        static Dictionary<string, bool> BoolDic = new Dictionary<string, bool>();
        /// <summary>
        /// 从XML元素node中读取xName指定的boolean值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ReadBooleanAttr(this XElement node, string xName, bool defaultValue)
        {
            var xElement = node.Attribute(xName);
            try
            {
                return BoolDic[xElement.Value];
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="bolvalue">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, bool bolvalue)
        {
            node.SetAttributeValue(recname, bolvalue);
        }
        #endregion .....Bool.....
 
        #region .....Short.....
        /// <summary>
        /// 从XML元素node中读取xName指定的short值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ReadShortAttr(this XElement node, string xName, short defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToInt16(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 从XML元素node中读取xName指定的short值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ReadInt16Attr(this XElement node, string xName, short defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToInt16(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="shortval">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, short shortval)
        {
            node.SetAttributeValue(recname, shortval);
        }
        #endregion .....Short.....

        #region .....DateTime.....
        /// <summary>
        /// 从XML元素node中读取xName指定的DateTime值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ReadDateTimeAttr(this XElement node, string xName, DateTime defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToDateTime(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="timeval">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, DateTime timeval)
        {
            node.SetAttributeValue(recname, timeval);
        }
        #endregion .....DateTime.....

        #region .....Long.....
        /// <summary>
        /// 从XML元素node中读取xName指定的long值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ReadLongAttr(this XElement node, string xName, long defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToInt64(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 从XML元素node中读取xName指定的long值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ReadInt64Attr(this XElement node, string xName, long defaultValue)
        {
            var xElement = node.Attribute(xName);
            return xElement != null ? Convert.ToInt64(xElement.Value) : defaultValue;
        }
        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="longval">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteAttr(this  XElement node, string recname, long longval)
        {
            node.SetAttributeValue(recname, longval);
        }
        #endregion .....Long.....

        #region .....Object.....
        /// <summary>
        /// 将对象转换为XML表示形式。
        /// </summary>
        /// <param name="obj">需要转化为XML数据的对象</param>
        /// <param name="node">对象要序列化为的XML对象。</param>
        public static void WriteBinaryObjectAttr(this XElement node, Object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                string objdata = Convert.ToBase64String(stream.ToArray());
                node.Write("ObjStream", objdata);
            }
        }
        /// <summary>
        /// 从对象的XML表示形式生成该对象。
        /// </summary>
        /// <param name="node">对象要序列化为的XML对象。</param>
        public static Object ReadBinaryObjectAttr(this XElement node)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string objdata = node.ReadStringAttr("ObjStream", string.Empty);
            byte[] objMemoryStream = Convert.FromBase64String(objdata);
            using (MemoryStream stream = new MemoryStream(objMemoryStream))
            {
                return formatter.Deserialize(stream);
            }
        }
        #endregion .....Object.....

        #region .....Type.....
        /// <summary>
        /// 从XML元素node中读取xName指定的long值,如果不存在就返回缺省值defaultValue
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xName"></param>
        /// <returns></returns>
        public static Type ReadTypeAttr(this XElement node, string xName)
        {
            var xElement = node.Attribute(xName);
            if (xElement != null)
            {
                var typeFullName = xElement.Value;
                return Type.GetType(typeFullName);
            }
            return null;
        }

        /// <summary>
        /// 将对象转换为Xml表示形式。
        /// </summary>
        /// <param name="mtype">需要转化Xml数据的数值</param>
        ///  <param name="recname">obj的名称</param>
        /// <param name="node">对象要序列化为的 Xml节点。</param>
        public static void WriteTypeAttr(this  XElement node, string recname, Type mtype)
        {
            var typeAssName = mtype.SlimAssemblyQualifiedName();
            node.SetAttributeValue(recname, typeAssName);
        }
        #endregion .....Type.....

    }
        /// <summary>
        /// 扩展微软的Type类为其添加获取AssemblyQualifiedName的短名称SlimAssemblyQualifiedName
        /// AssemblyQualifiedName包含5部分：
        /// 1、类全名 
        /// 2、dll名称 
        /// 3、Version 
        /// 4、Culture 
        /// 5、PublicKeyToken
        /// SlimAssemblyQualifiedName包含2部分：
        /// 1、类全名 
        /// 2、dll名称 
        /// 不包含 3、Version 4、Culture 5、PublicKeyToken
        /// </summary>
        public static class TypeExtensionsClass
        {   /// <summary>
            /// MoveUp
            /// </summary>
            /// <param name="type">Type</param>
            public static string SlimAssemblyQualifiedName(this Type type)
            {
                var assemblyQualifiedName = type.AssemblyQualifiedName;
                if (string.IsNullOrEmpty(assemblyQualifiedName))
                {
                    return string.Empty;
                }
                var sub = assemblyQualifiedName.Split(',');
                var slimAssemblyQualifiedName = string.Format("{0},{1}", sub[0], sub[1]);
                return slimAssemblyQualifiedName;
            }
        }

}
