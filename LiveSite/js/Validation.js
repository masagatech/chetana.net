//pankaj -- Message  For pending DC to  enter number not more than pass value
function MaxordNum(id,max)
{   
    var value = 0;
if(id.value != "")
{
    value = id.value;
}
    var maxl = max;
     if(value > max)
     {
        sloder('Entered Quantity Exceeds Order Qty..')
        alert("Entered Quantity Exceeds Order Qty.");
        //id.value = max;
        //id.focus();
     } 
     else
     {
       cloder()
     }
}
//pankaj -- Message to enter number not more than pass value
function MsgMaxNumber(id,max)
{   
    var value = 0;
if(id.value != "")
{
    value = id.value;
}
    var maxl = max;
     if(value > max)
     {
        sloder('Entered Return Quantity Exceeds Order Qty..')
        alert("Entered Return Quantity Exceeds Order Qty.");
        //id.value = max;
        //id.focus();
     } 
     else
     {
       cloder()
     }
}

//Rajnish -- Message to enter Paid Should less or equal then Total Amount
function MsgMaxAmount(id,max)
{   
    var value = 0;
if(id.value != "")
{
    value = id.value;
}
    var maxl = max;
     if(value > max)
     {
        sloder('Paid Amount Should be less then or equal to Total Amount.')
        alert("Paid Amount Should be less then or equal to Total Amount.");
        //id.value = max;
        //id.focus();
     } 
     else
     {
       cloder()
     }
}

//Rajnish -- Message Voucher Date should be greater than or equal to Payment Date
function MsgMaxPaymentDate(id,max)
{   
    var value = 0;
if(id.value != "")
{
    value = id.value;
}
    var maxl = max;
     if(value < max)
     {
        sloder('Voucher Date should be greater than or equal to Payment Date.')
        alert("Voucher Date should be greater than or equal to Payment Date.");
        //id.value = max;
        //id.focus();
     } 
     else
     {
       cloder()
     }
}

//validate to enter number not more than pass value
function SetMaxNumber(id,max)
{   

    var value = 0;
if(id.value != "")
{
    value = id.value;
}

 
    var maxl = max;
     if(value > max)
     {
        sloder('Invalid Qty..')
        alert("Invalid Qty.");
        id.value = max;
        id.focus();
     } 
     else
     {
       cloder()
     }
}


//for no zero 
function nozeroblank(id,blr)
{

if(id.value=="0")
    {
        id.value="1";
    }
    if(id.value=="")
    {
    if(blr=="bl")
    {
    id.value="1";
    }
    }
    if(id.value > 1000)
    {
    sloder('Check Qty');
    }
    else
    {
    cloder();
    }
}


//validate to enter only numeric value
function CheckNumeric(evt)
{
       var charCode = (evt.which) ? evt.which : event.keyCode
   if (charCode > 31 && (charCode < 48 || charCode > 57))
   {  

    document.getElementById('loding').style.display='block';
       document.getElementById('loder').innerHTML='only numeric value accept';
    
      return false;
    
}else
{
  document.getElementById('loding').style.display='none';
   return true;
 }   
}
function CheckNumericWithDot(evt)
{
       var charCode = (evt.which) ? evt.which : event.keyCode
   if (charCode > 31 && (charCode < 46 || charCode > 57 ))
   {  

        document.getElementById('loding').style.display='block';
        document.getElementById('loder').innerHTML='only numeric value accept';
    
        return false;
   } 
  
   
else
 {
 if (charCode == 47)
   {
    document.getElementById('loding').style.display='block';
       document.getElementById('loder').innerHTML='only numeric value accept';
   
        return false;
   }
   else{
   document.getElementById('loding').style.display='none';
   return true;
   }
 }   
}

function CheckNumericWithDash(evt)
{
       var charCode = (evt.which) ? evt.which : event.keyCode
   if (charCode > 31 && (charCode < 45 || charCode > 57 ))
   {  

        document.getElementById('loding').style.display='block';
        document.getElementById('loder').innerHTML='only numeric value accept';
    
        return false;
   } 
  
   
else
 {
 if (charCode == 47||charCode == 46)
   {
    document.getElementById('loding').style.display='block';
       document.getElementById('loder').innerHTML='only numeric value accept';
   
        return false;
   }
   else{
   document.getElementById('loding').style.display='none';
   return true;
   }
 }   
}


//Top Message 
function sloder(msg)
{
    document.getElementById('loding').style.display='block';
    document.getElementById('loder').innerHTML=msg;
}

function cloder()
{
   document.getElementById('loding').style.display='none';
}

function autosloder(msg, time)
{
var time1 = time;
    document.getElementById('loding').style.display='block';
    document.getElementById('loder').innerHTML=msg;
    setTimeout("cloder()",time1)
    
}

//For checking date and validate 
function lthantoday(date)
{
    var getd = new Date();
    var today = getd.format("dd/MM/yyyy");
    var selecteddate = date.value
//alert("today: "+ today+", slect: "+selecteddate);
    if(selecteddate  > today )
        {
    	    alert("Invalid Date[put manualy]");
    	    sloder("Invalid Date");
    	    date.focus();
        }
    else
        {
            cloder();
        }
}






