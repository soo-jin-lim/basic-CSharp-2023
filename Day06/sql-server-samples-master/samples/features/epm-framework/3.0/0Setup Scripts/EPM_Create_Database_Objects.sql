/*
SQLCMD script to generate the required
objects to support a centralized
Policy-Based Management solution.
This is the first script to run.

Set the variables to define the server
and database which stores the policy
results.
*/
:SETVAR ServerName "WIN2008"
:SETVAR ManagementDatabase "MDW"
GO
:CONNECT $(ServerName)
GO

--Create the specified database if it does not exist
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = '$(ManagementDatabase)')
CREATE DATABASE $(ManagementDatabase)
GO

--Create a schema to support the EPM framework objects.
USE $(ManagementDatabase)
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'policy')
EXEC sys.sp_executesql N'CREATE SCHEMA [policy] AUTHORIZATION [dbo]'

--Start create tables and indexes

--Create the table to store the results from the
--PowerShell evaluation.
IF NOT EXISTS(SELECT * FROM sys.objects WHERE type = N'U' AND name = N'PolicyHistory')
BEGIN
	CREATE TABLE [policy].[PolicyHistory](
		[PolicyHistoryID] [int] IDENTITY NOT NULL ,
		[EvaluatedServer] [nvarchar](50) NULL,
		[EvaluationDateTime] [datetime] NULL,
		[EvaluatedPolicy] [nvarchar](128) NULL,
		[EvaluationResults] [xml] NOT NULL,
		CONSTRAINT PK_PolicyHistory PRIMARY KEY CLUSTERED
		(PolicyHistoryID)
	) ON [PRIMARY]
	
	ALTER TABLE [policy].[PolicyHistory] ADD  CONSTRAINT [DF_PolicyHistory_EvaluationDateTime]  DEFAULT (getdate()) FOR [EvaluationDateTime]
END
GO
	IF EXISTS(SELECT * FROM sys.columns WHERE object_id = object_id('policy.policyhistory')	AND name = 'PolicyResult')
		BEGIN
			ALTER TABLE policy.PolicyHistory
			DROP COLUMN PolicyResult
		END
	GO
	IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistory]') AND name = N'IX_EvaluationResults')
	DROP INDEX IX_EvaluationResults ON policy.PolicyHistory
	GO
	CREATE PRIMARY XML INDEX IX_EvaluationResults ON policy.PolicyHistory(EvaluationResults)
	GO

	CREATE XML INDEX IX_EvaluationResults_PROPERTY ON policy.PolicyHistory(EvaluationResults)
	USING XML INDEX IX_EvaluationResults
	FOR PROPERTY
	GO

	IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistory]') AND name = N'IX_EvaluatedPolicy')
	DROP INDEX IX_EvaluatedPolicy ON policy.PolicyHistory
	GO
	CREATE INDEX IX_EvaluatedPolicy ON policy.PolicyHistory(EvaluatedPolicy)
	GO

	IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistory]') AND name = N'IX_EvaluatedServer')
	DROP INDEX IX_EvaluatedServer ON policy.PolicyHistory
	GO
	CREATE NONCLUSTERED INDEX IX_EvaluatedServer
	ON [policy].[PolicyHistory] ([EvaluatedServer])
	INCLUDE ([PolicyHistoryID],[EvaluationDateTime],[EvaluatedPolicy])
	GO

--Create the table to store the error information from the
--failed PowerShell executions.

IF NOT EXISTS(
	SELECT * FROM sys.objects WHERE type = N'U' AND name = N'EvaluationErrorHistory'
	)
