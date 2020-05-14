function id(input) {
	return document.getElementById(input);
}
function addClass(btn) {
	btn.className += " hover";
};
function removeClass(btn) {
	btn.className = btn.className.replace(/(?:^|\s)hover(?!\S)/g, '');
};

function onInit(){

	function adjustHeights(min, max, elem) {
		var fontstep = 1;
	  	var elemHeight = elem.offsetHeight;
		var elemWidth = elem.offsetWidth;
		var parentHeight = elem.parentElement.offsetHeight;
		var parentWidth = elem.parentElement.offsetWidth;
		var style = window.getComputedStyle(elem),
		    elemFontSize = style.getPropertyValue('font-size');
		var elemChildWidth = 0;
		if (elem.children[0]) {
			elemChildWidth = elem.children[0].offsetWidth;
		}

	  if (elemHeight > parentHeight || elemWidth > parentWidth || elemChildWidth > parentWidth) {
			var newFontSize = elemFontSize.substr(0,2)-fontstep;
			var newFontsizeStyle = newFontSize + 'px';
			elem.style.fontSize = newFontsizeStyle;
			//console.log(elemFontSize, newFontSize);

			if(newFontSize != min) {
				//console.log('not min, check again');
				adjustHeights(min, max, elem);
			} else {
				//console.log('got to min, do not do anything');
			}
	  }
	}

	var pElement = id('usp');
	pElement.style.hyphens = 'manual';
	pElement.innerHTML = dynamicContent.Coolblue_Mainfeed_Display_Prospecting_BE_Mainfeed[0].copyControl;

	var page = document.getElementsByTagName('gwd-page')[0];
	var bannerWidth = page.getAttribute('data-gwd-width').replace('px','');
	var bannerHeight = page.getAttribute('data-gwd-height').replace('px','');
	var bannerSize = bannerWidth + 'x' +bannerHeight;

		//console.log(bannerSize);
	var logoStartWidth = 90;
	switch(bannerSize) {
		case '120x600':
			var min = 17,
				max = 22;
				logoStartWidth = 90;
			break;
		case '160x600':
			var min = 19,
				max = 24;
				logoStartWidth = 90;
			break;
		case '200x200':
			var min = 13,
				max = 20;
				logoStartWidth = 75;
			break;
		case '250x250':
			var min = 17,
				max = 20;
				logoStartWidth = 90;
			break;
		case '300x250':
			var min = 18,
				max = 26;
				logoStartWidth = 90;
			break;
		case '336x280':
			var min = 20,
				max = 29;
				logoStartWidth = 110;
			break;
		case '300x600':
			var min = 19,
				max = 28;
				logoStartWidth = 120;
			break;
		case '468x60':
			var min = 16,
				max = 21;
				logoStartWidth = 50;
			break;
		case '728x90':
			var min = 20,
				max = 26;
				logoStartWidth = 70;
			break;
		case '970x90':
			var min = 20,
				max = 26;
				logoStartWidth = 70;
			break;
		case '970x250':
			var min = 20,
				max = 29;
				logoStartWidth = 140;
			break;
	}
	//console.log('before',bannerSize, min, max);
	pElement.style.fontSize = max+'px';
	adjustHeights(min, max, pElement);
	//console.log('after',bannerSize, min, max, pElement.style.fontSize);



	  var logo = id('logo'),
		  logoWidth = logo.offsetWidth,
		  blue = id('blue'),
		  transTime = .3,
		  delayTime = transTime*3,
		  logoPos = logo.getBoundingClientRect(),
		  logoPosX = logoPos.left,
		  logoPosY = logoPos.top,
		  pageOffsetWidth = id('init').offsetWidth,
		  pageOffsetHeight = id('init').offsetHeight,
		  logoStartPosX = pageOffsetWidth/2 - logoPosX,
		  logoStartPosY = pageOffsetHeight/2 - logoPosY,
		  blueBarHeight = blue.offsetHeight;

	  TweenMax.set(logo, {
		  x: logoStartPosX,
		  y: logoStartPosY,
		  height: 0,
		  width: 0
	  });

	  TweenMax.set(blue, {
		  y: 0,
		  height: pageOffsetHeight
	  });

	  TweenMax.to(logo, .8, {
		  x: logoStartPosX-logoStartWidth/2,
		  y: logoStartPosY-logoStartWidth/2,
		  height: logoStartWidth,
		  width: logoStartWidth,
		  delay: .25,
		  ease: Elastic.easeOut.config(.75, 0.3)
	  });

	  TweenMax.to(logo, transTime, {
		x: 0,
		y: 0,
		height: logoWidth,
		width: logoWidth,
		delay: delayTime + .4,
		ease: Power1.easeInOut
	  });

	switch(bannerSize) {
		case '728x90':
			var options = {
				y: 0,
				autoAlpha: 0,
				delay: delayTime + .3,
				ease: Power1.easeInOut
			  };
			break;

		default:
			var options = {
				y: 0,
				height: blueBarHeight,
				delay: delayTime + .5,
				ease: Power1.easeInOut
			  };
	}
	TweenMax.to(blue, transTime, options);

	//Btn hover
	var btn = document.getElementById('Btn1');

	if (btn) {
		document.getElementById('exit1').addEventListener('mouseenter', function(){
			addClass(btn)});
		document.getElementById('exit1').addEventListener('mouseleave', function(){
			removeClass(btn)});
	}

	if (bannerSize == '120x600' || bannerSize == '728x90') {
		if (btn) {
			if (btn.offsetHeight > 50) {
				btn.setAttribute('style', 'padding: 13px !important; font-size: 11px !important');
			}
		}
	}
}
