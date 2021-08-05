
--DROP TABLE tb_UserMaster
IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tb_UserMaster' and type = 'U')
BEGIN

	CREATE TABLE tb_UserMaster
	(
		n_UserID			INT IDENTITY(1,1)	NOT NULL,
		s_UserName			VARCHAR(50)			NOT NULL,
		s_Email				VARCHAR(100)		NULL,
		s_Password			VARCHAR(MAX)		NOT NULL,
		CONSTRAINT PK_tb_UserMaster_n_UserID PRIMARY KEY (n_UserID)
	)
END

--DROP TABLE tb_RestDetails
IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tb_RestDetails' and type = 'U')
BEGIN

	CREATE TABLE tb_RestDetails
	(
		n_RestID			INT IDENTITY(1,1)	NOT NULL,
		s_Name				VARCHAR(50)			NOT NULL,
		s_Address			VARCHAR(100)		NULL,
		s_Contact			VARCHAR(50)			NULL,
	)
END