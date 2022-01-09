using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public static class Operations
    {
        public static dynamic GetInputRepresOfList(List<object> list)
        {            
            return list.All(v => ((string)v).Length == 1) ? string.Join("", list) : string.Join(" ", list);
        }

        public static dynamic NumToString(dynamic num)
        {
            if (num is bool)
            {
                return num ? "1" : "0";
            }
            if (num is string)
            {
                return num;
            }
            return num.ToString("g", CultureInfo.InvariantCulture);
        }

        public static dynamic ToString(dynamic value)
        {
            if (value is bool)
            {
                return value ? "true" : "false";
            }
            if (value is string)
            {
                return value;
            }
            return value.ToString("g", CultureInfo.InvariantCulture);
        }

        public static int ToInt(dynamic value)
        {
            int iValue = 0;
            int.TryParse(NumToString(value), NumberStyles.Integer, null, out iValue);
            return iValue;
        }

        public static bool ToBool(dynamic value)
        {
            if (value is bool)
            {
                return value;
            }
            var sValue = ToString(value);
            switch (sValue)
            {
                case "true":
                    return true;
                case "false":
                    return false;
                case "1":
                    return true;
                case "0":
                    return false;
                case "":
                    return false;
                default:
                    return true;
            }
        }

        public static double DegToRad(double value)
        {
            return Math.PI * value / 180.0;
        }
        public static double RadToDeg(double value)
        {
            return 180.0 * value / Math.PI;
        }

        public static void SetVariableTo(ref dynamic variable, dynamic value)
        {
            variable = value;
        }

        public static void ChangeVariableBy(ref dynamic variable, dynamic value)
        {
            double dValue, dVar;
            if (double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue))
            {
                variable = double.TryParse(NumToString(variable), NumberStyles.Float, null, out dVar) ? dValue + dVar : dValue;
            }
        }

        public static void AddToList(ref List<object> list, dynamic obj)
        {
            list.Add(ToString(obj));
        }

        public static void DeleteOfList(ref List<object> list, dynamic index)
        {
            int iIndex;
            if (int.TryParse(NumToString(index), NumberStyles.Integer, null, out iIndex))
            {
                if (iIndex - 1 >= 0 && iIndex - 1 < list.Count)
                {
                    list.RemoveAt(iIndex - 1);
                }
            }
        }

        public static void DeleteAllOfList(ref List<object> list)
        {
            list.Clear();
        }

        public static void InsertAtList(ref List<object> list, dynamic index, dynamic obj)
        {
            int iIndex;
            if (int.TryParse(NumToString(index), NumberStyles.Integer, null, out iIndex))
            {
                if (iIndex - 1 >= 0 && iIndex - 1 <= list.Count)
                {
                    list.Insert(iIndex - 1, ToString(obj));
                }
            }
        }

        public static void ReplaceItemOfList(ref List<object> list, dynamic index, dynamic obj)
        {
            int iIndex;
            if (int.TryParse(NumToString(index), NumberStyles.Integer, null, out iIndex))
            {
                if (iIndex - 1 >= 0 && iIndex - 1 < list.Count)
                {
                    list[iIndex - 1] = ToString(obj);
                }
            }
        }

        public static dynamic ItemOfList(List<object> list, dynamic index)
        {
            int iIndex;
            if (int.TryParse(NumToString(index), NumberStyles.Integer, null, out iIndex))
            {
                if (iIndex - 1 >= 0 && iIndex - 1 < list.Count)
                {
                    return list[iIndex - 1];
                }
            }
            return "";
        }

        public static dynamic ItemNumOfList(List<object> list, dynamic obj)
        {
            return list.IndexOf(ToString(obj)) + 1;
        }

        public static dynamic LengthOfList(List<object> list)
        {
            return list.Count;
        }

        public static dynamic ListContainsItem(List<object> list, dynamic obj)
        {
            return list.Contains(ToString(obj));
        }

        public static dynamic Add(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            double.TryParse(NumToString(f), NumberStyles.Float, null, out df);
            double.TryParse(NumToString(s), NumberStyles.Float, null, out ds);
            return df + ds;
        }
        public static dynamic Subtract(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            double.TryParse(NumToString(f), NumberStyles.Float, null, out df);
            double.TryParse(NumToString(s), NumberStyles.Float, null, out ds);
            return df - ds;
        }
        public static dynamic Multiply(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            double.TryParse(NumToString(f), NumberStyles.Float, null, out df);
            double.TryParse(NumToString(s), NumberStyles.Float, null, out ds);
            return df * ds;
        }
        public static dynamic Divide(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            double.TryParse(NumToString(f), NumberStyles.Float, null, out df);
            double.TryParse(NumToString(s), NumberStyles.Float, null, out ds);
            return df / ds;
        }

        public static dynamic Random(dynamic from, dynamic to)
        {
            var rand = new Random();
            int iFrom = 0, iTo = 0;
            double dFrom = 0, dTo = 0;
            if ((!int.TryParse(NumToString(from), NumberStyles.Integer, null, out iFrom) &&
                double.TryParse(NumToString(from), NumberStyles.Float, null, out dFrom)) ||
                (!int.TryParse(NumToString(to), NumberStyles.Integer, null, out iTo) &&
                double.TryParse(NumToString(to), NumberStyles.Float, null, out dTo)))
            {
                var (minValue, maxValue) = dFrom < dTo ? (dFrom, dTo) : (dTo, dFrom);
                return minValue + rand.NextDouble() * (maxValue - minValue);
            }
            else
            {
                var (minValue, maxValue) = iFrom < iTo ? (iFrom, iTo) : (iTo, iFrom);
                return rand.Next(minValue, maxValue + 1);
            }
        }

        public static dynamic Lt(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            if (!double.TryParse(NumToString(f), NumberStyles.Float, null, out df) ||
                !double.TryParse(NumToString(s), NumberStyles.Float, null, out ds))
            {
                return ToString(f).CompareTo(ToString(s)) < 0;
            }
            return df < ds;
        }

        public static dynamic Gt(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            if (!double.TryParse(NumToString(f), NumberStyles.Float, null, out df) ||
                !double.TryParse(NumToString(s), NumberStyles.Float, null, out ds))
            {
                return ToString(f).CompareTo(ToString(s)) > 0;
            }
            return df > ds;
        }

        public static dynamic Equal(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            if (!double.TryParse(NumToString(f), NumberStyles.Float, null, out df) ||
                !double.TryParse(NumToString(s), NumberStyles.Float, null, out ds))
            {
                return ToString(f).CompareTo(ToString(s)) == 0;
            }
            return df == ds;
        }

        public static dynamic And(dynamic f, dynamic s)
        {
            return ToBool(f) && ToBool(s);
        }

        public static dynamic Or(dynamic f, dynamic s)
        {
            return ToBool(f) || ToBool(s);
        }

        public static dynamic Not(dynamic v)
        {
            return !ToBool(v);
        }

        public static dynamic Join(dynamic f, dynamic s)
        {
            return ToString(f) + ToString(s);
        }

        public static dynamic LetterOf(dynamic str, dynamic index)
        {
            int iIndex;
            string sStr = ToString(str);
            if (int.TryParse(NumToString(index), NumberStyles.Integer, null, out iIndex))
            {
                if (iIndex - 1 >= 0 && iIndex - 1 < sStr.Length)
                {
                    return sStr[iIndex - 1].ToString();
                }
            }
            return "";
        }

        public static dynamic Length(dynamic str)
        {
            return ToString(str).Length;
        }

        public static dynamic Contains(dynamic str, dynamic substr)
        {
            return ToString(str).Contains(ToString(substr));
        }

        public static dynamic Mod(dynamic f, dynamic s)
        {
            double df = 0, ds = 0;
            double.TryParse(NumToString(f), NumberStyles.Float, null, out df);
            double.TryParse(NumToString(s), NumberStyles.Float, null, out ds);
            if (df * ds < 0 && double.IsNormal(df * ds))
            {
                return df % ds + ds;
            }
            return df % ds;
        }

        public static dynamic Round(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            var res = Math.Round(dValue, MidpointRounding.AwayFromZero);
            return (res == -0.0 || double.IsNaN(res)) ? 0 : res;
        }

        public static dynamic Abs(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Abs(dValue);
        }

        public static dynamic Floor(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Floor(dValue);
        }

        public static dynamic Ceiling(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Ceiling(dValue);
        }

        public static dynamic Sqrt(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Sqrt(dValue);
        }

        public static dynamic Sin(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Round(Math.Sin(DegToRad(dValue)) * 1e10) / 1e10;
        }

        public static dynamic Cos(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Round(Math.Cos(DegToRad(dValue)) * 1e10) / 1e10;
        }

        public static dynamic Tan(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Round(Math.Tan(DegToRad(dValue)) * 1e10) / 1e10;
        }

        public static dynamic Asin(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return RadToDeg(Math.Asin(dValue));
        }

        public static dynamic Acos(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return RadToDeg(Math.Acos(dValue));
        }

        public static dynamic Atan(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return RadToDeg(Math.Atan(dValue));
        }

        public static dynamic Ln(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Log(dValue);
        }

        public static dynamic Log(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Log10(dValue);
        }

        public static dynamic Exp(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Exp(dValue);
        }

        public static dynamic TenPow(dynamic value)
        {
            double dValue;
            double.TryParse(NumToString(value), NumberStyles.Float, null, out dValue);
            return Math.Pow(10.0, dValue);
        }
    }
}
