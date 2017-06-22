﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OhPrimitiveTypes.Extension;

namespace OhPrimitiveTypes.Utils
{
    /// <summary>
    /// 字段比较helper
    /// </summary>
    internal static class FieldCompareHelper
    {
        #region EqualsField<TPrimitive>.IsStatisfy

        public static bool IsStatisfy<TPrimitive>(EqualsField<TPrimitive> field, TPrimitive value)
            where TPrimitive : struct, IConvertible, IComparable
        {
            if (field.CompareMode == CompareMode.Equal)
            {
                return field.Value.CompareTo(value) == 0;
            }
            return false;
        }
        #endregion

        #region ContainsField<TPrimitive>.IsStatisfy

        public static bool IsStatisfy<TPrimitive>(ContainsField<TPrimitive> field, TPrimitive value)
            where TPrimitive : struct, IConvertible, IComparable
        {
            var result = false;
            if (field.CompareMode.IsInclude(CompareMode.Contains))
            {
                result = field.Values.FirstOrDefault(p => p.CompareTo(value) == 0).CompareTo(value) == 0;
            }
            if (!result)
            {
                if (field.CompareMode.IsInclude(CompareMode.NotContains))
                {
                    result = field.Values.FirstOrDefault(p => p.CompareTo(value) == 0).CompareTo(value) != 0;
                }
            }
            return result;
        }
        #endregion

        #region RangeField<TPrimitive>.IsStatisfy

        public static bool IsStatisfy<TPrimitive>(RangeField<TPrimitive> field, TPrimitive min, TPrimitive max)
            where TPrimitive : struct, IConvertible, IComparable
        {
            var _min = field.Min.GetValueOrDefault();
            var _max = field.Max.GetValueOrDefault();

            var left = false;
            var right = false;

            if (field.MinCompareMode == CompareMode.GreaterThan)
            {
                left = min.CompareTo(_min) > 0 && min.CompareTo(_max) < 0;
            }

            if (field.MaxCompareMode == CompareMode.LessThan)
            {
                right = max.CompareTo(_min) > 0 && max.CompareTo(_max) < 0;
            }

            return left && right;
        }
        #endregion

        #region BetweenField<TPrimitive>.IsStatisfy

        public static bool IsStatisfy<TPrimitive>(BetweenField<TPrimitive> field, TPrimitive min, TPrimitive max)
            where TPrimitive : struct, IConvertible, IComparable
        {

            var _min = field.Min.GetValueOrDefault();
            var _max = field.Max.GetValueOrDefault();

            var left = false;
            var right = false;

            if (field.MinCompareMode == CompareMode.GreaterThanOrEqual)
            {
                left = min.CompareTo(_min) >= 0 && min.CompareTo(_max) <= 0;
            }

            if (field.MaxCompareMode == CompareMode.LessThanOrEqaual)
            {
                right = max.CompareTo(_min) >= 0 && max.CompareTo(_max) <= 0;
            }

            return left && right;
        }
        #endregion
    }
}