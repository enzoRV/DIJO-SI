CREATE DATABASE BD_DijoSI

SET DATEFORMAT dmy;
  
USE BD_DijoSI

CREATE TABLE tb_usuario
(
	idUsuario		VARCHAR(12) NOT NULL,
	dniUsuario		CHAR(8) NOT NULL,
	nomUsuario		VARCHAR(100) NOT NULL,
	apePatUsuario	VARCHAR(100) NOT NULL,
	apeMatUsuario	VARCHAR(100) NOT NULL,
	telfUsuario		CHAR(30) NOT NULL,
	dirUsuario		VARCHAR(200) NOT NULL,
	emailUsuario	VARCHAR(100) NOT NULL,
	loginUsuario	VARCHAR(100) NOT NULL,
	passUsuario		VARCHAR(50) NOT NULL,
	verificaEmail   BIT NOT NULL,
	Codigo			UNIQUEIDENTIFIER NOT NULL,
	Reiniciarcontra VARCHAR(100) 
	PRIMARY KEY(idUsuario)
)
GO
	
CREATE TABLE tb_distrito
(
	idDistrito  VARCHAR(12) PRIMARY KEY,
	nomDistrito VARCHAR(100) 
)
GO

INSERT INTO tb_distrito VALUES('DIS01','Magdalena')
INSERT INTO tb_distrito VALUES('DIS02','Miraflores')
INSERT INTO tb_distrito VALUES('DIS03','San Miguel')
INSERT INTO tb_distrito VALUES('DIS04','San Isidro')
GO

CREATE TABLE tb_local
(
	idLocal    VARCHAR(12) PRIMARY KEY,
	nomLocal   VARCHAR(100)NOT NULL,
	dirLocal   VARCHAR(100) NOT NULL,
	telfLocal  VARCHAR(30) NOT NULL,
	cantLocal  INT,
	idDistrito VARCHAR(12) REFERENCES tb_distrito
)
GO

CREATE TABLE tb_admin
(
	idAdmin     VARCHAR(12),
	emailAdmin	VARCHAR(100) NOT NULL,
	loginAdmin	VARCHAR(100) NOT NULL,
	passAdmin	VARCHAR(50) NOT NULL,
)
GO


CREATE TABLE tb_fotografo
(
	idFotografo    VARCHAR(12) PRIMARY KEY,
	nomFotografo   VARCHAR(100) NOT NULL,
	dirFotografo   VARCHAR(250) NOT NULL,
	telfFotografo  CHAR(30) NOT NULL
)
GO

CREATE TABLE tb_categoria
(
	idCategoria  VARCHAR(12) PRIMARY KEY,
	nomCategoria VARCHAR(100) 
)
GO

INSERT INTO tb_categoria VALUES('CAT01','Mexicana')
INSERT INTO tb_categoria VALUES('CAT02','Peruana')
INSERT INTO tb_categoria VALUES('CAT03','Italiana')
INSERT INTO tb_categoria VALUES('CAT04','Oriental')

CREATE TABLE tb_buffet
(
	idBuffet       VARCHAR(12) PRIMARY KEY,
	nomprovBuffet  VARCHAR(500),
	nomBuffet      VARCHAR(100) NOT NULL,
	desBuffet      VARCHAR(500) NOT NULL,
	preBuffet      DECIMAL NOT NULL,
	idCategoria    VARCHAR(12) REFERENCES tb_categoria
)
GO

CREATE TABLE tb_regalo
(
	idRegalo   VARCHAR(12) PRIMARY KEY,
	desRegalo  VARCHAR(12),
)
GO

CREATE TABLE tb_invitados
(
	idInvitado		VARCHAR(12) NOT NULL,
	nomInvitado		VARCHAR(100) NOT NULL,
	apePatInvitado	VARCHAR(100) NOT NULL,
	apeMatInvitado	VARCHAR(100) NOT NULL,
	emailInvitado	VARCHAR(100) NOT NULL,
	idUsuario       VARCHAR(12) NOT NULL REFERENCES tb_usuario
)
GO

--PROCEDIMIENTOS ALMACENADOS
--DISTRITOS
CREATE PROC usp_ListarDistritos
AS
	SELECT idDistrito, 
		   nomDistrito 
	  FROM tb_distrito 
GO

--CATEGORIAS
CREATE PROC usp_ListarCategorias
AS
	SELECT idCategoria,
		   nomCategoria
	  FROM tb_categoria
GO

--USUARIOS
CREATE PROC usp_ListarUsuarios
AS
	SELECT idUsuario,	
		   nomUsuario,
	       apePatUsuario,	 
		   apeMatUsuario,
		   dniUsuario,		 
		   telfUsuario,	
		   dirUsuario,	
		   emailUsuario,
		   loginUsuario,
		   Codigo
	  FROM tb_usuario
