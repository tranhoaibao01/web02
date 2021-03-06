Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng giới thiệu doanh nghiệp>
-- =============================================
--DROP TABLE [AboutUs]
CREATE TABLE [dbo].[AboutUs]
(
  [IntroID] INT IDENTITY(1,1) NOT NULL,
  [Description] NTEXT NOT NULL DEFAULT(''),
  [Active] BIT NOT NULL DEFAULT(1),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (IntroID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem thông tin doanh nghiệp theo mã IntroID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_AboutUs_Select]
CREATE PROCEDURE [dbo].[sp_AboutUs_Select]
	@IntroID INT
As
BEGIN
	SELECT
		[IntroID],
		[Description],
		[Active],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[AboutUs]
	WHERE 
		[IntroID] = @IntroID 
END
GO		

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem thông tin doanh nghiệp theo nội dung được kích hoạt>
-- =============================================
--DROP PROCEDURE [dbo].[sp_AboutUs_SelectAllByActive]
CREATE PROCEDURE [dbo].[sp_AboutUs_SelectAllByActive]
As
BEGIN
	SELECT
		[IntroID],
		[Description],
		[Active],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[AboutUs]
	WHERE 
		[Active] = 1
END
GO	

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ thông tin doanh nghiệp>
-- =============================================
--DROP PROC [dbo].[sp_AboutUs_SelectAll]
CREATE PROCEDURE [dbo].[sp_AboutUs_SelectAll]
AS
BEGIN
	SELECT
		[IntroID],
		[Description],
		[Active],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[AboutUs]
END
GO

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới thông tin doanh nghiệp>
-- =============================================
--DROP PROCEDURE [dbo].[sp_AboutUs_Insert]
CREATE PROCEDURE [dbo].[sp_AboutUs_Insert]
	@Description NTEXT,
	@Active BIT,
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
As
BEGIN
	INSERT INTO [dbo].[AboutUs](
		[Description],
		[Active],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@Description,
		@Active,
		@CreateDate,
		@CreateUser
		)
END
GO

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa thông tin doanh nghiệp>
-- =============================================
--DROP PROC [dbo].[sp_AboutUs_Delete]
CREATE PROCEDURE [dbo].[sp_AboutUs_Delete]
	@IntroID INT
AS
BEGIN
	DELETE FROM [dbo].[AboutUs]
	WHERE 
		[IntroID] = @IntroID
END
GO

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập thông tin doan nghiệp>
-- =============================================
--DROP PROC [dbo].[sp_AboutUs_Update]
CREATE PROCEDURE [dbo].[sp_AboutUs_Update]
	@IntroID INT,
	@Description NTEXT,
	@Active BIT,
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
As
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[AboutUs] SET
		[Description] = @Description,
		[Active] = @Active,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[IntroID] = @IntroID
END
GO

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Reset thuộc tính Active>
-- =============================================
--DROP PROC [dbo].[sp_AboutUs_ResetActive]
CREATE PROCEDURE [dbo].[sp_AboutUs_ResetActive]
As
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[AboutUs] SET
		[Active] = 0
	WHERE 
		[Active] = 1
END
GO


-- Lấy dữ liệu
--select * from [AboutUs]
insert into [eCorp].[dbo].[AboutUs]([Description])
select [Description] from [ITEC_eCorp].[dbo].[eCorp_AboutUs]