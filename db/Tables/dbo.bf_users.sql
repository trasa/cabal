IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[bf_users]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [dbo].[bf_users]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bf_users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[UserEmail] [nvarchar](256) NOT NULL,
	[PasswordQuestion] [nvarchar](128) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordSalt] [nvarchar](50) NOT NULL,
	[UserCreated] [datetime] NOT NULL CONSTRAINT [DF_bf_users_UserCreated]  DEFAULT (getdate()),
 CONSTRAINT [PK_bf_users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IX_bf_users_UserEmail] ON [dbo].[bf_users] 
(
	[UserEmail] ASC
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_bf_users_UserName] ON [dbo].[bf_users] 
(
	[UserName] ASC
) ON [PRIMARY]
GO
