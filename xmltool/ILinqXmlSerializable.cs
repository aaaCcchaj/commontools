#region Copyright (c) 2014-2014 aaaCcchaj All Rights Reserved
/*********************************************************************************************
*文件名：	ILinqXmlSerializable.cs
*创建日期：2014-09-04
*作者：	aaaCcchaj
*版本：	1.0
*说明：	对象和XML元素互相转化的接口
*----------------------------------------------------------------------------------------------
*修改记录：
*日期			版本	修改人	修改内容

********************************************************************************************/
#endregion Copyright (c) 2014-2014 aaaCcchaj All Rights Reserved
using System.Xml.Linq;

namespace Common.Tools
{
    /// <summary>
    /// 对象和XML元素互相转化的接口
    /// </summary>
    public interface ILinqXmlSerializable : ILinqXmlReadSerializable, ILinqXmlWriteSerializable
    {
    }
    /// <summary>
    /// 对象和XML元素互相转化的接口
    /// </summary>
    public interface ILinqXmlReadSerializable
    {
        /// <summary>
        /// XML元素转化为对象
        /// </summary>
        /// <param name="node"></param>
        void ReadXml(XElement node);
    }
    /// <summary>
    /// 对象和XML元素互相转化的接口
    /// </summary>
    public interface ILinqXmlWriteSerializable
    {
        /// <summary>
        /// 对象转化为XML元素
        /// </summary>
        /// <param name="node"></param>
        void WriteXml(XElement node);

    }
}

