// Copyright (c) 2014, 2021, Oracle and/or its affiliates.
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

using System.Text;
using Xunit;
using Antlr.Runtime;


namespace MySql.Parser.Tests
{
  public class Other3
  {
    [Fact]
    public void Test1()
    {
      string sql = @"select ifnull(timestampdiff(MONTH,now(), now()),1)";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test2()
    {
      // when is not valid identifier
      string sql = @"CREATE TABLE app_starredrecipe ( id INTEGER AUTO_INCREMENT NOT NULL PRIMARY KEY , recipe_id INTEGER NOT NULL , user_id INTEGER NOT NULL , `when` datetime NOT NULL , notes VARCHAR( 1 ) NOT NULL ) ;";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test3()
    {
      // 'group' is not valid identifier
      string sql = @"SELECT app_grain . id , app_grain . name , app_grain . extract_min , app_grain . extract_max , app_grain . volume_potential_min , app_grain . volume_potential_max , app_grain . lovibond_min , app_grain . lovibond_max , app_grain . description , app_grain.`group` FROM app_grain";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test4()
    {
      string sql = @"create table app_grain(
 id int ,  
 name int,  
 extract_min int ,  
 extract_max int,  
 volume_potential_min int,  
 volume_potential_max int,  
 lovibond_min int,  
 lovibond_max int,  
 description int, 
`group` int) engine=InnoDB;";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test5()
    {
      // group is not valid identifier
      string sql = @"SELECT app_grain . id , app_grain . name , app_grain . extract_min , 
app_grain . extract_max , app_grain . volume_potential_min , app_grain . volume_potential_max , 
app_grain . lovibond_min , app_grain . lovibond_max , app_grain . description , 
app_grain.`group` FROM app_grain";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test6()
    {
      // May be illegal, check support for expression placeholders in server grammars
      // 'group' is not valid identifier
      string sql = @"INSERT INTO app_grain ( name , extract_min , extract_max , volume_potential_min , volume_potential_max , lovibond_min , lovibond_max , description , `group` ) VALUES ( ? , ? , ? , ? , ? , ? , ? , ? , ? )";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test7()
    {
      // 'group' is not valid identifier
      string sql = @"INSERT INTO app_grain ( name , extract_min , extract_max , volume_potential_min , volume_potential_max , lovibond_min , lovibond_max , description , `group` ) VALUES ( 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test8()
    {
      string sql = @"create table app_starredrecipe(
 id int,
 recipe_id int,
 user_id int,
 `when` int ,
 notes int) engine=InnoDB;
";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test9()
    {
      string sql = @"SELECT app_starredrecipe . id , app_starredrecipe . recipe_id , app_starredrecipe . user_id , app_starredrecipe. `when` , app_starredrecipe . notes FROM app_starredrecipe WHERE app_starredrecipe . user_id = 1;";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test10()
    {
      // keywords
      string sql = @"INSERT IGNORE INTO statement_summary_data ( bytes , count , errors , exec_time , max_bytes , max_exec_time , max_rows , min_bytes , min_exec_time , min_rows , no_good_index_used , no_index_used , rows , warnings , statement_summary_id , TIMESTAMP ) VALUES ( ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? )";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test11()
    {
      string sql = @"create table statement_summary_data ( bytes int ,
 count int ,
 errors int ,
 exec_time int ,
 max_bytes int ,
 max_exec_time int ,
 max_rows int ,
 min_bytes int ,
 min_exec_time int ,
 min_rows int ,
 no_good_index_used int ,
 no_index_used int ,
 rows int ,
 warnings int ,
 statement_summary_id int ,
 TIMESTAMP int);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test12()
    {
      string sql = @"INSERT IGNORE INTO statement_summary_data ( bytes , count , errors , exec_time , max_bytes , max_exec_time , max_rows , min_bytes , min_exec_time , min_rows , no_good_index_used , no_index_used , rows , warnings , statement_summary_id , TIMESTAMP ) VALUES ( 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test13()
    {
      //string sql = @"INSERT INTO statement_examples ( bytes , comment , connection_id , data_base , errors , exec_time , explain_plan , host_from , host_to , no_good_index_used , no_index_used , query_type , rows , source_location , TEXT , user , warnings , instance_id , TIMESTAMP ) VALUES ( ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? ) ON duplicate KEY UPDATE bytes = IFNULL( VALUES( bytes ) , bytes ) /* , ... */ = IFNULL( VALUES( comment ) , comment ) /* , ... */ = IFNULL( VALUES( connection_id ) , connection_id ) /* , ... */ = IFNULL( VALUES( data_base ) , data_base ) /* , ... */ = IFNULL( VALUES( errors ) , errors ) /* , ... */ = IFNULL( VALUES( exec_time ) , exec_time ) /* , ... */ = IFNULL( VALUES( explain_plan ) , explain_plan ) /* , ... */ = IFNULL( VALUES( host_from ) , host_from ) /* , ... */ = IFNULL( VALUES( host_to ) , host_to ) /* , ... */ = IFNULL( VALUES( no_good_index_used ) , no_good_index_used ) /* , ... */ = IFNULL( VALUES( no_index_used ) , no_index_used ) /* , ... */ = IFNULL( VALUES( query_type ) , query_type ) /* , ... */ = IFNULL( VALUES( rows ) , rows ) /* , ... */ = IFNULL( VALUES( source_location ) , source_location ) /* , ... */ TEXT = IFNULL( VALUES( TEXT ) , TEXT ) /* , ... */ = IFNULL( VALUES( user ) , user ) /* , ... */ = IFNULL( VALUES( warnings ) , warnings )";
      string sql = @"
INSERT INTO statement_examples ( bytes , comment , connection_id , data_base , errors , exec_time , explain_plan , 
  host_from , host_to , no_good_index_used , no_index_used , query_type , rows , source_location , TEXT , user , 
  warnings , instance_id , TIMESTAMP ) 
  VALUES ( ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? , ? ) 
  ON duplicate KEY UPDATE bytes = IFNULL( VALUES( bytes ) , bytes ), commet = IFNULL( VALUES( comment ) , comment ), 
  connection_id = IFNULL( VALUES( connection_id ) , connection_id ), data_base = IFNULL( VALUES( data_base ) , data_base ), 
  errors = IFNULL( VALUES( errors ) , errors ), exec_time = IFNULL( VALUES( exec_time ) , exec_time ), 
  explain_plan = IFNULL( VALUES( explain_plan ) , explain_plan ), host_from = IFNULL( VALUES( host_from ) , host_from ), 
  host_to = IFNULL( VALUES( host_to ) , host_to ), no_good_index_used = IFNULL( VALUES( no_good_index_used ) , 
  no_good_index_used ),
  no_index_used = IFNULL( VALUES( no_index_used ) , no_index_used ), query_type = IFNULL( VALUES( query_type ), query_type ),
  rows = IFNULL( VALUES( rows ) , rows ), source_location = IFNULL( VALUES( source_location ) , source_location ), 
  TEXT = IFNULL( VALUES( TEXT ) , TEXT ), user = IFNULL( VALUES( user ) , user ),
  warnings = IFNULL( VALUES( warnings ) , warnings )";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test14()
    {
      string sql = @"create table statement_examples 
( bytes int ,
 comment int ,
 connection_id int ,
 data_base int ,
 errors int ,
 exec_time int ,
 explain_plan int ,
 host_from int ,
 host_to int ,
 no_good_index_used int ,
 no_index_used int ,
 query_type int ,
 rows int ,
 source_location int ,
 TEXT int ,
 user int ,
 warnings int ,
 instance_id int ,
 TIMESTAMP int );
";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test15()
    {
      string sql = @"INSERT INTO statement_examples(bytes,
                               comment,
                               connection_id,
                               data_base,
                               errors,
                               exec_time,
                               explain_plan,
                               host_from,
                               host_to,
                               no_good_index_used,
                               no_index_used,
                               query_type,
                               rows,
                               source_location,
                               TEXT,
                               user,
                               warnings,
                               instance_id,
                               TIMESTAMP)
VALUES (1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1);
";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test16()
    {
      string sql = @"INSERT INTO statement_examples ( bytes , comment , connection_id , data_base , errors , exec_time , explain_plan , host_from , host_to , no_good_index_used , no_index_used , query_type , rows , source_location , TEXT , user , warnings , instance_id , TIMESTAMP ) 
VALUES (1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1)
ON duplicate KEY UPDATE 
bytes = IFNULL( VALUES( bytes ) , bytes ), 
comment = IFNULL( VALUES( comment ) , comment ),
connection_id = IFNULL( VALUES( connection_id ) , connection_id ),
data_base = IFNULL( VALUES( data_base ) , data_base ),
errors = IFNULL( VALUES( errors ) , errors ),
exec_time = IFNULL( VALUES( exec_time ) , exec_time ),
explain_plan = IFNULL( VALUES( explain_plan ) , explain_plan ),
host_from = IFNULL( VALUES( host_from ) , host_from ),
host_to = IFNULL( VALUES( host_to ) , host_to ),
no_good_index_used = IFNULL( VALUES( no_good_index_used ) , no_good_index_used ),
no_index_used = IFNULL( VALUES( no_index_used ) , no_index_used ),
query_type = IFNULL( VALUES( query_type ) , query_type ),
rows = IFNULL( VALUES( rows ) , rows ) ,
source_location = IFNULL( VALUES( source_location ) , source_location ),
TEXT = IFNULL( VALUES( TEXT ) , TEXT ),
user = IFNULL( VALUES( user ) , user ),
warnings = IFNULL( VALUES( warnings ) , warnings );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test17()
    {
      string sql = @"create table bdb(id int);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test18()
    {
      string sql = @"create table backup_progress (
  backup_id int,
  tool_name int,  
  error_code int, 
  error_message int, 
  `current_time` int, 
  current_state  int
) engine = MyISAM;
";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test19()
    {
      string sql = @"CREATE TABLE `backup_history` (
  `backup_id` int(11) DEFAULT NULL,
  `tool_name` int(11) DEFAULT NULL,
  `start_time` int(11) DEFAULT NULL,
  `end_time` int(11) DEFAULT NULL,
  `binlog_pos` int(11) DEFAULT NULL,
  `binlog_file` int(11) DEFAULT NULL,
  `compression_level` int(11) DEFAULT NULL,
  `engines` int(11) DEFAULT NULL,
  `innodb_data_file_path` int(11) DEFAULT NULL,
  `innodb_file_format` int(11) DEFAULT NULL,
  `start_lsn` int(11) DEFAULT NULL,
  `end_lsn` int(11) DEFAULT NULL,
  `backup_type` int(11) DEFAULT NULL,
  `backup_format` int(11) DEFAULT NULL,
  `mysql_data_dir` int(11) DEFAULT NULL,
  `innodb_data_home_dir` int(11) DEFAULT NULL,
  `innodb_log_group_home_dir` int(11) DEFAULT NULL,
  `innodb_log_files_in_group` int(11) DEFAULT NULL,
  `innodb_log_file_size` int(11) DEFAULT NULL,
  `backup_destination` int(11) DEFAULT NULL,
  `lock_time` int(11) DEFAULT NULL,
  `exit_state` int(11) DEFAULT NULL,
  `last_error` int(11) DEFAULT NULL,
  `last_error_code` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test20()
    {
      // 'curret_time' is not valid identifier
      string sql = @"SELECT start_time AS start_time_raw, UNIX_TIMESTAMP(start_time) AS start_time_ts, end_time AS end_time_raw, UNIX_TIMESTAMP(end_time) AS end_time_ts, IFNULL(TIMESTAMPDIFF(SECOND, start_time, end_time), 0) AS total_time, lock_time, exit_state, last_error, last_error_code, (SELECT GROUP_CONCAT('\\\\\n* ', backup_progress.`current_time`, ': ', IF((error_message != 'NO_ERROR' OR current_state = ''), CONCAT(error_message, ' (errcode: ', error_code, ') ', current_state), current_state)) progress_log FROM mysql.backup_progress WHERE backup_progress.backup_id = backup_history.backup_id GROUP BY backup_id) AS progress_log, UNIX_TIMESTAMP() AS collected_ts, UNIX_TIMESTAMP() AS collected_ts_counter, mysql_data_dir, backup_destination FROM mysql.backup_history ORDER BY backup_id DESC LIMIT 1";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test21()
    {
      string sql = @"SELECT CASE 1 WHEN 1 THEN 'one' WHEN 2 THEN 'two' ELSE 'more' END ";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test22()
    {
      string sql = @"select $a.* from (select 1 ) as $a ";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void Test23()
    {
      // original query was 'select * from t where where d <=concat(@d,' 23:59:59') '
      string sql = @"select * from t where d <=concat(@d,' 23:59:59') ";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestIfWithSpaces()
    {
      string sql = @"select if (1, 1, if(1,1, 1))";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestDatabaseWithSpaces()
    {
      string sql = @"SELECT DATABASE ();";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestRowcountWithSpaces()
    {
      string sql = @"SELECT ROW_COUNT ();";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestIfNullWithSpaces()
    {
      string sql = @"CREATE TABLE tmp SELECT IFNULL (1,'test') AS test;";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestNullIfWithSpaces()
    {
      string sql = @"SELECT NULLIF (1,2);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestModWithSpaces()
    {
      string sql = @"SELECT MOD (34.5,3);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestRepeatWithSpaces()
    {
      string sql = @"SELECT REPEAT ('MySQL', 3);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestReplaceWithSpaces()
    {
      string sql = @"SELECT REPLACE ('www.mysql.com', 'w', 'Ww');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestSchemaWithSpaces()
    {
      string sql = @"select schema ( );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestCharsetWithSpaces()
    {
      string sql = @"SELECT CHARSET ('abc');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestCharsetWithSpaces3()
    {
      string sql = @"SELECT CHARSET (USER ());";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestAsciiWithSpaces()
    {
      string sql = @"SELECT ASCII ('2');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestAsciiWithSpaces2()
    {
      string sql = @"SELECT ASCII (2);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestTruncateWithSpaces()
    {
      string sql = @"select TRUNCATE (1.223,1);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestCoalesceWithSpaces()
    {
      string sql = @"SELECT COALESCE (NULL,1);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestCoalesceWithSpaces2()
    {
      string sql = @"SELECT COALESCE (NULL,NULL,NULL);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestCollationWithSpaces()
    {
      string sql = @"SELECT COLLATION ('abc');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestMicrosecondWithSpaces()
    {
      string sql = @"SELECT MICROSECOND ('2009-12-31 23:59:59.000010');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestQuarterWithSpaces()
    {
      string sql = @"SELECT QUARTER ('2008-04-01');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestTimestampaddWithSpaces()
    {
      string sql = @"SELECT TIMESTAMPADD (MINUTE,1,'2003-01-02');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestTimestampaddWithSpaces2()
    {
      string sql = @"SELECT TIMESTAMPADD (WEEK,1,'2003-01-02');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestTimestampdiffWithSpaces()
    {
      string sql = @"SELECT TIMESTAMPDIFF (MONTH,'2003-02-01','2003-05-01');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestTimestampdiffWithSpaces2()
    {
      string sql = @"SELECT TIMESTAMPDIFF (YEAR,'2002-05-01','2001-01-01');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestTimestampdiffWithSpaces3()
    {
      string sql = @"SELECT TIMESTAMPDIFF (MINUTE,'2003-02-01','2003-05-01 12:05:55');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestWeekWithSpaces()
    {
      string sql = @"SELECT WEEK ('2008-02-20');";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestWeekWithSpaces2()
    {
      string sql = @"SELECT WEEK ('2008-02-20',1);";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestCurtimeWithSpaces()
    {
      string sql = @"SELECT CURTIME(), curtime( 1 );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestDayWithSpaces()
    {
      string sql = @"SELECT day ( curdate() );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestLeftWithSpaces()
    {
      string sql = @"SELECT left ( 'foobar', 5 );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestRightWithSpaces()
    {
      string sql = @"SELECT right ( 'foobar', 5 );";
      Utility.ParseSql(sql, false);
    }

    [Fact]
    public void TestUserWithSpaces()
    {
      string sql = @"SELECT user ();";
      Utility.ParseSql(sql, false);
    }
  }
}
