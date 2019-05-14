USE [master]
GO
/****** Object:  Database [Recursos]    Script Date: 14/5/2019 00:01:08 ******/
CREATE DATABASE [Recursos]
GO

USE [Recursos]
GO
/****** Object:  Table [dbo].[Localizacion]    Script Date: 14/5/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localizacion](
	[Nombre] [varchar](150) NOT NULL,
	[Mensaje] [text] NOT NULL,
	[Cultura] [varchar](5) NOT NULL,
	[Comentario] [varchar](500) NULL,
 CONSTRAINT [PK_Localizacion] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC,
	[Cultura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CreaActualizaLocalizacion]    Script Date: 14/5/2019 00:01:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreaActualizaLocalizacion]
	@Nombre varchar(150),
	@MensajeES varchar(1500),
	@MensajeEN varchar(1500),
	@Comentario varchar(500)
AS
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM Localizacion WHERE Nombre = @Nombre and Cultura = 'es')
	BEGIN
		INSERT INTO Localizacion VALUES (@Nombre , @MensajeES , 'es', @Comentario)	
		PRINT N'Recurso creado para cultura es'; 
	END
	ELSE
	BEGIN
		UPDATE Localizacion set Nombre = @Nombre , Mensaje = @MensajeES , Comentario = @Comentario
		where Nombre = @Nombre and Cultura = 'es'
		PRINT N'Recurso actualizado para cultura es'; 
	END
	IF NOT EXISTS (SELECT 1 FROM Localizacion WHERE Nombre = @Nombre and Cultura = 'en-US')
	BEGIN
		INSERT INTO Localizacion VALUES (@Nombre , @MensajeEN , 'en-US', @Comentario)
		PRINT N'Recurso creado para cultura en-US'; 
	END
	ELSE
	BEGIN
		UPDATE Localizacion set Nombre = @Nombre , Mensaje = @MensajeEN , Comentario = @Comentario
		where Nombre = @Nombre and Cultura = 'en-US'
		PRINT N'Recurso actualizado para cultura en-US'; 
	END


END
GO

