/****** Object:  Table [dbo].[OVFGrundlagen]    Script Date: 16.02.2020 18:24:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OVFGrundlagen](
	[Typ] [smallint] NOT NULL,
	[Mandant] [smallint] NOT NULL,
	[Bezeichnung] [varchar](200) NOT NULL,
	[Wert] [varchar](max) NOT NULL,
 CONSTRAINT [PK_OVFGrundlagen] PRIMARY KEY CLUSTERED 
(
	[Typ] ASC,
	[Mandant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OVFMandant]    Script Date: 16.02.2020 18:24:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OVFMandant](
	[Mandant] [smallint] NOT NULL,
	[Bezeichnung] [varchar](200) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OVFAdresse]    Script Date: 16.02.2020 18:25:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OVFAdresse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Mandant] [smallint] NOT NULL,
	[Strasse] [varchar](200) NOT NULL,
	[Hausnummer] [varchar](10) NOT NULL,
	[Ort] [varchar](100) NOT NULL,
	[Plz] [varchar](5) NOT NULL,
	[Bundesland] [varchar](100) NOT NULL,
	[Land] [varchar](100) NOT NULL,
	[Zusatz] [varchar](50) NULL,
	[Matchcode] [varchar](100) NOT NULL,
 CONSTRAINT [PK_OVFAdresse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Mandant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OVFBenutzer]    Script Date: 16.02.2020 18:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OVFBenutzer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Mandant] [smallint] NOT NULL,
	[Benutzer] [varchar](20) NOT NULL,
	[Vorname] [varchar](100) NOT NULL,
	[Nachname] [varchar](100) NOT NULL,
	[Matchcode] [varchar](200) NOT NULL,
	[Anrede] [varchar](10) NULL,
	[Titel] [varchar](10) NULL,
	[Geburtsdatum] [date] NULL,
	[EMailAdresse] [varchar](100) NULL,
	[TelefonGeschaeftlich] [varchar](30) NULL,
	[TelefonMobil] [varchar](20) NULL,
	[TelefonPrivat] [varchar](30) NULL,
	[FKAdresse] [int] NOT NULL,
 CONSTRAINT [PK_OVFBenutzer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Mandant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OVFFahrzeug]    Script Date: 16.02.2020 18:26:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OVFFahrzeug](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Mandant] [smallint] NOT NULL,
	[Kennzeichen] [varchar](10) NOT NULL,
	[Marke] [varchar](20) NOT NULL,
	[Modell] [varchar](30) NOT NULL,
	[Erstzulassung] [int] NOT NULL,
	[TypErwerb] [smallint] NOT NULL,
	[Fahrzeugnummer] [varchar](100) NOT NULL,
	[KilometerstandBeginn] [int] NOT NULL,
	[KilometerstandEnde] [int] NOT NULL,
	[DatumBeginn] [date] NOT NULL,
	[DatumEnde] [date] NOT NULL,
	[FesterBenutzer] [int] NULL,
 CONSTRAINT [PK_OVFFahrzeug] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Mandant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OVFFahrten]    Script Date: 16.02.2020 18:29:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OVFFahrten](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Mandant] [smallint] NOT NULL,
	[Bezeichnung] [varchar](200) NOT NULL,
	[Datum] [date] NOT NULL,
	[Anfangskilometerstand] [int] NOT NULL,
	[Endkilometerstand] [int] NOT NULL,
	[GefahreneKilometer] [int] NOT NULL,
	[GeschaeftlichPrivat] [smallint] NOT NULL,
	[ZweckDerFahrt] [varchar](200) NOT NULL,
	[Fahrtroute] [varchar](200) NOT NULL,
	[FKFahrzeug] [int] NOT NULL,
	[FKBenutzer] [int] NOT NULL,
 CONSTRAINT [PK_OVFFahrte] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Mandant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO