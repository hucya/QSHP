using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using QSHP.Data;
using QSHP.HW.AmpC;
using QSHP.HW.Spindle;
using QSHP.HW.Video;
using QSHP.HW.IO;
using System.Globalization;

namespace QSHP.HW
{
    public class HardwareProvider
    {
        bool createObjectSucessful = false;
        HW<HardwareType, object> hwLib = new HW<HardwareType, object>();

        internal HW<HardwareType, object> HwLib
        {
            get { return hwLib; }
        }

        public bool CreateSucessful
        {
            get
            {
                return createObjectSucessful;
            }
        }

        public bool SaveSystemObjectConfig(XmlDocument document)
        {
            XmlElement root = document.DocumentElement;
            if (document.DocumentElement == null)
            {
                root = document.CreateElement("DriverConfig");
                document.AppendChild(root);
            }
            XmlNode note = document.CreateElement("Drivers");
            XmlAttribute att = document.CreateAttribute("Key");
            root.AppendChild(note);
            try
            {
                note.AppendChild(SaveAxisObject(document));
                note.AppendChild(SaveSpindleObject(document));
                note.AppendChild(SaveCaptureObject(document));
                note.AppendChild(SaveDigitalObject(document));
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return false;
            }
        }

        public bool CreateSystemObject(XmlDocument document)
        {
            bool flag = false;
            bool rFlag = true;
            XmlNode node = document.DocumentElement;
            XmlNode driver = node.SelectSingleNode("Drivers");
            hwLib.Clear();
            if (driver == null)
            {
                return false;
            }
            flag = CreateAxisObject(driver);
            rFlag &= flag;
            flag = CreateSpinleObject(driver);
            rFlag &= flag;
            flag = CreateCaptureObject(driver);
            rFlag &= flag;
            flag = CreateDigitalObject(driver);
            if (flag)
            {
                Common.ReportCmdKeyProgress(CmdKey.S0700, false);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0701);
            }
            rFlag &= flag;
            createObjectSucessful = rFlag;
            return flag;
        }