GO

CREATE PROC usp_Login
@login VARCHAR(200),
@pass  VARCHAR(200)
AS
	SELECT idUsuario,
		   loginUsuario,
		   passUsuario,
		   verificaEmail
	  FROM tb_usuario
	 WHERE loginUsuario = @login
	   AND passUsuario = @pass
GO

CREATE PROC usp_RegistrarUsuarios	
@dniUsuario		  CHAR(8),
@nomUsuario		  VARCHAR(100),
@apePatUsuario	  VARCHAR(100), 
@apeMatUsuario	  VARCHAR(100), 
@telfUsuario	  CHAR(30), 
@dirUsuario		  VARCHAR(200),
@emailUsuario	  VARCHAR(100), 
@loginUsuario	  VARCHAR(100),
@passUsuario	  VARCHAR(50),
@verificaEmail    BIT ,
@Codigo			  UNIQUEIDENTIFIER 
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idUsuario) FROM tb_usuario
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'U001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idUsuario),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idUsuario),3)+1),3) 
				FROM tb_usuario
			END
	INSERT INTO tb_usuario VALUES(@id, @dniUsuario, @nomUsuario, @apePatUsuario, @apeMatUsuario, @telfUsuario, @dirUsuario, @emailUsuario, @loginUsuario, @passUsuario, @verificaEmail, @Codigo,null)
	END
GO

CREATE PROC usp_ActivarUsuarios
@verificaEmail    BIT ,
@id               VARCHAR(12)
AS
	UPDATE tb_usuario
	   SET verificaEmail = @verificaEmail
	 WHERE idUsuario = @id
GO


CREATE PROC usp_EliminarUsuarios 
@id VARCHAR(12)
AS
	DELETE FROM tb_usuario WHERE idUsuario = @id
GO

--SERVICIOS
--1 Buffets
CREATE PROC usp_ListarBuffets
AS
	SELECT idBuffet,
		   nomprovBuffet, 
		   nomBuffet ,
		   desBuffet ,
		   preBuffet ,
		   c.idCategoria,
		   c.nomCategoria   
     FROM tb_buffet buff 
     JOIN tb_categoria c
	   ON buff.idCategoria = c.idCategoria
GO

CREATE PROC usp_RegistrarBuffets
@nomprovBuffet VARCHAR(100),
@nomBuffet     VARCHAR(100),
@desBuffet     VARCHAR(100),
@preBuffet     DECIMAL,
@idCategoria   VARCHAR(12)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idBuffet) FROM tb_buffet
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'B001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idBuffet),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idBuffet),3)+1),3) 
				FROM tb_buffet
			END
	INSERT INTO tb_buffet VALUES(@id, @nomprovBuffet, @nomBuffet, @desBuffet, @preBuffet, @idCategoria)
	END
GO

CREATE PROC usp_ActualizarBuffets
@idBuffet      VARCHAR(12),
@nomprovBuffet VARCHAR(100),
@nomBuffet     VARCHAR(100),
@desBuffet     VARCHAR(100),
@preBuffet     DECIMAL
AS
	UPDATE tb_buffet 
	   SET nomprovBuffet = @nomprovBuffet ,
		   nomBuffet     = @nomBuffet,
		   desBuffet     = @desBuffet,  
	       preBuffet     = @preBuffet   
	 WHERE idBuffet      = @idBuffet  
GO

CREATE PROC usp_EliminarBuffets
@idBuffet VARCHAR(12)
AS
	DELETE FROM tb_buffet WHERE idBuffet = @idBuffet
GO

CREATE PROC usp_ListarCategoriaxId
@id varchar(12)
AS
	SELECT idCategoria,
		   nomCategoria
	 FROM tb_categoria
    WHERE idCategoria = @id
GO

--2 LOCALES
CREATE PROC usp_ListarLocales
AS
	SELECT idLocal, 
		   nomLocal, 
		   dirLocal, 
		   telfLocal,
		   cantLocal,
		   d.idDistrito,
		   d.nomDistrito
      FROM tb_local l 
	  JOIN tb_distrito d 
	    ON l.idDistrito = d.idDistrito
GO

CREATE PROC usp_RegistrarLocales
@nom   VARCHAR(100),
@dir   VARCHAR(100),
@fono  VARCHAR(30),
@cant  INT,
@iddis VARCHAR(12)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idLocal) FROM tb_local
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'L001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idLocal),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idLocal),3)+1),3) 
				FROM tb_local
			END
	INSERT INTO tb_local VALUES(@id, @nom, @dir, @fono, @cant, @iddis)
	END
GO

