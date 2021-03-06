Use [eCorp]
select * from Product
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Bảng giới thiệu danh mục sản phẩm của doanh nghiệp>
-- =============================================
--DROP TABLE [Product]
CREATE TABLE [dbo].[Product]
(
  [ProductID] INT IDENTITY(1,1) NOT NULL,
  [CateID] NVARCHAR(50) NOT NULL DEFAULT(''),
  [ProductTitle] NVARCHAR(200) NOT NULL DEFAULT(''),
  [FileName] NVARCHAR(50) NOT NULL DEFAULT(''),
  [ImageURL] VARCHAR(200) NOT NULL DEFAULT(''),
  [Description] NVARCHAR(MAX) NOT NULL DEFAULT(''),
  [CreateDate] SMALLDATETIME NULL,
  [CreateUser] NVARCHAR(50) NULL,
  [EditDate] SMALLDATETIME NULL,
  [EditUser] NVARCHAR(50) NULL,
  PRIMARY KEY (ProductID)
)

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem bảng giới thiệu danh mục sản phẩm theo mã ProductID>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Product_SelectByProductID]
ALTER PROCEDURE [dbo].[sp_Product_SelectByProductID]
	@ProductID INT
AS
BEGIN
	SELECT
		p.[CateID],
		c.[CateName],
		p.[ProductID],
		p.[ProductTitle],
		p.[ImageURL],
		p.[Description],
		p.[CreateDate],
		p.[CreateUser],
		p.[EditDate],
		p.[EditUser]
	FROM 
		[dbo].[Product] p
		Left join [dbo].[Categories] c on c.CateID = p.CateID
	WHERE 
		[ProductID] = @ProductID
END
GO		

-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem toàn bộ danh mục giới thiệu sản phẩm>
-- =============================================
--EXEC sp_Product_SelectAll
--DROP PROC [dbo].[sp_Product_SelectAll]
ALTER PROCEDURE [dbo].[sp_Product_SelectAll]
AS
BEGIN
	SELECT
		p.[CateID],
		c.[CateName],
		p.[ProductID],
		p.[ProductTitle],
		p.[ImageURL],
		p.[Description],
		p.[CreateDate],
		p.[CreateUser],
		p.[EditDate],
		p.[EditUser]
	FROM 
		[dbo].[Product] p
		Left join [dbo].[Categories] c on c.CateID = p.CateID
	ORDER BY p.[CateID],p.[ProductID]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem danh mục giới thiệu sản phẩm với mã CateID>
-- =============================================
--SELECT * FROM [Product] 
--EXEC sp_Product_SelectByCateID 'GACH.KINH'
--DROP PROC [dbo].[sp_Product_SelectByCateID]
ALTER PROCEDURE [dbo].[sp_Product_SelectByCateID]
	@CateID nvarchar(50)
AS
BEGIN
	SELECT
		p.[CateID],
		c.[CateName],
		p.[ProductID],
		right(p.[ProductTitle],5) as ProductTitle,
		p.[ImageURL],
		p.[Description],
		p.[CreateDate],
		p.[CreateUser],
		p.[EditDate],
		p.[EditUser]
	FROM 
		[dbo].[Product] p
		Left join [dbo].[Categories] c on c.CateID = p.CateID
	WHERE 
		p.CateID like ltrim(@CateID) + '%'
	ORDER BY p.CateID, p.ProductID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem danh mục giới thiệu sản phẩm với mã CateID>
-- =============================================
--exec sp_Product_SelectByCateIDTop3 2
--DROP PROC [dbo].[sp_Product_SelectByCateIDTop3]
ALTER PROCEDURE [dbo].[sp_Product_SelectByCateIDTop3]
	@CateID nvarchar(50)
AS
BEGIN
	SELECT	TOP 3
		p.[CateID],
		c.[CateName],
		p.[ProductID],
		right(p.[ProductTitle],5) as ProductTitle,
		p.[ImageURL],
		p.[Description],
		p.[CreateDate],
		p.[CreateUser],
		p.[EditDate],
		p.[EditUser]
	FROM 
		[dbo].[Product] p
		Left join [dbo].[Categories] c on c.CateID = p.CateID
	WHERE 
		p.CateID like ltrim(@CateID) + '%'
	ORDER BY p.CateID, p.ProductID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thủ tục xem danh mục giới thiệu sản phẩm có giới hạn>
-- =============================================
--DROP PROC [dbo].[sp_Product_SelectTop]
ALTER PROCEDURE [dbo].[sp_Product_SelectTop]
AS
BEGIN
	SELECT TOP 10
		p.[CateID],
		c.[CateName],
		p.[ProductID],
		p.[ProductTitle],
		p.[ImageURL],
		p.[Description],
		p.[CreateDate],
		p.[CreateUser],
		p.[EditDate],
		p.[EditUser]
	FROM 
		[dbo].[Product] p
		Left join [dbo].[Categories] c on c.CateID = p.CateID
	ORDER BY p.CateID,p.[ProductID]
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Thêm mới danh mục giới thiệu sản phẩm sản phẩm>
-- =============================================
--DROP PROCEDURE [dbo].[sp_Product_Insert]
ALTER PROCEDURE [dbo].[sp_Product_Insert]
	@CateID NVARCHAR(50),
	@ProductTitle NVARCHAR(200),
	@ImageURL VARCHAR(200),
	@Description NVARCHAR(MAX),
	@CreateDate SMALLDATETIME,
	@CreateUser NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Product](
		[CateID],
		[ProductTitle],
		[ImageURL],
		[Description],
		[CreateDate],
		[CreateUser]
		)
	VALUES(
		@CateID,
		@ProductTitle,
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
-- Description:	<Xóa danh mục giới thiệu sản phẩm>
-- =============================================
--DROP PROC [dbo].[sp_Product_Delete]
CREATE PROCEDURE [dbo].[sp_Product_Delete]
	@ProductID INT
AS
BEGIN
	DELETE FROM [dbo].[Product]
	WHERE 
		[ProductID] = @ProductID
END
GO
-- =============================================
-- Author:		<Trần Hoài Bảo>
-- Create date: <7/11/2013>
-- Description:	<Cập nhập danh mục giới thiệu sản phẩm>
-- =============================================
--DROP PROC [dbo].[sp_Product_Update]
ALTER PROCEDURE [dbo].[sp_Product_Update]
	@ProductID INT,
	@CateID NVARCHAR(50),
	@ProductTitle NVARCHAR(200),
	@ImageURL VARCHAR(200),
	@Description NVARCHAR(MAX),
	@EditDate SMALLDATETIME,
	@EditUser NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[Product] SET
		[CateID] = @CateID,
		[ProductTitle] = @ProductTitle,
		[ImageURL] = @ImageURL,
		[Description] = @Description,
		[EditDate] = @EditDate,
		[EditUser] = @EditUser
	WHERE 
		[ProductID] = @ProductID
END
GO

select * from [dbo].[Product]
select * from [ITEC_eCorp].[dbo].[eCorp_Product]


insert into  [dbo].[Product] (CateID,ProductTitle,ImageURL,Description)
select CateID,ProTitle,ImageURL,Description from [ITEC_eCorp].[dbo].[eCorp_Product]
select * from Categories order by cateID