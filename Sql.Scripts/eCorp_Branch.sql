Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng liên hệ: lưu trữ thông tin phản hồi của người dùng>
-- =============================================
--DROP TABLE [Branch]
CREATE TABLE [dbo].[Branch]
(
  [BranchID] INT IDENTITY(1,1) NOT NULL,
  [FullName] NVARCHAR(500) NOT NULL DEFAULT(''),
  [ImageURL] VARCHAR(100) NOT NULL DEFAULT(''),
  [Address] NVARCHAR(500) NOT NULL DEFAULT(''),
  [Phone] VARCHAR(50) NOT NULL DEFAULT(''),
  [Mobile] VARCHAR(50) NOT NULL DEFAULT(''),
  [Fax] NVARCHAR(50) NOT NULL DEFAULT(''),
  [Email] VARCHAR(100) NOT NULL DEFAULT(''),
  [WebSite] VARCHAR(100) NOT NULL DEFAULT(''),
  [Contents] NTEXT NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (BranchID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem thông tin liên hệ theo mã BranchID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Branch_Select]
CREATE PROCEDURE [dbo].[sp_Branch_Select]
	@BranchID INT
As
BEGIN
	SELECT
		[BranchID],
		[FullName],
		[ImageURL],
		[Address],
		[Phone],
		[Mobile],
		[Fax],
		[Email],
		[WebSite],
		[Contents],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Branch]
	WHERE 
		[BranchID] = @BranchID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ thông tin liên hệ>
-- =============================================
--DROP PROC [dbo].[sp_Branch_SelectAll]
CREATE PROCEDURE [dbo].[sp_Branch_SelectAll]
AS
BEGIN
	SELECT
		[BranchID],
		[FullName],
		[ImageURL],
		[Address],
		[Phone],
		[Mobile],
		[Fax],
		[Email],
		[WebSite],
		[Contents],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Branch]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới tin tức>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Branch_Insert]
CREATE PROCEDURE [dbo].[sp_Branch_Insert]
	@FullName NVARCHAR(500),
	@ImageURL NVARCHAR(100),
	@Address NVARCHAR(500),
	@Phone VARCHAR(50),
	@Mobile VARCHAR(50),
	@Fax NVARCHAR(50),
	@WebSite NVARCHAR(50),
	@Email VARCHAR(100),
	@Contents NTEXT,
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
As
BEGIN
	INSERT INTO [dbo].[Branch](
		[FullName],
		[ImageURL],
		[Address],
		[Phone],
		[Mobile],
		[Fax],
		[Email],
		[WebSite],
		[Contents],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@FullName,
		@ImageURL,
		@Address,
		@Phone,
		@Mobile,
		@Fax,
		@Email,
		@WebSite,
		@Contents,
		@CreateDate,
		@CreateUser
		)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa thông tin liên hệ>
-- =============================================
--DROP PROC [dbo].[sp_Branch_Delete]
CREATE PROCEDURE [dbo].[sp_Branch_Delete]
	@BranchID INT
AS
BEGIN
	DELETE FROM [dbo].[Branch]
	WHERE 
		[BranchID] = @BranchID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập thông tin liên hệ>
-- =============================================
--DROP PROC [dbo].[sp_Branch_Update]
CREATE PROCEDURE [dbo].[sp_Branch_Update]
	@BranchID INT,
	@FullName NVARCHAR(500),
	@ImageURL NVARCHAR(100),
	@Address NVARCHAR(500),
	@Phone VARCHAR(50),
	@Mobile VARCHAR(50),
	@Fax NVARCHAR(50),
	@Email VARCHAR(50),
	@WebSite VARCHAR(50),
	@Contents NTEXT,
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
As
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Branch] SET
		[FullName] = @FullName,
		[ImageURL] = @ImageURL,
		[Address] = @Address,
		[Phone] = @Phone,
		[Mobile] = @Mobile,
		[Fax] = @Fax,
		[Email] = @Email,
		[WebSite] = @WebSite,
		[Contents] = @Contents,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[BranchID] = @BranchID
END
GO


select * from branch