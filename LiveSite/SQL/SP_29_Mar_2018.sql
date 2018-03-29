-- Alter Table Script

alter table Idv_chetana_targetwise_yearly_commission add SDZoneid int
alter table Idv_chetana_targetwise_yearly_commission add sdzonepercent money


-- Alter Store Procedure

/****** Object:  StoredProcedure [dbo].[Idv_Chetana_Report_Commission]    Script Date: 29-Mar-2018 5:22:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec Idv_Chetana_Report_Commission @CustID=0,@FromDate=N'04/01/2016',@ToDate=N'03/31/2018',@FY=0,@Superzone=0,@Zone=0,@CustCode=NULL


          
ALTER procedure [dbo].[Idv_Chetana_Report_Commission]                                                            
  (                                                            
    @CustID int = 0,                                                            
    @FromDate nvarchar(30),                                                            
    @ToDate nvarchar(30)  ,                                                        
    @FY int = 0  ,                                                      
    @Superzone int =0 ,                                                        
    @Zone int = 0   ,                                      
    @CustCode nvarchar(50)= null ,                        
    @Amount money = 0,                        
    @Flags char = 'c'                        
   )                                                            
AS             
            
Begin  
set nocount on;
          
DECLARE @fromyear nvarchar(10)                                                            
DECLARE @toyear nvarchar(10)                
Declare @TotalAmount money            
Declare @TargetAmt money            
Declare @TotalPer money

	
	-- Comment SET @InvoiceDate  = '11/30/2016'
	--Also Remove 11/30/2016 from Exec statement below in the procedure 
	--DECLARE @InvoiceDate datetime

	-- Priyanka Mam Tolk To Comment Invoice Date ( 23/08/2017 )
	--SET @InvoiceDate  = '11/30/2016'
	-- SET @InvoiceDate   = @ToDate 
------------------------------------ExtraZoneCode To Get Id Zone Master----------------------------------------
--DECLARE @ExtrZoneCodeId	int
--		IF @Zone <> 0
--	BEGIN
--			SELECT @ExtrZoneCodeId=ZM.ZoneID FROM Idv_Chetana_ZoneMaster ZM
--			INNER JOIN Idv_Chetana_DC_Master DM ON ZM.ZoneCode=DM.ExtraZoneCode WHERE ZM.ZoneID=@Zone
--	END
----------------------------------------------End---------------------------------------------------------------            
	SELECT @fromyear = [FromYear] , @toyear =[ToYear] FROM Idv_Chetana_FinancialYear_Master                                                            
	WHERE yearAutoId= @FY                
            
	select 
	 @TargetAmt = TD.TargetAmt
	from             
	 Idv_Chetana_Target_Details TD             
	 inner join Idv_Chetana_Target_Master TM on            
	 TD.TargetId = TM.TargetPersonId            
	 inner join Idv_Chetana_ZoneMaster ZM on             
	 ZM.ZoneID = TD.TargetId             
	Where             
	 TD.TargetPersonId = @Zone            
	 and TD.FinancialYear=@FY            
	 and             
	 TM.FromYear = @fromyear            
	 and             
	 TM.ToYear = @toyear            
             
 	create table #tempRec                                                          
  (                                                          
   Autoid int ,                                                          
   OpeningBalance money,                                                       
   ReceivedAmount money,                                                          
   BillAmount money,                                                
   CNAmt      money,                                                        
   CustID int,                                                   
   CustCode   nvarchar(30),                                                       
   CustName nvarchar(400),                                                          
   Phone1 nvarchar(50),            
   keyperson nvarchar(50),                                                   
   Name nvarchar(50),                                                    
   AreaName nvarchar(50),                                                    
   SuperZoneName nvarchar(200)  ,                              
   FromDate Datetime,                              
   ToDate Datetime,            
   Zone nvarchar(50) ,           
   ZoneCode nvarchar(50),
     
   Disc money,            
   AddDisc money  ,        
   CreditAmount money   ,  
   Zoneid int,        
   SuperZoneid int   ,        
   TargetAmount money,        
   TargetPerc money        
  )               
    
  if(isnull(@TargetAmt,0) > 0 )            
  begin           
	  insert into #tempRec  (OpeningBalance,BillAmount,CreditAmount, CNAmt,CustID,CustCode,CustName,SuperZoneName,Zone,ZoneCode)        
	  -- Comment Talk To Priyanka Mam 23/08/2017  
		  --exec Idv_Chetana_Customer_Summary_Report 0, @FromDate,@ToDate ,@FY ,@Superzone ,@Zone,null,0,'c' ,'commission!11/30/2016'   
		  exec Idv_Chetana_Customer_Summary_Report 0, @FromDate,@ToDate ,@FY ,@Superzone ,@Zone,null,0,'c' ,'commission'   

	 ----------------------------------------------------------------------------------------------------------            
	  update #tempRec set fromdate = Convert(datetime,@FromDate), ToDate = Convert(datetime,@ToDate)        
	  --  print 'hello'
	  --select * from #tempRec
  end          
  
-------------------------Collection Amount-------------------------------------------------------------------          
 update #tempRec set ReceivedAmount = isnull(ReceivedAmount,0) + isnull(a.Amount,0) from         
 (        
  select                                               
    sum(BR.Amount) as Amount , BR.AccountCode                                   
            
   from                             
    Idv_Chetana_Bank_Receipt BR inner join                                               
    Idv_Chetana_CustomerMaster CM on BR.AccountCode = CM.CustCode and CM.IsActive = 1                                               
   where                                            
    BR.Isactive = 1                                               
    and BR.DocumentDate between @FromDate and @Todate                                               
    and  @Zone =  CM.ZoneID        
    group by BR.AccountCode                           
  )a         
  where a.AccountCode = #tempRec.CustCode        
          
  update #tempRec set ReceivedAmount = isnull(ReceivedAmount,0) + isnull(a.Amount,0)         
  from         
 (        
   SELECT                                    
    sum(Amount)as Amount,  CM.CustCode                         
                  
  FROM                                                                           
    Idv_Chetana_Cheque_Cash_Deposite_Details                                                 
    Inner Join Idv_Chetana_LedgerDetails On                                                                                 
    Idv_Chetana_Cheque_Cash_Deposite_Details.CQ_ID = Idv_Chetana_LedgerDetails.otherId                                                                                    
    inner join Idv_Chetana_CustomerMaster CM on                                                            
    Idv_Chetana_LedgerDetails.Particulars =  CM.CustID                                   
    left outer join Idv_Chetana_ZoneMaster on                         
    CM.ZoneId = Idv_Chetana_ZoneMaster.ZoneiD                                           
  WHERE                          
    @Zone =  CM.ZoneID             
    and                                                                        
    Idv_Chetana_LedgerDetails.remark='Payment'                                                               
    and Idv_Chetana_Cheque_Cash_Deposite_Details.IsActive = 1                                                                 
    AND                                                                          
    DepositDate is not null  AND  CreditAmount  <> 0                                        
    AND                                                                          
    convert(datetime,convert(nvarchar(20),DepositDate),103) between @fromDate and  @toDate                                        
    group by CM.CustCode        
  )a         
  where a.CustCode = #tempRec.CustCode        
        
 update #tempRec set ReceivedAmount = isnull(ReceivedAmount,0) + isnull(a.Amount,0)         
  from         
 (        
 SELECT                                      
   sum(Amount) as Amount,  CM.CustCode                                    
                                     
  FROM                                                                           
   Idv_Chetana_Cheque_Cash_Deposite_Details                             
   Inner Join Idv_Chetana_LedgerDetails On                                                                                 
   Idv_Chetana_Cheque_Cash_Deposite_Details.CQ_ID = Idv_Chetana_LedgerDetails.otherId                               
   inner join Idv_Chetana_CustomerMaster CM on                                                            
   Idv_Chetana_LedgerDetails.Particulars =  CM.CustID                                   
   inner join Idv_Chetana_ZoneMaster on                                     
   CM.ZoneId = Idv_Chetana_ZoneMaster.ZoneiD                                         
  WHERE                        
     @Zone =  CM.ZoneID                
   and                                                                  
   Idv_Chetana_LedgerDetails.remark like '%bounce%'                                   
   AND  CreditAmount  <> 0                                                                  
   AND  (LedgerDate  between @fromDate and  @toDate)                                          
   group by  CM.CustCode                                          
   )a         
  where a.CustCode = #tempRec.CustCode        
         
 update #tempRec set ReceivedAmount = isnull(ReceivedAmount,0) - isnull(a.Amount,0) from         
 (        
  select                                               
    sum(BR.Amount) as Amount , BR.AccountCode                                   
            
   from                             
    Idv_Chetana_Bank_Payment BR inner join                                               
    Idv_Chetana_CustomerMaster CM on BR.AccountCode = CM.CustCode and CM.IsActive = 1                                               
   where                                            
    BR.Isactive = 1                                               
    and BR.DocumentDate between @FromDate and @Todate                                               
    and  @Zone =  CM.ZoneID        
    group by BR.AccountCode                           
  )a         
  where a.AccountCode = #tempRec.CustCode        
---------------------------------------------------------------------------------------------------------------          
             
  update #tempRec set OpeningBalance = a.ob from (          
   select (ISNULL(DebitAmt,0)-ISNULL(CreditAmt,0)) as ob, Acount_code  from Idv_Chetana_Opening_Balance           
   where From_Year =@fromyear  and To_Year = @toyear )a          
   where #tempRec.CustCode = a.Acount_code          
-------------------------------------------------------------------------          
            
 update #tempRec set AddDisc = isnull(a.AdditinalDis ,0) from (            
select AdditinalDis, CM.CustCode            
from Idv_Chetana_CustomerDetails CD inner join Idv_Chetana_CustomerMaster CM           
on CM.CustID = CD.CustID and CM.IsActive = 1 --and CD.IsActive = 1          
where Cm.ZoneID = @Zone           
)a          
where a.CustCode =#tempRec.CustCode            
          
-------------------------------------------------------------------------------------          
update #tempRec set Disc = isnull(a.Disc ,0) from(      
 SELECT                                                 
        max(DAI.Discount) as Disc ,            
        CM.CustCode            
        FROM                                 
        Idv_Chetana_LedgerDetails LD                     
        inner join #tempRec CM             
        ON LD.Particulars = CM.CustID           
        inner join Idv_Chetana_DC_Actual_InvoiceDetails DAI            
        on convert(nvarchar,LD.otherId) = convert(nvarchar,DAI.SubDocId)            
        where                                 
        LD.LedgerDate  between @FromDate and @ToDate                                                              
        --LD.LedgerDate  between @FromDate and @InvoiceDate
                                                               
       and             
            (LD.remark like '%fright%' or  LD.remark like 'test')                                                       
        and             
        LD.DebitAmount <> 0  and DAI.Discount < 100            
        
and DAI.financialyearfrom = @fromyear        
        --and CM.isactive =1 and CM.Isdeleted = 0            
        group by CM.CustCode            
 )a          
where a.CustCode =#tempRec.CustCode            
------------------------------------------------------------------------------------------------------           
           
update #tempRec set Disc = 0  where  Disc is null           
update #tempRec set AddDisc = 0  where  AddDisc is null         
update #tempRec set ReceivedAmount = 0  where  ReceivedAmount is null                     
 -- select * from #tempRec          
  ---------------------------------------------------------------------------------------------------            
  create table #tempRec1                                  
  (                                                          
   Autoid int ,                                                          
   OpeningBalance money,                                                       
   ReceivedAmount money,                                                          
   BillAmount money,                                                
   CNAmt      money,                                                      
   CustID int,                                                   
   CustCode   nvarchar(30),                                                       
   CustName nvarchar(400),                                                          
   Phone1 nvarchar(50),            
   keyperson nvarchar(50),                                                   
   Name nvarchar(50),                                                    
   AreaName nvarchar(50),                           
   SuperZoneName nvarchar(200)  ,                              
   FromDate Datetime,                              
   ToDate Datetime,            
   Zone nvarchar(50),           
    Disc1 money,            
   AddDisc1 money ,             
   Disc money,            
   AddDisc money             
               
  )              
            
  ---------------------------------------------------------------------------------------------------              
	 update #tempRec set TargetAmount = k.targetamt,        
	TargetPerc = k.targetpercent        
	from         
	(select  min(TK.TargetAmt) as targetamt,        
	sum(        
	case when isnull(TK.TargetAmt,0) = 0 or isnull(TK.TargetAmt,0) = 1  then 0.00 else         
	((x.BillAmount -x.CNAmt) *100) / isnull(TK.TargetAmt,0)         
	 end        
	)as targetpercent,x.Zoneid as zid from  #tempRec x        
	left outer join (select TD.TargetPersonId,TD.TargetAmt,TD.TargetId from Idv_Chetana_Target_Details TD                   
	  inner join Idv_Chetana_Target_Master TM on                  
	  TD.TargetId = TM.TargetPersonId where TD.financialyear = @FY and TM.FromYear = @fromyear                  
	  and TM.ToYear = @toyear) TK  on TK.TargetPersonId = x.Zoneid        
	  group by x.Zoneid) k where #tempRec.Zoneid = k.zid        
-----------------------------------------------------------------------------------------------
  declare @totalsale money ,@totalcn money             
             
	select  
			@totalsale = SUM(round(LD.DebitAmount,0))                     
	from 
			Idv_Chetana_LedgerDetails LD                                                       
			inner join Idv_Chetana_CustomerMaster CM ON                                                      
			LD.Particulars = CM.CustID                     
	where                                                    
			LD.LedgerDate between @fromDate and @ToDate                                                        
		   --LD.LedgerDate between @fromDate and @InvoiceDate                                                        
			and (LD.remark like '%fright%' or  LD.remark like 'test')     and LD.DebitAmount <> 0                                  
			and @Zone = CM.ZoneID --case when  @Zone <> 0 then CM.ZoneID else CM.SuperZoneID end             
	 --   Group By CM.ZoneID            

	select  @totalcn = SUM(round(LD.CNAmt,0))                                                      
	   from Idv_Chetana_LedgerDetails LD                                                       
	   inner join Idv_Chetana_CustomerMaster CM ON                                                      
	   LD.Particulars = CM.CustID                                                     
	   where                                                    
	   LD.LedgerDate between @fromDate and @toDate                                                        
		and  LD.Remark = 'CN' and LD.CNAmt <> 0             
				  and @Zone= CM.ZoneID                    
	  select             
		  --@TotalAmount =  (sum(BillAmount) -sum(CNAmt)) - ((sum(OpeningBalance)+sum(BillAmount))- (sum(ReceivedAmount)+sum(CNAmt)))            
		  @TotalAmount =  (ISNULL(@totalsale,0) -isnull(@totalcn,0))            
	  from             
		#tempRec            
 
	 set @TotalPer = ((@TotalAmount*100)/@TargetAmt)            
	 update #tempRec set TargetPerc = @TotalPer
	--######################################################################################################             
     
 select discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, sdzoneid, superzoneid, zoneid, cnper
 into #tempzoneterms      
 from idv_Chetana_ZoneMaster CROSS JOIN          
    (           
    select discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, isnull(sdzoneid, 0) as sdzoneid, cnper     
    from Idv_chetana_targetwise_yearly_commission      
    where Fy = @FY and zoneid = 0 and superzoneid = 0          
    and isactive =1        
    ) AS fdur(discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, sdzoneid, cnper)  -- and zoneid not in(select distinct zoneid from  #YearlyDiscount  where Fy = @FY and isactive = 1) and        
        
 where idv_Chetana_ZoneMaster.ZoneID  = @zone
        
     
 insert into #tempzoneterms (discfromamt ,disctoamt ,targperfrom ,targperto,zoneprcent,superzoneprcent,sdzonepercent,sdzoneid,superzoneid, zoneid,cnper  )      
 select  discfromamt ,disctoamt ,targperfrom ,targperto,zoneprcent,superzoneprcent,sdzonepercent, sdzoneid,superzoneid, zoneid , cnper      
  from Idv_chetana_targetwise_yearly_commission where Fy = @FY and zoneid = @zone and superzoneid = @Superzone and isactive =1         
  
--################################################################################################################ 
 
       
  select tmp.*,          
  case when   
 (((tmp.CNAmt*100)/case when tmp.BillAmount = 0 then 1 else tmp.BillAmount end) > isnull(d.cnper, -1) )or  
 ((tmp.OpeningBalance - ReceivedAmount)>=0) or 
 ((ReceivedAmount)<=0) then 0 else 1 end as       
  IsCalculate ,          
             
   d.zoneprcent as Paise,
   d.superzoneprcent,
   d.sdzonepercent,
   @TotalAmount as TotalSale,
   @TargetAmt as [Target]
  from           
	  #tempRec tmp          
	  left outer join #tempzoneterms d on         
	   (@TotalPer between d.targperfrom and d.targperto)     
	  and     
	  ((tmp.Disc + tmp.AddDisc) between d.discfromamt and d.disctoamt)         
	 
  where 
		(OpeningBalance <> 0 or BillAmount <> 0 or ReceivedAmount <> 0 or CNAmt <> 0)            
  order by  CustCode       
      
        
  drop table #tempRec              
  drop table #tempRec1              
       set nocount off;       
 End 




USE [Chetana_New]
GO
/****** Object:  StoredProcedure [dbo].[Idv_Chetana_Save_Update_Comm]    Script Date: 29-Mar-2018 5:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Declare @File Xml='<Items><Id>101</Id><DisFrm>91</DisFrm><DisTo>100</DisTo><tarfrm>25</tarfrm><tarto>25</tarto><commz>0.80</commz><comms>0.20</comms><cnper>25.0000</cnper></Items>'  
--exec Idv_Chetana_Save_Update_Comm  10,188,5,@File,1                    
ALTER procedure [dbo].[Idv_Chetana_Save_Update_Comm]                    
(
	@SDzone int = 0,
	@Superzone int = 0,
	@Zone int = 0,
	@FY int,
	@xml XML,
	@flag int
)                    
As                    
begin
	DECLARE @TempDoc AS int;
	DECLARE @Szoneid int;
	DECLARE @zid int;
	DECLARE @count int;
      
	select @count = COUNT(*)
	from Idv_chetana_targetwise_yearly_commission
	where @SDzone != 0 and @Superzone != 0 and @Zone != 0
	and SDZoneid = @SDzone and Superzoneid = @Superzone and Zoneid = @Zone
        
	EXEC sp_xml_preparedocument @TempDoc OUTPUT, @xml                    
    
	SELECT AId, DiscFrm, DiscTo, TarFrm, TarTo, Commz, Comms, Commsdz, IsActive,CNPer into #tempdata                    
    FROM OPENXML(@TempDoc,'Root/Items')                    
    WITH                    
    (                    
		AId int 'Id',
		DiscFrm money 'DisFrm',
		DiscTo money 'DisTo',
		TarFrm money 'tarfrm',
		TarTo money 'tarto',
		Commz money 'commz',
		Comms money 'comms',
		Commsdz money 'commsdz',
		IsActive bit 'a',
		CNPer money 'cnper'
    )

    EXEC sp_xml_removedocument @TempDoc

	--------------------------Update Details ----------------------------
    
	select * from #tempdata
    
	IF @flag = 0 or @count > 0    
	BEGIN                  
		UPDATE Idv_chetana_targetwise_yearly_commission
		set discfromamt = t.DiscFrm,
			disctoamt = t.DiscTo,
			targperfrom = t.TarFrm,
			targperto = t.TarTo,
			zoneprcent = t.Commz,
			superzoneprcent = t.Comms,
			sdzonepercent = t.Commsdz,
			IsActive = t.IsActive ,
			CNPer = t.CNPer
		FROM (SELECT AId, DiscFrm, DiscTo, TarFrm, TarTo, Commz, Comms, Commsdz, #tempdata.IsActive, #tempdata.CNPer FROM #tempdata) as t
		inner join  Idv_chetana_targetwise_yearly_commission
			on Idv_chetana_targetwise_yearly_commission.AutoId = t.AId              
	END
-------------------------- Insert Details------------------------------------------                
	ELSE
           
	IF (@SDzone = 0 and @Superzone = 0 and @Zone = 0)  
	BEGIN
		DECLARE insert_cursor CURSOR FOR
		SELECT DISTINCT Superzoneid, Zoneid
		FROM Idv_chetana_targetwise_yearly_commission        
		WHERE Fy = @FY

		OPEN insert_cursor        
           
		IF(@@CURSOR_ROWS = 0)
		BEGIN
			INSERT INTO Idv_chetana_targetwise_yearly_commission
			(
				SDzoneid, Superzoneid, Zoneid, Fy, discfromamt, disctoamt, targperfrom, targperto, zoneprcent, superzoneprcent, sdzonepercent, IsActive, CNPer
			)
			SELECT @SDzone, @Superzone, @Zone, @FY, DiscFrm, DiscTo, TarFrm, TarTo, Commz, Comms, commsdz, IsActive, CNPer
			FROM #tempdata
		END
		ELSE
		BEGIN
			FETCH NEXT FROM insert_cursor INTO @Szoneid, @zid;
			
			WHILE @@FETCH_STATUS = 0        
			BEGIN        
				INSERT INTO Idv_chetana_targetwise_yearly_commission        
				(        
					Superzoneid,
					Zoneid,
					Fy,
					discfromamt,
					disctoamt,
					targperfrom,
					targperto,
					zoneprcent,
					superzoneprcent,
					sdzonepercent,
					IsActive,
					CNPer                   
				)                    
				SELECT @SDzone, @zid, @FY, DiscFrm, DiscTo, TarFrm, TarTo, Commz, Comms, Commsdz, IsActive, CNPer  
				FROM #tempdata              
          
				FETCH NEXT FROM insert_cursor INTO @Szoneid, @zid;
			END
		END
		
		CLOSE insert_cursor;
		DEALLOCATE insert_cursor;
  END
  ELSE
  BEGIN    
		INSERT INTO Idv_chetana_targetwise_yearly_commission        
		(
			SDzoneid,
			Superzoneid,
			Zoneid,
			Fy,
			discfromamt,
			disctoamt,
			targperfrom,
			targperto,
			zoneprcent,
			superzoneprcent,
			sdzonepercent,
			IsActive,
			CNPer  
		)

		SELECT @SDzone, @Superzone, @Zone, @FY, DiscFrm, DiscTo, TarFrm, TarTo, Commz, Comms, Commsdz, IsActive, CNPer  
		FROM #tempdata
	END

	drop table #tempdata
end




USE [Chetana_New]
GO
/****** Object:  StoredProcedure [dbo].[Idv_Chetana_Get_Global_Comm]    Script Date: 29-Mar-2018 5:41:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec Idv_Chetana_Get_Global_Comm 39,4,5            
ALTER procedure [dbo].[Idv_Chetana_Get_Global_Comm]             
(
	@SDZoneId int = 0,
	@Superzone int = 0,
	@Zone int = 0,
	@FY int,
	@Remark1 nvarchar(30) = null,
	@Remark2 nvarchar(30) = null,
	@Remark3 nvarchar(30) = null,
	@Remark4 nvarchar(30) = null
)            
AS            
BEGIN
-- select * from Idv_chetana_targetwise_yearly_commission
	SELECT AutoId, isnull(SDZoneid, 0) as SDZoneid, isnull(Superzoneid, 0) as Superzoneid, isnull(Zoneid, 0) as Zoneid, discfromamt, disctoamt, targperfrom, targperto,
			zoneprcent, superzoneprcent, sdzonepercent, CNPer, IsActive
	INTO #tempdata
	FROM Idv_chetana_targetwise_yearly_commission
	WHERE SDZoneid = (CASE WHEN ISNULL(@SDZoneId, 0) = 0 THEN SDZoneid ELSE ISNULL(@SDZoneId, 0) end)
	and Superzoneid = (CASE WHEN ISNULL(@Superzone, 0) = 0 THEN Superzoneid ELSE ISNULL(@Superzone, 0) end)
	and Zoneid = (CASE WHEN ISNULL(@Zone, 0) = 0 THEN Superzoneid ELSE ISNULL(@Zone, 0) end) and Fy = @FY

	select * from Idv_chetana_targetwise_yearly_commission
	where Superzoneid = 0 and Zoneid = 0 and Fy = @FY   
           
	/*SELECT AutoId, isnull(yc.Superzoneid, 0) as Superzoneid, isnull(yc.Zoneid, 0) as Zoneid, yc.discfromamt, yc.disctoamt, yc.targperfrom, yc.targperto,
			yc.zoneprcent, yc.superzoneprcent, yc.IsActive          
	FROM Idv_chetana_targetwise_yearly_commission  yc          
	where Superzoneid=0 and Zoneid=0 and IsActive=1          
	
	Union All

	select * from #tempdata t*/
             
	select * from #tempdata

	drop table #tempdata
END