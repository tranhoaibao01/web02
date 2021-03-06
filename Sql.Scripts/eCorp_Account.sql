Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng tài khoản người dùng>
-- =============================================
--DROP TABLE [Account]
CREATE TABLE [dbo].[Account]
(
  [UserID] NVARCHAR(50) NOT NULL DEFAULT(''),
  [Password] NVARCHAR(50) NOT NULL DEFAULT(''),
  [Email] NVARCHAR(50) NOT NULL DEFAULT(''),
  [Mobile] NVARCHAR(20) NOT NULL DEFAULT(''),
  [FullName] NVARCHAR(100) NOT NULL DEFAULT(''),
  [Active] BIT NOT NULL DEFAULT(1),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (UserID)
)
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem tài khoản theo mã UserID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Account_Select]
CREATE PROCEDURE [dbo].[sp_Account_Select]
	@UserID NVARCHAR(50)
As
BEGIN
	SELECT
		[UserID],
		[Password],
		[Email],
		[Mobile],
		[FullName],
		[Active],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Account]
	WHERE 
		UserID = @UserID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ tài khoản người dùng>
-- =============================================
--DROP PROC [dbo].[sp_Account_SelectAll]
CREATE PROCEDURE [dbo].[sp_Account_SelectAll]
	@UserID NVARCHAR(50)
AS
BEGIN
	SELECT
		[UserID],
		[Password],
		[Email],
		[Mobile],
		[FullName],
		[Active],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Account]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới một tài khoản>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Account_Insert]
CREATE PROCEDURE [dbo].[sp_Account_Insert]
	@UserID NVARCHAR(50),
	@Password NVARCHAR(50),
	@Email NVARCHAR(50),
	@Mobile NVARCHAR(20),
	@FullName NVARCHAR(100),
	@Active BIT,
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50),
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
As
BEGIN
	INSERT INTO [dbo].[Account](
		[UserID],
		[Password],
		[Email],
		[Mobile],
		[FullName],
		[Active],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@UserID,
		@Password,
		@Email,
		@Mobile,
		@FullName,
		@Active,
		@CreateDate,
		@CreateUser
		)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa một tài khoản theo mã UserID>
-- =============================================
--DROP PROC [dbo].[sp_Account_Delete]
CREATE PROCEDURE [dbo].[sp_Account_Delete]
	@UserID NVARCHAR(50)
AS
BEGIN
	DELETE FROM [dbo].[Account]
	WHERE 
		[UserID] = @UserID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập một tài khoản>
-- =============================================
--DROP PROC [dbo].[sp_Account_Update]
CREATE PROCEDURE [dbo].[sp_Account_Update]
	@UserID NVARCHAR(50),
	@Password NVARCHAR(50),
	@Email NVARCHAR(50),
	@Mobile NVARCHAR(20),
	@FullName NVARCHAR(100),
	@Active BIT,
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
As
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Account] SET
		[Password] = @Password,
		[Email] = @Email,
		[Mobile] = @Mobile,
		[FullName] = @FullName,
		[Active] = @Active,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[UserID] = @UserID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Kiểm tra tài khoản đã tồn tại hay chưa>
-- =============================================
--DROP PROC [dbo].[sp_Account_SelectByUserID]
CREATE PROCEDURE [dbo].[sp_Account_SelectByUserID]
	@UserID NVARCHAR(50)
AS
BEGIN
	SELECT
		[UserID]
	FROM 
		[dbo].[Account]
	WHERE 
		[UserID] = @UserID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Truy xuất UserID với tham số là UserID và Password>
-- =============================================
--DROP PROC [dbo].[sp_Account_SelectByUserIDPass]
CREATE PROCEDURE [dbo].[sp_Account_SelectByUserIDPass]
	@UserID NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN
	SELECT
		[UserID]
	FROM 
		[dbo].[Account]
	WHERE 
		[UserID] = @UserID AND [Password] = @Password
END
GO

select * from [dbo].[Account]