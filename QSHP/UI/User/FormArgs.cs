using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QSHP.UI
{
    [Serializable]
    //[TypeConverter(typeof(UITypeEditor))]
    [TypeConverter(typeof(FormArgConverter))]
    public class FormArg
    {
        private string context = string.Empty;
        private Image backImage;
        private EventHandler clickEventHander;
        [Category("自定义")]
        [DisplayName("按键文本")]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.All), SettingsBindable(true)]
        public string Context
        {
            get { return context; }
            set { context = value; }
        }
        [Category("自定义")]
        [DisplayName("背景图片")]
        [RefreshProperties(RefreshProperties.All), SettingsBindable(true)]

        public Image BackImage
        {
            get { return backImage; }
            set { backImage = value; }
        }
        [Category("自定义")]
        [DisplayName("触发事件")]
        [Browsable(false)]
        public EventHandler ClickEventHander
        {
            get { return clickEventHander; }
            set { clickEventHander = value; }
        }

        public override string ToString()
        {
            return this.context;
        }

        public FormArg()
        {
        }
        public FormArg(string name)
        {
            this.context = name;
        }
        public FormArg(string name,Image img)
        {
            this.context = name;
            this.backImage = img;
        }
        public FormArg(string name, Image img, EventHandler handler)
        {
            this.context = name;
            this.backImage = img;
            this.clickEventHander = handler;
        }
    }

    public class FormArgConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string text = value as string;
            if (text == null)
            {
                return base.ConvertFrom(context, culture, value);
            }
            return new FormArg(text.Trim());
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is FormArg)
            {
                if (destinationType == typeof(string))
                {
                    FormArg size = (FormArg)value;
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(string));
                    string array = converter.ConvertToString(context, culture, size.Context);
                    return string.Join(separator, array);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    FormArg arg = (FormArg)value;
                    ConstructorInfo constructor = typeof(FormArg).GetConstructor(new Type[]
					{
						typeof(string),
					});
                    if (constructor != null)
                    {
                        return new InstanceDescriptor(constructor, new object[]
						{
							arg.Context,
						});
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            object obj = propertyValues["Context"];
            object obj1 = propertyValues["BackImage"];
            return new FormArg((string)obj,(Image)obj1);
        }
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(FormArg), attributes);
            return properties.Sort(new string[]
			{
				"Context",
				"BackImage"
			});
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }

}
