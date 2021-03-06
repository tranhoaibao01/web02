Use [eCorp]

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng danh mục dịch vụ>
-- =============================================
--DROP TABLE [Service]
CREATE TABLE [dbo].[Service]
(
  [ServiceID] INT IDENTITY(1,1) NOT NULL,
  [ServiceName] NVARCHAR(50) NOT NULL DEFAULT(''),
  [ImageURL] NVARCHAR(50) NOT NULL DEFAULT(''),
  [Description] NTEXT NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (ServiceID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem bảng danh mục dịch vụ theo mã ServiceID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Service_Select]
CREATE PROCEDURE [dbo].[sp_Service_Select]
	@ServiceID INT
AS
BEGIN
	SELECT
		[ServiceID],
		[ServiceName],
		[ImageURL],
		[Description],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Service]
	WHERE 
		[ServiceID] = @ServiceID
END
GO		
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục dịch vụ>
-- =============================================
--DROP PROC [dbo].[sp_Service_SelectAll]
CREATE PROCEDURE [dbo].[sp_Service_SelectAll]
AS
BEGIN
	SELECT
		[ServiceID],
		[ServiceName],
		[ImageURL],
		[Description],
		[CreateDate],
		[CreateUser],
		[EditDate],
		[EditUser]
	FROM 
		[dbo].[Service]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục dịch vụ>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Service_Insert]
CREATE PROCEDURE [dbo].[sp_Service_Insert]
    @ServiceName NVARCHAR(50),
    @ImageURL NVARCHAR(50),
    @Description NTEXT,
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Service](
		[ServiceName],
		[ImageURL],
		[Description],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@ServiceName,
		@ImageURL,
		@Description,
		@CreateDate,
		@CreateUser
		)
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Xóa danh mục dịch vụ>
-- =============================================
--DROP PROC [dbo].[sp_Service_Delete]
CREATE PROCEDURE [dbo].[sp_Service_Delete]
	@ServiceID INT
AS
BEGIN
	DELETE FROM [dbo].[Service]
	WHERE 
		[ServiceID] = @ServiceID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập danh mục dịch vụ>
-- =============================================
--DROP PROC [dbo].[sp_Service_Update]
CREATE PROCEDURE [dbo].[sp_Service_Update]
	@ServiceID INT,
	@ServiceName NVARCHAR(50),
    @ImageURL NVARCHAR(50),
    @Description NTEXT,
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Service] SET
		[ServiceName] = @ServiceName,
		[ImageURL] = @ImageURL,
		[Description] = @Description,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[ServiceID] = @ServiceID
END
GO


select * from [dbo].[Service]

insert into [eCorp].[dbo].[Service] (ServiceName,ImageURL,[Description],CreateDate,CreateUser)
select Name,ImageURL,[Description],getdate() as CreateDate,'Admin' as CreateUser
	from [ITEC_eCorp].[dbo].[eCorp_Service]