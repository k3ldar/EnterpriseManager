Type.registerNamespace("Sys.Extended.UI.HtmlEditor.ToolbarButtons"),Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName=function(t){Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName.initializeBase(this,[t])},Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName.prototype={initialize:function(){Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName.callBaseMethod(this,"initialize")},callMethod:function(t,e){if(!Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName.callBaseMethod(this,"callMethod"))return!1;try{var o=this._designPanel;o._execCommand("fontname",!1,t.options.item(t.selectedIndex).value)}catch(t){}},checkState:function(){if(!Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName.callBaseMethod(this,"checkState"))return!1;var t=this._designPanel,e=null;try{e=Function.createDelegate(t,Sys.Extended.UI.HtmlEditor._queryCommandValue)("fontname")}catch(t){}t._FontNotSet||e&&0!=e.length||(e=Sys.Extended.UI.HtmlEditor.getStyle(t._doc.body,"font-family"));var o=this._select,n=0;if(e&&e.length>0){var l=e.toLowerCase().split(",")[0].replace(/^(['"])/,"").replace(/(['"])$/,"");for(n=0;n<o.options.length;n++){var a=o.options.item(n).value.toLowerCase().split(",")[0];if(a==l)break}if(n==o.options.length)try{var d=document.createElement("OPTION");d.value=e.replace(/^(['"])/,"").replace(/(['"])$/,""),d.text=e.split(",")[0].replace(/^(['"])/,"").replace(/(['"])$/,""),o.add(d,Sys.Extended.UI.HtmlEditor.isIE?n:null),$addHandler(d,"click",this._onclick_option$delegate)}catch(t){n=0}}o.selectedIndex=n}},Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName.registerClass("Sys.Extended.UI.HtmlEditor.ToolbarButtons.FontName",Sys.Extended.UI.HtmlEditor.ToolbarButtons.DesignModeSelectButton);