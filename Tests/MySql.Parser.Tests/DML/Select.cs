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

using System;
using System.Text;
using Antlr.Runtime;
using Xunit;

namespace MySql.Parser.Tests
{

  public class Select
  {
    [Fact]
    public void SelectSimple()
    {
      AstParserRuleReturnScope<object, IToken> r = Utility.ParseSql("select * from `t`");
      //CommonTree ct = r.Tree as CommonTree;
      //Assert.Equal( "select", ct.Text );
      //Assert.Equal( 2, ct.ChildCount );
      //Assert.Equal("into_from", ct.Children[1].Text.ToLower());

      //Assert.Equal( "from", ct.Children[ 1 ].GetChild( 0 ).Text );
      //Assert.Equal(1, ct.Children[1].GetChild(0).ChildCount);
      //Assert.Equal("TABLE", ct.Children[1].GetChild(0).GetChild(0).Text);
      //Assert.Equal(1, ct.Children[1].GetChild(0).GetChild(0).ChildCount);
      //Assert.Equal( "`t`", ct.Children[ 1 ].GetChild( 0 ).GetChild( 0 ).GetChild( 0 ).Text );

      //Assert.Equal( "COLUMNS", ct.Children[ 0 ].Text );
      //Assert.Equal( 1, ct.Children[ 0 ].ChildCount );
      //Assert.Equal( "SELECT_EXPR", ct.Children[ 0 ].GetChild( 0 ).Text );
      //Assert.Equal( 1, ct.Children[ 0 ].GetChild( 0 ).ChildCount );
      //Assert.Equal( "*", ct.Children[ 0 ].GetChild( 0 ).GetChild( 0 ).Text );
    }

