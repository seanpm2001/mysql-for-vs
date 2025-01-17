// Copyright (c) 2008, 2010, Oracle and/or its affiliates. All rights reserved.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MySql.Data.VisualStudio.Editors
{
  public class MySplitter : Splitter
  {

    public MySplitter()
    {
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle r = ClientRectangle;

      SolidBrush brush = new SolidBrush(SystemColors.Control);
      Pen light = new Pen(SystemColors.ControlLightLight);
      Pen dark = new Pen(SystemColors.ControlDarkDark);

      e.Graphics.FillRectangle(brush, r);

      e.Graphics.DrawLine(light, r.Left + 1, r.Top + 1, r.Left + 1, r.Bottom - 2);
      e.Graphics.DrawLine(light, r.Left + 1, r.Top + 1, r.Right - 2, r.Top + 1);

      e.Graphics.DrawLine(dark, r.Right - 1, r.Top, r.Right - 1, r.Bottom - 1);
      e.Graphics.DrawLine(dark, r.Left, r.Bottom - 1, r.Width, r.Bottom - 1);

      //            base.OnPaint(e);
    }
  }
}
