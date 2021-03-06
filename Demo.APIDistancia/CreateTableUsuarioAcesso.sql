﻿/****** Object:  Table [dbo].[UsuarioAcesso]    Script Date: 07/04/2018 16:45:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UsuarioAcesso](
	[UsuarioAcessoId] [varchar](20) NOT NULL,
	[ChaveAcesso] [varchar](32) NOT NULL,
 CONSTRAINT [PK_UsuarioAcesso_UsuarioId] PRIMARY KEY CLUSTERED 
(
	[UsuarioAcessoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DADOS]
) ON [DADOS]

GO

SET ANSI_PADDING OFF
GO