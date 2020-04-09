--====================================
-- AUTOR: Carlos Eduardo de Souza
-- DATA: 29/05/2019
-- DESCRICAO: Script Projeto Teste BRQ
--=====================================

CREATE DATABASE BRQ

GO

USE [BRQ]

GO


CREATE TABLE [dbo].[TB_CONTATO](
	[ID] [bigint] IDENTITY(1,1) Primary key NOT NULL ,
	[NOME] [nvarchar](50) NOT NULL,
	[EMAIL] [nvarchar](50) NULL,
	[TELEFONE] [nvarchar](11) NULL
	)

GO


CREATE PROCEDURE [dbo].[STP_SEL_CONTATO]
    @NOME nvarchar(50) = NULL,
	@EMAIL nvarchar(50) =  NULL,
	@TELEFONE nvarchar(11) = NULL
AS
BEGIN

   SELECT * FROM TB_CONTATO
   WHERE 
      (@NOME IS NULL OR NOME LIKE '%' + @NOME + '%') AND
	  (@EMAIL IS NULL OR EMAIL LIKE '%' + @EMAIL + '%') AND
	  (@TELEFONE IS NULL OR TELEFONE LIKE '%' + @TELEFONE +'%') 
END

GO


CREATE PROCEDURE [dbo].[STP_INS_CONTATO]

	@NOME nvarchar(50),
	@EMAIL nvarchar(50) = NULL,
	@TELEFONE nvarchar(11) = NULL
	AS
BEGIN
	
   INSERT INTO TB_CONTATO (NOME,EMAIL,TELEFONE)VALUES(@NOME,@EMAIL,@TELEFONE)
END

GO

CREATE PROCEDURE [dbo].[STP_UPD_CONTATO]

    @ID bigint,
	@NOME nvarchar(50),
	@EMAIL nvarchar(50) = NULL,
	@TELEFONE nvarchar(11) = NULL
	AS
BEGIN
   UPDATE TB_CONTATO SET NOME = @NOME, EMAIL = @EMAIL, TELEFONE = @TELEFONE
   WHERE ID = @ID
END

GO

CREATE PROCEDURE [dbo].[STP_DEL_CONTATO]
    @ID bigint
	AS
BEGIN

   DELETE TB_CONTATO  
   WHERE ID = @ID
END

GO


CREATE PROCEDURE [dbo].[STP_SEL_CONTATO_ByID]
 @ID bigint
	AS

BEGIN

   SELECT * FROM TB_CONTATO
   WHERE ID = @ID
END

