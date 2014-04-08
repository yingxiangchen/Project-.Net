using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CreateDB
    {
        public void  CreateDatabase(string DatabaseName){
//CREATE DATABASE [TEST]  ON 
//(
//NAME = 'XXXX', 
//FILENAME = 'C:\MSSQL\data\XXXX.MDF' , SIZE = 1,---数据库储存路径
//FILEGROWTH = 10%) LOG ON (NAME = N'fendoujob_Log',
//FILENAME = 'C:\MSSQL\data\XXXX.LDF' ,SIZE = 1,---数据库日志储存路径
//FILEGROWTH = 10%
        }
    }
   




//--2--建表ADMIN_USER
//USE TEST

//CREATE TABLE [ADMIN_USER] (
//    --[AD_ID] [int] IDENTITY (1, 1) NOT NULL ,--帐号ID自动递增 如:1 2 3 ...
//    [AD_ID] [int]  NOT NULL ,--帐号ID
//    [AD_NAME] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,--帐号
//    [AD_PASSWORD] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,--密码
//    [AD_popedom] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,--权限
//    [AD_ADDTIME] [datetime] NULL --创建日期
//) ON [PRIMARY]
//GO
}
