﻿// Copyright © 2004, 2012, Oracle and/or its affiliates. All rights reserved.
//
// MySQL Connector/NET is licensed under the terms of the GPLv2
// <http://www.gnu.org/licenses/old-licenses/gpl-2.0.html>, like most 
// MySQL Connectors. There are special exceptions to the terms and 
// conditions of the GPLv2 as it is applied to this software, see the 
// FLOSS License Exception
// <http://www.mysql.com/about/legal/licensing/foss-exception.html>.
//
// This program is free software; you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published 
// by the Free Software Foundation; version 2 of the License.
//
// This program is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License 
// for more details.
//
// You should have received a copy of the GNU General Public License along 
// with this program; if not, write to the Free Software Foundation, Inc., 
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Debugger.Interop;
using Microsoft.VisualStudio;
using System.Reflection;

namespace MySql.Debugger.VisualStudio
{
  public class AD7Property : IDebugProperty2
  {
    private AD7ProgramNode _node;
    private static Dictionary<string, decimal> numberTypeMax = new Dictionary<string, decimal>()
    {
      { "tinyint", sbyte.MaxValue },
      { "utinyint", byte.MaxValue },
      { "smallint", Int16.MaxValue },
      { "usmallint", UInt16.MaxValue },
      { "mediumint", 8388607 },
      { "umediumint", 16777215 },
      { "int", Int32.MaxValue },
      { "uint", UInt32.MaxValue },
      { "integer", Int32.MaxValue },
      { "uinteger", UInt32.MaxValue },
      { "bigint", Int64.MaxValue },
      { "ubigint", UInt64.MaxValue },
      { "decimal", decimal.MaxValue },
      { "bool", sbyte.MaxValue },
    };
    private static Dictionary<string, decimal> numberTypeMin = new Dictionary<string, decimal>()
    {
      { "tinyint", sbyte.MinValue },
      { "utinyint", byte.MinValue },
      { "smallint", Int16.MinValue },
      { "usmallint", UInt16.MinValue },
      { "mediumint", -8388608 },
      { "umediumint", 0 },
      { "int", Int32.MinValue },
      { "uint", UInt32.MinValue },
      { "integer", Int32.MinValue },
      { "uinteger", UInt32.MinValue },
      { "bigint", Int64.MinValue },
      { "ubigint", UInt64.MinValue },
      { "bool", sbyte.MinValue },
    };

    public string Name { get; set; }
    public string Value { get; set; }
    public string TypeName { get; set; }

    public AD7Property(string name, AD7ProgramNode node)
    {
      Name = name;
      _node = node;
      TypeName = _node.Debugger.Debugger.ScopeVariables[name].Type;
      if (numberTypeMax.ContainsKey(TypeName) && _node.Debugger.Debugger.ScopeVariables[name].Unsigned)
        TypeName += " unsigned";
      Value = GetValue(name);
    }

    public AD7Property(AD7ProgramNode node)
    {
      _node = node;
    }

    #region IDebugProperty2 Members

    int IDebugProperty2.EnumChildren(enum_DEBUGPROP_INFO_FLAGS dwFields, uint dwRadix, ref Guid guidFilter, enum_DBG_ATTRIB_FLAGS dwAttribFilter, string pszNameFilter, uint dwTimeout, out IEnumDebugPropertyInfo2 ppEnum)
    {
      ppEnum = new AD7PropertyCollection(_node);
      return VSConstants.S_OK;
    }

    int IDebugProperty2.GetDerivedMostProperty(out IDebugProperty2 ppDerivedMost)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.GetExtendedInfo(ref Guid guidExtendedInfo, out object pExtendedInfo)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.GetMemoryBytes(out IDebugMemoryBytes2 ppMemoryBytes)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.GetMemoryContext(out IDebugMemoryContext2 ppMemory)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.GetParent(out IDebugProperty2 ppParent)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.GetPropertyInfo(enum_DEBUGPROP_INFO_FLAGS dwFields, uint dwRadix, uint dwTimeout, IDebugReference2[] rgpArgs, uint dwArgCount, DEBUG_PROPERTY_INFO[] pPropertyInfo)
    {
      if ((dwFields & enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_NAME) != 0)
      {
        pPropertyInfo[0].bstrName = Name;
        pPropertyInfo[0].dwFields |= enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_NAME;
      }

      if ((dwFields & enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_VALUE) != 0)
      {
        pPropertyInfo[0].bstrValue = Value;
        pPropertyInfo[0].dwFields |= enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_VALUE;
      }

      if ((dwFields & enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_TYPE) != 0)
      {
        pPropertyInfo[0].bstrType = TypeName;
        pPropertyInfo[0].dwFields |= enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_TYPE;
      }

      return VSConstants.S_OK;
    }

    int IDebugProperty2.GetReference(out IDebugReference2 ppReference)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.GetSize(out uint pdwSize)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.SetValueAsReference(IDebugReference2[] rgpArgs, uint dwArgCount, IDebugReference2 pValue, uint dwTimeout)
    {
      throw new NotImplementedException();
    }

