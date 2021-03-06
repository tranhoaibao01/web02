Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng danh mục khách hàng>
-- =============================================
--DROP TABLE [Customer]
CREATE TABLE [dbo].[Customer]
(
  [CustomerID] INT IDENTITY(1,1) NOT NULL,
  [CustomerName] NVARCHAR(200) NOT NULL DEFAULT(''),
  [ImageURL] VARCHAR(50) NOT NULL DEFAULT(''),
  [Description] NTEXT NOT NULL DEFAULT(''),
  [Website] NVARCHAR(100) NOT NULL DEFAULT(''),
  [Email] NVARCHAR(50) NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (CustomerID)
)


-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem bảng danh mục khách hàng theo mã CustomerID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Customer_Select]
CREATE PROCEDURE [dbo].[sp_Customer_Select]
	@CustomerID INT
AS
BEGIN
	SELECT
		[CustomerID],
		[CustomerName],
		[ImageURL],
		[Description],
		[Website],
		[Email],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Customer]
	WHERE 
		[CustomerID] = @CustomerID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục khách hàng>
-- =============================================
--DROP PROC [dbo].[sp_Customer_SelectAll]
CREATE PROCEDURE [dbo].[sp_Customer_SelectAll]
AS
BEGIN
	SELECT
		[CustomerID],
		[CustomerName],
		[ImageURL],
		[Description],
		[Website],
		[Email],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Customer]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục khách hàng>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Customer_Insert]
CREATE PROCEDURE [dbo].[sp_Customer_Insert]
	@CustomerName NVARCHAR(200),
	@ImageURL VARCHAR(50),
	@Description NVARCHAR(50),
	@Website NVARCHAR(100),
	@Email NVARCHAR(50),
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Customer](
		[CustomerName],
		[ImageURL],
		[Description],
		[Website],
		[Email],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@CustomerName,
		@ImageURL,
		@Description,
		@Website,
		@Email,
		@CreateDate,
		@CreateUser
		)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa danh mục khách hàng>
-- =============================================
--DROP PROC [dbo].[sp_Customer_Delete]
CREATE PROCEDURE [dbo].[sp_Customer_Delete]
	@CustomerID INT
AS
BEGIN
	DELETE FROM [dbo].[Customer]
	WHERE 
		[CustomerID] = @CustomerID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập danh mục khách hàng>
-- =============================================
--DROP PROC [dbo].[sp_Customer_Update]
CREATE PROCEDURE [dbo].[sp_Customer_Update]
	@CustomerID INT,
	@CustomerName NVARCHAR(200),
	@ImageURL VARCHAR(50),
	@Description NVARCHAR(50),
	@Website NVARCHAR(100),
	@Email NVARCHAR(50),
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Customer] SET
		[CustomerName] = @CustomerName,
		[ImageURL] = @ImageURL,
		[Description] = @Description,
		[Website] = @Website,
		[Email] = @Email,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[CustomerID] = @CustomerID
END
GO



select * from [dbo].[Customer]
select * from [ITEC_eCorp].[dbo].[eCorp_Customer]


insert into  [dbo].[Customer] (CustomerName,ImageURL,Description,Website,Email)
select Name,ImageURL,Description,Website,Email from [ITEC_eCorp].[dbo].[eCorp_Customer]


select * from Product