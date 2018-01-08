$(document).ready(function() {
	$("ul.collapsible > li > a.collapsed + ul").slideToggle("medium");
	$("ul.collapsible > li > a").click(function() {
		$(this).toggleClass("expanded").toggleClass("collapsed").parent().find('> ul').slideToggle("medium");
	});
});