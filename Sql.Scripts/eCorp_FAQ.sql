Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng danh mục hỏi đáp>
-- =============================================
--DROP TABLE [FAQ]
CREATE TABLE [dbo].[FAQ]
(
  [FAQID] INT IDENTITY(1,1) NOT NULL,
  [Title] NVARCHAR(2000) NOT NULL DEFAULT(''),
  [Description] NTEXT NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (FAQID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem bảng danh mục hỏi đáp theo mã FAQID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_FAQ_Select]
CREATE PROCEDURE [dbo].[sp_FAQ_Select]
	@FAQID INT
AS
BEGIN
	SELECT
		[FAQID],
		[Title],
		[Description],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[FAQ]
	WHERE 
		[FAQID] = @FAQID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục hỏi đáp>
-- =============================================
--DROP PROC [dbo].[sp_FAQ_SelectAll]
CREATE PROCEDURE [dbo].[sp_FAQ_SelectAll]
AS
BEGIN
	SELECT
		[FAQID],
		[Title],
		[Description],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[FAQ]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục hỏi đáp>
-- =============================================
--DROP PROCEDURE [dbo].[sp_FAQ_Insert]
CREATE PROCEDURE [dbo].[sp_FAQ_Insert]
	@Title NVARCHAR(200),
	@Description NVARCHAR(50),
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[FAQ](
		[Title],
		[Description],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@Title,
		@Description,
		@CreateDate,
		@CreateUser
		)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa danh mục hỏi đáp>
-- =============================================
--DROP PROC [dbo].[sp_FAQ_Delete]
CREATE PROCEDURE [dbo].[sp_FAQ_Delete]
	@FAQID INT
AS
BEGIN
	DELETE FROM [dbo].[FAQ]
	WHERE 
		[FAQID] = @FAQID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập danh mục hỏi đáp>
-- =============================================
--DROP PROC [dbo].[sp_FAQ_Update]
CREATE PROCEDURE [dbo].[sp_FAQ_Update]
	@FAQID INT,
	@Title NVARCHAR(200),
	@Description NVARCHAR(50),
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[FAQ] SET
		[Title] = @Title,
		[Description] = @Description,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[FAQID] = @FAQID
END
GO


--select * from [eCorp].[dbo].[FAQ]
--insert into [eCorp].[dbo].[FAQ]([Title],[Description],[CreateDate],[CreateUser])
--select [Title],[Descript],getdate() as [CreateDate],'Admin' as [CreateUser]
--	from [ITEC_eCorp].[dbo].[eCorp_FAQ]