BEGIN
	CREATE TABLE [policy].[EvaluationErrorHistory](
		[ErrorHistoryID] [int] IDENTITY(1,1) NOT NULL,
		[EvaluatedServer] [nvarchar](50) NULL,
		[EvaluationDateTime] [datetime] NULL,
		[EvaluatedPolicy] [nvarchar](128) NULL,
		[EvaluationResults] [nvarchar](max) NOT NULL,
	CONSTRAINT PK_EvaluationErrorHistory PRIMARY KEY CLUSTERED
	(
		[ErrorHistoryID] ASC
	)) ON [PRIMARY]

	ALTER TABLE [policy].[EvaluationErrorHistory] ADD  CONSTRAINT [DF_EvaluationErrorHistory_EvaluationDateTime]  DEFAULT (getdate()) FOR [EvaluationDateTime]

END

	IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[policy].[EvaluationErrorHistory]') AND name = N'IX_EvaluationErrorHistoryView')
	DROP INDEX IX_EvaluationErrorHistoryView ON policy.EvaluationErrorHistory
	GO
	CREATE NONCLUSTERED INDEX [IX_EvaluationErrorHistoryView] ON policy.EvaluationErrorHistory
	(   [EvaluatedPolicy] ASC,
		[EvaluatedServer] ASC,
		[EvaluationDateTime] DESC) ON [PRIMARY]
	GO

GO


--Create the table to store the policy result details.
--This table is loaded with the procedure
--policy.epm_LoadPolicyHistoryDetail or through
--the SQL Server 2008 SSIS policy package.
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND type in (N'U'))
BEGIN
	CREATE TABLE [policy].[PolicyHistoryDetail](
		[PolicyHistoryDetailID] [int] IDENTITY NOT NULL,
		[PolicyHistoryID] [int] NULL,
		[EvaluatedServer] [nvarchar](128) NULL,
		[EvaluationDateTime] [datetime] NULL,
		[MonthYear] [nvarchar](14) NULL,
		[EvaluatedPolicy] [nvarchar](128) NULL,
		[policy_id] [int] NULL,
		[CategoryName] [nvarchar](128) NULL,
		[EvaluatedObject] [nvarchar](256) NULL,
		[PolicyResult] [nvarchar](5) NOT NULL,
		[ExceptionMessage] [nvarchar](max) NULL,
		[ResultDetail] [xml] NULL,
		[PolicyHistorySource] [nvarchar](50) NOT NULL,
		CONSTRAINT PK_PolicyHistoryDetail PRIMARY KEY CLUSTERED
			([PolicyHistoryDetailID])
	) ON [PRIMARY]
