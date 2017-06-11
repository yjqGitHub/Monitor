namespace JQ.Extensions
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：ObjectConvertExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：转换扩展类
    /// 创建标识：yjq 2017/6/10 23:01:12
    /// </summary>
    public static partial class ObjectConvertExtension
    {
        public static int ToSafeInt32(this object o, int defaultValue)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                int num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (int.TryParse(s, out num))
                {
                    return num;
                }
            }
            return defaultValue;
        }

        public static int? ToSafeInt32(this object o)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                int num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (int.TryParse(s, out num))
                {
                    return num;
                }
            }
            return null;
        }

        public static long ToSafeInt64(this object o, int defaultValue)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                long num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (long.TryParse(s, out num))
                {
                    return num;
                }
            }
            return defaultValue;
        }

        public static long? ToSafeInt64(this object o)
        {
            if ((o != null) && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                long num;
                string s = o.ToString().Trim().ToLower();
                switch (s)
                {
                    case "true":
                        return 1;

                    case "false":
                        return 0;
                }
                if (long.TryParse(s, out num))
                {
                    return num;
                }
            }
            return null;
        }

        public static float ToSafeFloat(this object o, float defValue)
        {
            if (o == null || string.IsNullOrWhiteSpace(o.ToString()))
            {
                return defValue;
            }
            float result = defValue;
            if ((o != null))
            {
                float.TryParse(o.ToString().Trim(), out result);
            }
            return result;
        }

        public static float? ToSafeFloat(this object o)
        {
            if (o != null && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                float result;
                float.TryParse(o.ToString().Trim(), out result);
                return result;
            }
            return null;
        }

        public static decimal ToSafeDecimal(this object o, decimal defValue)
        {
            if (o == null || string.IsNullOrWhiteSpace(o.ToString()))
            {
                return defValue;
            }
            decimal result = defValue;
            if ((o != null))
            {
                decimal.TryParse(o.ToString().Trim(), out result);
            }
            return result;
        }

        public static decimal? ToSafeDecimal(this object o)
        {
            if (o != null && !string.IsNullOrWhiteSpace(o.ToString()))
            {
                decimal result;
                decimal.TryParse(o.ToString().Trim(), out result);
                return result;
            }
            return null;
        }

        public static bool ToSafeBool(this object o, bool defValue)
        {
            if (o != null)
            {
                if (string.Compare(o.ToString().Trim(), "1") == 0)
                {
                    return true;
                }
                if (string.Compare(o.ToString().Trim(), "0") == 0)
                {
                    return false;
                }
                if (string.Compare(o.ToString().Trim(), "true", true) == 0)
                {
                    return true;
                }
                if (string.Compare(o.ToString().Trim(), "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        public static bool? ToSafeBool(this object o)
        {
            if (o != null)
            {
                if (string.Compare(o.ToString().Trim(), "1") == 0)
                {
                    return true;
                }
                if (string.Compare(o.ToString().Trim(), "0") == 0)
                {
                    return false;
                }
                if (string.Compare(o.ToString().Trim(), "true", true) == 0 || o.ToString().Trim() == "1")
                {
                    return true;
                }
                if (string.Compare(o.ToString().Trim(), "false", true) == 0 || o.ToString().Trim() == "0")
                {
                    return false;
                }
            }
            return null;
        }

        public static string ToSafeString(this object obj)
        {
            if (obj == null) return string.Empty;
            return obj.ToString();
        }
    }
}