USE [Chetana_New]
GO
/****** Object:  StoredProcedure [dbo].[Idv_Chetana_Get_MasterOfMaster_ByGroup]    Script Date: 06-Apr-2018 11:56:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================          
-- Author:  <Vivek Pandey>          
-- Create date: <07/Apr/2018>          
-- Description: <Description,,>          
-- =============================================          
ALTER procedure [dbo].[Idv_Chetana_Get_DropDown]
(
	@Group nvarchar(50),
	@Extra nvarchar(50) = null
)
AS          
BEGIN
	IF(@Group = 'State')
	BEGIN
		SELECT StateID, StateCode, StateName
		FROM Idv_Chetana_StateMaster
	END
	ELSE IF(@Group = 'GSTPer')
	BEGIN
		-- EXEC [dbo].[Idv_Chetana_Get_DropDown] 'GSTPer', 'CRD01'

		DECLARE @ApplicableGST AS TABLE
		(
			AppGST_ID INT
		)

		INSERT INTO @ApplicableGST
		SELECT Split.a.value('.', 'VARCHAR(100)') AS AppGST_ID
		FROM (SELECT APPLICABLE_GST, CAST ('<M>' + REPLACE([APPLICABLE_GST], ',', '</M><M>') + '</M>' AS XML) AS String
			  FROM Idv_chetana_Account_main
			  WHERE AC_CODE = @Extra) AS A CROSS APPLY String.nodes ('/M') AS Split(a);

		SELECT [key], Value
		FROM Idv_Chetana_MasterOfMaster mom
		INNER JOIN @ApplicableGST app
			ON mom.[key] = app.AppGST_ID
		WHERE [Group] = 'GST_PER' AND IsDeleted = 0
	END
	ELSE
	BEGIN
		SELECT AutoId, [key], Value, [Group], [Description], IsActive, OS_OMS
		FROM Idv_Chetana_MasterOfMaster
		WHERE [Group] = @Group AND IsDeleted = 0
		ORDER BY [key]
	END
END



/****** Object:  StoredProcedure [dbo].[Idv_chetana_Save_Account_main]    Script Date: 06-Apr-2018 3:04:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================          
-- Author:  <Vivek Pandey>          
-- Create date: <07/Apr/2018>          
-- Description: <Description,,>          
-- =============================================    

ALTER PROCEDURE [dbo].[Idv_Chetana_Save_SupplierBill]
(
	@SBillID INT,
	@SupplierCode NVARCHAR(50),
	@PurchaseCode NVARCHAR(50),
	@InvoiceNo NVARCHAR(50),
	@InvoiceDate DATETIME,
	@GSTPer INT,
	@FY INT,
	@CreatedBy nvarchar(50),
	@UpdatedBy nvarchar(50),
	@IsActive BIT
)
AS
BEGIN
	DECLARE @GROUP INT
	SET @GROUP = (SELECT [GROUP] FROM IDV_Chetana_sub_group where GR_HEAD = @InvoiceNo)

	IF(ISNULL(@GROUP, '') = '')
	BEGIN
		SELECT 0 as MsgID, 'Invalid Invoice No' as Msg
	END
	ELSE
	BEGIN
		IF NOT EXISTS (SELECT Top 1 1 FROM tblSupplierBill WHERE SBillID = @SBillID)
		BEGIN
			INSERT INTO tblSupplierBill
			(
				SupplierCode,
				PurchaseCode,
				InvoiceNo,
				InvoiceDate,
				GSTPer,
				FY,
				CreatedBy,
				UpdatedBy,
				IsActive
			)
			VALUES
			(
				@SupplierCode,
				@PurchaseCode,
				@GROUP,
				@InvoiceDate,
				@GSTPer,
				@FY,
				@CreatedBy,
				@Updatedby,
				@IsActive
			)

			Select 1 as MsgID, 'Record saved successfully' as Msg, SCOPE_IDENTITY() as SBillID
		END
		ELSE
		BEGIN
			UPDATE tblSupplierBill
			SET SupplierCode = @SupplierCode,
				PurchaseCode = @PurchaseCode,
				InvoiceNo = @InvoiceNo,
				InvoiceDate = @InvoiceDate,
				GSTPer = @GSTPer,
				FY = @FY,
				CreatedBy = @CreatedBy,
				UpdatedBy = @Updatedby,
				UpdatedOn = GETDATE(),
				IsActive = @IsActive
			WHERE SBillID = @SBillID

			Select 2 as MsgID, 'Record updates successfully' as Msg, @SBillID as SBillID
		END
	END
END



/****** Object:  StoredProcedure [dbo].[Idv_chetana_Save_Account_main]    Script Date: 06-Apr-2018 3:04:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================          
-- Author:  <Vivek Pandey>          
-- Create date: <07/Apr/2018>          
-- Description: <Description,,>          
-- =============================================    

ALTER PROCEDURE [dbo].[Idv_Chetana_Save_SupplierBill_Details]
(
	@SBillDID INT,
	@SBillID INT,
	@AccountCode NVARCHAR(50),
	@Quantity INT,
	@Amount DECIMAL(18, 0),
	@Remark NVARCHAR(500),
	@CreatedBy NVARCHAR(50),
	@UpdatedBy NVARCHAR(50),
	@IsActive BIT
)
AS

BEGIN
	IF NOT EXISTS (SELECT Top 1 1 FROM tblSupplierBillDetails WHERE SBillDID = @SBillDID)
	BEGIN
		INSERT INTO tblSupplierBillDetails
		(
			SBillID,
			AccountCode,
			Quantity,
			Amount,
			Remark,
			CreatedBy,
			UpdatedBy,
			IsActive
		)
		VALUES
		(
			@SBillID,
			@AccountCode,
			@Quantity,
			@Amount,
			@Remark,
			@CreatedBy,
			@Updatedby,
			@IsActive
		)
	END
	ELSE
	BEGIN
		UPDATE tblSupplierBillDetails
		SET SBillID = @SBillID,
			AccountCode = @AccountCode,
			Quantity = @Quantity,
			Amount = @Amount,
			Remark = @Remark,
			CreatedBy = @CreatedBy,
			UpdatedBy = @Updatedby,
			UpdatedOn = GETDATE(),
			IsActive = @IsActive
		WHERE SBillID  = @SBillID
	END
END



/****** Object:  StoredProcedure [dbo].[Idv_chetana_Save_Account_main]    Script Date: 07-Apr-2018 7:01:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================          
-- Author:  <Vivek Pandey>          
-- Create date: <07/Apr/2018>          
-- Description: <Description,,>          
-- ============================================= 

-- select * from  Idv_chetana_Account_main WHERE Idv_chetana_Account_main.AC_CODE='A01'

ALTER procedure [dbo].[Idv_chetana_Save_Account_main]
(
	@AutoID INT,
	@AC_CODE NVARCHAR(50),
	@AC_NAME NVARCHAR(200),
	@AC_GROUP nvarchar(50),
	@AC_ADD1 NVARCHAR(100),
	@AC_ADD2 NVARCHAR(100),
	@AC_ADD3 NVARCHAR(100),
	@TEL1 NVARCHAR(20),
	@TEL2 NVARCHAR(20),
	@TELR NVARCHAR(20),
	@CITY_CODE NVARCHAR(20),
	@PIN_CODE NVARCHAR(20),
	@STATE_CODE NVARCHAR(20),
	@COUNTRY NVARCHAR(20),
	@ZONE_CODE NVARCHAR(20),
	@BROKER NVARCHAR(20),
	@MEDIUM NVARCHAR(20),
	@BROK_PERC decimal(18,2),
	@PRIN_int NVARCHAR(20),
	@BLACKLIST NVARCHAR(1),
	@AC_TYPE NVARCHAR(20),
	@AC_ST_NO NVARCHAR(20),
	@AC_PA_NO NVARCHAR(20),
	@AC_CST_NO NVARCHAR(20),
	@AC_int_RAT decimal(18, 2),
	@AC_TDS_LIM decimal (18,2),
	@AC_TDS_RAT decimal(18,2),
	@AC_H15 BIT,
	@AC_DEPR_C decimal (18,2),
	@AC_DEPR_N decimal (18,2),
	@GST_NO NVARCHAR(20),
	@APPLICABLE_GST NVARCHAR(20),
	@TRANSPORT NVARCHAR(50),
	@PAYEE_BANK NVARCHAR(30),
	@CR_DAYS INT,
	@DISC_PREC decimal,
	@TAX_TYPE NVARCHAR(20),
	@AREA NVARCHAR(20),
	@SR_ORDER INT,
	@OPEN_BAL decimal(18,2),
	@PROFIT decimal (18,2),
	@REMUNA decimal (18,2),
	@CR_LIMIT decimal(18,2),
	@SP_DISC decimal (18,2),
	@EMAIL_NO NVARCHAR(20),
	@MOR_TIME NVARCHAR(20),
	@EVE_TIME NVARCHAR(20),
	@IN_CHARGE NVARCHAR(20),
	@CTYPE_CODE NVARCHAR(20),
	@L_O NVARCHAR(50),
	@FAM_CODE NVARCHAR(20),
	@CF_CODE NVARCHAR(20),
	@INSTRCTION NVARCHAR(20),
	@VIC_REMARK NVARCHAR(20),
	@DELETEREC NVARCHAR(20),
	@ACTIVE BIT,
	@INSTRUCT2 NVARCHAR(20),
	@INSTRUCT3 NVARCHAR(20),
	@INSTRUCT4 NVARCHAR(20),
	@CreatedBy nvarchar(50),
	@UpdatedBy nvarchar(50)
)
AS        
declare @GROUP int        
set @GROUP = (select [GROUP] from IDV_Chetana_sub_group where GR_HEAD = @AC_GROUP)

BEGIN
	IF NOT EXISTS (SELECT AutoID FROM Idv_chetana_Account_main WHERE AutoID = @AutoID)
	BEGIN
		INSERT INTO Idv_chetana_Account_main
		(
			AC_CODE,
			AC_NAME,
			AC_GROUP,
			AC_ADD1,
			AC_ADD2,
			AC_ADD3,
			TEL1,
			TEL2,
			TELR,
			CITY_CODE,
			PIN_CODE,
			COUNTRY,
			STATE_CODE,
			ZONE_CODE,
			BROKER,
			MEDIUM,
			BROK_PERC,
			PRIN_int,
			BLACKLIST,
			AC_TYPE,
			AC_ST_NO,
			AC_PA_NO,
			AC_CST_NO,
			AC_int_RAT,
			AC_TDS_LIM,
			AC_TDS_RAT,
			AC_H15,
			AC_DEPR_C,
			AC_DEPR_N,
			GST_NO,
			APPLICABLE_GST,
			TRANSPORT,
			PAYEE_BANK,
			CR_DAYS,
			DISC_PREC,
			TAX_TYPE,
			AREA,
			SR_ORDER,
			OPEN_BAL,
			PROFIT,
			REMUNA,
			CR_LIMIT,
			SP_DISC,
			EMAIL_NO,
			MOR_TIME,
			EVE_TIME,
			IN_CHARGE,
			CTYPE_CODE,
			L_O,
			FAM_CODE,
			CF_CODE,
			INSTRCTION,
			VIC_REMARK,
			DELETEREC,
			ACTIVE,
			INSTRUCT2,
			INSTRUCT3,
			INSTRUCT4,
			CreatedBy,
			UpdatedBy
		)
		VALUES
		(
			@AC_CODE,
			@AC_NAME,
			@GROUP,
			@AC_ADD1,
			@AC_ADD2,
			@AC_ADD3,
			@TEL1,
			@TEL2,
			@TELR,
			@CITY_CODE,
			@PIN_CODE,
			@COUNTRY,
			@STATE_CODE,
			@ZONE_CODE,
			@BROKER,
			@MEDIUM,
			@BROK_PERC,
			@PRIN_int,
			@BLACKLIST,
			@AC_TYPE,
			@AC_ST_NO,
			@AC_PA_NO,
			@AC_CST_NO,
			@AC_int_RAT,
			@AC_TDS_LIM,
			@AC_TDS_RAT,
			@AC_H15,
			@AC_DEPR_C,
			@AC_DEPR_N,
			@GST_NO,
			@APPLICABLE_GST,
			@TRANSPORT,
			@PAYEE_BANK,
			@CR_DAYS,
			@DISC_PREC,
			@TAX_TYPE,
			@AREA,
			@SR_ORDER,
			@OPEN_BAL,
			@PROFIT,
			@REMUNA,
			@CR_LIMIT,
			@SP_DISC,
			@EMAIL_NO,
			@MOR_TIME,
			@EVE_TIME,
			@IN_CHARGE,
			@CTYPE_CODE,
			@L_O,
			@FAM_CODE,
			@CF_CODE,
			@INSTRCTION,
			@VIC_REMARK,
			@DELETEREC,
			@ACTIVE,
			@INSTRUCT2,
			@INSTRUCT3,
			@INSTRUCT4,
			@CreatedBy,
			@Updatedby
		)
	END 
	ELSE
	BEGIN
		UPDATE Idv_chetana_Account_main
		SET AC_NAME = @AC_NAME,
			AC_GROUP = @GROUP,
			AC_ADD1 = @AC_ADD1,
			AC_ADD2 = @AC_ADD2,
			AC_ADD3 = @AC_ADD3,
			TEL1 = @TEL1,
			TEL2 = @TEL2,
			TELR = @TELR,
			CITY_CODE = @CITY_CODE,
			PIN_CODE = @PIN_CODE,
			COUNTRY = @COUNTRY,
			STATE_CODE = @STATE_CODE,
			ZONE_CODE = @ZONE_CODE,
			BROKER = @BROKER,
			MEDIUM = @MEDIUM,
			BROK_PERC = @BROK_PERC,
			PRIN_int = @PRIN_int,
			BLACKLIST = @BLACKLIST,
			AC_TYPE = @AC_TYPE,
			AC_ST_NO = @AC_ST_NO,
			AC_PA_NO = @AC_PA_NO,
			AC_CST_NO = @AC_CST_NO,
			AC_int_RAT = @AC_int_RAT,
			AC_TDS_LIM = @AC_TDS_LIM,
			AC_TDS_RAT = @AC_TDS_RAT,
			AC_H15 = @AC_H15,
			AC_DEPR_C = @AC_DEPR_C,
			AC_DEPR_N = @AC_DEPR_N,
			GST_NO = @GST_NO,
			APPLICABLE_GST = @APPLICABLE_GST,
			TRANSPORT = @TRANSPORT,
			PAYEE_BANK = @PAYEE_BANK,
			CR_DAYS = @CR_DAYS,
			DISC_PREC = @DISC_PREC,
			TAX_TYPE = @TAX_TYPE,
			AREA = @AREA,
			SR_ORDER = @SR_ORDER,
			OPEN_BAL = @OPEN_BAL,
			PROFIT = @PROFIT,
			REMUNA = @REMUNA,
			CR_LIMIT = @CR_LIMIT,
			SP_DISC = @SP_DISC,
			EMAIL_NO = @EMAIL_NO,
			MOR_TIME = @MOR_TIME,
			EVE_TIME = @EVE_TIME,
			IN_CHARGE = @IN_CHARGE,
			CTYPE_CODE = @CTYPE_CODE,
			L_O = @L_O,
			FAM_CODE = @FAM_CODE,
			CF_CODE = @CF_CODE,
			INSTRCTION = @INSTRCTION,
			VIC_REMARK = @VIC_REMARK,
			DELETEREC = @DELETEREC,
			ACTIVE = @ACTIVE,
			INSTRUCT2 = @INSTRUCT2,
			INSTRUCT3 = @INSTRUCT3,
			INSTRUCT4 = @INSTRUCT4,
			CreatedBy = @CreatedBy,
			UpdatedBy = @Updatedby,      
			UpdatedOn = GETDATE()
		WHERE AutoID  = @AutoID
	END
END



/****** Object:  StoredProcedure [dbo].[Idv_Chetana_Get_Account_main]    Script Date: 07-Apr-2018 7:01:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Vivek Pandey>          
-- Create date: <07/Apr/2018>          
-- Description: <Description,,>          
-- =============================================
ALTER procedure [dbo].[Idv_Chetana_Get_Account_main]
(
	@AcCode nvarchar(20)
)
as
begin
	declare @Delimiter nvarchar(50)
	declare @List nvarchar(50)
	declare @LenString int
      
	set @Delimiter = '#'
	set @List = @AcCode

	SELECT @LenString = (CASE charindex( @Delimiter, @List) WHEN 0 THEN len(@List) ELSE (charindex(@Delimiter, @List) -1) END)
	
	SELECT @List = (CASE (len(@List) - @LenString) WHEN 0 THEN '' ELSE right(@List, len(@List) - @LenString - 1) END)

	if(@List = 'b')
	begin
		SELECT	@AcCode = (LEFT(@AcCode, len(@AcCode) - LEN(right(@AcCode, len(@AcCode) -
				(CASE charindex(@Delimiter, @AcCode) WHEN 0 THEN len(@AcCode) ELSE (charindex(@Delimiter, @AcCode) -1) END) - 1)) -1))
               
		SELECT *, IDV_Chetana_sub_group.GR_HEAD  
		FROM dbo.Idv_chetana_Account_main
		inner join IDV_Chetana_sub_group
			ON IDV_Chetana_sub_group.[GROUP] = Idv_chetana_Account_main.AC_GROUP
		WHERE Idv_chetana_Account_main.BROKER = @AcCode
	end
	else
	begin
		SELECT *, IDV_Chetana_sub_group.GR_HEAD
		FROM dbo.Idv_chetana_Account_main
		inner join IDV_Chetana_sub_group
			ON IDV_Chetana_sub_group.[GROUP] = Idv_chetana_Account_main.AC_GROUP
		WHERE Idv_chetana_Account_main.AC_CODE = @AcCode
	end
end