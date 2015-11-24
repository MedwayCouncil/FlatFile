namespace FlatFile.Core.Base
{
    public abstract class LineBulderBase<TLayoutDescriptor, TFieldSettings> : ILineBulder
        where TLayoutDescriptor : ILayoutDescriptor<TFieldSettings>
        where TFieldSettings : IFieldSettingsContainer 
    {
        private readonly TLayoutDescriptor _descriptor;

        protected LineBulderBase(TLayoutDescriptor descriptor)
        {
            this._descriptor = descriptor;
        }

        protected TLayoutDescriptor Descriptor
        {
            get { return _descriptor; }
        }

        public abstract string BuildLine<T>(T entry);

        protected virtual string GetStringValueFromField(TFieldSettings field, object fieldValue)
        {
            if (fieldValue == null)
            {
                //NZ - null value should be padded, and therefore assigned to field value rather than returned
                // return field.NullValue;
                fieldValue = field.NullValue;
            }

            string lineValue = fieldValue.ToString();

            //NZ - adding converter use
            var converter = field.TypeConverter;
            if (converter != null)
            {
                if(fieldValue != null && converter.CanConvertTo(fieldValue.GetType()))
                {
                    lineValue = converter.ConvertToString(fieldValue);
                }
               
            }

            lineValue = TransformFieldValue(field, lineValue);

            return lineValue;
        }

        protected virtual string TransformFieldValue(TFieldSettings field, string lineValue)
        {
            return lineValue;
        }
    }
}