﻿// Copyright © 2015, Oracle and/or its affiliates. All rights reserved.
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
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using MySql.Data.MySqlClient;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace MySql.Data.VisualStudio.Editors
{
  /// <summary>
  /// This class will handle the logic for the MyJs Files Editor.
  /// </summary>
  internal partial class MyJsEditor : GenericEditor
  {
    /// <summary>
    /// Gets the pane for the current editor. In this case, the pane is from type MyJsEditorPane.
    /// </summary>    
    internal MyJsEditorPane Pane { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyJsEditor"/> class.
    /// </summary>
    /// <exception cref="System.Exception">MySql Data Provider is not correctly registered</exception>
    public MyJsEditor()
    {
      InitializeComponent();
      factory = MySqlClientFactory.Instance;
      if (factory == null)
        throw new Exception("MySql Data Provider is not correctly registered");
      tabControl1.TabPages.Remove(resultsPage);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MyJsEditor"/> class.
    /// </summary>
    /// <param name="sp">The service provider.</param>
    /// <param name="pane">The pane.</param>
    internal MyJsEditor(ServiceProvider sp, MyJsEditorPane pane)
      : this()
    {
      Pane = pane;
      serviceProvider = sp;
      codeEditor.Init(sp, this);

      var package = MySqlDataProviderPackage.Instance;
      if (package != null)
      {
        if (package.MysqlConnectionSelected != null)
        {
          connection = package.MysqlConnectionSelected;
          if (connection.State != ConnectionState.Open)
            connection.Open();
          UpdateButtons();
        }
      }  
    }

    #region Overrides

    /// <summary>
    /// Gets the file format list.
    /// </summary>
    /// <returns>The string with the file name and extensions for the 'Save as' dialog.</returns>
    protected override string GetFileFormatList()
    {
      return "MyJs Script Files (*.myjs)\n*.myjs\n\n";
    }

    /// <summary>
    /// Gets the full document path, including file name and extension
    /// </summary>
    /// <returns>The full document path, including file name and extension</returns>
    public override string GetDocumentPath()
    {
      return Pane.DocumentPath;
    }

    /// <summary>
    /// Saves the file.
    /// </summary>
    /// <param name="newFileName">New name of the file.</param>
    protected override void SaveFile(string newFileName)
    {
      using (StreamWriter writer = new StreamWriter(newFileName, false))
      {
        writer.Write(codeEditor.Text);
      }
    }

    /// <summary>
    /// Loads the file.
    /// </summary>
    /// <param name="newFileName">New name of the file.</param>
    protected override void LoadFile(string newFileName)
    {
      if (!File.Exists(newFileName)) return;
      using (StreamReader reader = new StreamReader(newFileName))
      {
        string sql = reader.ReadToEnd();
        codeEditor.Text = sql;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is dirty.
    /// </summary>    
    protected override bool IsDirty
    {
      get { return codeEditor.IsDirty; }
      set { codeEditor.IsDirty = value; }
    }

    #endregion      
    
    /// <summary>
    /// Handles the Click event of the connectButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void connectButton_Click(object sender, EventArgs e)
    {
      resultsPage.Hide();
      ConnectDialog d = new ConnectDialog();
      d.Connection = Connection;
      DialogResult r = d.ShowDialog();
      if (r == DialogResult.Cancel) return;
      try
      {
        connection = d.Connection;
        UpdateButtons();
      }
      catch (MySqlException)
      {
        MessageBox.Show(
@"Error establishing the database Connection.
Check that the server is running, the database exist and the user credentials are valid.", "Error", MessageBoxButtons.OK);
      }
      finally
      {
        d.Dispose();
      }
    }

    /// <summary>
    /// Handles the Click event of the runSqlButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void runSqlButton_Click(object sender, EventArgs e)
    {
      string js = codeEditor.Text.Trim();
      bool isResultSet = LanguageServiceUtil.DoesStmtReturnResults(js, (MySqlConnection)Connection);
      if (isResultSet)
        ExecuteSelect(js);
      else
        ExecuteScript(js);
      StoreCurrentDatabase();
    }

    /// <summary>
    /// Reads the current database from the last query executed or batch 
    /// of queries.
    /// </summary>
    private void StoreCurrentDatabase()
    {
      MySqlConnection con = (MySqlConnection)Connection;
      MySqlCommand cmd = new MySqlCommand("select database();", con);
      object val = cmd.ExecuteScalar();
      if (val is DBNull) CurrentDatabase = "";
      else CurrentDatabase = (string)val;
    }

    /// <summary>
    /// Executes the select statement.
    /// </summary>
    /// <param name="sql">The SQL.</param>
    private void ExecuteSelect(string sql)
    {
      tabControl1.TabPages.Clear();
      MySqlDataAdapter da = new MySqlDataAdapter(sql, (MySqlConnection)Connection);
      DataTable dt = new DataTable();
      try
      {
        da.Fill(dt);
        tabControl1.TabPages.Add(resultsPage);
        resultsGrid.CellFormatting -= new DataGridViewCellFormattingEventHandler(this.resultsGrid_CellFormatting);
        resultsGrid.DataSource = dt;
        SanitizeBlobs();
        resultsGrid.CellFormatting += new DataGridViewCellFormattingEventHandler(this.resultsGrid_CellFormatting);
      }
      catch (Exception ex)
      {
        messages.Text = ex.Message;
      }
      finally
      {
        tabControl1.TabPages.Add(messagesPage);
      }
    }

    /// <summary>
    /// In DataGridView column with blob data type are by default associated with a DataGridViewImageColumn
    /// this column internally uses the System.Drawing APIs to try to load images, obviously not all blobs
    /// are images, so that fails.
    ///   The fix implemented in this function represents blobs a a fixed &lt;Blob&gt; string.
    /// </summary>
    private void SanitizeBlobs()
    {
      DataGridViewColumnCollection coll = resultsGrid.Columns;
      _isColBlob = new bool[coll.Count];
      for (int i = 0; i < coll.Count; i++)
      {
        DataGridViewColumn col = coll[i];
        DataGridViewTextBoxColumn newCol = null;
        if (!(col is DataGridViewImageColumn)) continue;
        coll.Insert(i, newCol = new DataGridViewTextBoxColumn()
        {
          DataPropertyName = col.DataPropertyName,
          HeaderText = col.HeaderText,
          ReadOnly = true
        });
        coll.Remove(col);
        _isColBlob[i] = true;
      }
    }

    /// <summary>
    /// Handles the CellFormatting event of the resultsGrid control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="DataGridViewCellFormattingEventArgs"/> instance containing the event data.</param>
    private void resultsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.ColumnIndex == -1) return;
      if (_isColBlob[e.ColumnIndex])
      {
        if (e.Value == null || e.Value is DBNull)
          e.Value = "<NULL>";
        else
          e.Value = "<BLOB>";
      }
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <param name="js">The javascript code.</param>
    private void ExecuteScript(string js)
    {
      tabControl1.TabPages.Clear();
      MySqlScript script = new MySqlScript((MySqlConnection)Connection, js);
      try
      {
        int rows = script.Execute();
        messages.Text = String.Format("{0} row(s) affected", rows);
      }
      catch (Exception ex)
      {
        messages.Text = ex.Message;
      }
      finally
      {
        tabControl1.TabPages.Add(messagesPage);
      }
    }

    /// <summary>
    /// Handles the Click event of the disconnectButton control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void disconnectButton_Click(object sender, EventArgs e)
    {
      Connection.Close();
      UpdateButtons();
    }

    /// <summary>
    /// Updates the buttons.
    /// </summary>
    private void UpdateButtons()
    {
      bool connected = Connection.State == ConnectionState.Open;
      runJsButton.Enabled = connected;
      //            validateSqlButton.Enabled = connected;
      disconnectButton.Enabled = connected;
      connectButton.Enabled = !connected;
      serverLabel.Text = String.Format("Server: {0}",
          connected ? Connection.ServerVersion : "<none>");
      DbConnectionStringBuilder builder = factory.CreateConnectionStringBuilder();
      builder.ConnectionString = Connection.ConnectionString;
      userLabel.Text = String.Format("User: {0}",
          connected ? builder["userid"] as string : "<none>");
      dbLabel.Text = String.Format("Database: {0}",
          connected ? Connection.Database : "<none>");
    }
  }
}