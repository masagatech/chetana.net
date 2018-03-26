<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DragThings.ascx.cs"
    Inherits="UserControls_uc_DragThings" %>
    <script src="js/interface.js" type="text/javascript"></script>
    
    
    
<div id="sort1" class="groupWrapper">
    <p>
        &nbsp;</p>
    <div style="position: static; display: block; left: 593px; top: 253px;" id="news"
        class="groupItem">
        <div style="-moz-user-select: none;" class="itemHeader">
            News<a href="#" class="closeEl">[+]</a></div>
        <div style="display: none; overflow: visible;" class="itemContent">
            <ul>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
            </ul>
        </div>
    </div>
    <div style="position: static; display: block; left: -673px; top: 152px;" id="Links"
        class="groupItem">
        <div style="-moz-user-select: none;" class="itemHeader">
            Links<a href="#" class="closeEl">[-]</a></div>
        <div style="display: block; overflow: visible;" class="itemContent">
            <ul>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
            </ul>
        </div>
    </div>
    <div style="position: static; display: block; left: -232px; top: 213px;" id="images"
        class="groupItem">
        <div style="-moz-user-select: none;" class="itemHeader">
            Images<a href="#" class="closeEl">[-]</a></div>
        <div style="display: block; overflow: visible;" class="itemContent">
            <ul>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
            </ul>
        </div>
    </div>
    <div style="position: static; display: block; left: -464px; top: 252px;" id="shop"
        class="groupItem">
        <div style="-moz-user-select: none;" class="itemHeader">
            Shopping<a href="#" class="closeEl">[-]</a></div>
        <div style="display: block; overflow: visible;" class="itemContent">
            <ul>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
            </ul>
        </div>
    </div>
</div>
<div id="sort2" class="groupWrapper">
    <p>
        &nbsp;</p>
    <div style="position: static; display: block; left: -284px; top: 451px;" id="newsFeeder"
        class="groupItem">
        <div style="-moz-user-select: none;" class="itemHeader">
            Feeds<a href="#" class="closeEl">[-]</a></div>
        <div style="display: block; overflow: visible;" class="itemContent">
            <ul>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
                <li>orem ipsum dolor sit amet, consectetuer adipiscing elit</li>
            </ul>
        </div>
    </div>
</div>
<div id="sort3" class="groupWrapper">
    <p>
        &nbsp;</p>
</div>

<script type="text/javascript">
$(document).ready(
	function () {
		$('a.closeEl').bind('click', toggleContent);
		$('div.groupWrapper').Sortable(
			{
				accept: 'groupItem',
				helperclass: 'sortHelper',
				activeclass : 	'sortableactive',
				hoverclass : 	'sortablehover',
				handle: 'div.itemHeader',
				tolerance: 'pointer',
				onChange : function(ser)
				{
				},
				onStart : function()
				{
					$.iAutoscroller.start(this, document.getElementsByTagName('body'));
					
				},
				onStop : function()
				{
					$.iAutoscroller.stop();
					serialize();
				}
			}
		);
	}
);
var toggleContent = function(e)
{
	var targetContent = $('div.itemContent', this.parentNode.parentNode);
	if (targetContent.css('display') == 'none') {
		targetContent.slideDown(300);
		$(this).html('[>]');
	} else {
		targetContent.slideUp(300);
		$(this).html('[<]');
	}
	return false;
};
function serialize(s)
{
	serial = $.SortSerialize(s);
	var str =  serial.hash;
//	alert(str);
//	alert((str.split("&")[0]).replace("[]",""));
//	alert(str.split("&")[1]);
//	alert(str.split("&")[2]);
//	alert(str.split("&")[3]);
//	alert(str.split("&")[4]);

	
	
};
</script>

<div class="serializer" style="display:none;">
    <a href="#" onclick="serialize(); return false;">serialize all lists</a> <a href="#"
        onclick="serialize('sort1'); return false;">serialize list 1</a> <a href="#" onclick="serialize('sort2'); return false;">
            serialize list 2</a> <a href="#" onclick="serialize('sort3'); return false;">serialize
                list 3</a> <a href="#" onclick="serialize(['sort1', 'sort3']); return false;">serialize
                    lists 2 and 3</a>
</div>
