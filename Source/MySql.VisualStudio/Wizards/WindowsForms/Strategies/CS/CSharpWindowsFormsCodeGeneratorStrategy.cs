﻿// Copyright © 2008, 2014, Oracle and/or its affiliates. All rights reserved.
//
// MySQL for Visual Studio is licensed under the terms of the GPLv2
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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.VisualStudio.SchemaComparer;
using MySql.Data.VisualStudio.Wizards.WindowsForms;


namespace MySql.Data.VisualStudio.Wizards.WindowsForms
{
  internal class CSharpWindowsFormsCodeGeneratorStrategy : WindowsFormsCodeGeneratorStrategy
  {
    internal CSharpWindowsFormsCodeGeneratorStrategy(
      StrategyConfig config)
      : base(config)
    {
      ActionMappings = new Dictionary<string, WriterDelegate>();

      ActionMappings["// <WizardGeneratedCode>Namespace_UserCode</WizardGeneratedCode>"] = WriteUsingUserCode;
      ActionMappings["// <WizardGeneratedCode>Form_Load</WizardGeneratedCode>"] = WriteFormLoadCode;
      ActionMappings["// <WizardGeneratedCode>Validation Events</WizardGeneratedCode>"] = WriteValidationCode;
      ActionMappings["// <WizardGeneratedCode>Private Variables Frontend</WizardGeneratedCode>"] = WriteVariablesUserCode;
      ActionMappings["// <WizardGeneratedCode>Save Event</WizardGeneratedCode>"] = WriteSaveEventCode;
      ActionMappings["// <WizardGeneratedCode>Designer Control Declaration</WizardGeneratedCode>"] = WriteDesignerControlDeclCode;
      ActionMappings["// <WizardGeneratedCode>Designer Control Initialization</WizardGeneratedCode>"] = WriteDesignerControlInitCode;
      ActionMappings["// <WizardGeneratedCode>Designer BeforeSuspendLayout</WizardGeneratedCode>"] = WriteDesignerBeforeSuspendCode;
      ActionMappings["// <WizardGeneratedCode>Designer AfterSuspendLayout</WizardGeneratedCode>"] = WriteDesignerAfterSuspendCode;
      ActionMappings["// <WizardGeneratedCode>Designer BeforeResumeSuspendLayout</WizardGeneratedCode>"] = WriteBeforeResumeSuspendCode;
    }

    /// <summary>
    /// Transforms a user identifier like MySql table to ensure it is a valid identifier in C#/VB.NET.
    /// </summary>
    /// <returns></returns>
    internal protected override string GetCanonicalIdentifier(string Identifier)
    {
        if (String.IsNullOrEmpty(Identifier))
            return Identifier;
        return Identifier.Replace(' ', '_').Replace('`', '_');
    }

    internal protected override string GetEdmDesignerFileName()
    {
      return "{0}.Designer.cs";
    }

    internal protected override string GetFormDesignerFileName()
    {
      return "Form1.Designer.cs";
    }

    internal protected override string GetFormFileName()
    {
      return "Form1.cs";
    }

    protected override void WriteUsingUserCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteFormLoadCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteValidationCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteVariablesUserCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteSaveEventCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteDesignerControlDeclCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteDesignerControlInitCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteDesignerBeforeSuspendCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteDesignerAfterSuspendCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteBeforeResumeSuspendCode()
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected override void WriteControlInitialization(bool addBindings)
    {
      // TODO:
      throw new NotImplementedException();
    }

    protected string GetMaxWidthString(Dictionary<string, Column> l)
    {
      KeyValuePair<string, Column> maxWidthItem = new KeyValuePair<string, Column>("", null);
      foreach (KeyValuePair<string, Column> kvp in l)
      {
        if (kvp.Key.Length > maxWidthItem.Key.Length) maxWidthItem = kvp;
      }
      return maxWidthItem.Key;
    }
  }
}