    [Fact]
    public void UnionTest()
    {
      Utility.ParseSql(@"(SELECT a FROM t1 WHERE a=10 AND B=1)
        UNION
        (SELECT a FROM t2 WHERE a=11 AND B=2)
        union all ( select 1, 2, 3, t.* from t1 straight_join t2 )
        ");
    }

    [Fact]
    public void CompoundOperatorsTest()
    {
      Utility.ParseSql("select a from t where ( a <= b )");
    }

    [Fact]
    public void LimitTest()
    {
      Utility.ParseSql("select a, b, c from Table1 limit 100");
      Utility.ParseSql("select a, b, c from Table1 limit 5000, 6000");
      Utility.ParseSql("select a, b, c from Table1 where ( a = 1 ) limit 200 offset 100");
    }

    [Fact]
    public void OrderByTest()
    {
      Utility.ParseSql("select a, b, c from Table1 order by c asc, b desc, 2 asc");
      Utility.ParseSql("select a, b, c from Table1 order by null");
    }

    [Fact]
    public void WhereTestBroken()
    {
      Utility.ParseSql("select a from", true);
    }

    [Fact]
    public void WhereBetweenTest()
    {
      Utility.ParseSql("select a from `table` where `a` between 1 and 2");
    }

    [Fact]
    public void WhereBetweenTest2()
    {
      Utility.ParseSql("select `a` from `table` where ( `a` between 1 and 2 )");
    }

    [Fact]
    public void JoinTest()
    {
      Utility.ParseSql("select `a`, `b`, `c` from `tabA` inner join `tabB` on `tabA`.`KeyId` = `tabB`.`ForeignKeyId`;");
    }

    [Fact]
    public void StarSimpleTest()
    {
      Utility.ParseSql("select * from TabA");
    }

    [Fact]
    public void StarComplexTest()
    {
      Utility.ParseSql(@"select t1.*, t2.*, t3.*, * from t1 inner join t2 on t1.Id = t2.ParentId 
          inner join t3 on t2.Id = t3.ParentId ");
    }

    [Fact]
    public void SimpleCrossJoinWithoutOnTest()
    {
      Utility.ParseSql("select * from t1 cross join t2");
    }

    [Fact]
    public void SimpleCrossJoinTest()
    {
      Utility.ParseSql("select * from t1 cross join t2 on t1.col1 = t2.col2");
    }

    [Fact]
    public void SimpleInnerJoinWithoutOnTest()
    {
      Utility.ParseSql("select * from t1 inner join t2");
    }

    [Fact]
    public void SimpleInnerJoinTest()
    {
      Utility.ParseSql("select * from t1 inner join t2 on t1.col1 = t2.col2");
    }

    [Fact]
    public void SimpleStraightJoinWithoutOnTest()
    {
      Utility.ParseSql("select * from t1 straight_join t2");
    }

    [Fact]
    public void SimpleStraightJoinTest()
    {
      Utility.ParseSql("select * from t1 straight_join t2 on t1.col1 = t2.col2");
    }

    [Fact]
    public void SimpleLeftJoinTest()
    {
      Utility.ParseSql("select * from t1 left join t2 on t1.col1 = t2.col2");
    }

    [Fact]
    public void SimpleRightJoinTest()
    {
      Utility.ParseSql("select * from t1 right join t2 on t1.col1 = t2.col2");
    }

    [Fact]
    public void SimpleLeftOuterJoinTest()
    {
      Utility.ParseSql("select * from t1 left outer join t2 on t1.col1 = t2.col2");
    }

    [Fact]
    public void SimpleRightOuterJoinTest()
    {
      Utility.ParseSql("select * from t1 right outer join t2 on t1.col1 = t2.col2");
    }

    [Fact]
    public void SimpleNaturalJoinTest()
    {
      Utility.ParseSql("select * from t1 natural join t2");
    }

    [Fact]
    public void SimpleNaturalLeftJoinTest()
    {
      Utility.ParseSql("select * from t1 natural left join t2");
    }

    [Fact]
    public void SimpleNaturalLeftOuterJoinTest()
    {
      Utility.ParseSql("select * from t1 natural left outer join t2");
    }

    [Fact]
    public void SimpleNaturalRightJoinTest()
    {
      Utility.ParseSql("select * from t1 natural right join t2");
    }

    [Fact]
    public void SimpleNaturalRightOuterJoinTest()
    {
      Utility.ParseSql("select * from t1 natural right outer join t2");
    }

    [Fact]
    public void SimpleInnerJoinSimplestOnConditionalTest()
    {
      Utility.ParseSql("select * from t1 inner join t2 on true");
    }

    [Fact]
    public void MissingOnClausuleForJoinsTest()
    {
      Utility.ParseSql("select * from t1 left join t2", true);
      Utility.ParseSql("select * from t1 left join t2 ", true);
      Utility.ParseSql("select * from t1 right join t2 ", true);
      Utility.ParseSql("select * from t1 left outer join t2", true);
      Utility.ParseSql("select * from t1 right outer join t2", true);
    }

    [Fact]
    public void WithoutFromTestTest()
    {
      Utility.ParseSql("select 1, 2, 3");
    }

    [Fact]
    public void OdbcJoinTest()
    {
      Utility.ParseSql("select * from { oj TabA left outer join TabB on TabA.ID = TabB.ID }");
    }

    [Fact]
    public void LikeConditionTest()
    {
      Utility.ParseSql("select * from t where a like 'ab'");
    }

    [Fact]
    public void T()
    {
      Utility.ParseSql("select * from mysql.user limit 2;");
      //Utility.ParseSql("select * from t where a between b");
    }

    [Fact]
    public void MissingTable()
    {
      Utility.ParseSql("select * from", true);
    }

    [Fact]
    public void MissingColumn()
    {
      Utility.ParseSql("select from t2, t3;", true);
    }

    [Fact]
    public void Tx1()
    {
      Utility.ParseSql("select  \nfrom t; \n delete from tbl1", true);
    }

    [Fact]
    public void Tx3()
    {
      Utility.ParseSql("select from table1 inner join table2 on true", true);
    }

    [Fact]
    public void Tx4()
    {
      Utility.ParseSql("select * from table1 inner join table2 on true", false);
    }

    [Fact]
    public void Tx5()
    {
      Utility.ParseSql(
        @"
select *, `fromtable`.`Id` from `fromtable` as f inner join `fromtable` on true where ( 1 = 1 );
delete from `order` where `order`.`Id` = 1;
update `facility` set `facility`.`name` = '' where `facility`.`Id` is null or `facility`.`Id` > 0;
insert into `computer`( `computer`.`Processor`, `computer`.`Model` ) values ( 1, 0 );
select `computer`.`Brand`  from `facility` as a;
",
        false);
    }

    [Fact]
    public void Subquery()
    {
      Utility.ParseSql("SELECT * FROM t1 WHERE column1 = (SELECT column1 FROM t2);", false);
    }

    [Fact]
    public void Subquery2()
    {
      StringBuilder sb;
      AstParserRuleReturnScope<object, IToken> r =
        Utility.ParseSql("SELECT *,(SELECT COUNT(*) FROM table2 WHERE table2.field1 = table1.id) AS count FROM table1 WHERE table1.field1 = 'value';", false, out sb);
    }
    /*
     * TODO:
     * Since it is legal ( select * from t ) limit 10, but illegal
     * ((select * from t ) limit 20 ) limit 30
     * This might need a semantic predicate to be resolved.
     * */
    /*
    [Fact]
    public void NestedLimitTest()
    {
        Utility.ParseSql("(SELECT * from T LIMIT 1) LIMIT 2;");
    }
     * */

    [Fact]
    public void WithPartition_55()
    {
      StringBuilder sb;
      AstParserRuleReturnScope<object, IToken> r = Utility.ParseSql(
        @"SELECT * FROM employees PARTITION (p1);", true, out sb, new Version(5, 5));
      //Assert.True(sb.ToString().IndexOf("missing EndOfFile at '('", StringComparison.OrdinalIgnoreCase) != -1);
      Assert.True(sb.ToString().IndexOf("no viable alternative at input 'PARTITION'", StringComparison.OrdinalIgnoreCase) != -1);
    }

    [Fact]
    public void WithPartition_56()
    {
      Utility.ParseSql(@"SELECT * FROM employees PARTITION (p1);", false, new Version(5, 6));
    }

    [Fact]
    public void WithPartition_2_56()
    {
      Utility.ParseSql(
        @"SELECT * FROM employees PARTITION (p0, p2)
WHERE lname LIKE 'S%';", false, new Version(5, 6));
    }

    [Fact]
    public void WithPartition_3_56()
    {
      Utility.ParseSql(
        @"SELECT id, CONCAT(fname, ' ', lname) AS name 
    FROM employees PARTITION (p0) ORDER BY lname;", false, new Version(5, 6));
    }

    [Fact]
    public void WithPartition_4_56()
    {
      Utility.ParseSql(
        @"SELECT store_id, COUNT(department_id) AS c 
    FROM employees PARTITION (p1,p2,p3) 
    GROUP BY store_id HAVING c > 4;", false, new Version(5, 6));
    }

    [Fact]
    public void WithPartition_5_56()
    {
      Utility.ParseSql(
        @"SELECT id, CONCAT(fname, ' ', lname) AS name
    FROM employees_sub PARTITION (p2sp1);", false, new Version(5, 6));
    }

    [Fact]
    public void WithPartition_6_56()
    {
      Utility.ParseSql(
        @"SELECT
         e.id AS 'Employee ID', CONCAT(e.fname, ' ', e.lname) AS Name,
         s.city AS City, d.name AS department
     FROM employees AS e
         JOIN stores PARTITION (p1) AS s ON e.store_id=s.id
         JOIN departments PARTITION (p0) AS d ON e.department_id=d.id
     ORDER BY e.lname;", false, new Version(5, 6));
    }

    [Fact]
    public void Arnaud1()
    {
      Utility.ParseSql(@"
( 
  SELECT COUNT( * ) `c` 
  FROM meetings LEFT JOIN users jt1 
  ON jt1 . id = meetings . assigned_user_id AND jt1 . deleted = ? AND jt1 . deleted = ? 
  INNER JOIN meetings_contacts 
    ON ( meetings . id = meetings_contacts . meeting_id AND meetings_contacts . contact_id = ? )
  WHERE ( meetings_contacts . deleted = ? AND meetings . deleted = ? AND ( meetings . status = ? ) ) AND meetings . deleted = ?
)
UNION ALL ( 
  SELECT COUNT( * ) `c`
  FROM tasks LEFT JOIN contacts contacts 
  ON contacts . id = tasks . contact_id AND contacts . deleted = ? AND contacts . deleted = ?
    LEFT JOIN users jt1 
    ON jt1 . id = tasks . assigned_user_id AND jt1 . deleted = ? AND jt1 . deleted = ? 
    WHERE ( tasks . contact_id = ? AND tasks . deleted = ? AND ( tasks . status = ? OR tasks . status = ? OR tasks . status = ? ) ) AND tasks . deleted = ? 
) UNION ALL ( 
  SELECT COUNT( * ) `c`
  FROM calls LEFT JOIN users jt1 
  ON jt1 . id = calls . assigned_user_id AND jt1 . deleted = ? AND jt1 . deleted = ? 
  INNER JOIN calls_contacts 
  ON ( calls . id = calls_contacts . call_id AND calls_contacts . contact_id = ? ) 
  WHERE ( calls_contacts . deleted = ? AND calls . deleted = ? AND ( calls . status = ? ) ) AND calls . deleted = ?
)", false);
    }

    [Fact]
    public void Arnaud2()
    {
      Utility.ParseSql(@"
SELECT * FROM merlintest . agentlist
WHERE id NOT IN ( SELECT SUBSTR( `o` . value , ? , ? ) AS agentID 
FROM mem . dc_ng_string_now AS `o`
JOIN mem . inventory_instance_attributes AS iia USING ( instance_attribute_id )
JOIN mem . inventory_instances USING ( instance_id ) 
JOIN (
SELECT inventory_attributes . attribute_id , attribute_name , instance_attribute_id , MAX( end_time ) AS _end_time 
FROM mem . dc_ng_string_now 
JOIN mem . inventory_instance_attributes USING ( instance_attribute_id ) 
JOIN mem . inventory_instances USING ( instance_id ) 
JOIN mem . inventory_attributes USING ( attribute_id )
WHERE attribute_name = ? 
GROUP BY instance_attribute_id ) AS `i` ON `o` . instance_attribute_id = `i` . instance_attribute_id AND `o` . end_time = `i` . _end_time 
)
ORDER BY id", false);
    }

    [Fact]
    public void Arnaud3()
    {
      Utility.ParseSql(@"
SELECT QRY_SID_QQ.QuestionID AS QuestionID,QRY_SID_QQ.QuestionTypeID AS QuestionTypeID,QRY_SID_QQ.Options AS Options,QRY_SID_QQ.Points AS Points,Now() AS Date,
QRY_SID_QQ.Unknown AS Unknown,
QRY_SID_QQ.UnitID AS UnitID,
QRY_SID_QQ.Threshold AS Threshold,
QRY_SID_QQ.OtherUnit AS OtherUnit
FROM 
QRY_A0154_QuizQuestions QRY_SID_QQ 
LEFT JOIN
QRY_A0154_RecordQns QRY_SID_RQ 
ON (
QRY_SID_QQ.QuizID=QRY_SID_RQ.QuizID AND
QRY_SID_QQ.QuestionID=QRY_SID_RQ.QuestionID AND 
QRY_SID_RQ.AttemptID='0' AND 
QRY_SID_RQ.UserID='319459'
)
WHERE 
QRY_SID_QQ.QuizID='c29f8c6a94a2488eb93750d631b96ebb' AND
QRY_SID_RQ.QuestionID IS NULL
ORDER BY 
RAND()
LIMIT 1", false);
    }

    [Fact]
    public void MixingParenthesisInTable()
    {
      Utility.ParseSql(@"select * from (( select * from actor )) as t limit 1", false);
    }

    [Fact]
    public void MixingParenthesisInTable2()
    {
      Utility.ParseSql(@"select * from ( actor ) as t limit 1", true);
    }

    [Fact]
    public void MixingParenthesisInTable3()
    {
      Utility.ParseSql(@"select * from ( actor ) limit 1", false);
    }

    [Fact]
    public void MixingParenthesisInTable4()
    {
      Utility.ParseSql(@"select * from ( actor ), film limit 1", false);
    }

    [Fact]
    public void MixingParenthesisInTable5()
    {
      Utility.ParseSql(@"select * from ( actor ), ( film  ) limit 1", false);
    }

    [Fact]
    public void MixingParenthesisInTable6()
    {
      Utility.ParseSql(@"select * from (( actor )) limit 1", false);
    }

    [Fact]
    public void MixingParenthesisInTable7()
    {
      Utility.ParseSql(@"select * from (( actor )), film limit 1", false);
    }

    [Fact]
    public void MixingParenthesisInTable8()
    {
      Utility.ParseSql(@"select * from (( actor )), ((( film  ))) limit 1", false);
    }

    [Fact]
    public void MaxStatementTime56()
    {
      Utility.ParseSql(@"SELECT MAX_STATEMENT_TIME = 109 * FROM my_table;", true, new Version(5, 6));
    }

    [Fact]
    public void MaxStatementTime57()
    {
      Utility.ParseSql(@"SELECT MAX_STATEMENT_TIME = 109 * FROM my_table;", false, new Version(5, 7));
    }

    [Fact]
    public void GroupBy()
    {
      Utility.ParseSql("SELECT a, b, c FROM t1 GROUP BY a", false);
    }

    [Fact]
    public void GroupByWithOrdering()
    {
      Utility.ParseSql("SELECT a, b, c FROM t1 GROUP BY a ASC", false, new Version(8, 0, 12));
      Utility.ParseSql("SELECT a, b, c FROM t1 GROUP BY a DESC", false, new Version(8, 0, 12));
    }

    [Fact]
    public void Table()
    {
      Utility.ParseSql("TABLE t;", false, new Version(8, 0, 19));
      Utility.ParseSql("TABLE t ORDER BY b;", false, new Version(8, 0, 19));
      Utility.ParseSql("TABLE t LIMIT 3;", false, new Version(8, 0, 19));
      Utility.ParseSql("TABLE t ORDER BY b LIMIT 3;", false, new Version(8, 0, 19));
      Utility.ParseSql("TABLE t ORDER BY c LIMIT 10 OFFSET 3;", false, new Version(8, 0, 19));
      Utility.ParseSql("TABLE t ORDER BY c LIMIT 10 OFFSET 3;", true, new Version(8, 0, 18));
    }

    [Fact]
    public void Into()
    {
      Utility.ParseSql("SELECT * INTO OUTFILE 'file_name' FROM table_name;", false);
      Utility.ParseSql("SELECT * FROM table_name INTO OUTFILE 'file_name' FOR UPDATE;");
      Utility.ParseSql("SELECT * FROM table_name FOR UPDATE INTO OUTFILE 'file_name';", false, new Version(8, 0, 20));
      Utility.ParseSql("SELECT * FROM table_name FOR UPDATE INTO OUTFILE 'file_name';", true, new Version(8, 0, 19));
    }
  }
}