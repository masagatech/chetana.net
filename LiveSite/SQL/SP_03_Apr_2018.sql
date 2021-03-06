USE [Chetana_New]
GO
/****** Object:  StoredProcedure [dbo].[Idv_Chetana_Report_Commission_1]    Script Date: 03-Apr-2018 11:32:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- exec Idv_Chetana_Report_Commission_1 @CustID=0,@FromDate=N'04/01/2016',@ToDate=N'03/31/2017',@FY=7,@Superzone=39,@Zone=0,@CustCode=NULL

ALTER procedure [dbo].[Idv_Chetana_Report_Commission_1]                                                                  
(
	@CustID int = 0,
	@FromDate nvarchar(30),
	@ToDate nvarchar(30),
	@FY int = 0,
	@Superzone int = 0,
	@Zone int = 0,
	@CustCode nvarchar(50) = null,
	@Amount money = 0,
	@Flags char = 'c'
)                                                                  
AS                   
                  
Begin         
--######################################################################################################             
                 
	DECLARE @fromyear nvarchar(10)
	DECLARE @toyear nvarchar(10)
	Declare @TotalAmount money
	Declare @TargetAmt money
	Declare @TotalPer money

	DECLARE @InvoiceDate datetime
	SET @InvoiceDate  = '11/30/2016'

	SELECT @fromyear = [FromYear], @toyear = [ToYear]
	FROM Idv_Chetana_FinancialYear_Master                                                                  
	WHERE yearAutoId = @FY                      

	--######################################################################################################

	Declare @id int
                
	if(@Zone <> 0)          
	begin                                                               
		SET @CustCode =(Select top 1  CustCode from Idv_Chetana_CustomerMaster Where  CustID =  @CustID and IsActive = 1 and IsDeleted = 0)
		SET @CustCode = isnull(@CustCode,'')
		SET @id = @Zone

		if(@CustCode = '')
		begin
			set @CustCode = '1'
		end
	end
	else if (@Superzone <> 0)
	begin                                                              
		set @id = @Superzone
		set @CustCode = '2'
	end
	else if(@CustCode is null)
	begin
		set @CustCode = 'all'
	end

	declare @fromdatr datetime                                                                
	declare @todatr datetime                                                                
	set @fromdatr = (Convert(datetime,('1-apr-' + (Convert(nvarchar(10),@fromyear))),101))                           
	set @todatr = Convert(datetime,@FromDate) - 1          
           
	create table #tempsummaryOp
	(
		CustCode nvarchar(50),
		Os money,
		BalDate datetime
	)
	insert into #tempsummaryOp                                                
	exec Idv_Chetana_Customer_Outstanding_Flag @CustCode, @id, -999999999, @fromdatr, @todatr, @FY

	--######################################################################################################
	
	create table #tempRec           
	(
		Autoid int,
		OpeningBalance money,
		ReceivedAmount money,
		BillAmount money,
		CNAmt money,
		CustID int,
		CustCode nvarchar(30),
		CustName nvarchar(400),
		Phone1 nvarchar(50),
		keyperson nvarchar(50),
		Name nvarchar(50),
		AreaName nvarchar(50),
		SuperZoneName nvarchar(200),
		FromDate Datetime,
		ToDate Datetime,
		ZoneCode nvarchar(30),
		Zone nvarchar(50),
		Disc money,
		AddDisc money,
		Zoneid int,
		SuperZoneid int,
		TargetAmount money,
		TargetPerc money
	)
    
	insert into #tempRec
	(
		OpeningBalance, BillAmount, ReceivedAmount, CNAmt, CustID, CustCode, CustName, SuperZoneName, Zoneid, SuperZoneid, Zone, ZoneCode
	)
	exec Idv_Chetana_Customer_Summary_Report 0, @FromDate, @ToDate, @FY, @Superzone, @Zone, null, 0, 'c', 'commissionsm!11/30/2016', null, 'l'
          
	--######################################################################################################
	
	update #tempRec set fromdate = Convert(datetime, @FromDate), ToDate = Convert(datetime, @ToDate)
	
	--######################################################################################################

	update #tempRec set AddDisc = isnull(a.AdditinalDis, 0) from
	(
		select AdditinalDis, CM.CustCode                  
		from Idv_Chetana_CustomerDetails CD
		inner join Idv_Chetana_CustomerMaster CM                 
			on CM.CustID = CD.CustID and CM.IsActive = 1
			and @Zone = case when @Zone = 0 then 0 else CM.ZoneID END
			and  @Superzone = case when @Superzone = 0 then 0 else CM.SuperZoneID END            
	) a                
	where a.CustCode = #tempRec.CustCode

	--######################################################################################################                    

	update #tempRec set ReceivedAmount = isnull(ReceivedAmount,0) - isnull(a.Amount,0) from               
	(              
		select sum(BR.Amount) as Amount, BR.AccountCode
		from Idv_Chetana_Bank_Payment BR
		inner join Idv_Chetana_CustomerMaster CM
			on BR.AccountCode = CM.CustCode and CM.IsActive = 1
		where BR.Isactive = 1 and BR.DocumentDate between @FromDate and @Todate and @Zone = case when @Zone = 0 then 0 else CM.ZoneID END
		and  @Superzone = case when @Superzone = 0 then 0 else CM.SuperZoneID END
		group by BR.AccountCode
	) a
	where a.AccountCode = #tempRec.CustCode

	--######################################################################################################
	                
	update #tempRec set Disc = isnull(a.Disc ,0) from
	(
		SELECT max(DAI.Discount) as Disc, CM.CustCode
		FROM Idv_Chetana_LedgerDetails LD
		inner join #tempRec CM
			ON LD.Particulars = CM.CustID
		inner join Idv_Chetana_DC_Actual_InvoiceDetails DAI
			ON convert(nvarchar,LD.otherId) = convert(nvarchar,DAI.SubDocId)
		where LD.LedgerDate  between @FromDate and @InvoiceDate and (LD.remark like '%fright%' or LD.remark like 'test')
		and LD.DebitAmount <> 0  and DAI.Discount < 100 and DAI.financialyearfrom = @fromyear
        group by CM.CustCode
	) a
	where a.CustCode = #tempRec.CustCode

	--######################################################################################################
	
	update #tempRec set Disc = 0  where  Disc is null
	update #tempRec set AddDisc = 0  where  AddDisc is null
	update #tempRec set ReceivedAmount = 0  where  ReceivedAmount is null

	--######################################################################################################
     
	select discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, superzoneid, zoneid,cnper  into #tempzoneterms      
	from idv_Chetana_ZoneMaster
	CROSS JOIN	(           
					select discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, cnper
					from Idv_chetana_targetwise_yearly_commission
					where Fy = @FY and zoneid = 0 and superzoneid = 0 and isactive = 1
				) AS fdur(discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, cnper)
	where idv_Chetana_ZoneMaster.ZoneID not in (select distinct zoneid from Idv_chetana_targetwise_yearly_commission  where Fy = @FY and isactive = 1)

	insert into #tempzoneterms
	(
		discfromamt, disctoamt, targperfrom , targperto, zoneprcent, superzoneprcent, sdzonepercent, superzoneid, zoneid, cnper
	)      
	select discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, superzoneid, zoneid, cnper      
	from Idv_chetana_targetwise_yearly_commission
	where Fy = @FY and zoneid <> 0 and superzoneid <> 0 and isactive = 1
        
	update #tempRec set TargetAmount = k.targetamt,
	TargetPerc = k.targetpercent
	from (
			select	min(TK.TargetAmt) as targetamt,
					sum(case when isnull(TK.TargetAmt, 0) = 0 or isnull(TK.TargetAmt, 0) = 1  then 0.00 else ((x.BillAmount -x.CNAmt) * 100) / isnull(TK.TargetAmt, 0) end
		 ) as targetpercent, x.Zoneid as zid from #tempRec x
	left outer join (
						select TD.TargetPersonId, TD.TargetAmt, TD.TargetId
						from Idv_Chetana_Target_Details TD
						inner join Idv_Chetana_Target_Master TM
							on TD.TargetId = TM.TargetPersonId
						where TD.financialyear = @FY and TM.FromYear = @fromyear and TM.ToYear = @toyear) TK  on TK.TargetPersonId = x.Zoneid
						group by x.Zoneid) k
	where #tempRec.Zoneid = k.zid

	select	CustID, CustCode, CustName, SuperZoneName, Zone, ZoneCode, OpeningBalance, ReceivedAmount, BillAmount - CNAmt as TSalesAmt, AddDisc + Disc as TotalDisc,
			d.zoneprcent, d.superzoneprcent, d.sdzonepercent, t.Zoneid, t.SuperZoneid, t.TargetPerc, t.TargetAmount, 
			case when ((CNAmt * 100 / (case when BillAmount = 0 then 1 else BillAmount end) > isnull(d.cnper, -1))
				or ((OpeningBalance - ReceivedAmount) >= 0) or (ReceivedAmount <= 0)) then 0 else 1 end as IsCalculate    
	INTO #temp_final_calc
	FROM #tempRec  t
	left outer join #tempzoneterms d
		on (t.TargetPerc between d.targperfrom and d.targperto) and ((t.Disc + t.AddDisc) between d.discfromamt and d.disctoamt)
		and t.Zoneid = d.zoneid and t.SuperZoneid = d.superzoneid
	order by SuperZoneName, Zone, CustName

	select	SuperZoneNAme, Zone, ZoneCode, TargetPerc, TargetAmount, Zoneid, SuperZoneid, SUM(TSalesAmt) As SalesAmt,
			sum(case when IsCalCulate = 1 then  case when OpeningBalance < 0 then ReceivedAmount + abs(OpeningBalance)
				else ReceivedAmount - OpeningBalance end * zonePrcent / 100 else 0 end) as ZonePerAmt,
			sum(case when IsCalCulate = 1 then  case when OpeningBalance < 0 then ReceivedAmount + abs(OpeningBalance)
				else ReceivedAmount - OpeningBalance end * superzoneprcent / 100 else 0 end) as SuperZonePerAmt,
			sum(case when IsCalCulate = 1 then  case when OpeningBalance < 0 then ReceivedAmount + abs(OpeningBalance)
				else ReceivedAmount - OpeningBalance end * sdzonepercent / 100 else 0 end) as SDZonePerAmt
	from #temp_final_calc
	group by SuperZoneNAme, Zone, ZoneCode, TargetPerc, TargetAmount, Zoneid, SuperZoneid
	
	select * from #temp_final_calc
	
	drop table #tempRec
END