END
GO

	IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = N'IX_EvaluatedPolicy')
	DROP INDEX IX_EvaluatedPolicy ON policy.PolicyHistoryDetail
	GO
	CREATE INDEX IX_EvaluatedPolicy ON [policy].[PolicyHistoryDetail]
	([EvaluatedPolicy])
	INCLUDE ([PolicyHistoryID],
		[EvaluatedServer],
		[EvaluationDateTime],
		[MonthYear],
		[policy_id],
		[CategoryName],
		[EvaluatedObject],
		[PolicyResult])
		
	IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = N'IX_PolicyHistoryView')
	DROP INDEX IX_PolicyHistoryView ON policy.PolicyHistoryDetail
	GO
	CREATE NONCLUSTERED INDEX [IX_PolicyHistoryView] ON [policy].[PolicyHistoryDetail]
	(   [EvaluatedPolicy] ASC,
		[EvaluatedServer] ASC,
		[EvaluatedObject] ASC,
		[EvaluationDateTime] DESC,
		[PolicyResult] ASC,
		[policy_id] ASC,
		CategoryName,
		MonthYear) ON [PRIMARY]
	GO

	IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = N'IX_EvaluatedServer')
	DROP INDEX IX_EvaluatedServer ON policy.PolicyHistoryDetail
	GO
	CREATE NONCLUSTERED INDEX [IX_EvaluatedServer] ON [policy].[PolicyHistoryDetail]
	(	[EvaluatedServer] ASC,
		[EvaluatedPolicy] ASC,
		[EvaluatedObject] ASC,
		[EvaluationDateTime] ASC)
	INCLUDE ( [PolicyResult])  ON [PRIMARY]
	GO


	IF EXISTS(SELECT * FROM sys.stats WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = 'Stat_EvaluatedServer' )
	DROP STATISTICS policy.[PolicyHistoryDetail].[Stat_EvaluatedServer]
	GO
	CREATE STATISTICS [Stat_EvaluatedServer] ON [policy].[PolicyHistoryDetail]([EvaluatedServer], [EvaluationDateTime])
	GO

	IF EXISTS(SELECT * FROM sys.stats WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = 'Stat_EvaluatedPolicy' )
	DROP STATISTICS policy.[PolicyHistoryDetail].[Stat_EvaluatedPolicy]
	GO
	CREATE STATISTICS [Stat_EvaluatedPolicy] ON [policy].[PolicyHistoryDetail]([EvaluatedPolicy], [CategoryName])
	GO

	IF EXISTS(SELECT * FROM sys.stats WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = 'Stat_CategoryName')
	DROP STATISTICS policy.[PolicyHistoryDetail].[Stat_CategoryName]
	GO
	CREATE STATISTICS [Stat_CategoryName] ON [policy].[PolicyHistoryDetail]([CategoryName], [EvaluatedServer])
	GO

	IF EXISTS(SELECT * FROM sys.stats WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = 'Stat_PolicyResult' )
	DROP STATISTICS policy.[PolicyHistoryDetail].[Stat_PolicyResult]
	GO
	CREATE STATISTICS [Stat_PolicyResult] ON [policy].[PolicyHistoryDetail]([PolicyResult], [EvaluatedServer])
	GO

	IF EXISTS(SELECT * FROM sys.stats WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = 'Stat_Policy_Server_Category' )
	DROP STATISTICS policy.[PolicyHistoryDetail].[Stat_Policy_Server_Category]
	GO
	CREATE STATISTICS [Stat_Policy_Server_Category] ON [policy].[PolicyHistoryDetail]([EvaluatedPolicy], [EvaluatedServer], [CategoryName])
	GO

	IF EXISTS(SELECT * FROM sys.stats WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = 'Stat_Policy_Result_Server')
	DROP STATISTICS policy.[PolicyHistoryDetail].[Stat_Policy_Result_Server]
	GO
	CREATE STATISTICS [Stat_Policy_Result_Server] ON [policy].[PolicyHistoryDetail]([EvaluatedPolicy], [PolicyResult], [EvaluatedServer])
	GO

	IF EXISTS(SELECT * FROM sys.stats WHERE object_id = OBJECT_ID(N'[policy].[PolicyHistoryDetail]') AND name = 'Stat_Covered' )
	DROP STATISTICS policy.[PolicyHistoryDetail].[Stat_Covered]
	GO
	CREATE STATISTICS [Stat_Covered] ON [policy].[PolicyHistoryDetail]([EvaluatedPolicy], [EvaluatedServer], [EvaluationDateTime], [PolicyResult], [PolicyHistoryID], [CategoryName])
	GO


--Create the function to support server selection.
--The following function will support nested
--CMS folders for the EPM Framework
--The function must be created in a database ON the
--CMS server. This database will also store the
--policy history.

USE $(ManagementDatabase)
GO
IF EXISTS(SELECT * FROM sys.objects WHERE name = 'pfn_ServerGroupInstances' AND type = 'TF')
	DROP FUNCTION policy.pfn_ServerGroupInstances
