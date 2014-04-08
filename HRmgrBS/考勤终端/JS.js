function showsubpage(pagename, widthX, heightX) {
    var iTop = (screen.height - heightX) / 2;
    var iLeft = (screen.width - widthX) / 2;
    window.open(pagename, "newwin", "width=" + widthX + ",height=" + heightX + ",top=" + iTop + ",left=" + iLeft + ",scrollbars=yes,resizable=yes");


}

function setparenttextvalue( parenttextname,setvalue) {
    window.opener.document.getElementById(parenttextname).innerText = setvalue;
    window.close();
}
function closeWin(who) {
    window.close(who);
}
