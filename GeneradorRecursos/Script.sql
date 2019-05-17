USE [master]
GO

CREATE DATABASE [Recursos]

USE [Recursos]
GO
/****** Object:  Table [dbo].[Constantes]    Script Date: 17/5/2019 08:01:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Constantes](
	[Nombre] [varchar](150) NOT NULL,
	[Valor] [varchar](500) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Constantes] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localizacion]    Script Date: 17/5/2019 08:01:32 ******/
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
/****** Object:  StoredProcedure [dbo].[CreaActualizaLocalizacion]    Script Date: 17/5/2019 08:01:33 ******/
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
/****** Object:  StoredProcedure [dbo].[CrearConstante]    Script Date: 17/5/2019 08:01:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CrearConstante]
@Nombre varchar(150),
@Valor varchar(150),
@Tipo varchar(150)
as
BEGIN

	IF NOT EXISTS (SELECT 1 FROM Constantes WHERE Nombre = @Nombre)
	BEGIN
		INSERT INTO Constantes VALUES(UPPER(@Nombre), @Valor, @Tipo)
		PRINT('Constante agregada con exito')
	END
	ELSE
	BEGIN
		PRINT('---- Constante existente NO SE AGREGO -----')
	END

END
GO
USE [master]
GO
ALTER DATABASE [Recursos] SET  READ_WRITE 
GO
