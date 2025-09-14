USE Northwind;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetOhMyTasks]') AND type in (N'U'))
BEGIN
    DROP TABLE [dbo].[AspNetOhMyTasks]
END
GO

CREATE TABLE [dbo].[AspNetOhMyTasks](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Description] [varchar](100) NOT NULL,
    [IsCompleted] [bit] NOT NULL,
    CONSTRAINT [PK_AspNetOhMyTasks] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO
