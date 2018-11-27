
drop proc usp_ActualizarUsuarios
drop proc usp_ActualizarLocales
drop proc usp_EliminarUsuarios
drop proc usp_EliminarFotografo
drop proc usp_EliminarLocales

CREATE PROC usp_ActualizarUsuarios
@idUsuario		VARCHAR(12),
@telfUsuario		CHAR(30),
@dirUsuario		VARCHAR(200),
@emailUsuario	VARCHAR(100),
@passUsuario		VARCHAR(50)
AS
	UPDATE tb_usuario 
	   SET telfUsuario     = @telfUsuario,
		   dirUsuario     = @dirUsuario,
		   emailUsuario     = @emailUsuario,
		   passUsuario     = @passUsuario
	 WHERE idUsuario      = @idUsuario  
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
	 Go


CREATE PROC usp_EliminarUsuarios 
@id VARCHAR(12)
AS
	DELETE FROM tb_usuario WHERE idUsuario = @id
GO


CREATE PROC usp_EliminarFotografo
@idFotografo   VARCHAR(12)
AS
	DELETE FROM tb_fotografo WHERE idFotografo = @idFotografo


CREATE PROC usp_EliminarLocales
@id VARCHAR(12)
AS
	DELETE FROM tb_local WHERE idLocal = @id