GO
CREATE FUNCTION policy.pfn_ServerGroupInstances
	(@server_group_name NVARCHAR(128))
	RETURNS @ServerGroups TABLE
	(server_name nvarchar(128)
	, GroupName nvarchar(128)
	)
	AS
	BEGIN
	IF @server_group_name = ''
		BEGIN
			INSERT @ServerGroups
			SELECT s.server_name, ssg.name as GroupName
			FROM [msdb].[dbo].[sysmanagement_shared_registered_servers_internal] s
			INNER JOIN msdb.dbo.sysmanagement_shared_server_groups ssg
			ON s.server_group_id = ssg.server_group_id
		END
		ELSE
			WITH ServerGroups(parent_id, server_group_id, name) AS
			(
				SELECT parent_id, server_group_id, name
				FROM msdb.dbo.sysmanagement_shared_server_groups tg
				WHERE is_system_object = 0
				AND (tg.name = @server_group_name
				OR @server_group_name = '')	
				UNION ALL
				SELECT cg.parent_id, cg.server_group_id, cg.name
				FROM msdb.dbo.sysmanagement_shared_server_groups cg
				INNER JOIN ServerGroups pg
				ON cg.parent_id = pg.server_group_id
			)
			INSERT @ServerGroups
			SELECT s.server_name, sg.name as GroupName
			FROM [msdb].[dbo].[sysmanagement_shared_registered_servers_internal] s
			INNER JOIN ServerGroups SG
			ON s.server_group_id = sg.server_group_id
			RETURN
	END
GO

--Create the views which are used in
--the policy reports

--Drop the view if it exists.
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[policy].[v_ServerGroups]'))
DROP VIEW [policy].[v_ServerGroups]
GO
CREATE VIEW policy.v_ServerGroups AS
	WITH ServerGroups(parent_id
		, server_group_id
		, GroupName
		, GroupLevel
		, Sort
		, GroupValue)
	AS
	(SELECT parent_id
			, server_group_id
			, cast('ALL' as varchar(500))
			, 1 as GroupLevel
			, cast('ALL' as varchar(500)) as Sort
			, cast('' as varchar(255))AS GroupValue
		FROM msdb.dbo.sysmanagement_shared_server_groups tg
		WHERE server_type = 0
		AND parent_id IS NULL
		UNION ALL
		SELECT cg.parent_id
			, cg.server_group_id
			, cast(replicate('  ', GroupLevel) + cg.name as varchar(500))
			, GroupLevel + 1
			, cast(Sort + ' | ' + cg.name as varchar(500)) AS Sort
			, cast(name as varchar(255))AS GroupValue
		FROM msdb.dbo.sysmanagement_shared_server_groups cg
		INNER JOIN ServerGroups pg
		ON cg.parent_id = pg.server_group_id)
		
		SELECT	parent_id
			, server_group_id
			, GroupName
			, GroupLevel
			, Sort
			, GroupValue
		FROM	ServerGroups
GO			


--Drop the view if it exists.
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[policy].[v_PolicyHistory]'))
DROP VIEW [policy].[v_PolicyHistory]
GO
CREATE VIEW policy.v_PolicyHistory
AS
--The policy.v_PolicyHistory view will return all results
--and identify the policy evaluation result AS PASS, FAIL, or
--ERROR.  The ERROR result indicates that the policy was not able
--to evaluate against an object.
	SELECT PH.PolicyHistoryID
	 , PH.EvaluatedServer
	 , PH.EvaluationDateTime
	 , PH.EvaluatedPolicy
	 , PH.PolicyResult
	 , PH.ExceptionMessage
	 , PH.ResultDetail
	 , PH.EvaluatedObject
	 , PH.policy_id
	 , PH.CategoryName
	 , PH.MonthYear
	FROM policy.PolicyHistoryDetail PH
	INNER JOIN msdb.dbo.syspolicy_policies AS p ON p.name = PH.EvaluatedPolicy
	INNER JOIN msdb.dbo.syspolicy_policy_categories AS c ON
	p.policy_category_id = c.policy_category_id
GO


