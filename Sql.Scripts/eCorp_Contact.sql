Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng liên hệ: lưu trữ thông tin phản hồi của người dùng>
-- =============================================
--DROP TABLE [Contact]
CREATE TABLE [dbo].[Contact]
(
  [ContactID] INT IDENTITY(1,1) NOT NULL,
  [FullName] NVARCHAR(100) NOT NULL DEFAULT(''),
  [Address] NVARCHAR(500) NOT NULL DEFAULT(''),
  [Phone] VARCHAR(50) NOT NULL DEFAULT(''),
  [Email] VARCHAR(50) NOT NULL DEFAULT(''),
  [Subject] NVARCHAR(50) NOT NULL DEFAULT(''),
  [IPClient] CHAR(20) NOT NULL DEFAULT(''),
  [Contents] NTEXT NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (ContactID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem thông tin liên hệ theo mã ContactID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Contact_Select]
CREATE PROCEDURE [dbo].[sp_Contact_Select]
	@ContactID INT
As
BEGIN
	SELECT
		[ContactID],
		[FullName],
		[Address],
		[Phone],
		[Email],
		[Subject],
		[IPClient],
		[Contents],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Contact]
	WHERE 
		[ContactID] = @ContactID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ thông tin liên hệ>
-- =============================================
--DROP PROC [dbo].[sp_Contact_SelectAll]
CREATE PROCEDURE [dbo].[sp_Contact_SelectAll]
AS
BEGIN
	SELECT
		[ContactID],
		[FullName],
		[Address],
		[Phone],
		[Email],
		[Subject],
		[IPClient],
		[Contents],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Contact]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới tin tức>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Contact_Insert]
CREATE PROCEDURE [dbo].[sp_Contact_Insert]
	@FullName NVARCHAR(100),
	@Address NVARCHAR(500),
	@Phone VARCHAR(50),
	@Email VARCHAR(50),
	@Subject NVARCHAR(50),
	@IPClient CHAR(20),
	@Contents NTEXT,
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
As
BEGIN
	INSERT INTO [dbo].[Contact](
		[FullName],
		[Address],
		[Phone],
		[Email],
		[Subject],
		[IPClient],
		[Contents],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@FullName,
		@Address,
		@Phone,
		@Email,
		@Subject,
		@IPClient,
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
--DROP PROC [dbo].[sp_Contact_Delete]
CREATE PROCEDURE [dbo].[sp_Contact_Delete]
	@ContactID INT
AS
BEGIN
	DELETE FROM [dbo].[Contact]
	WHERE 
		[ContactID] = @ContactID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập thông tin liên hệ>
-- =============================================
--DROP PROC [dbo].[sp_Contact_Update]
CREATE PROCEDURE [dbo].[sp_Contact_Update]
	@ContactID INT,
	@FullName NVARCHAR(100),
	@Address NVARCHAR(500),
	@Phone VARCHAR(50),
	@Email VARCHAR(50),
	@Subject NVARCHAR(50),
	@IPClient CHAR(20),
	@Contents NTEXT,
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
As
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Contact] SET
		[FullName] = @FullName,
		[Address] = @Address,
		[Phone] = @Phone,
		[Email] = @Email,
		[Subject] = @Subject,
		[IPClient] = @IPClient,
		[Contents] = @Contents,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[ContactID] = @ContactID
END
GO



--select [ContactID],[FullName],[Address],[Phone],[Email],[Subject],[IPClient],[Contents],[CreateDate],[CreateUser]
--	from [eCorp].[dbo].[Contact]
	
--insert into [eCorp].[dbo].[Contact]([FullName],[Address],[Phone],[Email],[Subject],[IPClient],[Contents],[CreateDate],[CreateUser])
--select [FullName],[Address],[Phone],[Email],[Subject],[IPClient],[Contents],getdate() as [CreateDate],'Admin' as [CreateUser]
--	from [ITEC_eCorp].[dbo].[eCorp_Contact]