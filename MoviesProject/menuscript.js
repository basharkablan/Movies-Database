
/*** SET BUTTON'S FOLDER HERE ***/
var buttonFolder = "/Pictures/Other/Buttons/Vertical Menu/";

/*** SET BUTTONS' FILENAMES HERE ***/
upSources = new Array("button1up.png","button2up.png","button3up.png","button4up.png","button5up.png","button6up.png");

overSources = new Array("button1over.png","button2over.png","button3over.png","button4over.png","button5over.png","button6over.png");

// SUB MENUS DECLARATION, YOU DONT NEED TO EDIT THIS
subInfo = new Array();
subInfo[1] = new Array();
subInfo[2] = new Array();
subInfo[3] = new Array();
subInfo[4] = new Array();
subInfo[5] = new Array();
subInfo[6] = new Array();


//*** SET SUB MENUS TEXT LINKS AND TARGETS HERE ***//

// Movies
subInfo[1][1] = new Array("By A-B", "/Pages/AllMovies.aspx?oid=1", "");
subInfo[1][2] = new Array("By Year", "/Pages/AllMovies.aspx?oid=2", "");
subInfo[1][3] = new Array("By Rating", "/Pages/AllMovies.aspx?oid=3", "");
subInfo[1][4] = new Array("By Total Time", "/Pages/AllMovies.aspx?oid=4", "");
//subInfo[1][5] = new Array("By Awards Number", "/Pages/AllMovies.aspx?oid=5", "");

// Actors
subInfo[2][1] = new Array("By A-B (First Name)", "/Pages/AllActors.aspx?oid=1", "");
subInfo[2][2] = new Array("By A-B (Last Name)", "/Pages/AllActors.aspx?oid=2", "");
subInfo[2][3] = new Array("By Born Year", "/Pages/AllActors.aspx?oid=3", "");
//subInfo[2][4] = new Array("By Born Country", "/Pages/AllActors.aspx?oid=4", "");
//subInfo[2][5] = new Array("By Movies Number","/Pages/AllActors.aspx?oid=5","");

// Directors
subInfo[3][1] = new Array("By A-B (First Name)", "/Pages/AllDirectors.aspx?oid=1", "");
subInfo[3][2] = new Array("By A-B (Last Name)", "/Pages/AllDirectors.aspx?oid=2", "");
subInfo[3][3] = new Array("By Born Year", "/Pages/AllDirectors.aspx?oid=3", "");
//subInfo[3][4] = new Array("By Born Country","/Pages/AllDirectors.aspx?oid=4","");
//subInfo[3][5] = new Array("By Movies Number","/Pages/AllDirectors.aspx?oid=5","");

// Writers
subInfo[4][1] = new Array("By A-B (First Name)", "/Pages/AllWriters.aspx?oid=1", "");
subInfo[4][2] = new Array("By A-B (Last Name)", "/Pages/AllWriters.aspx?oid=2", "");
subInfo[4][3] = new Array("By Born Year", "/Pages/AllWriters.aspx?oid=3", "");
//subInfo[4][4] = new Array("By Born Country","/Pages/AllWriters.aspx?oid=4","");
//subInfo[4][5] = new Array("By Movies Number","/Pages/AllWriters.aspx?oid=5","");




//*** SET SUB MENU POSITION ( RELATIVE TO BUTTON ) ***//
var xSubOffset = 127;
var ySubOffset = 8;



//*** NO MORE SETTINGS BEYOND THIS POINT ***//
var overSub = false;
var delay = 1000;
totalButtons = upSources.length;

// GENERATE SUB MENUS
for ( x=0; x<totalButtons; x++) {
	// SET EMPTY DIV FOR BUTTONS WITHOUT SUBMENU
	if ( subInfo[x+1].length < 1 ) { 
		document.write('<div id="submenu' + (x+1) + '">');
	// SET DIV FOR BUTTONS WITH SUBMENU
	} else {
		document.write('<div id="submenu' + (x+1) + '" class="dropmenu" ');
		document.write('onMouseOver="overSub=true;');
		document.write('setOverImg(\'' + (x+1) + '\',\'\');"');
		document.write('onMouseOut="overSub=false;');
		document.write('setTimeout(\'hideSubMenu(\\\'submenu' + (x+1) + '\\\')\',delay);');
		document.write('setOutImg(\'' + (x+1) + '\',\'\');">');


		document.write('<ul>');
		for ( k=0; k<subInfo[x+1].length-1; k++ ) {
			document.write('<li>');
			document.write('<a href="' + subInfo[x+1][k+1][1] + '" ');
			document.write('target="' + subInfo[x+1][k+1][2] + '">');
			document.write( subInfo[x+1][k+1][0] + '</a>');
			document.write('</li>');
		}
		document.write('</ul>');
	}
	document.write('</div>');
}





//*** MAIN BUTTONS FUNCTIONS ***//
// PRELOAD MAIN MENU BUTTON IMAGES
function preload() {
	for ( x=0; x<totalButtons; x++ ) {
		buttonUp = new Image();
		buttonUp.src = buttonFolder + upSources[x];
		buttonOver = new Image();
		buttonOver.src = buttonFolder + overSources[x];
	}
}

// SET MOUSEOVER BUTTON
function setOverImg(But) {
	document.getElementById('button' + But).src = buttonFolder + overSources[But-1];
}

// SET MOUSEOUT BUTTON
function setOutImg(But) {
	document.getElementById('button' + But).src = buttonFolder + upSources[But-1];
}



//*** SUB MENU FUNCTIONS ***//
// GET ELEMENT ID MULTI BROWSER
function getElement(id) {
	return document.getElementById ? document.getElementById(id) : document.all ? document.all(id) : null; 
}

// GET X COORDINATE
function getRealLeft(id) { 
	var el = getElement(id);
	if (el) { 
		xPos = el.offsetLeft;
		tempEl = el.offsetParent;
		while (tempEl != null) {
			xPos += tempEl.offsetLeft;
			tempEl = tempEl.offsetParent;
		} 
		return xPos;
	} 
} 

// GET Y COORDINATE
function getRealTop(id) {
	var el = getElement(id);
	if (el) { 
		yPos = el.offsetTop;
		tempEl = el.offsetParent;
		while (tempEl != null) {
			yPos += tempEl.offsetTop;
			tempEl = tempEl.offsetParent;
		}
		return yPos;
	}
}

// MOVE OBJECT TO COORDINATE
function moveObjectTo(objectID,x,y) {
	var el = getElement(objectID);
	el.style.left = x;
	el.style.top = y;
}

// MOVE SUBMENU TO CORRESPONDING BUTTON
function showSubMenu(subID, buttonID) {
	hideAllSubMenus();
	butX = getRealLeft(buttonID);
	butY = getRealTop(buttonID);
	moveObjectTo(subID,butX+xSubOffset, butY+ySubOffset);
}

// HIDE ALL SUB MENUS
function hideAllSubMenus() {
	for ( x=0; x<totalButtons; x++) {
		moveObjectTo("submenu" + (x+1) + "",-500, -500 );
	}
}

// HIDE ONE SUB MENU
function hideSubMenu(subID) {
	if ( overSub == false ) {
		moveObjectTo(subID,-500, -500);
	}
}



//preload();

