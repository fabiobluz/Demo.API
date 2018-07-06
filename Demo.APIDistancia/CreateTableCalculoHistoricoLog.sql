
/****** Object:  Table [dbo].[CalculoHistoricoLog]    Script Date: 07/06/2018 10:36:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalculoHistoricoLog](
	[CalculoHistoricoLogId] [int] IDENTITY(1,1) NOT NULL,
	[AmigoId] [int] NULL,
	[LatitudeRef] [float] NULL,
	[LongitudeRef] [float] NULL,
	[LatitudeAmigo] [float] NULL,
	[LongitudeAmigo] [float] NULL,
	[Distancia] [float] NULL,
	[DataCriacao] [datetime] NULL
) ON [DADOS]

GO