CREATE PROC usp_ActualizarLocales
@id    VARCHAR(12),
@nom   VARCHAR(100),
@dir   VARCHAR(100),
@fONo  VARCHAR(30),
@cant   INT,
@iddis VARCHAR(12)
AS
	UPDATE tb_local 
	   SET nomLocal   = @nom, 
	       dirLocal   = @dir, 
		   telfLocal  = @fONo,
		   cantLocal  = @cant,
		   idDistrito = @iddis 
     WHERE idLocal    = @id
GO

CREATE PROC usp_EliminarLocales
@id VARCHAR(12)
AS
	DELETE FROM tb_local WHERE idLocal = @id
GO

--3 REGALOS
CREATE PROC usp_ListarRegalos
AS
	SELECT idRegalo ,
		   desRegalo
	  FROM tb_regalo
GO

CREATE PROC usp_RegistrarRegalos
@desRegalo  VARCHAR(100)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idRegalo) FROM tb_regalo
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'R001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idRegalo),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idRegalo),3)+1),3) 
				FROM tb_regalo
			END
	INSERT INTO tb_regalo VALUES(@id, @desRegalo)
	END
GO

CREATE PROC usp_EliminarRegalo
@idRegalo VARCHAR(12)
AS
	DELETE FROM tb_regalo WHERE idRegalo = @idRegalo
GO

--4 FOTOGRAFOS
CREATE PROC usp_ListarFotografos
AS
	SELECT idFotografo,
		   nomFotografo,
		   telfFotografo,
		   dirFotografo
	  FROM tb_fotografo
GO

CREATE PROC usp_RegistrarFotografo
@NomFotografo  VARCHAR(100),
@telfFotografo CHAR(30),
@dirFotografo  VARCHAR(250)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idFotografo) FROM tb_fotografo
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'F001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idFotografo),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idFotografo),3)+1),3) 
				FROM tb_fotografo
			END
	INSERT INTO tb_fotografo VALUES(@id, @NomFotografo, @dirFotografo, @telfFotografo)
	END
GO

CREATE PROC usp_ActualizarFotografo
@idFotografo   VARCHAR(12),
@telfFotografo CHAR(12),
@dirFotografo  VARCHAR(250)
AS
	UPDATE tb_fotografo
	   SET telfFotografo = @telfFotografo,
	       dirFotografo  = @dirFotografo
	 WHERE idFotografo   = @idFotografo
GO

CREATE PROC usp_EliminarFotografo
@idFotografo   VARCHAR(12)
AS
	DELETE FROM tb_fotografo WHERE idFotografo = @idFotografo
GO

--INVITADOS
CREATE PROC usp_ListarInvitados
AS
	SELECT idInvitado,
	       nomInvitado,
		   apePatInvitado,
		   apeMatInvitado,
		   usu.idUsuario,
		   usu.nomUsuario,
		   usu.apePatUsuario,
		   usu.apeMatUsuario
	  FROM tb_invitados invi
	  JOIN tb_usuario usu
	    ON invi.idUsuario = usu.idUsuario
GO

CREATE PROC usp_RegistrarInvitados
@nomInvitado	 VARCHAR(100),
@apePatInvitado  VARCHAR(100),
@apeMatInvitado  VARCHAR(100),
@emailInvitado	 VARCHAR(100),
@idUsuario        VARCHAR(12)
AS
	BEGIN
		DECLARE @id VARCHAR(12)
		DECLARE @idExiste INT
	SELECT @idExiste = COUNT(idInvitado) FROM tb_invitados
		IF(@idExiste = 0)
			BEGIN
				SET @id = 'I001'
			END
		ELSE
			BEGIN
				SELECT @id = LEFT(MAX(idInvitado),1)+RIGHT('0000'+CONVERT(VARCHAR(12),RIGHT(MAX(idInvitado),3)+1),3) 
				FROM tb_invitados
			END
	INSERT INTO tb_invitados VALUES(@id, @nomInvitado, @apePatInvitado, @apeMatInvitado, @emailInvitado, @idUsuario)
	END
GO

CREATE PROC usp_ActualizarInvitados
@idInvitado      VARCHAR(12) ,
@nomInvitado	 VARCHAR(100),
@apePatInvitado  VARCHAR(100),
@apeMatInvitado  VARCHAR(100),
@emailInvitado	 VARCHAR(100)
AS
	UPDATE tb_invitados
	   SET nomInvitado    = @nomInvitado,
	       apePatInvitado = @apePatInvitado,
		   apeMatInvitado = @apeMatInvitado,
		   emailInvitado  = @emailInvitado
     WHERE idInvitado     = @idInvitado
GO

CREATE PROC usp_EliminarInvitados
@idInvitado      VARCHAR(12)
AS
	DELETE FROM tb_invitados WHERE idInvitado = @idInvitado
GO
