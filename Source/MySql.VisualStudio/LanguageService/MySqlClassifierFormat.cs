// Copyright (c) 2011-2013, Oracle and/or its affiliates. All rights reserved.
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

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Windows.Media;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;


namespace MySql.Data.VisualStudio
{
  internal static class MySqlClassifierDefinitions
  {
    internal const string Comment = "MySqlComment";
    internal const string Literal = "MySqlLiteral";
    internal const string Keyword = "MySqlKeyword";
    internal const string Operator = "MySqlOperator";
    internal const string Text = "MySqlText";

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(Comment)]
    public static ClassificationTypeDefinition MySqlCommentDefinition { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(Literal)]
    public static ClassificationTypeDefinition MySqlLiteralDefinition { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(Keyword)]
    public static ClassificationTypeDefinition MySqlKeywordDefinition { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(Operator)]
    public static ClassificationTypeDefinition MySqlOperatorDefinition { get; set; }

    [Export(typeof(ClassificationTypeDefinition))]
    [Name(Text)]
    public static ClassificationTypeDefinition MySqlTextDefinition { get; set; }
  }

  /// <summary>
  /// Represents an editor format for the MySqlComment type.
  /// </summary>
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = MySqlClassifierDefinitions.Comment)]
  [Name(MySqlClassifierDefinitions.Comment)]
  [UserVisible(true)]
  [Order(Before = Priority.Default)]
  internal sealed class MySqlComment : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the MySqlComment class.
    /// </summary>
    public MySqlComment()
    {
      this.DisplayName = "MySql Comment";
      this.ForegroundColor = Colors.Green;
    }
  }

  /// <summary>
  /// Represents an editor format for the MySqlLiteral type.
  /// </summary>
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = MySqlClassifierDefinitions.Literal)]
  [Name(MySqlClassifierDefinitions.Literal)]
  [UserVisible(true)] //this should be visible to the end user
  [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
  internal sealed class MySqlLiteral : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the MySqlLineComment class.
    /// </summary>
    public MySqlLiteral()
    {
      this.DisplayName = "MySql Literal";
      this.ForegroundColor = Colors.Brown;
    }
  }

  /// <summary>
  /// Represents an editor format for the MySqlKeyword type.
  /// </summary>
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = MySqlClassifierDefinitions.Keyword)]
  [Name(MySqlClassifierDefinitions.Keyword)]
  [UserVisible(true)]
  [Order(Before = Priority.Default)]
  internal sealed class MySqlKeyword : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the MySqlLineComment class.
    /// </summary>
    public MySqlKeyword()
    {
      this.DisplayName = "MySql Keyword";
      this.ForegroundColor = Colors.Blue;
    }
  }

  /// <summary>
  /// Represents an editor format for the MySqlOperator type.
  /// </summary>
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = MySqlClassifierDefinitions.Operator)]
  [Name(MySqlClassifierDefinitions.Operator)]
  [UserVisible(true)]
  [Order(Before = Priority.Default)]
  internal sealed class MySqlOperator : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the MySqlOperator class.
    /// </summary>
    public MySqlOperator()
    {
      this.DisplayName = "MySql Operator";
      this.ForegroundColor = Colors.Gray;
    }
  }

  /// <summary>
  /// Represents an editor format for the MySqlText type.
  /// </summary>
  [Export(typeof(EditorFormatDefinition))]
  [ClassificationType(ClassificationTypeNames = MySqlClassifierDefinitions.Text)]
  [Name(MySqlClassifierDefinitions.Text)]
  [UserVisible(true)]
  [Order(Before = Priority.Default)]
  internal sealed class MySqlText : ClassificationFormatDefinition
  {
    /// <summary>
    /// Initializes a new instance of the MySqlText class.
    /// </summary>
    public MySqlText()
    {
      this.DisplayName = "MySql Text";
      this.ForegroundColor = Colors.Black;
    }
  }
}