        public bool CreateSystemObject(string path)
        {
            if (File.Exists(path))
            {
                var document = new XmlDocument();
                try
                {
                    document.Load(path);
                    return CreateSystemObject(document);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteDebugException(ex);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool SaveSystemObjectConfig(string path)
        {
            try
            {
                var document = new XmlDocument();
                if (SaveSystemObjectConfig(document))
                {
                    document.Save(path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return false;
            }
        }

        public bool InitHardwareDriver()
        {
            if (createObjectSucessful)
            {
                bool rflag = true;
                bool flag = Common.X_Axis.InitAmpC();
                rflag &= flag;

                flag = Common.Y_Axis.InitAmpC();
                rflag &= flag;

                flag = Common.Z_Axis.InitAmpC();
                rflag &= flag;

                flag = Common.T_Axis.InitAmpC();
                rflag &= flag;

                flag = Common.SPD.InitSpd();
                rflag &= flag;

                flag = Common.Capture.InitDriver();
                rflag &= flag;

                flag = Common.DI.InitHardWare();
                rflag &= flag;

                flag = Common.DO.InitHardWare();
                rflag &= flag;
                if (Common.DoubleCap)
                {
                    flag = Common.CaptureL.InitDriver();
                }
                return rflag;
            }
            else
            {
                return false;
            }
        }

        public bool UnInitHardwareDriver()
        {
            bool flag = true;
            try
            {
                if (Common.X_Axis == null || !Common.X_Axis.CloseAmpC())
                {
                    flag = false;
                }
                if (Common.Y_Axis == null || !Common.Y_Axis.CloseAmpC())
                {
                    flag = false;
                }
                if (Common.Z_Axis == null || !Common.Z_Axis.CloseAmpC())
                {
                    flag = false;
                }
                if (Common.T_Axis == null || !Common.T_Axis.CloseAmpC())
                {
                    flag = false;
                }
                if (Common.SPD == null || !Common.SPD.CloseSpd())
                {
                    flag = false;
                }
                if (Common.Capture == null || !Common.Capture.UninitDriver())
                {
                    flag = false;
                }
                if (Common.DoubleCap)
                {
                    if (Common.CaptureL == null || Common.CaptureL.UninitDriver())
                    {
                        flag = false;
                    }
                }
                return flag;
            }
            catch
            {
                return false;
            }

        }

        public bool InitAxisSystemParam()
        {
            foreach (var item in hwLib.Values)
            {
                IAmpCProvider provider = item as IAmpCProvider;
                if (provider != null)
                {
                    provider.InitSystemParam();
                }
            }
            return true;
        }

        #region 序列化存储创建设备对象
        internal XmlNode SaveSpindleObject(XmlDocument document)
        {
            XmlNode spd = document.CreateElement("Spindle");
            spd.AppendChild(SaveSingleSpdCObject(HardwareType.SPD, Common.SPD, document));
            return spd;
        }

        internal XmlNode SaveCaptureObject(XmlDocument document)
        {
            XmlNode ccd = document.CreateElement("Capture");
            ccd.AppendChild(SaveSingleCaptureObject(HardwareType.CCD, Common.Capture, document));
            if (Common.DoubleCap)
            {
                ccd.AppendChild(SaveSingleCaptureObject(HardwareType.CCD2, Common.CaptureL, document));
            }
            XmlAttribute attr = document.CreateAttribute("DoubleCap");
            attr.Value = Common.DoubleCap.ToString();
            ccd.Attributes.Append(attr);
            return ccd;
        }

        internal XmlNode SaveAxisObject(XmlDocument document)
        {
            XmlNode ampC = document.CreateElement("AmpC");
            ampC.AppendChild(SaveSingleAmpCObject(HardwareType.X_Axis, Common.X_Axis, document));
            ampC.AppendChild(SaveSingleAmpCObject(HardwareType.Y_Axis, Common.Y_Axis, document));
            ampC.AppendChild(SaveSingleAmpCObject(HardwareType.Z_Axis, Common.Z_Axis, document));
            ampC.AppendChild(SaveSingleAmpCObject(HardwareType.T_Axis, Common.T_Axis, document));
            return ampC;
        }

        internal XmlNode SaveDigitalObject(XmlDocument document)
        {
            XmlNode dig = document.CreateElement("Digital");
            dig.AppendChild(SaveSingleDigitalObject(HardwareType.DI, Common.DI, document));
            dig.AppendChild(SaveSingleDigitalObject(HardwareType.DO, Common.DO, document));
            if (Common.DI != null && Common.DI.Provider != null)
            {
                XmlNode hw = document.CreateElement("Hardware");
                Serialize.XmlSerialize(Common.DI.Provider, hw);
                dig.AppendChild(hw);
            }
            return dig;
        }

        internal bool CreateAxisObject(XmlNode node)
        {
            if (node == null)
            {
                return false;
            }
            XmlNode item = node.SelectSingleNode("AmpC");
            if (item == null)
            {
                return false;
            }
            Common.X_Axis = CreateSigleAmpCObject(item, HardwareType.X_Axis);
            if (Common.X_Axis != null)
            {
                Common.ReportCmdKeyProgress(CmdKey.S0200,false);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0201);
            }
            Common.Y_Axis = CreateSigleAmpCObject(item, HardwareType.Y_Axis);
            if (Common.Y_Axis != null)
            {
                Common.ReportCmdKeyProgress(CmdKey.S0300,false);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0301);
            }
            Common.Z_Axis = CreateSigleAmpCObject(item, HardwareType.Z_Axis);
            if (Common.Z_Axis != null)
            {
                Common.ReportCmdKeyProgress(CmdKey.S0400,false);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0401);
            }
            Common.T_Axis = CreateSigleAmpCObject(item, HardwareType.T_Axis);
            if (Common.T_Axis != null)
            {
                Common.ReportCmdKeyProgress(CmdKey.S0500,false);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0501);
            }
            return Common.T_Axis != null && Common.Y_Axis != null || Common.Z_Axis != null || Common.T_Axis != null;
        }

        internal bool CreateSpinleObject(XmlNode node)
        {
            if (node == null)
            {
                return false;
            }
            XmlNode item = node.SelectSingleNode("Spindle");
            if (item == null)
            {
                return false;
            }
            Common.SPD = CreateSigleSpdObject(item, HardwareType.SPD);
            if (Common.SPD!=null)
            {
                Common.ReportCmdKeyProgress(CmdKey.S0600,false);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0601);
            }
            return true;
        }