--Drop the view if it exists.
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[policy].[v_PolicyHistory_Rank]'))
DROP VIEW policy.v_PolicyHistory_Rank
GO
CREATE VIEW policy.v_PolicyHistory_Rank AS
	SELECT PolicyHistoryID
		, EvaluatedServer
		, EvaluationDateTime
		, EvaluatedPolicy
		, EvaluatedObject
		, PolicyResult
		, ResultDetail
		, ExceptionMessage
		, policy_id
		, CategoryName
		, MonthYear
		, DENSE_RANK() OVER (
			PARTITION BY EvaluatedPolicy, EvaluatedServer, EvaluatedObject
			ORDER BY EvaluationDateTime DESC)AS EvaluationOrderDesc
	FROM policy.v_PolicyHistory VPH
GO


--Drop the view if it exists.
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[policy].[v_PolicyHistory_LastEvaluation]'))
DROP VIEW policy.v_PolicyHistory_LastEvaluation
GO
CREATE VIEW policy.v_PolicyHistory_LastEvaluation
AS
	--The policy.v_PolicyHistory_LastEvaluation view will
	--the last result for any given policy evaluated against
	--an object.  This view requires the v_PolicyHistory view
	--exist.
	SELECT PolicyHistoryID
		, EvaluatedServer
		, EvaluationDateTime
		, EvaluatedPolicy
		, EvaluatedObject
		, PolicyResult
		, ResultDetail
		, ExceptionMessage
		, policy_id
		, CategoryName
		, MonthYear
		, EvaluationOrderDesc
	FROM policy.v_PolicyHistory_Rank VPH
	WHERE EvaluationOrderDesc = 1
	AND NOT EXISTS(
		SELECT *
		FROM   policy.PolicyHistoryDetail PH
		WHERE  PH.EvaluatedPolicy = VPH.EvaluatedPolicy
		AND PH.EvaluatedServer = VPH.EvaluatedServer
		AND PH.EvaluationDateTime  > VPH.EvaluationDateTime)
GO


