Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng danh mục tin tức>
-- =============================================
--DROP TABLE [News]
CREATE TABLE [dbo].[News]
(
  [NewsID] INT IDENTITY(1,1) NOT NULL,
  [Title] NVARCHAR(200) NOT NULL DEFAULT(''),
  [ImageURL] NVARCHAR(50) NOT NULL DEFAULT(''),
  [ShortDescript] NVARCHAR(MAX) NOT NULL DEFAULT(''),
  [Description] NTEXT NOT NULL DEFAULT(''),
  [Copyright] NVARCHAR(50) NOT NULL DEFAULT(''),
  [ViewNumber] INT NOT NULL DEFAULT(0),
  [IsHotNews] BIT NOT NULL DEFAULT(0),
  [PostDate] SMALLDATETIME NULL,
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (NewsID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem danh mục tin tức theo mã NewsID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_News_Select]
CREATE PROCEDURE [dbo].[sp_News_Select]
	@NewsID INT
As
BEGIN
	SELECT
		[NewsID],
		[Title],
		[ImageURL],
		[ShortDescript],
		[Description],
		[Copyright],
		[ViewNumber],
		[IsHotNews],
		[PostDate],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[News]
	WHERE 
		[NewsID] = @NewsID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục tin tức>
-- =============================================
--DROP PROC [dbo].[sp_News_SelectAll]
CREATE PROCEDURE [dbo].[sp_News_SelectAll]
AS
BEGIN
	SELECT
		[NewsID],
		[Title],
		[ImageURL],
		[ShortDescript],
		[Description],
		[Copyright],
		[ViewNumber],
		[IsHotNews],
		[PostDate],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[News]
	ORDER BY [PostDate] DESC
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục tin tức>
-- =============================================
--DROP PROC [dbo].[sp_News_SelectAllNotTop1]
CREATE PROCEDURE [dbo].[sp_News_SelectAllNotTop1]
AS
BEGIN
	SELECT
		[NewsID],
		[Title],
		[ImageURL],
		[ShortDescript],
		[Description],
		[Copyright],
		[ViewNumber],
		[IsHotNews],
		[PostDate],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[News]
	WHERE NewsID <> (SELECT TOP 1 NewsID FROM [dbo].[News] ORDER BY [PostDate] DESC)
	ORDER BY [PostDate] DESC
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục tin tức>
-- =============================================
--DROP PROC [dbo].[sp_News_SelectTop1]
CREATE PROCEDURE [dbo].[sp_News_SelectTop1]
AS
BEGIN
	SELECT Top 1
		[NewsID],
		[Title],
		[ImageURL],
		[ShortDescript],
		[Description],
		[Copyright],
		[ViewNumber],
		[IsHotNews],
		[PostDate],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[News]
	ORDER BY [PostDate] DESC
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục tin tức>
-- =============================================
--DROP PROC [dbo].[sp_News_SelectTop10]
CREATE PROCEDURE [dbo].[sp_News_SelectTop10]
AS
BEGIN
	SELECT Top 10
		[NewsID],
		[Title],
		[ImageURL],
		[ShortDescript],
		[Description],
		[Copyright],
		[ViewNumber],
		[IsHotNews],
		[PostDate],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[News]
	ORDER BY [PostDate] DESC
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục tin tức>
-- =============================================
--DROP PROCEDURE [dbo].[sp_News_Insert]
CREATE PROCEDURE [dbo].[sp_News_Insert]
	@Title NVARCHAR(200),
	@ImageURL NVARCHAR(50),
	@ShortDescript NVARCHAR(MAX),
	@Description NTEXT,
	@Copyright NVARCHAR(50),
	@IsHotNews BIT,
	@PostDate SMALLDATETIME,
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
As
BEGIN
	INSERT INTO [dbo].[News](
		[Title],
		[ImageURL],
		[ShortDescript],
		[Description],
		[Copyright],
		[IsHotNews],
		[PostDate],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@Title,
		@ImageURL,
		@ShortDescript,
		@Description,
		@Copyright,
		@IsHotNews,
		@PostDate,
		@CreateDate,
		@CreateUser
		)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa danh mục tin tức>
-- =============================================
--DROP PROC [dbo].[sp_News_Delete]
CREATE PROCEDURE [dbo].[sp_News_Delete]
	@NewsID INT
AS
BEGIN
	DELETE FROM [dbo].[News]
	WHERE 
		[NewsID] = @NewsID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập danh mục tin tức>
-- =============================================
--DROP PROC [dbo].[sp_News_Update]
CREATE PROCEDURE [dbo].[sp_News_Update]
	@NewsID INT,
	@Title NVARCHAR(200),
	@ImageURL NVARCHAR(50),
	@ShortDescript NVARCHAR(MAX),
	@Description NTEXT,
	@Copyright NVARCHAR(50),
	@ViewNumber INT,
	@IsHotNews BIT,
	@PostDate SMALLDATETIME,
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
As
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[News] SET
		[Title] = @Title,
		[ImageURL] = @ImageURL,
		[ShortDescript] = @ShortDescript,
		[Description] = @Description,
		[Copyright] = @Copyright,
		[ViewNumber] = @ViewNumber,
		[IsHotNews] = @IsHotNews,
		[PostDate] = @PostDate,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[NewsID] = @NewsID
END
GO
