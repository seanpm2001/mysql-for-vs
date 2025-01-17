// Copyright (c) 2004, 2013, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License, version 2.0, as
// published by the Free Software Foundation.
//
// This program is also distributed with certain software (including
// but not limited to OpenSSL) that is licensed under separate terms,
// as designated in a particular file or component or in included license
// documentation.  The authors of MySQL hereby grant you an
// additional permission to link the program and your derivative works
// with the separately licensed software that they have included with
// MySQL.
//
// Without limiting anything contained in the foregoing, this file,
// which is part of MySQL for Visual Studio, is also subject to the
// Universal FOSS Exception, version 1.0, a copy of which can be found at
// http://oss.oracle.com/licenses/universal-foss-exception.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License, version 2.0, for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using Microsoft.Win32;
using System.Reflection;


namespace MySql.Debugger.VisualStudio
{
  [RunInstaller(true)]
  public partial class Installer : System.Configuration.Install.Installer
  {
    private const string ENGINE_PATH = @"SOFTWARE\Microsoft\VisualStudio\{0}\AD7Metrics\Engine\";
    private const string CLSID_PATH = @"SOFTWARE\Microsoft\VisualStudio\{0}\CLSID\";

    public Installer()
    {
      InitializeComponent();
    }

    public override void Install(IDictionary stateSaver)
    {
      base.Install(stateSaver);
      switch (Environment.Version.Major)
      {
        case 2:
          RegisterDebugEngine("9.0", false);
          break;
        case 4:
          RegisterDebugEngine("10.0", false);
          RegisterDebugEngine("11.0", true);
          break;
      }
    }

    public override void Uninstall(IDictionary savedState)
    {
      base.Uninstall(savedState);
      switch (Environment.Version.Major)
      {
        case 2:
          UnregisterDebugEngine("9.0", false);
          break;
        case 4:
          UnregisterDebugEngine("10.0", false);
          UnregisterDebugEngine("11.0", true);
          break;
      }
    }

    protected void RegisterDebugEngine(string version, bool installCU)
    {
      List<RegistryKey> rootKeys = new List<RegistryKey>();
      rootKeys.Add(Registry.LocalMachine);
      if (installCU)
        rootKeys.Add(Registry.CurrentUser);

      foreach (RegistryKey rootKey in rootKeys)
      {
        string configSufix = rootKey == Registry.CurrentUser ? "_Config" : string.Empty;
        string enginePath = string.Format(ENGINE_PATH, version + configSufix);
        string clsidPath = string.Format(CLSID_PATH, version + configSufix);

        RegistryKey engineKey = rootKey.CreateSubKey(enginePath + AD7Guids.EngineGuid.ToString("B").ToUpper());
        engineKey.SetValue(null, "guidMySqlStoredProcedureDebugEngine");
        engineKey.SetValue("CLSID", AD7Guids.CLSIDGuid.ToString("B").ToUpper());
        engineKey.SetValue("ProgramProvider", AD7Guids.ProgramProviderGuid.ToString("B").ToUpper());
        engineKey.SetValue("Attach", 1, RegistryValueKind.DWord);
        engineKey.SetValue("AddressBP", 0, RegistryValueKind.DWord);
        engineKey.SetValue("AutoSelectPriority", 4, RegistryValueKind.DWord);
        engineKey.SetValue("CallstackBP", 1, RegistryValueKind.DWord);
        engineKey.SetValue("Name", AD7Guids.EngineName);
        engineKey.SetValue("PortSupplier", AD7Guids.PortSupplierGuid.ToString("B").ToUpper());
        engineKey.SetValue("AlwaysLoadLocal", 0, RegistryValueKind.DWord);

        RegistryKey clsidKey = rootKey.CreateSubKey(clsidPath + AD7Guids.CLSIDGuid.ToString("B").ToUpper());
        clsidKey.SetValue("Assembly", Assembly.GetExecutingAssembly().GetName().Name);
        clsidKey.SetValue("Class", typeof(AD7Engine).FullName);
        clsidKey.SetValue("InprocServer32", @"c:\windows\system32\mscoree.dll");
        clsidKey.SetValue("CodeBase", @"file:///" + Assembly.GetExecutingAssembly().Location);

        RegistryKey programProviderKey = rootKey.CreateSubKey(clsidPath + AD7Guids.ProgramProviderGuid.ToString("B").ToUpper());
        programProviderKey.SetValue("Assembly", Assembly.GetExecutingAssembly().GetName().Name);
        programProviderKey.SetValue("Class", typeof(AD7ProgramProvider).FullName);
        programProviderKey.SetValue("InprocServer32", @"c:\windows\system32\mscoree.dll");
        programProviderKey.SetValue("CodeBase", @"file:///" + Assembly.GetExecutingAssembly().Location);
      }
    }

    protected void UnregisterDebugEngine(string version, bool installCU)
    {
      List<RegistryKey> rootKeys = new List<RegistryKey>();
      rootKeys.Add(Registry.LocalMachine);
      if (installCU)
        rootKeys.Add(Registry.CurrentUser);

      foreach (RegistryKey rootKey in rootKeys)
      {
        string configSufix = rootKey == Registry.CurrentUser ? "_Config" : string.Empty;
        string enginePath = string.Format(ENGINE_PATH, version + configSufix);
        string clsidPath = string.Format(CLSID_PATH, version + configSufix);

        rootKey.DeleteSubKeyTree(enginePath + AD7Guids.EngineGuid.ToString("B").ToUpper());
        rootKey.DeleteSubKeyTree(clsidPath + AD7Guids.CLSIDGuid.ToString("B").ToUpper());
        rootKey.DeleteSubKeyTree(clsidPath + AD7Guids.ProgramProviderGuid.ToString("B").ToUpper());
      }
    }
  }
}
