Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng danh mục loại sản phẩm>
-- =============================================
--DROP TABLE [Categories]
CREATE TABLE [dbo].[Categories]
(
  [ID] INT IDENTITY(1,1) NOT NULL,
  [ParentID] INT NOT NULL DEFAULT(0),
  [Level] INT NOT NULL DEFAULT(0),
  [CateID] NVARCHAR(50) NOT NULL DEFAULT(''),
  [CateName] NVARCHAR(100) NOT NULL DEFAULT(''),
  [ImageURL] VARCHAR(100) NOT NULL DEFAULT(''),
  [CatePos] INT NOT NULL DEFAULT(0),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (CateID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem danh mục sản phẩm theo mã CateID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Categories_Select]
CREATE PROCEDURE [dbo].[sp_Categories_Select]
	@CateID nvarchar(50)
AS
BEGIN
	SELECT
		[ID],
		[ParentID],
		[Level],
		[CateID],
		[CateName],
		[ImageURL],
		[CatePos],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Categories]
	WHERE 
		[CateID] = @CateID 
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục Categories>
-- =============================================
--exec sp_Categories_SelectAll
--DROP PROC [dbo].[sp_Categories_SelectAll]
ALTER PROCEDURE [dbo].[sp_Categories_SelectAll]
AS
BEGIN
	SELECT
		[ID],
		[ParentID],
		[Level],
		[CateID],
		[CateID] + '-' + ltrim(CateName) as CateName,
		[ImageURL],
		[CatePos],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Categories]
	Order by [CateID],[CatePos]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục sản phẩm>
-- =============================================
--DROP PROC [dbo].[sp_Categories_SelectByLevel]
CREATE PROCEDURE [dbo].[sp_Categories_SelectByLevel]
	@Level INT
AS
BEGIN
	SELECT
		[ID],
		[ParentID],
		[Level],
		[CateID],
		[CateName],
		[ImageURL],
		[CatePos],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Categories]
	WHERE 
		[Level] = @Level

END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục sản phẩm>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Categories_Insert]
CREATE PROCEDURE [dbo].[sp_Categories_Insert]
	@ParentID INT,
	@Level INT,
	@CateID  NVARCHAR(50),
	@CateName NVARCHAR(100),
	@ImageURL VARCHAR(100),
	@CatePos INT,
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Categories](
		[ParentID],
		[Level],
		[CateID],
		[CateName],
		[ImageURL],
		[CatePos],
		[CreateDate],
		[CreateUser]
		)
	VALUES
	(
		@ParentID,
		@Level,
		@CateID,
		@CateName,
		@ImageURL,
		@CatePos,
		@CreateDate,
		@CreateUser
	)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa danh mục sản phẩm>
-- =============================================
--DROP PROC [dbo].[sp_Categories_Delete]
CREATE PROCEDURE [dbo].[sp_Categories_Delete]
	@CateID nvarchar(50)
AS
BEGIN
	DELETE FROM [dbo].[Categories]
	WHERE 
		[CateID] = @CateID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập thông tin liên hệ>
-- =============================================
--DROP PROC [dbo].[sp_Categories_Update]
CREATE PROCEDURE [dbo].[sp_Categories_Update]
	@ParentID INT,
	@Level INT,
	@CateID INT,
	@CateName NVARCHAR(100),
	@ImageURL VARCHAR(100),
	@CatePos INT,
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Categories] SET
		[ParentID] = @ParentID,
		[Level] = @Level,
		[CateID] = @CateID,
		[CateName] = @CateName,
		[ImageURL] = @ImageURL,
		[CatePos] = @CatePos,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[CateID] = @CateID
END
GO

select * from [dbo].[Categories]
select * from [ITEC_eCorp].[dbo].[eCorp_Categories]

insert into  [dbo].[Categories] (CateName,ImageURL,CatePos)
select CateName,ImageURL,CatePos from [ITEC_eCorp].[dbo].[eCorp_Categories]