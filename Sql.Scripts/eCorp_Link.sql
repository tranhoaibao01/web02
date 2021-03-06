Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng danh mục liên kết>
-- =============================================
--DROP TABLE [Link]
CREATE TABLE [dbo].[Link]
(
  [LinkID] INT IDENTITY(1,1) NOT NULL,
  [LinkName] NVARCHAR(50) NOT NULL DEFAULT(''),
  [URL] NVARCHAR(50) NOT NULL DEFAULT(''),
  [Pos] INT NOT NULL DEFAULT(0),
  [Logo] NVARCHAR(50) NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (LinkID)
)
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem bảng danh mục liên kết theo mã LinkID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Link_Select]
CREATE PROCEDURE [dbo].[sp_Link_Select]
	@LinkID INT
AS
BEGIN
	SELECT
		[LinkID],
		[LinkName],
		[URL],
		[Pos],
		[Logo],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Link]
	WHERE 
		[LinkID] = @LinkID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục liên kết>
-- =============================================
--DROP PROC [dbo].[sp_Link_SelectAll]
CREATE PROCEDURE [dbo].[sp_Link_SelectAll]
AS
BEGIN
	SELECT
		[LinkID],
		[LinkName],
		[URL],
		[Pos],
		[Logo],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Link]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục liên kết>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Link_Insert]
CREATE PROCEDURE [dbo].[sp_Link_Insert]
    @LinkName NVARCHAR(50),
    @URL NVARCHAR(50),
    @Pos INT,
    @Logo NVARCHAR(50),
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Link](
		[LinkName],
		[URL],
		[Pos],
		[Logo],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@LinkName,
		@URL,
		@Pos,
		@Logo,
		@CreateDate,
		@CreateUser
		)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa danh mục liên kết>
-- =============================================
--DROP PROC [dbo].[sp_Link_Delete]
CREATE PROCEDURE [dbo].[sp_Link_Delete]
	@LinkID INT
AS
BEGIN
	DELETE FROM [dbo].[Link]
	WHERE 
		[LinkID] = @LinkID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập danh mục liên kết>
-- =============================================
--DROP PROC [dbo].[sp_Link_Update]
CREATE PROCEDURE [dbo].[sp_Link_Update]
	@LinkID INT,
	@LinkName NVARCHAR(50),
    @URL NVARCHAR(50),
    @Pos INT,
    @Logo NVARCHAR(50),
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Link] SET
		[LinkName] = @LinkName,
		[URL] = @URL,
		[Pos] = @Pos,
		[Logo] = @Logo,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[LinkID] = @LinkID
END
GO


select * from [eCorp].[dbo].[Link]
select * from [ITEC_eCorp].[dbo].[eCorp_Link]
	
insert into [eCorp].[dbo].[Link](LinkName,URL,Pos,Logo)
select Name,URL,Pos,isnull(Logo,'') as Logo
	from [ITEC_eCorp].[dbo].[eCorp_Link]