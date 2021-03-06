IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[bf_UsersInRoles]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [dbo].[bf_UsersInRoles]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bf_UsersInRoles](
	[RoleId] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_bf_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[RoleId] ASC
)
) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IX_bf_UsersInRoles_UserName] ON [dbo].[bf_UsersInRoles] 
(
	[UserName] ASC
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bf_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_bf_UsersInRoles_bf_roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[bf_roles] ([RoleId])
GO
ALTER TABLE [dbo].[bf_UsersInRoles] CHECK CONSTRAINT [FK_bf_UsersInRoles_bf_roles]
GO