        internal bool CreateCaptureObject(XmlNode node)
        {
            if (node == null)
            {
                return false;
            }
            XmlNode item = node.SelectSingleNode("Capture");
            if (item == null)
            {
                return false;
            }
            bool flag = false;
            if (bool.TryParse(item.Attributes["DoubleCap"].Value, out flag))
            {
                Common.DoubleCap = flag;
            }
            Common.Capture = CreateSigleCaptureObject(item, HardwareType.CCD);
            if (Common.Capture != null)
            {
                Common.ReportCmdKeyProgress(CmdKey.S0802,false);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0803);
            }
            if (Common.DoubleCap)
            {
                Common.CaptureL = CreateSigleCaptureObject(item, HardwareType.CCD2);
                if (Common.CaptureL != null)
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0800,false);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0801);
                }
            }
            return true;
        }

        internal bool CreateDigitalObject(XmlNode node)
        {
            if (node == null)
            {
                return false;
            }
            XmlNode item = node.SelectSingleNode("Digital");
            if (item == null)
            {
                return false;
            }
            Common.DI = CreateSingleDigitalObject(item, HardwareType.DI);
            Common.DO = CreateSingleDigitalObject(item, HardwareType.DO);
            XmlNode hw = item.SelectSingleNode("Hardware");
            if (hw != null)
            {
                IOProvider provider = Serialize.XmlDeSerialize(hw) as IOProvider;
                if (provider != null)
                {
                    Common.DI.Provider = provider;
                    Common.DO.Provider = provider;
                    Common.ReportCmdKeyProgress(CmdKey.S0704,false);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0705);
                    return false;
                }
            }
            return Common.DI != null & Common.DO != null;
        }

        private XmlNode SaveSingleAmpCObject(HardwareType hwType, IAmpCProvider item, XmlDocument document)
        {
            if (item == null)
            {
                return null;
            }
            XmlNode ampC = document.CreateElement(hwType.ToString());
            XmlAttribute attr = document.CreateAttribute("Type");
            attr.Value = item.GetType().FullName;
            ampC.Attributes.Append(attr);
            XmlNode amp = document.CreateElement("Params");
            attr = document.CreateAttribute("Driver");
            attr.Value = item.DevIndex.ToString();
            amp.Attributes.Append(attr);

            attr = document.CreateAttribute("Index");
            attr.Value = item.AmpCIndex.ToString();
            amp.Attributes.Append(attr);
            Serialize.XmlSerialize(item.Param, amp);
            ampC.AppendChild(amp);
            return ampC;
        }

        private XmlNode SaveSingleSpdCObject(HardwareType hwType, ISpindleProvider item, XmlDocument document)
        {
            if (item == null)
            {
                return null;
            }
            XmlNode ampC = document.CreateElement(hwType.ToString());
            Serialize.XmlSerialize(item, ampC);
            return ampC;
        }

        private XmlNode SaveSingleCaptureObject(HardwareType hwType, IVideoProvider item, XmlDocument document)
        {
            if (item == null)
            {
                return null;
            }
            XmlNode cap = document.CreateElement(hwType.ToString());
            Serialize.XmlSerialize(item, cap);
            return cap;
        }

        private XmlNode SaveSingleDigitalObject(HardwareType hwType, DigProvider item, XmlDocument document)
        {
            if (item == null)
            {
                return null;
            }
            XmlNode dig = document.CreateElement(hwType.ToString());
            XmlAttribute attr = document.CreateAttribute("IsOutPut");
            attr.Value = item.IsOutput.ToString();
            dig.Attributes.Append(attr);
            attr = document.CreateAttribute("Mask");
            attr.Value = item.Mask.ToString("X");
            dig.Attributes.Append(attr);
            attr = document.CreateAttribute("Used");
            attr.Value = item.Used.ToString("X");
            dig.Attributes.Append(attr);
            attr = document.CreateAttribute("Status");
            attr.Value = item.Status.ToString("X");
            dig.Attributes.Append(attr);
            return dig;
        }

        private IAmpCProvider CreateSigleAmpCObject(XmlNode node, HardwareType hw)
        {
            if (node == null)
            {
                return null;
            }
            XmlNode item = node.SelectSingleNode(hw.ToString());
            if (item == null)
            {
                return null;
            }
            if (hwLib.ContainsKey(hw) && hwLib[hw] is IAmpCProvider)
            {
                return (IAmpCProvider)hwLib[hw];
            }
            try
            {
                XmlAttribute attr = item.Attributes["Type"];
                Type type = Type.GetType(attr.Value, false);//反射获取对象类型
                IAmpCProvider provider = Activator.CreateInstance(type) as IAmpCProvider;
                if (provider != null)
                {
                    int dev = 0;
                    XmlNode n = item.SelectSingleNode("Params");
                    int.TryParse(n.Attributes["Driver"].Value,out dev);
                    provider.DevIndex = dev;
                    int.TryParse(n.Attributes["Index"].Value, out dev);
                    provider.AmpCIndex = dev;
                    provider.Param = Serialize.XmlDeSerialize(n) as AxisParams;
                    hwLib.Add(hw, provider);
                }
                return provider;
            }
            catch (Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return null;
            }
        }

        private ISpindleProvider CreateSigleSpdObject(XmlNode node, HardwareType hw)
        {
            if (node == null)
            {
                return null;
            }
            XmlNode item = node.SelectSingleNode(hw.ToString());
            if (item == null)
            {
                return null;
            }
            if (hwLib.ContainsKey(hw) && hwLib[hw] is ISpindleProvider)
            {
                return (ISpindleProvider)hwLib[hw];
            }
            try
            {
                ISpindleProvider adapter = Serialize.XmlDeSerialize(item) as ISpindleProvider;
                return adapter;
            }
            catch (Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return null;
            }
        }

        private IVideoProvider CreateSigleCaptureObject(XmlNode node, HardwareType hw)
        {
            if (node == null)
            {
                return null;
            }
            XmlNode item = node.SelectSingleNode(hw.ToString());
            if (item == null)
            {
                return null;
            }
            if (hwLib.ContainsKey(hw) && hwLib[hw] is IVideoProvider)
            {
                return (IVideoProvider)hwLib[hw];
            }
            try
            {
                IVideoProvider provider = Serialize.XmlDeSerialize(item) as IVideoProvider;
                return provider;
            }
            catch (Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return null;
            }
        }

        private DigProvider CreateSingleDigitalObject(XmlNode node, HardwareType hw)
        {
            if (node == null)
            {
                return null;
            }
            XmlNode item = node.SelectSingleNode(hw.ToString());
            if (item == null)
            {
                return null;
            }
            if (hwLib.ContainsKey(hw) && hwLib[hw] is DigProvider)
            {
                return (DigProvider)hwLib[hw];
            }
            try
            {
                XmlAttribute output = item.Attributes["IsOutPut"];
                XmlAttribute mask = item.Attributes["Mask"];  //获取名称
                XmlAttribute used = item.Attributes["Used"];
                XmlAttribute status = item.Attributes["Status"];
                DigProvider adapter = new DigProvider();
                hwLib.Add(hw, adapter);
                uint index = 0;
                bool r = false;
                if (bool.TryParse(output.Value, out r))
                {
                    adapter.IsOutput = r;
                }
                if (uint.TryParse(used.Value, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out index))
                {
                    adapter.Used = index;
                }
                if (uint.TryParse(status.Value, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out index))
                {
                    adapter.Status = index;
                }
                if (uint.TryParse(mask.Value, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out index))
                {
                    adapter.Mask = index;
                }
                return adapter;
            }
            catch (Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                return null;
            }
        }
        #endregion
    }
}
