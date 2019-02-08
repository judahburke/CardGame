CREATE TABLE [CardGame].[dbo].[GameRules] (

   [GameRulesId] int IDENTITY(1,1) NOT NULL,
   [GameName] nvarchar(128) NULL,
   [RuleJson] nvarchar(max) NULL,
   [CreatedAtDate] datetime NOT NULL,
   [CreatedByUser] nvarchar(128) NOT NULL,
   [CreatedByHost] nvarchar(128) NOT NULL

   CONSTRAINT [PK_CardGame_dbo_GameRules] 
     PRIMARY KEY CLUSTERED ([GameRulesId] ASC) 
	 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
	       ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
     ON [PRIMARY]

) ON [PRIMARY];