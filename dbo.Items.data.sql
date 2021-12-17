SET IDENTITY_INSERT [dbo].[Items] ON
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [Price]) VALUES (1, N'Beer', N'Only beggars will buy it', CAST(2.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [Price]) VALUES (2, N'White Beer', N'Only women will drink it', CAST(5.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [Price]) VALUES (3, N'Dark Beer', N'Maded for true mans', CAST(5.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [Price]) VALUES (4, N'Vodka', N'If u wanna to fight, this is your choice', CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Items] OFF