--Create a view to return all errors.  Errors will be returned from
--the table EvaluationErrorHistory and the errors in the PolicyHistory
--table.
--Drop the view if it exists.
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[policy].[v_EvaluationErrorHistory]'))
DROP VIEW policy.v_EvaluationErrorHistory
GO
CREATE VIEW policy.v_EvaluationErrorHistory
AS
	SELECT
		EEH.ErrorHistoryID
		, EEH.EvaluatedServer
		, EEH.EvaluationDateTime
		, EEH.EvaluatedPolicy
		, CASE WHEN CHARINDEX('\', EEH.EvaluatedServer) > 0
			THEN RIGHT(EEH.EvaluatedServer, CHARINDEX('\', REVERSE(EEH.EvaluatedServer)) - 1)	
			ELSE EEH.EvaluatedServer
			END
		AS EvaluatedObject
		, EEH.EvaluationResults
		, p.policy_id
		, c.name AS CategoryName
		, datename(month, EvaluationDateTime) + ' ' + datename(year, EvaluationDateTime)  AS MonthYear
	    , 'ERROR' AS PolicyResult	
	FROM policy.EvaluationErrorHistory AS EEH
	INNER JOIN msdb.dbo.syspolicy_policies AS p ON p.name = EEH.EvaluatedPolicy
	INNER JOIN msdb.dbo.syspolicy_policy_categories AS c ON
	p.policy_category_id = c.policy_category_id
	UNION ALL
	SELECT PolicyHistoryID
		, EvaluatedServer
		, EvaluationDateTime
		, EvaluatedPolicy
		, RIGHT(EvaluatedObject, CHARINDEX('\', REVERSE(EvaluatedObject)) - 1)	
		, ExceptionMessage
		, policy_id
		, CategoryName
		, MonthYear
		, PolicyResult
	FROM policy.v_PolicyHistory_LastEvaluation
	WHERE PolicyResult = 'ERROR'
GO
	
--Create a view to return the last error for each policy against
--an instance.
--Drop the view if it exists.
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[policy].[v_EvaluationErrorHistory_LastEvaluation]'))	
DROP VIEW policy.v_EvaluationErrorHistory_LastEvaluation
GO
CREATE VIEW policy.v_EvaluationErrorHistory_LastEvaluation
AS
	SELECT
		ErrorHistoryID
		, EvaluatedServer
		, EvaluationDateTime
		, EvaluatedPolicy
		, Policy_ID
		, EvaluatedObject
		, EvaluationResults
		, CategoryName
		, MonthYear
		, PolicyResult
		, DENSE_RANK() OVER (
			PARTITION BY EvaluatedServer, EvaluatedPolicy
			ORDER BY EvaluationDateTime DESC)AS EvaluationOrderDesc
	FROM policy.v_EvaluationErrorHistory EEH
	WHERE NOT EXISTS (
		SELECT *
		FROM policy.PolicyHistoryDetail PH
		WHERE PH.EvaluatedPolicy = EEH.EvaluatedPolicy
		AND PH.EvaluatedServer = EEH.EvaluatedServer
		AND PH.EvaluationDateTime > EEH.EvaluationDateTime)	
GO


--Create the procedures
--epm_LoadPolicyHistoryDetail will load the details from the
--XML documents in PolicyHistory to the PolicyHistoryDetails
--table.
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[policy].[epm_LoadPolicyHistoryDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [policy].[epm_LoadPolicyHistoryDetail]
GO
CREATE PROCEDURE policy.epm_LoadPolicyHistoryDetail
AS
	--Insert the evaluation results.
	WITH XMLNAMESPACES ('http://schemas.microsoft.com/sqlserver/DMF/2007/08' AS DMF)
	INSERT INTO policy.PolicyHistoryDetail	(		
		PolicyHistoryID
		, EvaluatedServer
		, EvaluationDateTime
		, EvaluatedPolicy
		, EvaluatedObject
		, PolicyResult
		, ExceptionMessage
		, ResultDetail
		, policy_id
		, CategoryName
		, MonthYear
		, PolicyHistorySource
	)
	SELECT
		PH.PolicyHistoryID
		, PH.EvaluatedServer
		, PH.EvaluationDateTime
		, PH.EvaluatedPolicy
		, Res.Expr.value('(../DMF:TargetQueryExpression)[1]', 'nvarchar(150)') AS EvaluatedObject
		, (CASE WHEN Res.Expr.value('(../DMF:Result)[1]', 'nvarchar(150)')= 'FALSE' AND Expr.value('(../DMF:Exception)[1]', 'nvarchar(max)') = ''
			   THEN 'FAIL'
			   WHEN Res.Expr.value('(../DMF:Result)[1]', 'nvarchar(150)')= 'FALSE' AND Expr.value('(../DMF:Exception)[1]', 'nvarchar(max)')<> ''
			   THEN 'ERROR'
			   ELSE 'PASS'
			END) AS PolicyResult
		, Expr.value('(../DMF:Exception)[1]', 'nvarchar(max)') AS ExceptionMessage
		, CAST(Expr.value('(../DMF:ResultDetail)[1]', 'nvarchar(max)')AS XML) AS ResultDetail
		, p.policy_id
		, c.name AS CategoryName
		, datename(month, EvaluationDateTime) + ' ' + datename(year, EvaluationDateTime)  AS MonthYear
		, 'PowerShell EPM Framework'
	FROM policy.PolicyHistory AS PH
	INNER JOIN msdb.dbo.syspolicy_policies AS p
		ON p.name = PH.EvaluatedPolicy
	INNER JOIN msdb.dbo.syspolicy_policy_categories AS c
		ON p.policy_category_id = c.policy_category_id
	CROSS APPLY EvaluationResults.nodes('
	declare default element namespace "http://schemas.microsoft.com/sqlserver/DMF/2007/08";
	//TargetQueryExpression'
	) AS Res(Expr)
	WHERE NOT EXISTS (SELECT *
		FROM policy.PolicyHistoryDetail PHD
		WHERE PHD.PolicyHistoryID = PH.PolicyHistoryID);
	
	--Insert the error records
	WITH XMLNAMESPACES ('http://schemas.microsoft.com/sqlserver/DMF/2007/08' AS DMF)
	INSERT INTO policy.EvaluationErrorHistory(		
		EvaluatedServer
		, EvaluationDateTime
		, EvaluatedPolicy
		, EvaluationResults
		)
	SELECT
		PH.EvaluatedServer
		, PH.EvaluationDateTime
		, PH.EvaluatedPolicy
		, Expr.value('(../DMF:Exception)[1]', 'nvarchar(max)') AS ExceptionMessage
	FROM policy.PolicyHistory AS PH
	INNER JOIN msdb.dbo.syspolicy_policies AS p
		ON p.name = PH.EvaluatedPolicy
	INNER JOIN msdb.dbo.syspolicy_policy_categories AS c
		ON 	p.policy_category_id = c.policy_category_id
	CROSS APPLY EvaluationResults.nodes('
	declare default element namespace "http://schemas.microsoft.com/sqlserver/DMF/2007/08";
	//DMF:ServerInstance'
	) AS Res(Expr)
	WHERE EvaluationResults.exist('declare namespace DMF="http://schemas.microsoft.com/sqlserver/DMF/2007/08";
		 //DMF:EvaluationDetail'
		) = 0	
	AND Res.Expr.value('(../DMF:Result)[1]', 'nvarchar(150)')= 'FALSE'
	AND Expr.value('(../DMF:Exception)[1]', 'nvarchar(max)')<> ''
	AND NOT EXISTS (SELECT *
	FROM policy.PolicyHistoryDetail PHD
	WHERE PHD.PolicyHistoryID = PH.PolicyHistoryID);

	--Insert the policies that evaluated with no target	
	WITH XMLNAMESPACES ('http://schemas.microsoft.com/sqlserver/DMF/2007/08' AS DMF)
	INSERT INTO policy.PolicyHistoryDetail	(		
		PolicyHistoryID
		, EvaluatedServer
		, EvaluationDateTime
		, EvaluatedPolicy
		, EvaluatedObject
		, PolicyResult
		, ExceptionMessage
		, ResultDetail
		, policy_id
		, CategoryName
		, MonthYear
		, PolicyHistorySource
		)
	SELECT
		 PH.PolicyHistoryID
		 , PH.EvaluatedServer
		 , PH.EvaluationDateTime
		 , PH.EvaluatedPolicy
		 , 'No Targets Found' AS EvaluatedObject
		 , 'PASS' AS PolicyResult
		 , Expr.value('(../DMF:Exception)[1]', 'nvarchar(max)') AS ExceptionMessage
		 , NULL AS ResultDetail
		 , p.policy_id
		 , c.name AS CategoryName
		 , datename(month, EvaluationDateTime) + ' ' + datename(year, EvaluationDateTime)  AS MonthYear
		, 'PowerShell EPM Framework'
	FROM policy.PolicyHistory AS PH
	INNER JOIN msdb.dbo.syspolicy_policies AS p
		ON p.name = PH.EvaluatedPolicy
	INNER JOIN msdb.dbo.syspolicy_policy_categories AS c
		ON 	p.policy_category_id = c.policy_category_id
	CROSS APPLY EvaluationResults.nodes('
	declare default element namespace "http://schemas.microsoft.com/sqlserver/DMF/2007/08";
	//DMF:ServerInstance'
	) AS Res(Expr)
	WHERE EvaluationResults.exist('declare namespace DMF="http://schemas.microsoft.com/sqlserver/DMF/2007/08";
		 //DMF:EvaluationDetail'
		) = 0	
	AND Expr.value('(../DMF:Exception)[1]', 'nvarchar(max)')= ''
	AND NOT EXISTS (SELECT *
	FROM policy.PolicyHistoryDetail PHD
	WHERE PHD.PolicyHistoryID = PH.PolicyHistoryID)
GO

exec policy.epm_LoadPolicyHistoryDetail