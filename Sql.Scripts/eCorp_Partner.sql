Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng danh mục đối tác>
-- =============================================
--DROP TABLE [Partner]
CREATE TABLE [dbo].[Partner]
(
  [PartnerID] INT IDENTITY(1,1) NOT NULL,
  [PartnerName] NVARCHAR(200) NOT NULL DEFAULT(''),
  [ImageURL] VARCHAR(50) NOT NULL DEFAULT(''),
  [Description] NTEXT NOT NULL DEFAULT(''),
  [Website] NVARCHAR(100) NOT NULL DEFAULT(''),
  [Email] NVARCHAR(50) NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (PartnerID)
)
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem bảng danh mục đối tác theo mã PartnerID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Partner_Select]
CREATE PROCEDURE [dbo].[sp_Partner_Select]
	@PartnerID INT
AS
BEGIN
	SELECT
		[PartnerID],
		[PartnerName],
		[ImageURL],
		[Description],
		[Website],
		[Email],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Partner]
	WHERE 
		[PartnerID] = @PartnerID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục đối tác>
-- =============================================
--DROP PROC [dbo].[sp_Partner_SelectAll]
CREATE PROCEDURE [dbo].[sp_Partner_SelectAll]
AS
BEGIN
	SELECT
		[PartnerID],
		[PartnerName],
		[ImageURL],
		[Description],
		[Website],
		[Email],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Partner]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục đối tác>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Partner_Insert]
CREATE PROCEDURE [dbo].[sp_Partner_Insert]
	@PartnerName NVARCHAR(200),
	@ImageURL VARCHAR(50),
	@Description NVARCHAR(50),
	@Website NVARCHAR(100),
	@Email NVARCHAR(50),
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Partner](
		[PartnerName],
		[ImageURL],
		[Description],
		[Website],
		[Email],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@PartnerName,
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
-- Description:	<Xóa danh mục đối tác>
-- =============================================
--DROP PROC [dbo].[sp_Partner_Delete]
CREATE PROCEDURE [dbo].[sp_Partner_Delete]
	@PartnerID INT
AS
BEGIN
	DELETE FROM [dbo].[Partner]
	WHERE 
		[PartnerID] = @PartnerID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập danh mục đối tác>
-- =============================================
--DROP PROC [dbo].[sp_Partner_Update]
CREATE PROCEDURE [dbo].[sp_Partner_Update]
	@PartnerID INT,
	@PartnerName NVARCHAR(200),
	@ImageURL VARCHAR(50),
	@Description NVARCHAR(50),
	@Website NVARCHAR(100),
	@Email NVARCHAR(50),
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Partner] SET
		[PartnerName] = @PartnerName,
		[ImageURL] = @ImageURL,
		[Description] = @Description,
		[Website] = @Website,
		[Email] = @Email,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[PartnerID] = @PartnerID
END
GO



select * from [Partner]
insert into [eCorp].[dbo].[Partner] (PartnerName,ImageURL,[Description],CreateDate,CreateUser)
select Name,ImageURL,[Description],getdate() as CreateDate,'Admin' as CreateUser
	from [ITEC_eCorp].[dbo].[eCorp_Partner]
