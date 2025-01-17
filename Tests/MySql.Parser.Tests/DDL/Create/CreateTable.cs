// Copyright (c) 2013, 2021, Oracle and/or its affiliates.
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

using Antlr.Runtime;
using System;
using System.Text;
using Xunit;


namespace MySql.Parser.Tests.Create
{
  
  public class CreateTable
  {
    [Fact]
    public void Simple()
    {
      Utility.ParseSql("CREATE TABLE T1 ( id int, name varchar( 20 ) )");
    }

    [Fact]
    public void CreateSelect()
    {
      Utility.ParseSql(
          @"CREATE TABLE test (a INT NOT NULL AUTO_INCREMENT,
        PRIMARY KEY (a) )
        ENGINE=MyISAM SELECT b,c FROM test2;");
    }

    [Fact]
    public void Complex1()
    {
      Utility.ParseSql(
          @"CREATE TABLE IF NOT EXISTS `schema`.`Employee` (
        `idEmployee` VARCHAR(45) NOT NULL ,
        `Name` VARCHAR(255) NULL ,
        `idAddresses` VARCHAR(45) NULL ,
        PRIMARY KEY (`idEmployee`) ,
        CONSTRAINT `fkEmployee_Addresses`
        FOREIGN KEY `fkEmployee_Addresses` (`idAddresses`)
        REFERENCES `schema`.`Addresses` (`idAddresses`)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION)
        ENGINE = InnoDB,
        DEFAULT CHARACTER SET = utf8,
        COLLATE = utf8_bin");
    }

    [Fact]
    public void MergeUnion()
    {
      Utility.ParseSql(
          "create temporary table tmp2 ( Id int primary key, Name varchar( 50 ) ) engine merge union (tmp1);");
    }