//Popup open in full width
function f_open_window_max( aURL, aWinName )
{
 
   var wOpen;
   var sOptions;

   sOptions = 'status=yes,menubar=yes,scrollbars=yes,resizable=yes,toolbar=yes';
   sOptions = sOptions + ',width=' + (screen.availWidth - 10).toString();
   sOptions = sOptions + ',height=' + (screen.availHeight - 122).toString();
   sOptions = sOptions + ',screenX=0,screenY=0,left=0,top=0';
  
   wOpen = window.open( '', aWinName, sOptions );
   wOpen.location = aURL;
   
   wOpen.focus();
   //wOpen.moveTo( 0, 0 );
   //wOpen.resizeTo( 100, 100);
   return wOpen;
}




//Advance Search
 function filter (phrase, _id, tableId){
 sloder('searching....');
		                var words = phrase.value.toLowerCase().split(" ");
		                 
		                
		                var table = document.getElementById(tableId);
		                //document.getElementById(_id);
		                var ele;
		                for (var r = 1; r < table.rows.length; r++){
			                ele = table.rows[r].innerHTML.replace(/<[^>]+>/g,"");
		                        var displayStyle = 'none';
		                        for (var i = 0; i < words.length; i++) {
			                    if (ele.toLowerCase().indexOf(words[i])>=0)
			                    {
				                displayStyle = ''; 
				                
				                }
			                    else {
				                displayStyle = 'none';
				                break;
			                    }
		                        }
			                table.rows[r].style.display = displayStyle;
		                }
		               
		               // $('table').highlight('book');
		                
		                if(words != "")
		{
		sloder('search for : '+ words);
		    $('#'+tableId).removeHighlight().highlight(words.toString().trim());
		}
		else
		{
		cloder();
		        $('#'+tableId).removeHighlight();
		}
		
		
		
		
		
		
		}
		
		
		
		
		
		
		
		
		
		
//select Row
 var SelectedRow = null;
    var SelectedRowIndex = null;
    var UpperBound = null;
    var LowerBound = null;
    var RowIndex1 = null;
 function SelectRow(CurrentRow, RowIndex)
    {        
        if(SelectedRow == CurrentRow || RowIndex > UpperBound || RowIndex < LowerBound) return;
         
        if(SelectedRow != null)
        {
            SelectedRow.style.backgroundColor = SelectedRow.originalBackgroundColor;
            SelectedRow.style.color = SelectedRow.originalForeColor;
        }
        
        if(CurrentRow != null)
        {
            CurrentRow.originalBackgroundColor = CurrentRow.style.backgroundColor;
            CurrentRow.originalForeColor = CurrentRow.style.color;
            CurrentRow.style.backgroundColor = '#3D84D2';
            CurrentRow.style.color = '#FFFFFF';
        } 
        
        SelectedRow = CurrentRow;
        SelectedRowIndex = RowIndex;
        RowIndex1 =RowIndex
        setTimeout("SelectedRow.focus();",0); 
    }
    
    function SelectSibling(e)
    { 
        var e = e ? e : window.event;
        var KeyCode = e.which ? e.which : e.keyCode;
        
        if(KeyCode == 40)
            {
                SelectRow(SelectedRow.nextSibling, SelectedRowIndex + 1);
              
            }
            
        else if(KeyCode == 38)
        {
            SelectRow(SelectedRow.previousSibling, SelectedRowIndex - 1);
          
        }
        return false;
    }		
    
    
    
    function ValidInYearDate(getdate)
    {
   
            var txt = getdate;
              
            var frmYear = document.getElementById('ctl00_uc_New_Header1_spnYear').innerHTML; 
            
            var temp1="";
          
            var dt1  = txt.value.substring(0,2); 
            var mon1 = txt.value.substring(3,5); 
            var yr1  = txt.value.substring(6,10); 
            temp1 = mon1 +"/"+ dt1 +"/"+ yr1;
            
          
    try{
         var date = Date.parse("04/1/" + frmYear);var date1 = Date.parse("03/31/"+(parseInt(frmYear)+1));
         var date3 =Date.parse(temp1);
         
         if((date3 >= date) &  (date3<= date1))
         {
           cloder();
          
         }
         else
         {   
             autosloder("Invalid Date [Date should be between "+"01/04/" + frmYear +  " and "+ "31/03/"+(parseInt(frmYear)+1)+" ]",5000);
             txt.focus();
             alert('Invalid Date (Enter manually)');
            
         }
    }
    catch(err)
    {
        txt.focus();
    }
      
    
    }
    
      /*Ajax Call*/
    function callAboutUs(valu) 
{
        
        var str = valu;
        $('#load').show('normal');
        $('#dataload').load(str + " #cont",'',showNewContent());
        return false;
}


function callAjax(toid,valu,fromid,fy) 
{

    var str = valu;
    $('#'+ toid ).load("adminpages/orderstatus.aspx?flag=&DcNo="+valu+"&Flag1=D&Fy=" +fy+ " #" + fromid);
    return false;
}

function callIndustry(toid,valu,fromid) 
{
    var str = valu;
    $('#'+ toid ).load("~/adminpages/industryandproject.aspx?id="+valu+' #'+ fromid);
    return false;
}

function showNewContent() {
			$('#dataload').show('normal',hideLoader());
		}
		function hideLoader() {
			$('#load').fadeOut('normal');
		}
    
    
    
    