
CREATE PROCEDURE CreateEntry	-- Add the parameters for the stored procedure here
	@BookName nvarchar(50),
	@BookAuthor nvarchar(50),
	@CreatedBy int,
	@CreatedOn DateTime,
	@UpdatedBy int,
	@UpdatedOn DateTime,
	@IsAvailable bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert Into BooksInfo (BookName, BookAuthor, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsAvailable) Values (@BookName, @BookAuthor, @CreatedBy, @CreatedOn, @UpdatedBy, @UpdatedOn, @IsAvailable)
END
GO

CREATE PROCEDURE ReadEntry	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
   Select * From BooksInfo;
END
GO

CREATE PROCEDURE UpdateEntry 
	-- Add the parameters for the stored procedure here
	@BookId bigint,
	@BookName nvarchar(50),
	@BookAuthor nvarchar(50),
	@UpdatedBy int,
	@UpdatedOn DateTime,
	@IsAvailable bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update BooksInfo Set BookName = @BookName, BookAuthor = @BookAuthor, UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy,  IsAvailable = @IsAvailable Where BookId = @BookId;
END
GO

CREATE PROCEDURE DeleteEntry 
	-- Add the parameters for the stored procedure here
	@BookId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from BooksInfo Where BookId = @BookId;
END
GO