    int IDebugProperty2.SetValueAsString(string pszValue, uint dwRadix, uint dwTimeout)
    {
      if (!ValidateNewValue(ref pszValue))
        return VSConstants.E_FAIL;
      _node.Debugger.SetLocalNewValue(Name, pszValue.Trim('\'').Trim('"'));
      return VSConstants.S_OK;
    }

    #endregion

    private string GetValue(string variableName)
    {
      string value = _node.Debugger.Debugger.FormatValue(_node.Debugger.Debugger.Eval(variableName));
      value = value.Trim('\'');

      return value;
    }

    private bool ValidateNewValue(ref string value)
    {
      StoreType type = _node.Debugger.Debugger.ScopeVariables[Name];
      string typeName = type.Type.ToLower();
      bool isValid;
      switch (typeName)
      {
          //TODO case "bit":
        case "tinyint":
        case "smallint":
        case "mediumint":
        case "int":
        case "integer":
        case "bigint":
        case "bool":
          if (type.Unsigned)
            typeName = "u" + typeName;
          isValid = ParseToNumber(ref value, numberTypeMin[typeName], numberTypeMax[typeName]);
          break;

        case "decimal":
        case "dec":
        case "numeric":
        case "fixed":
        case "float":
        case "double":
        case "real":
          double doubleValue;
          isValid = double.TryParse(value, out doubleValue);
          if (isValid)
          {
            double maxValue = (Math.Pow(10, type.Length - type.Precision) - Math.Pow(10, type.Precision * -1));
            if (doubleValue > maxValue)
              doubleValue = maxValue;
            else if (type.Precision < 29)
              doubleValue = (double)decimal.Round((decimal)doubleValue, type.Precision, MidpointRounding.AwayFromZero);
            value = doubleValue.ToString();
            if (type.Unsigned && doubleValue < 0)
              value = "0";
          }
          break;

        case "varchar":
        case "char":
        case "binary":
        case "varbinary":
          isValid = true;
          if (value.Length > type.Length)
            value = value.Substring(0, type.Length);
          break;

        default:
          return true;
      }
      return isValid;
    }

    private bool ParseToNumber(ref string value, Decimal minValue, Decimal maxValue)
    {
      bool isValid;
      Decimal decValue;

      isValid = Decimal.TryParse(value, out decValue);
      if (isValid)
      {
        decValue = Decimal.Truncate(decValue);
        value = decValue.ToString();
        if (decValue > maxValue)
          value = maxValue.ToString();
        else if (decValue < minValue)
          value = minValue.ToString();
      }

      return isValid;
    }
  }

  public class AD7PropertyCollection : List<AD7Property>, IEnumDebugPropertyInfo2
  {
    private uint count;
    private AD7ProgramNode _node;

    public AD7PropertyCollection(AD7ProgramNode node)
    {
      _node = node;
      Debugger dbg = DebuggerManager.Instance.Debugger;
      foreach (StoreType st in DebuggerManager.Instance.ScopeVariables.Values)
      {
        if (st.VarKind == VarKindEnum.Internal) continue;
        this.Add(new AD7Property(st.Name, node));
      }
    }

    public AD7PropertyCollection(params AD7Property[] properties)
    {
      foreach (var property in properties)
      {
        this.Add(property);
      }
    }

    #region IEnumDebugPropertyInfo2 Members

    int IEnumDebugPropertyInfo2.Clone(out IEnumDebugPropertyInfo2 ppEnum)
    {
      throw new NotImplementedException();
    }

    int IEnumDebugPropertyInfo2.GetCount(out uint pcelt)
    {
      pcelt = (uint)this.Count;
      return VSConstants.S_OK;
    }

    int IEnumDebugPropertyInfo2.Next(uint celt, DEBUG_PROPERTY_INFO[] rgelt, out uint pceltFetched)
    {
      for (var i = 0; i < celt; i++)
      {
        rgelt[i].bstrName = this[(int)(i + count)].Name;
        rgelt[i].bstrValue = this[(int)(i + count)].Value != null ? this[(int)(i + count)].Value.ToString() : "$null";
        rgelt[i].bstrType = this[(int)(i + count)].TypeName;
        rgelt[i].pProperty = this[(int)(i + count)];
        rgelt[i].dwAttrib = GetAttributes(this[(int)(i + count)].Value);
        rgelt[i].dwFields = enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_NAME |
                            enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_VALUE |
                            enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_TYPE |
                            enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_PROP |
                            enum_DEBUGPROP_INFO_FLAGS.DEBUGPROP_INFO_ATTRIB;
      }
      pceltFetched = celt;
      return VSConstants.S_OK;
    }

    int IEnumDebugPropertyInfo2.Reset()
    {
      count = 0;
      return VSConstants.S_OK;
    }

    int IEnumDebugPropertyInfo2.Skip(uint celt)
    {
      count += celt;
      return VSConstants.S_OK;
    }

    #endregion

    private enum_DBG_ATTRIB_FLAGS GetAttributes(object obj)
    {
      if (obj == null)
      {
        return 0;
      }

      if (obj is string || obj is int || obj is char || obj is byte)
      {
        return 0;
      }

      return enum_DBG_ATTRIB_FLAGS.DBG_ATTRIB_OBJ_IS_EXPANDABLE;
    }
  }
}