    [Fact]
    public void AllOptions()
    {
      Utility.ParseSql(
@"
create temporary table if not exists Table1 ( id int ) 
engine = innodb, auto_increment = 7, avg_row_length = 100,
default character set = latin1, checksum = 1, collate = 'latin1_swedish_ci', comment = 'A test script',
connection = 'unknown', data directory = '/home/user/data', delay_key_write = 0, index directory = '/tmp',
insert_method = last, max_rows = 65536, min_rows = 1, pack_keys = default, password = 'ndn789w4^%$tf', 
row_format = dynamic, union = ( `db1`.`table2` );
");
    }

    [Fact]
    public void Partition()
    {
      Utility.ParseSql(
          @"CREATE TABLE t1 (col1 INT, col2 CHAR(5), col3 DATETIME)
PARTITION BY HASH ( YEAR(col3) );");
    }

    [Fact]
    public void Partition2()
    {
      Utility.ParseSql(
          @"CREATE TABLE tk (col1 INT, col2 CHAR(5), col3 DATE)
PARTITION BY KEY(col3)
PARTITIONS 4;");
    }

    [Fact]
    public void Partition3()
    {
      Utility.ParseSql(
          @"CREATE TABLE tk (col1 INT, col2 CHAR(5), col3 DATE)
PARTITION BY LINEAR KEY(col3)
PARTITIONS 5;");
    }

    [Fact]
    public void Partition4()
    {
      Utility.ParseSql(
          @"CREATE TABLE t1 (
year_col  INT,
some_data INT
)
PARTITION BY RANGE (year_col) (
PARTITION p0 VALUES LESS THAN (1991),
PARTITION p1 VALUES LESS THAN (1995),
PARTITION p2 VALUES LESS THAN (1999),
PARTITION p3 VALUES LESS THAN (2002),
PARTITION p4 VALUES LESS THAN (2006),
PARTITION p5 VALUES LESS THAN MAXVALUE
);");
    }

    [Fact]
    public void Partition5()
    {
      Utility.ParseSql(
          @"CREATE TABLE client_firms (
id   INT,
name VARCHAR(35)
)
PARTITION BY LIST (id) (
PARTITION r0 VALUES IN (1, 5, 9, 13, 17, 21),
PARTITION r1 VALUES IN (2, 6, 10, 14, 18, 22),
PARTITION r2 VALUES IN (3, 7, 11, 15, 19, 23),
PARTITION r3 VALUES IN (4, 8, 12, 16, 20, 24)
);");
    }

    [Fact]
    public void Partition6()
    {
      Utility.ParseSql(
          @"
CREATE TABLE th (id INT, name VARCHAR(30), adate DATE)
PARTITION BY LIST(YEAR(adate))
(
PARTITION p1999 VALUES IN (1995, 1999, 2003)
DATA DIRECTORY = '/var/appdata/95/data'
INDEX DIRECTORY = '/var/appdata/95/idx',
PARTITION p2000 VALUES IN (1996, 2000, 2004)
DATA DIRECTORY = '/var/appdata/96/data'
INDEX DIRECTORY = '/var/appdata/96/idx',
PARTITION p2001 VALUES IN (1997, 2001, 2005)
DATA DIRECTORY = '/var/appdata/97/data'
INDEX DIRECTORY = '/var/appdata/97/idx',
PARTITION p2002 VALUES IN (1998, 2002, 2006)
DATA DIRECTORY = '/var/appdata/98/data'
INDEX DIRECTORY = '/var/appdata/98/idx'
);
");
    }

    [Fact]
    public void Partition7()
    {
      Utility.ParseSql(
          @"CREATE TABLE tn (c1 INT)
      PARTITION BY LIST(1 DIV c1) (
        PARTITION p0 VALUES IN (NULL),
        PARTITION p1 VALUES IN (1) )");
    }

    [Fact]
    public void Partition8()
    {
      Utility.ParseSql(
          @"CREATE TABLE tu (c1 BIGINT UNSIGNED)
    PARTITION BY RANGE(c1 - 10) (
      PARTITION p0 VALUES LESS THAN (-5),
      PARTITION p1 VALUES LESS THAN (0),
      PARTITION p2 VALUES LESS THAN (5),
      PARTITION p3 VALUES LESS THAN (10),
      PARTITION p4 VALUES LESS THAN (MAXVALUE) )");
    }

    [Fact]
    public void Partition9()
    {
      Utility.ParseSql(
          @"CREATE TABLE tkc (c1 CHAR)
PARTITION BY KEY(c1)
PARTITIONS 4;
");
    }

    [Fact]
    public void Partition10()
    {
      Utility.ParseSql(
          @"CREATE TABLE ts (
id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(30)
)
PARTITION BY KEY() 
PARTITIONS 4;");
    }

    [Fact]
    public void Partition11()
    {
      Utility.ParseSql(
          @"CREATE TABLE ts (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
      name VARCHAR(30)
  )
  PARTITION BY RANGE(id)
  SUBPARTITION BY KEY()
  SUBPARTITIONS 4
  (
      PARTITION p0 VALUES LESS THAN (100),
      PARTITION p1 VALUES LESS THAN (MAXVALUE)
  );
");
    }

    [Fact]
    public void Partition12()
    {
      Utility.ParseSql(
          @"CREATE TABLE t1 (col1 INT, col2 CHAR(5), col3 DATETIME)
PARTITION BY HASH ( YEAR(col3) );");
    }

    [Fact]
    public void Partition13()
    {
      Utility.ParseSql(
          @"CREATE TABLE t1 (col1 INT, col2 CHAR(5), col3 DATETIME)
PARTITION BY HASH ( YEAR(col3) );");
    }

    [Fact]
    public void PartitionColumns_51()
    {
      StringBuilder sb;
      Utility.ParseSql(
          @"CREATE TABLE members (
    firstname VARCHAR(25) NOT NULL,
    lastname VARCHAR(25) NOT NULL,
    username VARCHAR(16) NOT NULL,
    email VARCHAR(35),
    joined DATE NOT NULL
)
PARTITION BY RANGE COLUMNS(joined) (
    PARTITION p0 VALUES LESS THAN ('1960-01-01'),
    PARTITION p1 VALUES LESS THAN ('1970-01-01'),
    PARTITION p2 VALUES LESS THAN ('1980-01-01'),
    PARTITION p3 VALUES LESS THAN ('1990-01-01'),
    PARTITION p4 VALUES LESS THAN MAXVALUE;", true, out sb, new Version(5, 1));
      Assert.True(sb.ToString().IndexOf(" no viable alternative at input 'COLUMNS'") != -1);
    }

    [Fact]
    public void PartitionColumns_55()
    {
      StringBuilder sb;
      Utility.ParseSql(
          @"CREATE TABLE members (
    firstname VARCHAR(25) NOT NULL,
    lastname VARCHAR(25) NOT NULL,
    username VARCHAR(16) NOT NULL,
    email VARCHAR(35),
    joined DATE NOT NULL
)
PARTITION BY RANGE COLUMNS(joined) (
    PARTITION p0 VALUES LESS THAN ('1960-01-01'),
    PARTITION p1 VALUES LESS THAN ('1970-01-01'),
    PARTITION p2 VALUES LESS THAN ('1980-01-01'),
    PARTITION p3 VALUES LESS THAN ('1990-01-01'),
    PARTITION p4 VALUES LESS THAN MAXVALUE );", false, out sb, new Version(5, 5));
    }

    [Fact]
    public void PartitionColumns_2_55()
    {
      StringBuilder sb;
      Utility.ParseSql(
          @"CREATE TABLE members (
    firstname VARCHAR(25) NOT NULL,
    lastname VARCHAR(25) NOT NULL,
    username VARCHAR(16) NOT NULL,
    email VARCHAR(35),
    joined DATE NOT NULL
)
PARTITION BY LIST COLUMNS(joined) (
    PARTITION p0 VALUES LESS THAN ('1960-01-01'),
    PARTITION p1 VALUES LESS THAN ('1970-01-01'),
    PARTITION p2 VALUES LESS THAN ('1980-01-01'),
    PARTITION p3 VALUES LESS THAN ('1990-01-01'),
    PARTITION p4 VALUES LESS THAN MAXVALUE );", false, out sb, new Version(5, 5));
    }

    [Fact]
    public void PartitionColumns_3_55()
    {
      StringBuilder sb;
      Utility.ParseSql(
          @"CREATE TABLE t1 (
year_col  INT,
some_data INT
)
PARTITION BY RANGE (year_col) (
PARTITION p0 VALUES LESS THAN (1991, 1995, 1999, 2002, 2006));", false, out sb, new Version(5, 5));
    }

    [Fact]
    public void PartitionColumns_2_51()
    {
      StringBuilder sb;
      Utility.ParseSql(
          @"CREATE TABLE members (
    firstname VARCHAR(25) NOT NULL,
    lastname VARCHAR(25) NOT NULL,
    username VARCHAR(16) NOT NULL,
    email VARCHAR(35),
    joined DATE NOT NULL
)
PARTITION BY LIST COLUMNS(joined) (
    PARTITION p0 VALUES LESS THAN ('1960-01-01'),
    PARTITION p1 VALUES LESS THAN ('1970-01-01'),
    PARTITION p2 VALUES LESS THAN ('1980-01-01'),
    PARTITION p3 VALUES LESS THAN ('1990-01-01'),
    PARTITION p4 VALUES LESS THAN MAXVALUE;", true, out sb, new Version(5, 1));
      Assert.True(sb.ToString().IndexOf("'columns'", StringComparison.OrdinalIgnoreCase ) != -1);
    }

    [Fact]
    public void Select()
    {
      Utility.ParseSql(
          @"CREATE TABLE bar (m INT) SELECT n FROM foo;");
    }

    [Fact]
    public void Select2()
    {
      Utility.ParseSql(
          @"CREATE TABLE artists_and_works
  SELECT artist.name, count( * ), COUNT(work.artist_id) AS number_of_works
  FROM artist LEFT JOIN work ON artist.id = work.artist_id
  GROUP BY artist.id;");

    }

    [Fact]
    public void Select3()
    {
      Utility.ParseSql(
          @"CREATE TABLE bar (UNIQUE (n)) SELECT n FROM foo;");
    }

    [Fact]
    public void Select4()
    {
      Utility.ParseSql(
          @"CREATE TABLE foo (a TINYINT NOT NULL) SELECT b+1 AS a FROM bar;");
    }

    [Fact]
    public void Default()
    {
      Utility.ParseSql(
          @"CREATE TABLE t1 (i1 INT DEFAULT 0, i2 INT, i3 INT, i4 INT);");
    }

    [Fact]
    public void IfNotExists()
    {
      Utility.ParseSql(
          @"CREATE TABLE IF NOT EXISTS t1 (c1 CHAR(10)) SELECT 1, 2;");
    }

    [Fact]
    public void Enum()
    {
      Utility.ParseSql(
          @"CREATE TABLE t
(
  c1 VARCHAR(10) CHARACTER SET binary,
  c2 TEXT CHARACTER SET binary,
  c3 ENUM('a','b','c') CHARACTER SET binary
);");
    }

    [Fact]
    public void Enum2()
    {
      Utility.ParseSql(
          @"CREATE TABLE t
(
  c1 VARBINARY(10),
  c2 BLOB,
  c3 ENUM('a','b','c') CHARACTER SET binary
);");
    }

    //[Fact]
    //public void f1()
    //{
    //    Utility.ParseSql("");
    //}

    [Fact]
    public void TableType50()
    {
      Utility.ParseSql(
          @"CREATE TABLE t
(
  c1 VARBINARY(10),
  c2 BLOB,
  c3 ENUM('a','b','c') CHARACTER SET binary
) type=innodb;", false, new Version(5, 0));
    }

    [Fact]
    public void TableType51()
    {
      StringBuilder sb;
      Utility.ParseSql(
          @"CREATE TABLE t
(
  c1 VARBINARY(10),
  c2 BLOB,
  c3 ENUM('a','b','c') CHARACTER SET binary
) type=innodb;", true, out sb, new Version(5, 1));
      Assert.True(sb.ToString().IndexOf("missing EndOfFile at 'type'") != -1);
    }

    [Fact]
    public void Charset()
    {
      Utility.ParseSql(
          @"CREATE TABLE `city` ( `Name` char(35) NOT NULL DEFAULT '', `CountryCode` char(3) NOT NULL DEFAULT '', 
  `District` char(20) NOT NULL DEFAULT '', `Population` int(11) NOT NULL DEFAULT '0', `ID` int(11) NOT NULL AUTO_INCREMENT, 
  PRIMARY KEY (`ID`) ) ENGINE=MyISAM AUTO_INCREMENT=4080 DEFAULT CHARSET=latin1;", false);
    }

    [Fact]
    public void Charset2()
    {
      Utility.ParseSql(
        @"CREATE TABLE `city` ( `Name` char(35) NOT NULL DEFAULT '', `CountryCode` char(3) NOT NULL DEFAULT '', 
  `District` char(20) NOT NULL DEFAULT '', `Population` int(11) NOT NULL DEFAULT '0', `ID` int(11) NOT NULL AUTO_INCREMENT, 
  PRIMARY KEY (`ID`) ) ENGINE=MyISAM AUTO_INCREMENT=4080 DEFAULT CHARACTER SET=latin1;", false);
    }
  }
}
