IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[bf_roles]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [dbo].[bf_roles]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bf_roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_bf_roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_bf_roles_RoleName] ON [dbo].[bf_roles] 
(
	[RoleName] ASC
) ON [PRIMARY]
GO
