CREATE TABLE [CardGame].[dbo].[Log] (

   [LogId] int IDENTITY(1,1) NOT NULL,
   [Message] nvarchar(512) NULL,
   [MessageTemplate] nvarchar(256) NULL,
   [Level] nvarchar(128) NULL,
   [TimeStamp] datetimeoffset(7) NOT NULL,  -- use datetime for SQL Server pre-2008
   [Exception] nvarchar(max) NULL,
   [EventJson] nvarchar(max) NULL,
   --[Properties] xml NULL,
   [CreatedAtDate] datetime NOT NULL DEFAULT GETUTCDATE(),
   [CreatedByUser] nvarchar(128) NOT NULL DEFAULT SUSER_NAME(),
   [CreatedByHost] nvarchar(128) NOT NULL DEFAULT HOST_NAME()
   

   CONSTRAINT [PK_CardGame_dbo_Log] 
     PRIMARY KEY CLUSTERED ([LogId] ASC) 
	 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
	       ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
     ON [PRIMARY]

) ON [PRIMARY];