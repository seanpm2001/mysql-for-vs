﻿// Copyright (c) 2017, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License as
// published by the Free Software Foundation; version 2 of the
// License.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
// 02110-1301  USA

using System.ComponentModel;
using MySql.Utility.Classes.Spatial;

namespace MySql.Utility.Enums
{
  /// <summary>
  /// Specifies identifiers to indicate the type of format used to encode a <see cref="Geometry"/> in text.
  /// </summary>
  public enum GeometryAsTextFormatType
  {
    /// <summary>
    ///  Not set or unknown.
    /// </summary>
    [Description("Not set or unknown")]
    None = -1,

    /// <summary>
    /// Well-Known Text (WKT), which is a text markup language for representing vector geometry objects on a map
    /// This is the default used by MySQL spatial functions.
    /// </summary>
    [Description("Well-Known Text")]
    WKT = 0,

    /// <summary>
    /// Keyhole Markup Language (KML), which is an XML notation for expressing geographic annotation and visualization within Internet-based, two-dimensional maps and three-dimensional Earth browsers.
    /// </summary>
    [Description("Keyhole Markup Language")]
    KML = 1,

    /// <summary>
    /// Geography Markup Language (GML), which is the XML grammar defined by the Open Geospatial Consortium (OGC) to express geographical features.
    /// </summary>
    [Description("Geography Markup Language")]
    GML = 2,

    /// <summary>
    ///  GeoJSON, which is a format for encoding a variety of geographic data structures.
    /// </summary>
    [Description("GeoJSON")]
    GeoJSON = 3
  }
}
