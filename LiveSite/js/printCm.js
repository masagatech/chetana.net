function trim(stringToTrim) {
	return stringToTrim.replace(/^\s+|\s+$/g,"");
}
function setWValue(divId)
{
	var obj = document.getElementById(divId+'');
	var objParent = window.opener.document.getElementById(divId+'');
	
	if(obj && objParent)
	{
		obj.innerHTML = objParent.innerHTML;
		if (divId=='change')
		{
			/*up/down indication*/
			$('#change').removeClass('up');
			$('#change').removeClass('down');
			if (obj.innerHTML<0)
			{				
				$('#change').addClass('down');
				$('#pChange').css({'color' : 'red'});
			}
			else
			{
				$('#change').addClass('up');
				$('#pChange').css({'color' : 'green'});
			}		
		}
		//alert(objParent.innerHTML);
	}
}
function populatePrintDivs()
{	
	/*last Update Date*/
	setWValue('LastUpdatedDiv');	
	setWValue('industry');	
	/*basic info*/
	setWValue("symbol" );				
	setWValue("name");

	setWValue("lastPrice" );
	setWValue('change');
	setWValue("pChange");
	setWValue('previousClose');
	setWValue('open');
	setWValue('dayHigh');
	setWValue('dayLow');
	
	setWValue("tradedValue" );				
	setWValue("tradedVolume" );
	setWValue("marketCapitalization");
	setWValue("vwap");
	setWValue("beta");
	setWValue("faceValue");
	setWValue("bookValue");
	setWValue("eps");
	setWValue("payoutRatio");
	setWValue("dividentCover");
	setWValue("peRatio");
	setWValue("corporateAction");
	setWValue("quantityTraded");
	setWValue("deliveryQuantity");
	setWValue("deliveryToTradedQuantity");
	setWValue("securityVar");
	setWValue("varMargin");
	setWValue("SecwiseDT");
	setWValue("applicableMargin");
	setWValue("extremeLossMargin");
	setWValue('companyName');	
	setWValue('series');
	setWValue('isinCode');	
	setWValue('closePrice');	
	setWValue('high52');
	setWValue('low52');
	setWValue("dividentYield");		
	setWValue("priceBand");
	
	/*Order book*/
	setWValue('buyQuantity1');
	setWValue('buyQuantity2');
	setWValue('buyQuantity3');
	setWValue('buyQuantity4');
	setWValue('buyQuantity5');
	setWValue('buyPrice1');
	setWValue('buyPrice2');
	setWValue('buyPrice3');
	setWValue('buyPrice4');
	setWValue('buyPrice5');		
	setWValue('sellQuantity1');
	setWValue('sellQuantity2');
	setWValue('sellQuantity3');
	setWValue('sellQuantity4');
	setWValue('sellQuantity5');
	setWValue('sellPrice1');
	setWValue('sellPrice2');
	setWValue('sellPrice3');
	setWValue('sellPrice4');
	setWValue('sellPrice5');
	setWValue('totalBuyQuantity');
	setWValue('totalSellQuantity');
	
}
